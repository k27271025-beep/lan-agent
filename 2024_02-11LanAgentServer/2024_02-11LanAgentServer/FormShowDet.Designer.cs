namespace _2024_02_11LanAgentServer
{
    partial class FormShowDet
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbxDrive = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbxProcess = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbxIP = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblNetName = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pbxScreen = new System.Windows.Forms.PictureBox();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbxDrive);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1137, 668);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Информация о логических дисках";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbxDrive
            // 
            this.tbxDrive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxDrive.Location = new System.Drawing.Point(3, 3);
            this.tbxDrive.Multiline = true;
            this.tbxDrive.Name = "tbxDrive";
            this.tbxDrive.ReadOnly = true;
            this.tbxDrive.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxDrive.Size = new System.Drawing.Size(1131, 662);
            this.tbxDrive.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbxProcess);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.lbxIP);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.lblUserName);
            this.tabPage1.Controls.Add(this.lblNetName);
            this.tabPage1.Controls.Add(this.lblDateTime);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1137, 668);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Общая информация и список процессов";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbxProcess
            // 
            this.tbxProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxProcess.Location = new System.Drawing.Point(616, 63);
            this.tbxProcess.Multiline = true;
            this.tbxProcess.Name = "tbxProcess";
            this.tbxProcess.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxProcess.Size = new System.Drawing.Size(499, 565);
            this.tbxProcess.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(611, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(243, 29);
            this.label8.TabIndex = 8;
            this.label8.Text = "Список процессов:";
            // 
            // lbxIP
            // 
            this.lbxIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxIP.FormattingEnabled = true;
            this.lbxIP.ItemHeight = 29;
            this.lbxIP.Location = new System.Drawing.Point(27, 247);
            this.lbxIP.Name = "lbxIP";
            this.lbxIP.Size = new System.Drawing.Size(545, 381);
            this.lbxIP.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "Список IP-адресов:";
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblUserName.Location = new System.Drawing.Point(272, 130);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(300, 39);
            this.lblUserName.TabIndex = 5;
            // 
            // lblNetName
            // 
            this.lblNetName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblNetName.Location = new System.Drawing.Point(272, 77);
            this.lblNetName.Name = "lblNetName";
            this.lblNetName.Size = new System.Drawing.Size(300, 38);
            this.lblNetName.TabIndex = 4;
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblDateTime.Location = new System.Drawing.Point(272, 21);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(300, 40);
            this.lblDateTime.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Имя пользователя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Сетевое имя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата и время";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1145, 710);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pbxScreen);
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1137, 668);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Снимок экрана";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pbxScreen
            // 
            this.pbxScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxScreen.Location = new System.Drawing.Point(3, 3);
            this.pbxScreen.Name = "pbxScreen";
            this.pbxScreen.Size = new System.Drawing.Size(1131, 662);
            this.pbxScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxScreen.TabIndex = 0;
            this.pbxScreen.TabStop = false;
            // 
            // FormShowDet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1145, 710);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FormShowDet";
            this.Text = "Детальная информация";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ListBox lbxIP;
        public System.Windows.Forms.Label lblUserName;
        public System.Windows.Forms.Label lblNetName;
        public System.Windows.Forms.Label lblDateTime;
        public System.Windows.Forms.TextBox tbxProcess;
        public System.Windows.Forms.PictureBox pbxScreen;
        public System.Windows.Forms.TextBox tbxDrive;
    }
}