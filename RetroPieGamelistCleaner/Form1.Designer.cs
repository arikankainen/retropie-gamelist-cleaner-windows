namespace RetroPieGamelistCleaner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboEmulators = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefreshEmulators = new System.Windows.Forms.Button();
            this.btnRestoreHost = new System.Windows.Forms.Button();
            this.btnRestoreUsername = new System.Windows.Forms.Button();
            this.btnRestorePassword = new System.Windows.Forms.Button();
            this.btnRestoreRom = new System.Windows.Forms.Button();
            this.panelName = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelName.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHost
            // 
            this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHost.Location = new System.Drawing.Point(92, 63);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(262, 20);
            this.txtHost.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Host:";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(12, 229);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(431, 227);
            this.txtLog.TabIndex = 10;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(360, 466);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(83, 23);
            this.btnGo.TabIndex = 12;
            this.btnGo.Text = "Clean";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(92, 92);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(262, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(92, 121);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(262, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(92, 150);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(262, 20);
            this.txtDirectory.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "ROM directory:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(-3, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(461, 2);
            this.label2.TabIndex = 13;
            // 
            // comboEmulators
            // 
            this.comboEmulators.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboEmulators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmulators.FormattingEnabled = true;
            this.comboEmulators.Location = new System.Drawing.Point(92, 196);
            this.comboEmulators.Name = "comboEmulators";
            this.comboEmulators.Size = new System.Drawing.Size(262, 21);
            this.comboEmulators.Sorted = true;
            this.comboEmulators.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Emulator:";
            // 
            // btnRefreshEmulators
            // 
            this.btnRefreshEmulators.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshEmulators.Location = new System.Drawing.Point(360, 195);
            this.btnRefreshEmulators.Name = "btnRefreshEmulators";
            this.btnRefreshEmulators.Size = new System.Drawing.Size(83, 23);
            this.btnRefreshEmulators.TabIndex = 9;
            this.btnRefreshEmulators.Text = "Refresh";
            this.btnRefreshEmulators.UseVisualStyleBackColor = true;
            this.btnRefreshEmulators.Click += new System.EventHandler(this.btnRefreshEmulators_Click);
            // 
            // btnRestoreHost
            // 
            this.btnRestoreHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestoreHost.Location = new System.Drawing.Point(360, 61);
            this.btnRestoreHost.Name = "btnRestoreHost";
            this.btnRestoreHost.Size = new System.Drawing.Size(83, 23);
            this.btnRestoreHost.TabIndex = 1;
            this.btnRestoreHost.Text = "Use default";
            this.btnRestoreHost.UseVisualStyleBackColor = true;
            this.btnRestoreHost.Click += new System.EventHandler(this.btnRestoreHost_Click);
            // 
            // btnRestoreUsername
            // 
            this.btnRestoreUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestoreUsername.Location = new System.Drawing.Point(360, 90);
            this.btnRestoreUsername.Name = "btnRestoreUsername";
            this.btnRestoreUsername.Size = new System.Drawing.Size(83, 23);
            this.btnRestoreUsername.TabIndex = 3;
            this.btnRestoreUsername.Text = "Use default";
            this.btnRestoreUsername.UseVisualStyleBackColor = true;
            this.btnRestoreUsername.Click += new System.EventHandler(this.btnRestoreUsername_Click);
            // 
            // btnRestorePassword
            // 
            this.btnRestorePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestorePassword.Location = new System.Drawing.Point(360, 119);
            this.btnRestorePassword.Name = "btnRestorePassword";
            this.btnRestorePassword.Size = new System.Drawing.Size(83, 23);
            this.btnRestorePassword.TabIndex = 5;
            this.btnRestorePassword.Text = "Use default";
            this.btnRestorePassword.UseVisualStyleBackColor = true;
            this.btnRestorePassword.Click += new System.EventHandler(this.btnRestorePassword_Click);
            // 
            // btnRestoreRom
            // 
            this.btnRestoreRom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestoreRom.Location = new System.Drawing.Point(360, 148);
            this.btnRestoreRom.Name = "btnRestoreRom";
            this.btnRestoreRom.Size = new System.Drawing.Size(83, 23);
            this.btnRestoreRom.TabIndex = 7;
            this.btnRestoreRom.Text = "Use default";
            this.btnRestoreRom.UseVisualStyleBackColor = true;
            this.btnRestoreRom.Click += new System.EventHandler(this.btnRestoreRom_Click);
            // 
            // panelName
            // 
            this.panelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelName.BackColor = System.Drawing.SystemColors.Window;
            this.panelName.Controls.Add(this.labelName);
            this.panelName.Location = new System.Drawing.Point(0, 0);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(456, 50);
            this.panelName.TabIndex = 21;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(12, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(431, 32);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Utility to clean deleted games from gamelist.xml";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(0, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(461, 2);
            this.label7.TabIndex = 22;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(12, 466);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 501);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panelName);
            this.Controls.Add(this.btnRestoreRom);
            this.Controls.Add(this.btnRestorePassword);
            this.Controls.Add(this.btnRestoreUsername);
            this.Controls.Add(this.btnRestoreHost);
            this.Controls.Add(this.btnRefreshEmulators);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboEmulators);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RetroPie Gamelist Cleaner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panelName.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboEmulators;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefreshEmulators;
        private System.Windows.Forms.Button btnRestoreHost;
        private System.Windows.Forms.Button btnRestoreUsername;
        private System.Windows.Forms.Button btnRestorePassword;
        private System.Windows.Forms.Button btnRestoreRom;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button btnClose;
    }
}

