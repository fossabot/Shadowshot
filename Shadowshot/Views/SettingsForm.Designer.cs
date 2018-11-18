namespace Shadowshot.Views
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.generalGroupBox = new System.Windows.Forms.GroupBox();
            this.generalTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.isAutoStartCheckBox = new System.Windows.Forms.CheckBox();
            this.keyboardShortcutsGroupBox = new System.Windows.Forms.GroupBox();
            this.keyboardShortcutsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.entireScreenToDesktopTextBox = new System.Windows.Forms.TextBox();
            this.activeWindowToDesktopTextBox = new System.Windows.Forms.TextBox();
            this.entireScreenToClipboardTextBox = new System.Windows.Forms.TextBox();
            this.activeWindowToClipboardTextBox = new System.Windows.Forms.TextBox();
            this.entireScreenToDesktopLabel = new System.Windows.Forms.Label();
            this.activeWindowToDesktopLabel = new System.Windows.Forms.Label();
            this.entireScreenToClipboardLabel = new System.Windows.Forms.Label();
            this.activeWindowToClipboardLabel = new System.Windows.Forms.Label();
            this.buttonFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.generalGroupBox.SuspendLayout();
            this.generalTableLayoutPanel.SuspendLayout();
            this.keyboardShortcutsGroupBox.SuspendLayout();
            this.keyboardShortcutsTableLayoutPanel.SuspendLayout();
            this.buttonFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalGroupBox
            // 
            resources.ApplyResources(this.generalGroupBox, "generalGroupBox");
            this.generalGroupBox.Controls.Add(this.generalTableLayoutPanel);
            this.generalGroupBox.Name = "generalGroupBox";
            this.generalGroupBox.TabStop = false;
            // 
            // generalTableLayoutPanel
            // 
            resources.ApplyResources(this.generalTableLayoutPanel, "generalTableLayoutPanel");
            this.generalTableLayoutPanel.Controls.Add(this.isAutoStartCheckBox, 0, 0);
            this.generalTableLayoutPanel.Name = "generalTableLayoutPanel";
            // 
            // isAutoStartCheckBox
            // 
            resources.ApplyResources(this.isAutoStartCheckBox, "isAutoStartCheckBox");
            this.isAutoStartCheckBox.Name = "isAutoStartCheckBox";
            this.isAutoStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // keyboardShortcutsGroupBox
            // 
            resources.ApplyResources(this.keyboardShortcutsGroupBox, "keyboardShortcutsGroupBox");
            this.keyboardShortcutsGroupBox.Controls.Add(this.keyboardShortcutsTableLayoutPanel);
            this.keyboardShortcutsGroupBox.Name = "keyboardShortcutsGroupBox";
            this.keyboardShortcutsGroupBox.TabStop = false;
            // 
            // keyboardShortcutsTableLayoutPanel
            // 
            resources.ApplyResources(this.keyboardShortcutsTableLayoutPanel, "keyboardShortcutsTableLayoutPanel");
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.entireScreenToDesktopTextBox, 1, 0);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.activeWindowToDesktopTextBox, 1, 1);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.entireScreenToClipboardTextBox, 1, 2);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.activeWindowToClipboardTextBox, 1, 3);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.entireScreenToDesktopLabel, 0, 0);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.activeWindowToDesktopLabel, 0, 1);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.entireScreenToClipboardLabel, 0, 2);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.activeWindowToClipboardLabel, 0, 3);
            this.keyboardShortcutsTableLayoutPanel.Name = "keyboardShortcutsTableLayoutPanel";
            // 
            // entireScreenToDesktopTextBox
            // 
            resources.ApplyResources(this.entireScreenToDesktopTextBox, "entireScreenToDesktopTextBox");
            this.entireScreenToDesktopTextBox.Name = "entireScreenToDesktopTextBox";
            this.entireScreenToDesktopTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entireScreenToDesktopTextBox_KeyDown);
            // 
            // activeWindowToDesktopTextBox
            // 
            resources.ApplyResources(this.activeWindowToDesktopTextBox, "activeWindowToDesktopTextBox");
            this.activeWindowToDesktopTextBox.Name = "activeWindowToDesktopTextBox";
            this.activeWindowToDesktopTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.activeWindowToDesktopTextBox_KeyDown);
            // 
            // entireScreenToClipboardTextBox
            // 
            resources.ApplyResources(this.entireScreenToClipboardTextBox, "entireScreenToClipboardTextBox");
            this.entireScreenToClipboardTextBox.Name = "entireScreenToClipboardTextBox";
            this.entireScreenToClipboardTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entireScreenToClipboardTextBox_KeyDown);
            // 
            // activeWindowToClipboardTextBox
            // 
            resources.ApplyResources(this.activeWindowToClipboardTextBox, "activeWindowToClipboardTextBox");
            this.activeWindowToClipboardTextBox.Name = "activeWindowToClipboardTextBox";
            this.activeWindowToClipboardTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.activeWindowToClipboardTextBox_KeyDown);
            // 
            // entireScreenToDesktopLabel
            // 
            resources.ApplyResources(this.entireScreenToDesktopLabel, "entireScreenToDesktopLabel");
            this.entireScreenToDesktopLabel.Name = "entireScreenToDesktopLabel";
            // 
            // activeWindowToDesktopLabel
            // 
            resources.ApplyResources(this.activeWindowToDesktopLabel, "activeWindowToDesktopLabel");
            this.activeWindowToDesktopLabel.Name = "activeWindowToDesktopLabel";
            // 
            // entireScreenToClipboardLabel
            // 
            resources.ApplyResources(this.entireScreenToClipboardLabel, "entireScreenToClipboardLabel");
            this.entireScreenToClipboardLabel.Name = "entireScreenToClipboardLabel";
            // 
            // activeWindowToClipboardLabel
            // 
            resources.ApplyResources(this.activeWindowToClipboardLabel, "activeWindowToClipboardLabel");
            this.activeWindowToClipboardLabel.Name = "activeWindowToClipboardLabel";
            // 
            // buttonFlowLayoutPanel
            // 
            resources.ApplyResources(this.buttonFlowLayoutPanel, "buttonFlowLayoutPanel");
            this.buttonFlowLayoutPanel.Controls.Add(this.cancelButton);
            this.buttonFlowLayoutPanel.Controls.Add(this.okButton);
            this.buttonFlowLayoutPanel.Name = "buttonFlowLayoutPanel";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.keyboardShortcutsGroupBox);
            this.Controls.Add(this.generalGroupBox);
            this.Controls.Add(this.buttonFlowLayoutPanel);
            this.Name = "SettingsForm";
            this.generalGroupBox.ResumeLayout(false);
            this.generalTableLayoutPanel.ResumeLayout(false);
            this.generalTableLayoutPanel.PerformLayout();
            this.keyboardShortcutsGroupBox.ResumeLayout(false);
            this.keyboardShortcutsTableLayoutPanel.ResumeLayout(false);
            this.keyboardShortcutsTableLayoutPanel.PerformLayout();
            this.buttonFlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox generalGroupBox;
        private System.Windows.Forms.TableLayoutPanel generalTableLayoutPanel;
        private System.Windows.Forms.CheckBox isAutoStartCheckBox;
        private System.Windows.Forms.GroupBox keyboardShortcutsGroupBox;
        private System.Windows.Forms.TableLayoutPanel keyboardShortcutsTableLayoutPanel;
        private System.Windows.Forms.Label entireScreenToDesktopLabel;
        private System.Windows.Forms.Label activeWindowToDesktopLabel;
        private System.Windows.Forms.Label entireScreenToClipboardLabel;
        private System.Windows.Forms.Label activeWindowToClipboardLabel;
        private System.Windows.Forms.TextBox entireScreenToDesktopTextBox;
        private System.Windows.Forms.TextBox activeWindowToDesktopTextBox;
        private System.Windows.Forms.TextBox entireScreenToClipboardTextBox;
        private System.Windows.Forms.TextBox activeWindowToClipboardTextBox;
        private System.Windows.Forms.FlowLayoutPanel buttonFlowLayoutPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}