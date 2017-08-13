namespace Shadowshot.Views
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        
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
            this.commonGroupBox = new System.Windows.Forms.GroupBox();
            this.autoStartCheckBox = new System.Windows.Forms.CheckBox();
            this.hotkeyGroupBox = new System.Windows.Forms.GroupBox();
            this.HotkeyTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.entireScreenToClipboardTextBox = new System.Windows.Forms.TextBox();
            this.activeWindowToClipboardTextBox = new System.Windows.Forms.TextBox();
            this.entireScreenToDesktopTextBox = new System.Windows.Forms.TextBox();
            this.activeWindowToDesktopTextBox = new System.Windows.Forms.TextBox();
            this.entireScreenToClipboardLabel = new System.Windows.Forms.Label();
            this.entireScreenToDesktopLabel = new System.Windows.Forms.Label();
            this.activeWindowToClipboardLabel = new System.Windows.Forms.Label();
            this.activeWindowToDesktopLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.commonGroupBox.SuspendLayout();
            this.hotkeyGroupBox.SuspendLayout();
            this.HotkeyTableLayoutPanel.SuspendLayout();
            this.buttonFlowLayoutPanel.SuspendLayout();
            this.MainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // commonGroupBox
            // 
            this.commonGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commonGroupBox.Controls.Add(this.autoStartCheckBox);
            this.commonGroupBox.Location = new System.Drawing.Point(3, 3);
            this.commonGroupBox.Name = "commonGroupBox";
            this.commonGroupBox.Size = new System.Drawing.Size(594, 42);
            this.commonGroupBox.TabIndex = 0;
            this.commonGroupBox.TabStop = false;
            this.commonGroupBox.Text = "Common";
            // 
            // autoStartCheckBox
            // 
            this.autoStartCheckBox.AutoSize = true;
            this.autoStartCheckBox.Location = new System.Drawing.Point(11, 20);
            this.autoStartCheckBox.Name = "autoStartCheckBox";
            this.autoStartCheckBox.Size = new System.Drawing.Size(240, 16);
            this.autoStartCheckBox.TabIndex = 0;
            this.autoStartCheckBox.Text = "Launch Shadowshot when system starts";
            this.autoStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // hotkeyGroupBox
            // 
            this.hotkeyGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hotkeyGroupBox.Controls.Add(this.HotkeyTableLayoutPanel);
            this.hotkeyGroupBox.Location = new System.Drawing.Point(3, 51);
            this.hotkeyGroupBox.Name = "hotkeyGroupBox";
            this.hotkeyGroupBox.Size = new System.Drawing.Size(594, 134);
            this.hotkeyGroupBox.TabIndex = 1;
            this.hotkeyGroupBox.TabStop = false;
            this.hotkeyGroupBox.Text = "Hotkey";
            // 
            // HotkeyTableLayoutPanel
            // 
            this.HotkeyTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HotkeyTableLayoutPanel.ColumnCount = 2;
            this.HotkeyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.HotkeyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.HotkeyTableLayoutPanel.Controls.Add(this.entireScreenToClipboardLabel, 0, 2);
            this.HotkeyTableLayoutPanel.Controls.Add(this.entireScreenToDesktopLabel, 0, 0);
            this.HotkeyTableLayoutPanel.Controls.Add(this.activeWindowToClipboardLabel, 0, 3);
            this.HotkeyTableLayoutPanel.Controls.Add(this.activeWindowToDesktopLabel, 0, 1);
            this.HotkeyTableLayoutPanel.Controls.Add(this.entireScreenToClipboardTextBox, 1, 2);
            this.HotkeyTableLayoutPanel.Controls.Add(this.entireScreenToDesktopTextBox, 1, 0);
            this.HotkeyTableLayoutPanel.Controls.Add(this.activeWindowToClipboardTextBox, 1, 3);
            this.HotkeyTableLayoutPanel.Controls.Add(this.activeWindowToDesktopTextBox, 1, 1);
            this.HotkeyTableLayoutPanel.Location = new System.Drawing.Point(6, 20);
            this.HotkeyTableLayoutPanel.Name = "HotkeyTableLayoutPanel";
            this.HotkeyTableLayoutPanel.RowCount = 4;
            this.HotkeyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HotkeyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HotkeyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HotkeyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HotkeyTableLayoutPanel.Size = new System.Drawing.Size(582, 108);
            this.HotkeyTableLayoutPanel.TabIndex = 0;
            // 
            // entireScreenToClipboardTextBox
            // 
            this.entireScreenToClipboardTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.entireScreenToClipboardTextBox.Location = new System.Drawing.Point(350, 57);
            this.entireScreenToClipboardTextBox.Name = "entireScreenToClipboardTextBox";
            this.entireScreenToClipboardTextBox.Size = new System.Drawing.Size(232, 21);
            this.entireScreenToClipboardTextBox.TabIndex = 1;
            // 
            // activeWindowToClipboardTextBox
            // 
            this.activeWindowToClipboardTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.activeWindowToClipboardTextBox.Location = new System.Drawing.Point(350, 84);
            this.activeWindowToClipboardTextBox.Name = "activeWindowToClipboardTextBox";
            this.activeWindowToClipboardTextBox.Size = new System.Drawing.Size(232, 21);
            this.activeWindowToClipboardTextBox.TabIndex = 2;
            // 
            // entireScreenToDesktopTextBox
            // 
            this.entireScreenToDesktopTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.entireScreenToDesktopTextBox.Location = new System.Drawing.Point(350, 3);
            this.entireScreenToDesktopTextBox.Name = "entireScreenToDesktopTextBox";
            this.entireScreenToDesktopTextBox.Size = new System.Drawing.Size(232, 21);
            this.entireScreenToDesktopTextBox.TabIndex = 3;
            // 
            // activeWindowToDesktopTextBox
            // 
            this.activeWindowToDesktopTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.activeWindowToDesktopTextBox.Location = new System.Drawing.Point(350, 30);
            this.activeWindowToDesktopTextBox.Name = "activeWindowToDesktopTextBox";
            this.activeWindowToDesktopTextBox.Size = new System.Drawing.Size(232, 21);
            this.activeWindowToDesktopTextBox.TabIndex = 4;
            // 
            // entireScreenToClipboardLabel
            // 
            this.entireScreenToClipboardLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.entireScreenToClipboardLabel.AutoSize = true;
            this.entireScreenToClipboardLabel.Location = new System.Drawing.Point(3, 61);
            this.entireScreenToClipboardLabel.Name = "entireScreenToClipboardLabel";
            this.entireScreenToClipboardLabel.Size = new System.Drawing.Size(341, 12);
            this.entireScreenToClipboardLabel.TabIndex = 0;
            this.entireScreenToClipboardLabel.Text = "Take a screenshot of entire screen and save to clipboard";
            // 
            // entireScreenToDesktopLabel
            // 
            this.entireScreenToDesktopLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.entireScreenToDesktopLabel.AutoSize = true;
            this.entireScreenToDesktopLabel.Location = new System.Drawing.Point(3, 7);
            this.entireScreenToDesktopLabel.Name = "entireScreenToDesktopLabel";
            this.entireScreenToDesktopLabel.Size = new System.Drawing.Size(329, 12);
            this.entireScreenToDesktopLabel.TabIndex = 2;
            this.entireScreenToDesktopLabel.Text = "Take a screenshot of entire screen and save to desktop";
            // 
            // activeWindowToClipboardLabel
            // 
            this.activeWindowToClipboardLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activeWindowToClipboardLabel.AutoSize = true;
            this.activeWindowToClipboardLabel.Location = new System.Drawing.Point(3, 88);
            this.activeWindowToClipboardLabel.Name = "activeWindowToClipboardLabel";
            this.activeWindowToClipboardLabel.Size = new System.Drawing.Size(341, 12);
            this.activeWindowToClipboardLabel.TabIndex = 1;
            this.activeWindowToClipboardLabel.Text = "Take a screenshot of active window and save to clipboard";
            // 
            // activeWindowToDesktopLabel
            // 
            this.activeWindowToDesktopLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activeWindowToDesktopLabel.AutoSize = true;
            this.activeWindowToDesktopLabel.Location = new System.Drawing.Point(3, 34);
            this.activeWindowToDesktopLabel.Name = "activeWindowToDesktopLabel";
            this.activeWindowToDesktopLabel.Size = new System.Drawing.Size(329, 12);
            this.activeWindowToDesktopLabel.TabIndex = 3;
            this.activeWindowToDesktopLabel.Text = "Take a screenshot of active window and save to desktop";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(522, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(441, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // buttonFlowLayoutPanel
            // 
            this.buttonFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFlowLayoutPanel.Controls.Add(this.cancelButton);
            this.buttonFlowLayoutPanel.Controls.Add(this.okButton);
            this.buttonFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonFlowLayoutPanel.Location = new System.Drawing.Point(12, 280);
            this.buttonFlowLayoutPanel.Name = "buttonFlowLayoutPanel";
            this.buttonFlowLayoutPanel.Size = new System.Drawing.Size(600, 29);
            this.buttonFlowLayoutPanel.TabIndex = 1;
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayoutPanel.Controls.Add(this.commonGroupBox, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.hotkeyGroupBox, 0, 1);
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(600, 262);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Controls.Add(this.buttonFlowLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.commonGroupBox.ResumeLayout(false);
            this.commonGroupBox.PerformLayout();
            this.hotkeyGroupBox.ResumeLayout(false);
            this.HotkeyTableLayoutPanel.ResumeLayout(false);
            this.HotkeyTableLayoutPanel.PerformLayout();
            this.buttonFlowLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox commonGroupBox;
        private System.Windows.Forms.CheckBox autoStartCheckBox;
        private System.Windows.Forms.GroupBox hotkeyGroupBox;
        private System.Windows.Forms.TableLayoutPanel HotkeyTableLayoutPanel;
        private System.Windows.Forms.Label entireScreenToClipboardLabel;
        private System.Windows.Forms.TextBox entireScreenToClipboardTextBox;
        private System.Windows.Forms.Label activeWindowToClipboardLabel;
        private System.Windows.Forms.Label entireScreenToDesktopLabel;
        private System.Windows.Forms.Label activeWindowToDesktopLabel;
        private System.Windows.Forms.TextBox activeWindowToClipboardTextBox;
        private System.Windows.Forms.TextBox entireScreenToDesktopTextBox;
        private System.Windows.Forms.TextBox activeWindowToDesktopTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.FlowLayoutPanel buttonFlowLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
    }
}