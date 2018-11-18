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
            this.generalGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generalGroupBox.Controls.Add(this.generalTableLayoutPanel);
            this.generalGroupBox.Location = new System.Drawing.Point(12, 12);
            this.generalGroupBox.Name = "generalGroupBox";
            this.generalGroupBox.Size = new System.Drawing.Size(600, 61);
            this.generalGroupBox.TabIndex = 0;
            this.generalGroupBox.TabStop = false;
            this.generalGroupBox.Text = "General";
            // 
            // generalTableLayoutPanel
            // 
            this.generalTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generalTableLayoutPanel.ColumnCount = 1;
            this.generalTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.generalTableLayoutPanel.Controls.Add(this.isAutoStartCheckBox, 0, 0);
            this.generalTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.generalTableLayoutPanel.Name = "generalTableLayoutPanel";
            this.generalTableLayoutPanel.RowCount = 1;
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalTableLayoutPanel.Size = new System.Drawing.Size(588, 36);
            this.generalTableLayoutPanel.TabIndex = 0;
            // 
            // isAutoStartCheckBox
            // 
            this.isAutoStartCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.isAutoStartCheckBox.AutoSize = true;
            this.isAutoStartCheckBox.Location = new System.Drawing.Point(3, 9);
            this.isAutoStartCheckBox.Name = "isAutoStartCheckBox";
            this.isAutoStartCheckBox.Size = new System.Drawing.Size(216, 17);
            this.isAutoStartCheckBox.TabIndex = 0;
            this.isAutoStartCheckBox.Text = "Launch Shadowshot when system starts";
            this.isAutoStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // keyboardShortcutsGroupBox
            // 
            this.keyboardShortcutsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyboardShortcutsGroupBox.Controls.Add(this.keyboardShortcutsTableLayoutPanel);
            this.keyboardShortcutsGroupBox.Location = new System.Drawing.Point(12, 79);
            this.keyboardShortcutsGroupBox.Name = "keyboardShortcutsGroupBox";
            this.keyboardShortcutsGroupBox.Size = new System.Drawing.Size(600, 142);
            this.keyboardShortcutsGroupBox.TabIndex = 1;
            this.keyboardShortcutsGroupBox.TabStop = false;
            this.keyboardShortcutsGroupBox.Text = "Keyboard Shortcuts";
            // 
            // keyboardShortcutsTableLayoutPanel
            // 
            this.keyboardShortcutsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyboardShortcutsTableLayoutPanel.ColumnCount = 2;
            this.keyboardShortcutsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.keyboardShortcutsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.entireScreenToDesktopTextBox, 1, 0);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.activeWindowToDesktopTextBox, 1, 1);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.entireScreenToClipboardTextBox, 1, 2);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.activeWindowToClipboardTextBox, 1, 3);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.entireScreenToDesktopLabel, 0, 0);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.activeWindowToDesktopLabel, 0, 1);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.entireScreenToClipboardLabel, 0, 2);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.activeWindowToClipboardLabel, 0, 3);
            this.keyboardShortcutsTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.keyboardShortcutsTableLayoutPanel.Name = "keyboardShortcutsTableLayoutPanel";
            this.keyboardShortcutsTableLayoutPanel.RowCount = 4;
            this.keyboardShortcutsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.keyboardShortcutsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.keyboardShortcutsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.keyboardShortcutsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.keyboardShortcutsTableLayoutPanel.Size = new System.Drawing.Size(588, 117);
            this.keyboardShortcutsTableLayoutPanel.TabIndex = 0;
            // 
            // entireScreenToDesktopTextBox
            // 
            this.entireScreenToDesktopTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.entireScreenToDesktopTextBox.Location = new System.Drawing.Point(296, 4);
            this.entireScreenToDesktopTextBox.Name = "entireScreenToDesktopTextBox";
            this.entireScreenToDesktopTextBox.Size = new System.Drawing.Size(289, 20);
            this.entireScreenToDesktopTextBox.TabIndex = 1;
            this.entireScreenToDesktopTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entireScreenToDesktopTextBox_KeyDown);
            // 
            // activeWindowToDesktopTextBox
            // 
            this.activeWindowToDesktopTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.activeWindowToDesktopTextBox.Location = new System.Drawing.Point(296, 33);
            this.activeWindowToDesktopTextBox.Name = "activeWindowToDesktopTextBox";
            this.activeWindowToDesktopTextBox.Size = new System.Drawing.Size(289, 20);
            this.activeWindowToDesktopTextBox.TabIndex = 2;
            this.activeWindowToDesktopTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.activeWindowToDesktopTextBox_KeyDown);
            // 
            // entireScreenToClipboardTextBox
            // 
            this.entireScreenToClipboardTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.entireScreenToClipboardTextBox.Location = new System.Drawing.Point(296, 62);
            this.entireScreenToClipboardTextBox.Name = "entireScreenToClipboardTextBox";
            this.entireScreenToClipboardTextBox.Size = new System.Drawing.Size(289, 20);
            this.entireScreenToClipboardTextBox.TabIndex = 3;
            this.entireScreenToClipboardTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entireScreenToClipboardTextBox_KeyDown);
            // 
            // activeWindowToClipboardTextBox
            // 
            this.activeWindowToClipboardTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.activeWindowToClipboardTextBox.Location = new System.Drawing.Point(296, 92);
            this.activeWindowToClipboardTextBox.Name = "activeWindowToClipboardTextBox";
            this.activeWindowToClipboardTextBox.Size = new System.Drawing.Size(289, 20);
            this.activeWindowToClipboardTextBox.TabIndex = 4;
            this.activeWindowToClipboardTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.activeWindowToClipboardTextBox_KeyDown);
            // 
            // entireScreenToDesktopLabel
            // 
            this.entireScreenToDesktopLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.entireScreenToDesktopLabel.AutoSize = true;
            this.entireScreenToDesktopLabel.Location = new System.Drawing.Point(3, 8);
            this.entireScreenToDesktopLabel.Name = "entireScreenToDesktopLabel";
            this.entireScreenToDesktopLabel.Size = new System.Drawing.Size(275, 13);
            this.entireScreenToDesktopLabel.TabIndex = 0;
            this.entireScreenToDesktopLabel.Text = "Take a screenshot of entire screen and save to desktop:";
            // 
            // activeWindowToDesktopLabel
            // 
            this.activeWindowToDesktopLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activeWindowToDesktopLabel.AutoSize = true;
            this.activeWindowToDesktopLabel.Location = new System.Drawing.Point(3, 37);
            this.activeWindowToDesktopLabel.Name = "activeWindowToDesktopLabel";
            this.activeWindowToDesktopLabel.Size = new System.Drawing.Size(282, 13);
            this.activeWindowToDesktopLabel.TabIndex = 2;
            this.activeWindowToDesktopLabel.Text = "Take a screenshot of active window and save to desktop:";
            // 
            // entireScreenToClipboardLabel
            // 
            this.entireScreenToClipboardLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.entireScreenToClipboardLabel.AutoSize = true;
            this.entireScreenToClipboardLabel.Location = new System.Drawing.Point(3, 66);
            this.entireScreenToClipboardLabel.Name = "entireScreenToClipboardLabel";
            this.entireScreenToClipboardLabel.Size = new System.Drawing.Size(280, 13);
            this.entireScreenToClipboardLabel.TabIndex = 3;
            this.entireScreenToClipboardLabel.Text = "Take a screenshot of entire screen and save to clipboard:";
            // 
            // activeWindowToClipboardLabel
            // 
            this.activeWindowToClipboardLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activeWindowToClipboardLabel.AutoSize = true;
            this.activeWindowToClipboardLabel.Location = new System.Drawing.Point(3, 95);
            this.activeWindowToClipboardLabel.Name = "activeWindowToClipboardLabel";
            this.activeWindowToClipboardLabel.Size = new System.Drawing.Size(287, 13);
            this.activeWindowToClipboardLabel.TabIndex = 4;
            this.activeWindowToClipboardLabel.Text = "Take a screenshot of active window and save to clipboard:";
            // 
            // buttonFlowLayoutPanel
            // 
            this.buttonFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFlowLayoutPanel.Controls.Add(this.cancelButton);
            this.buttonFlowLayoutPanel.Controls.Add(this.okButton);
            this.buttonFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonFlowLayoutPanel.Location = new System.Drawing.Point(12, 239);
            this.buttonFlowLayoutPanel.Name = "buttonFlowLayoutPanel";
            this.buttonFlowLayoutPanel.Size = new System.Drawing.Size(600, 30);
            this.buttonFlowLayoutPanel.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(522, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(441, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 281);
            this.Controls.Add(this.keyboardShortcutsGroupBox);
            this.Controls.Add(this.generalGroupBox);
            this.Controls.Add(this.buttonFlowLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
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