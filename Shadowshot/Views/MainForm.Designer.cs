namespace Shadowshot.Views
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.entireScreenToDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeWindowToDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entireScreenToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeWindowToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entireScreenToDesktopToolStripMenuItem,
            this.activeWindowToDesktopToolStripMenuItem,
            this.entireScreenToClipboardToolStripMenuItem,
            this.activeWindowToClipboardToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // entireScreenToDesktopToolStripMenuItem
            // 
            this.entireScreenToDesktopToolStripMenuItem.Name = "entireScreenToDesktopToolStripMenuItem";
            resources.ApplyResources(this.entireScreenToDesktopToolStripMenuItem, "entireScreenToDesktopToolStripMenuItem");
            this.entireScreenToDesktopToolStripMenuItem.Click += new System.EventHandler(this.entireScreenToDesktopToolStripMenuItem_Click);
            // 
            // activeWindowToDesktopToolStripMenuItem
            // 
            this.activeWindowToDesktopToolStripMenuItem.Name = "activeWindowToDesktopToolStripMenuItem";
            resources.ApplyResources(this.activeWindowToDesktopToolStripMenuItem, "activeWindowToDesktopToolStripMenuItem");
            this.activeWindowToDesktopToolStripMenuItem.Click += new System.EventHandler(this.activeWindowToDesktopToolStripMenuItem_Click);
            // 
            // entireScreenToClipboardToolStripMenuItem
            // 
            this.entireScreenToClipboardToolStripMenuItem.Name = "entireScreenToClipboardToolStripMenuItem";
            resources.ApplyResources(this.entireScreenToClipboardToolStripMenuItem, "entireScreenToClipboardToolStripMenuItem");
            this.entireScreenToClipboardToolStripMenuItem.Click += new System.EventHandler(this.entireScreenToClipboardToolStripMenuItem_Click);
            // 
            // activeWindowToClipboardToolStripMenuItem
            // 
            this.activeWindowToClipboardToolStripMenuItem.Name = "activeWindowToClipboardToolStripMenuItem";
            resources.ApplyResources(this.activeWindowToClipboardToolStripMenuItem, "activeWindowToClipboardToolStripMenuItem");
            this.activeWindowToClipboardToolStripMenuItem.Click += new System.EventHandler(this.activeWindowToClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MainForm";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem entireScreenToDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeWindowToDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entireScreenToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeWindowToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}