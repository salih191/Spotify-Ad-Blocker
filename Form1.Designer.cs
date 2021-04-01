
namespace Spotify_Ad_Blocker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bilgisayarlaAçılmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilidirimGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geçilenReklamSayısıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geçilenDiğerSayısıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "salih";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bilgisayarlaAçılmaToolStripMenuItem,
            this.bilidirimGösterToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.geçilenReklamSayısıToolStripMenuItem,
            this.geçilenDiğerSayısıToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(216, 124);
            // 
            // bilgisayarlaAçılmaToolStripMenuItem
            // 
            this.bilgisayarlaAçılmaToolStripMenuItem.Name = "bilgisayarlaAçılmaToolStripMenuItem";
            this.bilgisayarlaAçılmaToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.bilgisayarlaAçılmaToolStripMenuItem.Text = "Bilgisayarla Açılma";
            this.bilgisayarlaAçılmaToolStripMenuItem.Click += new System.EventHandler(this.bilgisayarlaAçılmaToolStripMenuItem_Click);
            // 
            // bilidirimGösterToolStripMenuItem
            // 
            this.bilidirimGösterToolStripMenuItem.Name = "bilidirimGösterToolStripMenuItem";
            this.bilidirimGösterToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.bilidirimGösterToolStripMenuItem.Text = "Bildirim Göster";
            this.bilidirimGösterToolStripMenuItem.Click += new System.EventHandler(this.bilidirimGösterToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // geçilenReklamSayısıToolStripMenuItem
            // 
            this.geçilenReklamSayısıToolStripMenuItem.Name = "geçilenReklamSayısıToolStripMenuItem";
            this.geçilenReklamSayısıToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.geçilenReklamSayısıToolStripMenuItem.Text = "Geçilen reklam sayısı";
            // 
            // geçilenDiğerSayısıToolStripMenuItem
            // 
            this.geçilenDiğerSayısıToolStripMenuItem.Name = "geçilenDiğerSayısıToolStripMenuItem";
            this.geçilenDiğerSayısıToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.geçilenDiğerSayısıToolStripMenuItem.Text = "Geçilen diğer sayısı:";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 318);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bilgisayarlaAçılmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilidirimGösterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geçilenReklamSayısıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geçilenDiğerSayısıToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
    }
}

