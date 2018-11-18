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
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Shadowshot";
            this.notifyIcon.Visible = true;
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
            this.contextMenuStrip.Size = new System.Drawing.Size(377, 170);
            // 
            // entireScreenToDesktopToolStripMenuItem
            // 
            this.entireScreenToDesktopToolStripMenuItem.Name = "entireScreenToDesktopToolStripMenuItem";
            this.entireScreenToDesktopToolStripMenuItem.Size = new System.Drawing.Size(376, 22);
            this.entireScreenToDesktopToolStripMenuItem.Text = "Take a screenshot of entire screen and save to desktop";
            this.entireScreenToDesktopToolStripMenuItem.Click += new System.EventHandler(this.entireScreenToDesktopToolStripMenuItem_Click);
            // 
            // activeWindowToDesktopToolStripMenuItem
            // 
            this.activeWindowToDesktopToolStripMenuItem.Name = "activeWindowToDesktopToolStripMenuItem";
            this.activeWindowToDesktopToolStripMenuItem.Size = new System.Drawing.Size(376, 22);
            this.activeWindowToDesktopToolStripMenuItem.Text = "Take a screenshot of active window and save to desktop";
            this.activeWindowToDesktopToolStripMenuItem.Click += new System.EventHandler(this.activeWindowToDesktopToolStripMenuItem_Click);
            // 
            // entireScreenToClipboardToolStripMenuItem
            // 
            this.entireScreenToClipboardToolStripMenuItem.Name = "entireScreenToClipboardToolStripMenuItem";
            this.entireScreenToClipboardToolStripMenuItem.Size = new System.Drawing.Size(376, 22);
            this.entireScreenToClipboardToolStripMenuItem.Text = "Take a screenshot of entire screen and save to clipboard";
            this.entireScreenToClipboardToolStripMenuItem.Click += new System.EventHandler(this.entireScreenToClipboardToolStripMenuItem_Click);
            // 
            // activeWindowToClipboardToolStripMenuItem
            // 
            this.activeWindowToClipboardToolStripMenuItem.Name = "activeWindowToClipboardToolStripMenuItem";
            this.activeWindowToClipboardToolStripMenuItem.Size = new System.Drawing.Size(376, 22);
            this.activeWindowToClipboardToolStripMenuItem.Text = "Take a screenshot of active window and save to clipboard";
            this.activeWindowToClipboardToolStripMenuItem.Click += new System.EventHandler(this.activeWindowToClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(373, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(376, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(376, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(373, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(376, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Main";
            this.Text = "Main";
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