namespace ImageDetect
{
    partial class Connection
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Find_btn = new System.Windows.Forms.Button();
            this.devices = new InTheHand.Windows.Forms.SelectBluetoothDeviceDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Parear_btn = new System.Windows.Forms.Button();
            this.Connect_btn = new System.Windows.Forms.Button();
            this.Comunicar_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Find_btn
            // 
            this.Find_btn.Location = new System.Drawing.Point(232, 12);
            this.Find_btn.Name = "Find_btn";
            this.Find_btn.Size = new System.Drawing.Size(104, 38);
            this.Find_btn.TabIndex = 0;
            this.Find_btn.Text = "Buscar";
            this.Find_btn.UseVisualStyleBackColor = true;
            // 
            // devices
            // 
            this.devices.AddNewDeviceWizard = false;
            this.devices.DeviceFilter = null;
            this.devices.DiscoverableOnly = false;
            this.devices.ForceAuthentication = false;
            this.devices.Info = null;
            this.devices.ShowAuthenticated = true;
            this.devices.ShowDiscoverableOnly = false;
            this.devices.ShowRemembered = true;
            this.devices.ShowUnknown = true;
            this.devices.SkipServicesPage = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 134);
            this.listBox1.TabIndex = 3;
            // 
            // Parear_btn
            // 
            this.Parear_btn.Enabled = false;
            this.Parear_btn.Location = new System.Drawing.Point(232, 56);
            this.Parear_btn.Name = "Parear_btn";
            this.Parear_btn.Size = new System.Drawing.Size(104, 38);
            this.Parear_btn.TabIndex = 4;
            this.Parear_btn.Text = "Parear";
            this.Parear_btn.UseVisualStyleBackColor = true;
            // 
            // Connect_btn
            // 
            this.Connect_btn.Location = new System.Drawing.Point(232, 100);
            this.Connect_btn.Name = "Connect_btn";
            this.Connect_btn.Size = new System.Drawing.Size(104, 38);
            this.Connect_btn.TabIndex = 5;
            this.Connect_btn.Text = "Conectar";
            this.Connect_btn.UseVisualStyleBackColor = true;
            // 
            // Comunicar_btn
            // 
            this.Comunicar_btn.Location = new System.Drawing.Point(232, 144);
            this.Comunicar_btn.Name = "Comunicar_btn";
            this.Comunicar_btn.Size = new System.Drawing.Size(104, 38);
            this.Comunicar_btn.TabIndex = 6;
            this.Comunicar_btn.Text = "Comunicar";
            this.Comunicar_btn.UseVisualStyleBackColor = true;
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 297);
            this.Controls.Add(this.Comunicar_btn);
            this.Controls.Add(this.Connect_btn);
            this.Controls.Add(this.Parear_btn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Find_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Connection";
            this.Text = "Connection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button Find_btn;
        private InTheHand.Windows.Forms.SelectBluetoothDeviceDialog devices;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Parear_btn;
        private System.Windows.Forms.Button Connect_btn;
        private System.Windows.Forms.Button Comunicar_btn;
    }
}