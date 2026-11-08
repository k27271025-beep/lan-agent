using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLLanAgent;
using Microsoft.Win32;

namespace _2024_02_11LanAgentServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        string addr = "127.0.0.1";
        int port = 5000;
        bool autoStart = false;//включение сервера при запуске приложения
        int delMaxDay = 7;//максимальное кол-во дней 7
        int delMaxCount = 4;//максимальное кол-во записей 25
       
        TcpListener server;
        //список данных полученных от клиента 
        List<ClientInfo> lstClient = new List<ClientInfo>();

        /// <summary>
        /// сохранение списка данных от клиента в файле
        /// </summary>
        /// <param name="fName">имя файла для сохранения</param>
        void SaveToFile(string fName)
        {
            BinaryFormatter bf = new BinaryFormatter();//сериализатор
            FileStream f = File.OpenWrite(fName);//открыть файл для записи 
            bf.Serialize(f, lstClient);//вывести данные в файл
            f.Close();
        }

        /// <summary>
        /// чтение списка данных от клиента из файла
        /// </summary>
        /// <param name="fName">имя файла для чтения</param>
        void LoadFromFile(string fName)
        {
            BinaryFormatter bf = new BinaryFormatter();//сериализатор
            FileStream f = File.OpenRead(fName);//открыть файл для чтения
            lstClient = (List<ClientInfo>)bf.Deserialize(f);//прочитать данные из файла
            f.Close();
        }

        ClientInfo ByteToObj(byte[] data)
        {
            BinaryFormatter bf = new BinaryFormatter();// сериализатор
            MemoryStream ms = new MemoryStream(data);// вывод всех байт из массива 
            return (ClientInfo) bf.Deserialize(ms);// десериализовать
        }

        async void WorkServer()
        {
            while (true)
            {
                TcpClient Client;
                try
                {
                    Client = await server.AcceptTcpClientAsync();
                }
                catch
                {
                    return;
                }

                NetworkStream ns = Client.GetStream();//сет поток 
                MemoryStream ms = new MemoryStream();
                ns.CopyTo(ms); //скопировать байты в поток в ОЗУ
                ns.Close();
                Client.Close();
                //преобразовать данные в объект
                ClientInfo ci = ByteToObj(ms.ToArray());
                //дата и время получения отчета от клиента 
                ci.DtReport = DateTime.Now;
                lstClient.Add(ci);// добавить объект в список
                SaveToFile(Application.StartupPath + "\\LanAgentServer.dat");
                dgvClient.Rows.Add(ci.NetName, ci.UserName, ci.DtReport.ToString("dd.MM.yyyy HH:mm:ss"));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFromFile(Application.StartupPath + "\\LanAgentServer.dat");
            }
            catch
            {

            }

            //выполнить перебор списка lstClient
            foreach(ClientInfo ci in lstClient)
            {
                //каждый элемент списка вывести в DataGridView
                dgvClient.Rows.Add(ci.NetName, ci.UserName, ci.DtReport.ToString("dd.MM.yyyy HH:mm:ss"));
            }

            //прочитать из реестра значения настроек
            RegistryKey keySave = Registry.CurrentUser.OpenSubKey("Software\\AppLanAgentServer");
            if (keySave != null)
            {
                addr = keySave.GetValue("address", "127.0.0.1").ToString();
                port = int.Parse(keySave.GetValue("port", 5000).ToString());
                autoStart = bool.Parse(keySave.GetValue("autostart", false).ToString());
                delMaxDay = int.Parse(keySave.GetValue("delmaxday", 7).ToString());
                delMaxCount = int.Parse(keySave.GetValue("delmaxcount", 25).ToString());
                keySave.Close();
                if (autoStart)
                {
                    button1_Click(sender, e);
                }
            }

            string[] arg = Environment.GetCommandLineArgs();//запрашиваем строки при включении
            // если приложению передаются параметры.
            if (arg.Length > 1)
            {
                if (arg.Contains("tray")) // если приложение запущено из автозагрузки (в arg содержится tray)
                {
                    // свернуть окно
                    this.WindowState = FormWindowState.Minimized;
                    
                    // убрать с панели задач
                    this.ShowInTaskbar = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(server == null)
            {
                server = new TcpListener(IPAddress.Parse(addr), port);
                server.Start();
                tslMessage.Text = "Сервер запущен";
                WorkServer();
            }
            else
            {
                tslMessage.Text = "Сервер уже запущен ранее";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Stop();
                tslMessage.Text = "Сервер остановлен!";
                server = null;
            }
            else
            {
                tslMessage.Text = "Сервер еще не был запущен!";
            }
        }

        private void dgvClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex; //номер строки на которой выполнен двойной щелчок 
            if(n == -1)
            {
                return;//если номера строки нет выйти 
            }

            FormShowDet frm = new FormShowDet();

            frm.lblNetName.Text = lstClient[n].NetName;
            frm.lblUserName.Text = lstClient[n].UserName;
            frm.lblDateTime.Text = lstClient[n].DtReport.ToString("dd.MM.yyyy HH:mm:ss");
            //перебор IP адресов для выделеного элемента в списке 
            foreach(IPAddress ip in lstClient[n].IPAddrs)
            {
                frm.lbxIP.Items.Add(ip.ToString());
            }

            //вывести список процессов используя перебор курсора на новую строку 
            frm.tbxProcess.Text = string.Join("\r\n", lstClient[n].Proc);


            frm.pbxScreen.Image = lstClient[n].Scr;//скриншот

            //frm.tbxDrive.Text = lstClient[n].AllDrives.ToString(); //список дисков

            //перебор информации о дисках
            foreach(DriveInfo drive in lstClient[n].AllDrives)
            {
                frm.tbxDrive.Text += $"Имя: {drive.Name} \r\n";
                frm.tbxDrive.Text += $"Тип: {drive.DriveType} \r\n";
                if (drive.IsReady)
                {
                    frm.tbxDrive.Text += $"Файловая система: {drive.DriveFormat} \r\n";
                    frm.tbxDrive.Text += $"Метка: {drive.VolumeLabel} \r\n";
                    frm.tbxDrive.Text += $"Объём: {drive.TotalSize} \r\n";
                    frm.tbxDrive.Text += $"Свободное место: {drive.TotalFreeSpace}  \r\n\r\n";
                }
            }

            frm.ShowDialog();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            FormOptions frm = new FormOptions();
            //Вывести на форму с настройками текущее значение переменных

            frm.tbxDelMaxCount.Text = delMaxCount.ToString() ;
            frm.tbxDelMaxDay.Text = delMaxDay.ToString() ;
            frm.tbxAdres.Text = addr;
            frm.tbxPort.Text = port.ToString();
            frm.cbxAutoStart.Checked = autoStart;
            //открыть ключ реестр для автозагрузки
            //если есть в автозагрузки LanAgentServer то включить cbxAutoRun
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
            frm.cbxAutoRun.Checked = key.GetValue("LanAgentServer") != null;
            key.Close();


            if (frm.ShowDialog() == DialogResult.OK)
            {
                addr = frm.tbxAdres.Text;
                port = int.Parse(frm.tbxPort.Text);
                autoStart = frm.cbxAutoStart.Checked;
                delMaxDay = int.Parse(frm.tbxDelMaxDay.Text);
                delMaxCount = int.Parse(frm.tbxDelMaxCount.Text);

                //если установлен cbxAutoRun то добавить приложение в автозагрузку, иначе удалить приложение из автозагрудки LanAgentServer
                SetAutorun("AppLanAgentServer", frm.cbxAutoRun.Checked);
                //ключ для сохранения настроек в реестре
                RegistryKey keySave = Registry.CurrentUser.CreateSubKey("Software\\AppLanAgentServer");
                keySave.SetValue("address", addr);
                keySave.SetValue("port", port);
                keySave.SetValue("autostart", autoStart);
                keySave.SetValue("delmaxday", delMaxDay);
                keySave.SetValue("delmaxcount", delMaxCount);
                keySave.Close();
            }
        }

        void SetAutorun(string nameApp, bool autoRun)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (autoRun)
            {
                string exeFileCurrentApp = Application.ExecutablePath;//полный путь к файлу 
                key.SetValue(nameApp, $"\"{exeFileCurrentApp}\""); //имя exe файла с путем доступа 
            }
            else
            {
                key.DeleteValue(nameApp, false);//удалить из автозагрузки
            }

            key.Close();
        }

        //для ворачивания
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                this.Hide(); //скрыть форму
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show(); //показать форму
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false; //выключить пиктограмму
            this.ShowInTaskbar = true; //отображать форму на панели задач
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool onDelete = false;

            //пока кол-во елементов списка больше delMaxCount 
            while (lstClient.Count > delMaxCount)
            {
                //удалить нулевой элемент lstClient
                lstClient.RemoveAt(0);
                //удалить нулевую строку dgvClient
                dgvClient.Rows.RemoveAt(0);

                onDelete = true;
            }

            //перебрать даты записей
            DateTime currentDate = DateTime.Now;// текущая дата
            //перебор в обратном порядке 
            for (int i =lstClient.Count-1; i>= 0; i--)
            {
                //если разница между текущей датой и датой i-го элемента больше допустимой
                if ((currentDate - lstClient[i].DtReport).TotalDays > delMaxDay)
                {
                    //удалить i-е элементы из обоих списков
                    lstClient.RemoveAt(i);
                    dgvClient.Rows.RemoveAt(i);

                    onDelete = true;
                }
            }

            if (onDelete) //если в списке были удаления элементов
            {
                SaveToFile(Application.StartupPath + "\\LanAgentServer.dat");
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            //вывести диалоговое окно с вопросом да и нет 
            //если да то очистить если нет 

            DialogResult res = MessageBox.Show("Вы хотите очистить список?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                lstClient.Clear();
                dgvClient.Rows.Clear();
            }
            else
            {
                return;
            }

            SaveToFile(Application.StartupPath + "\\LanAgentServer.dat");
        }

        //удалить строки выделенные
        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы хотите удалить выделенные строки?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }

            //номера элементов предназначенные для удаления
            List<int> lstNumDel = new List<int>();

            //перебор элемента списка с конца
            for(int i = lstClient.Count - 1; i >= 0; i--)
            {
                //если i-строка в dgvClient выделена
                if (dgvClient.Rows[i].Selected)
                {
                    //запомнить номер строки для удаления
                   lstNumDel.Add(i);
                }
            }

            //перебор номеров строк для удаления
            foreach (int num in lstNumDel)
            {
                //удалить i-элемент из списка
                lstClient.RemoveAt(num);
                dgvClient.Rows.RemoveAt(num);
            }

            SaveToFile(Application.StartupPath + "\\LanAgentServer.dat");
        }

        private void tbxFind_TextChanged(object sender, EventArgs e)
        {
            string txtFind = tbxFind.Text; //символы для поиска

            //перебор записи из списка с начала
            for (int i = 0; i < lstClient.Count-1; i++)
            {
                string txtFind2; //то с чем сравниваем символы для поиска

                if (rbtNatName.Checked)
                {
                    txtFind2 = lstClient[i].NetName;
                }
                else if (rbtUserName.Checked)
                {
                    txtFind2 = lstClient[i].UserName;
                }
                else
                {
                    txtFind2 = lstClient[i].DtReport.ToString("dd.MM.yyyy HH:mm:ss");
                }

                //если текс из списка содержит символы для поиска 
                if (txtFind2.Contains(txtFind))
                {
                    dgvClient.ClearSelection();//очистить выделение
                    dgvClient.Rows[i].Selected = true;
                    return;
                }
            }
        }
    }
}
