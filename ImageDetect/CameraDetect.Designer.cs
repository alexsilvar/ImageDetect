using Emgu.CV;
using Emgu.CV.UI;
namespace ImageDetect
{
    partial class CameraDetect
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
            this.captureImageBox = new Emgu.CV.UI.ImageBox();
            this.formatedImageBox = new Emgu.CV.UI.ImageBox();
            this.blobsImageBox = new Emgu.CV.UI.ImageBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Capture_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Cameras_cb = new System.Windows.Forms.ComboBox();
            this.CortarCampo_btn = new System.Windows.Forms.Button();
            this.PegaCor_btn = new System.Windows.Forms.Button();
            this.ResetCorte_btn = new System.Windows.Forms.Button();
            this.Mostrar_cbox = new System.Windows.Forms.CheckBox();
            this.Finding_cb = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.testesImageBox = new Emgu.CV.UI.ImageBox();
            this.fps = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formatedImageBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testesImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // captureImageBox
            // 
            this.captureImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.captureImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.captureImageBox.Location = new System.Drawing.Point(0, 0);
            this.captureImageBox.MaximumSize = new System.Drawing.Size(640, 480);
            this.captureImageBox.Name = "captureImageBox";
            this.captureImageBox.Size = new System.Drawing.Size(480, 270);
            this.captureImageBox.TabIndex = 1;
            this.captureImageBox.TabStop = false;
            this.captureImageBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.captureImageBox_MouseClick);
            this.captureImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.captureImageBox_MouseDown);
            this.captureImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.captureImageBox_MouseMove);
            this.captureImageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.captureImageBox_MouseUp);
            // 
            // formatedImageBox
            // 
            this.formatedImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formatedImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.formatedImageBox.Location = new System.Drawing.Point(0, 0);
            this.formatedImageBox.MaximumSize = new System.Drawing.Size(640, 480);
            this.formatedImageBox.Name = "formatedImageBox";
            this.formatedImageBox.Size = new System.Drawing.Size(480, 270);
            this.formatedImageBox.TabIndex = 1;
            this.formatedImageBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.captureImageBox);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 270);
            this.panel1.TabIndex = 0;
            // 
            // Capture_btn
            // 
            this.Capture_btn.Location = new System.Drawing.Point(219, 10);
            this.Capture_btn.Name = "Capture_btn";
            this.Capture_btn.Size = new System.Drawing.Size(75, 21);
            this.Capture_btn.TabIndex = 1;
            this.Capture_btn.Text = "Capturar";
            this.Capture_btn.UseVisualStyleBackColor = true;
            this.Capture_btn.Click += new System.EventHandler(this.Capture_btn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.formatedImageBox);
            this.panel2.Location = new System.Drawing.Point(520, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 270);
            this.panel2.TabIndex = 13;
            // 
            // Cameras_cb
            // 
            this.Cameras_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cameras_cb.FormattingEnabled = true;
            this.Cameras_cb.Location = new System.Drawing.Point(12, 10);
            this.Cameras_cb.Name = "Cameras_cb";
            this.Cameras_cb.Size = new System.Drawing.Size(201, 21);
            this.Cameras_cb.TabIndex = 14;
            this.Cameras_cb.SelectionChangeCommitted += new System.EventHandler(this.Cameras_cb_SelectionChangeCommitted);
            // 
            // CortarCampo_btn
            // 
            this.CortarCampo_btn.Location = new System.Drawing.Point(12, 358);
            this.CortarCampo_btn.Name = "CortarCampo_btn";
            this.CortarCampo_btn.Size = new System.Drawing.Size(96, 23);
            this.CortarCampo_btn.TabIndex = 15;
            this.CortarCampo_btn.Text = "Cortar Campo";
            this.CortarCampo_btn.UseVisualStyleBackColor = true;
            this.CortarCampo_btn.Click += new System.EventHandler(this.CortarCampo_btn_Click);
            // 
            // PegaCor_btn
            // 
            this.PegaCor_btn.Location = new System.Drawing.Point(156, 385);
            this.PegaCor_btn.Name = "PegaCor_btn";
            this.PegaCor_btn.Size = new System.Drawing.Size(96, 23);
            this.PegaCor_btn.TabIndex = 16;
            this.PegaCor_btn.Text = "Pega Cor";
            this.PegaCor_btn.UseVisualStyleBackColor = true;
            this.PegaCor_btn.Click += new System.EventHandler(this.PegaCor_btn_Click);
            // 
            // ResetCorte_btn
            // 
            this.ResetCorte_btn.Location = new System.Drawing.Point(12, 387);
            this.ResetCorte_btn.Name = "ResetCorte_btn";
            this.ResetCorte_btn.Size = new System.Drawing.Size(96, 23);
            this.ResetCorte_btn.TabIndex = 17;
            this.ResetCorte_btn.Text = "Reseta Corte";
            this.ResetCorte_btn.UseVisualStyleBackColor = true;
            this.ResetCorte_btn.Click += new System.EventHandler(this.ResetCorte_btn_Click);
            // 
            // Mostrar_cbox
            // 
            this.Mostrar_cbox.AutoSize = true;
            this.Mostrar_cbox.Checked = true;
            this.Mostrar_cbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Mostrar_cbox.Location = new System.Drawing.Point(12, 329);
            this.Mostrar_cbox.Name = "Mostrar_cbox";
            this.Mostrar_cbox.Size = new System.Drawing.Size(97, 17);
            this.Mostrar_cbox.TabIndex = 18;
            this.Mostrar_cbox.Text = "Mostrar vídeos";
            this.Mostrar_cbox.UseVisualStyleBackColor = true;
            // 
            // Finding_cb
            // 
            this.Finding_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Finding_cb.FormattingEnabled = true;
            this.Finding_cb.Items.AddRange(new object[] {
            "Bola",
            "Contorno Campo",
            "Time",
            "Goleiro",
            "Zagueiro",
            "Atacante"});
            this.Finding_cb.Location = new System.Drawing.Point(157, 358);
            this.Finding_cb.Name = "Finding_cb";
            this.Finding_cb.Size = new System.Drawing.Size(95, 21);
            this.Finding_cb.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(417, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.testesImageBox);
            this.panel3.Location = new System.Drawing.Point(520, 322);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(480, 270);
            this.panel3.TabIndex = 21;
            // 
            // testesImageBox
            // 
            this.testesImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testesImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.testesImageBox.Location = new System.Drawing.Point(0, 0);
            this.testesImageBox.MaximumSize = new System.Drawing.Size(640, 480);
            this.testesImageBox.Name = "testesImageBox";
            this.testesImageBox.Size = new System.Drawing.Size(480, 270);
            this.testesImageBox.TabIndex = 2;
            this.testesImageBox.TabStop = false;
            // 
            // fps
            // 
            this.fps.AutoSize = true;
            this.fps.Location = new System.Drawing.Point(263, 510);
            this.fps.Name = "fps";
            this.fps.Size = new System.Drawing.Size(35, 13);
            this.fps.TabIndex = 22;
            this.fps.Text = "label1";
            this.fps.Click += new System.EventHandler(this.fps_Click);
            // 
            // blobsImageBox
            // 
            this.blobsImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blobsImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.blobsImageBox.Location = new System.Drawing.Point(0, 0);
            this.blobsImageBox.MaximumSize = new System.Drawing.Size(640, 480);
            this.blobsImageBox.Name = "blobsImageBox";
            this.blobsImageBox.Size = new System.Drawing.Size(480, 270);
            this.blobsImageBox.TabIndex = 2;
            this.blobsImageBox.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(1031, 41);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(480, 270);
            this.panel4.TabIndex = 23;
            this.panel4.Controls.Add(this.blobsImageBox);
            // 
            // CameraDetect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1612, 604);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.fps);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Finding_cb);
            this.Controls.Add(this.Mostrar_cbox);
            this.Controls.Add(this.ResetCorte_btn);
            this.Controls.Add(this.PegaCor_btn);
            this.Controls.Add(this.CortarCampo_btn);
            this.Controls.Add(this.Cameras_cb);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Capture_btn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CameraDetect";
            this.Text = "Captura da Camera";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formatedImageBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testesImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //Elementos
        private ImageBox captureImageBox;
        private ImageBox formatedImageBox;
        private ImageBox testesImageBox;
        private ImageBox blobsImageBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Capture_btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox Cameras_cb;
        private System.Windows.Forms.Button CortarCampo_btn;
        private System.Windows.Forms.Button PegaCor_btn;
        private System.Windows.Forms.Button ResetCorte_btn;
        private System.Windows.Forms.CheckBox Mostrar_cbox;
        private System.Windows.Forms.ComboBox Finding_cb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label fps;
        private System.Windows.Forms.Panel panel4;
    }
}

