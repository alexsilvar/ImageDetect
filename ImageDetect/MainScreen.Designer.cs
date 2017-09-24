namespace ImageDetect
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.Container_ts = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Camera_tsbtn = new System.Windows.Forms.ToolStripButton();
            this.DetectRobots_tsbtn = new System.Windows.Forms.ToolStripButton();
            this.Container_ts.TopToolStripPanel.SuspendLayout();
            this.Container_ts.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Container_ts
            // 
            this.Container_ts.BottomToolStripPanelVisible = false;
            // 
            // Container_ts.ContentPanel
            // 
            this.Container_ts.ContentPanel.Size = new System.Drawing.Size(784, 536);
            this.Container_ts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container_ts.LeftToolStripPanelVisible = false;
            this.Container_ts.Location = new System.Drawing.Point(0, 0);
            this.Container_ts.Name = "Container_ts";
            this.Container_ts.RightToolStripPanelVisible = false;
            this.Container_ts.Size = new System.Drawing.Size(784, 561);
            this.Container_ts.TabIndex = 0;
            this.Container_ts.Text = "toolStripContainer1";
            // 
            // Container_ts.TopToolStripPanel
            // 
            this.Container_ts.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Camera_tsbtn,
            this.DetectRobots_tsbtn});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(89, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // Camera_tsbtn
            // 
            this.Camera_tsbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Camera_tsbtn.Image = ((System.Drawing.Image)(resources.GetObject("Camera_tsbtn.Image")));
            this.Camera_tsbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Camera_tsbtn.Name = "Camera_tsbtn";
            this.Camera_tsbtn.Size = new System.Drawing.Size(23, 22);
            this.Camera_tsbtn.Text = "Definir Visão";
            this.Camera_tsbtn.Click += new System.EventHandler(this.Camera_tsbtn_Click);
            // 
            // DetectRobots_tsbtn
            // 
            this.DetectRobots_tsbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DetectRobots_tsbtn.Image = ((System.Drawing.Image)(resources.GetObject("DetectRobots_tsbtn.Image")));
            this.DetectRobots_tsbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DetectRobots_tsbtn.Name = "DetectRobots_tsbtn";
            this.DetectRobots_tsbtn.Size = new System.Drawing.Size(23, 22);
            this.DetectRobots_tsbtn.Text = "Detectar Robôs";
            this.DetectRobots_tsbtn.Click += new System.EventHandler(this.DetectRobots_tsbtn_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Container_ts);
            this.Name = "MainScreen";
            this.Text = "Futebol de Robos - CEFET-MG Timóteo By: Silva R.A.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Container_ts.TopToolStripPanel.ResumeLayout(false);
            this.Container_ts.TopToolStripPanel.PerformLayout();
            this.Container_ts.ResumeLayout(false);
            this.Container_ts.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer Container_ts;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Camera_tsbtn;
        private System.Windows.Forms.ToolStripButton DetectRobots_tsbtn;
    }
}