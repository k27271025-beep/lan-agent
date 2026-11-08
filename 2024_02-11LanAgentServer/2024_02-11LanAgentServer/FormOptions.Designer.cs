namespace _2024_02_11LanAgentServer
{
    partial class FormOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxAdres = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.cbxAutoRun = new System.Windows.Forms.CheckBox();
            this.cbxAutoStart = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDelMaxDay = new System.Windows.Forms.TextBox();
            this.tbxDelMaxCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxAdres
            // 
            this.tbxAdres.Location = new System.Drawing.Point(29, 80);
            this.tbxAdres.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxAdres.Name = "tbxAdres";
            this.tbxAdres.Size = new System.Drawing.Size(184, 34);
            this.tbxAdres.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Адрес сервера:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Порт:";
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(279, 80);
            this.tbxPort.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(184, 34);
            this.tbxPort.TabIndex = 3;
            // 
            // cbxAutoRun
            // 
            this.cbxAutoRun.AutoSize = true;
            this.cbxAutoRun.Location = new System.Drawing.Point(29, 154);
            this.cbxAutoRun.Name = "cbxAutoRun";
            this.cbxAutoRun.Size = new System.Drawing.Size(199, 33);
            this.cbxAutoRun.TabIndex = 4;
            this.cbxAutoRun.Text = "Автозагрузка";
            this.cbxAutoRun.UseVisualStyleBackColor = true;
            // 
            // cbxAutoStart
            // 
            this.cbxAutoStart.AutoSize = true;
            this.cbxAutoStart.Location = new System.Drawing.Point(29, 193);
            this.cbxAutoStart.Name = "cbxAutoStart";
            this.cbxAutoStart.Size = new System.Drawing.Size(558, 33);
            this.cbxAutoStart.TabIndex = 5;
            this.cbxAutoStart.Text = "Включать сервер при запуске приложения";
            this.cbxAutoStart.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 261);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(311, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Удалять записи старше:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 307);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Удалять записи более:";
            // 
            // tbxDelMaxDay
            // 
            this.tbxDelMaxDay.Location = new System.Drawing.Point(347, 256);
            this.tbxDelMaxDay.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxDelMaxDay.Name = "tbxDelMaxDay";
            this.tbxDelMaxDay.Size = new System.Drawing.Size(122, 34);
            this.tbxDelMaxDay.TabIndex = 8;
            // 
            // tbxDelMaxCount
            // 
            this.tbxDelMaxCount.Location = new System.Drawing.Point(347, 307);
            this.tbxDelMaxCount.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxDelMaxCount.Name = "tbxDelMaxCount";
            this.tbxDelMaxCount.Size = new System.Drawing.Size(122, 34);
            this.tbxDelMaxCount.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(506, 261);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "дней.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(506, 307);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "шт.";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(29, 388);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 54);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(279, 388);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 54);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(601, 470);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxDelMaxCount);
            this.Controls.Add(this.tbxDelMaxDay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxAutoStart);
            this.Controls.Add(this.cbxAutoRun);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxAdres);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки сервера";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox tbxAdres;
        public System.Windows.Forms.TextBox tbxPort;
        public System.Windows.Forms.CheckBox cbxAutoRun;
        public System.Windows.Forms.CheckBox cbxAutoStart;
        public System.Windows.Forms.TextBox tbxDelMaxDay;
        public System.Windows.Forms.TextBox tbxDelMaxCount;
    }
}