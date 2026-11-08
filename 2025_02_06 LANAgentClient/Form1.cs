using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLLanAgent;
using Microsoft.Win32;

namespace _2025_02_06_LANAgentClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        byte[] ObjToByte(ClientInfo clientInfo)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, clientInfo);
            return ms.ToArray();
        }


        void SendData(string address, int port, ClientInfo clientInfo)
        {
            TcpClient Client;
            try
            {
                Client = new TcpClient(address, port);//связываемся с сервером
            }
            catch
            {
                tslMessage.Text = "Невозможно установить соединение с сервером";
                return;
            }
            //создать сетевой поток
            NetworkStream ns = Client.GetStream();
            //преобразоать объект в масси байт
            byte[] Data = ObjToByte(clientInfo);
            //вывести байты из массива в сетевой поток
            ns.Write(Data, 0, Data.Length);
            //закрыть поток и подключение к серверу
            ns.Close();
            Client.Close();

            tslMessage.Text = "Данные на сервер успешно отправлены";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ClientInfo clientInfo = new ClientInfo();
            clientInfo.UserName = Environment.UserName;
            clientInfo.NetName = Environment.MachineName;
            clientInfo.IPAddrs = Dns.GetHostEntry(Environment.MachineName).AddressList;
            clientInfo.AllDrives = DriveInfo.GetDrives();
            //выполнить перебор процесса 
            foreach(Process p in Process.GetProcesses())
            {
                //добавить в ci для очередного процесса его имя и объем памяти 
                clientInfo.Proc.Add($"{p.ProcessName} - {p.PrivateMemorySize64/1024} Кбайт");
            }

            //Изображение с размерами, равными размерам экрана
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //создать поверхность для рисования
            Graphics gr = Graphics.FromImage(bmp);
            //скопировать изображение с экрана в bmp
            gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
            //сохранить скриншот в поле объекта ClientInfo
            clientInfo.Scr = bmp;

            SendData(tbxAddress.Text, int.Parse(tbxPort.Text), clientInfo);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadInform();
            timer1.Interval = int.Parse(nutMin.Text) * 60000;
            timer1.Start();
            timer1_Tick(sender, e);
            // переданные параметры приложением
            string[] arg = Environment.GetCommandLineArgs();
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

        void SaveInform()
        {
            RegistryKey k = Registry.CurrentUser.CreateSubKey("Software\\LanAgentClient");
            k.SetValue("ServerAddress", tbxAddress.Text);
            k.SetValue("ServerPort", int.Parse(tbxPort.Text));
            k.SetValue("AutoRun", cbxAutoRun.Checked);
            k.SetValue("Interval", int.Parse(nutMin.Value.ToString()));
            k.Close();
        }

        void LoadInform()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\LanAgentClient");
            if (key != null)
            {
                tbxAddress.Text = key.GetValue("ServerAddress", "127.0.0.1").ToString();
                tbxPort.Text = key.GetValue("ServerPort", "5000").ToString();
                cbxAutoRun.Checked = bool.Parse(key.GetValue("AutoRun", "false").ToString());
                nutMin.Value = decimal.Parse(key.GetValue("Interval", "1").ToString());
                key.Close();
            }
        }

        void SetAutorun(string nameApp, bool autoRun)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (autoRun)
            {
                string exeFileCurrentApp = Application.ExecutablePath;
                key.SetValue(nameApp, $"\"{exeFileCurrentApp}\" tray");
            }
            else
            {
                key.DeleteValue(nameApp, false);
            }

            key.Close();
        }

        //изменение размера
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveInform();
        }

        private void cbxAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            SetAutorun("AppLanAgentClient", cbxAutoRun.Checked);
        }

    }
}
