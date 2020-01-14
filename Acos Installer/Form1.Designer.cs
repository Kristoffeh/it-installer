namespace Acos_Installer
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
            this.btn_startInstall = new System.Windows.Forms.Button();
            this.cb_websak = new System.Windows.Forms.CheckBox();
            this.cb_ansettelse = new System.Windows.Forms.CheckBox();
            this.version = new System.Windows.Forms.Label();
            this.loadingLog = new System.Windows.Forms.TextBox();
            this.cb_trace = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_apen = new System.Windows.Forms.CheckBox();
            this.cb_citrix = new System.Windows.Forms.CheckBox();
            this.cb_chrome = new System.Windows.Forms.CheckBox();
            this.cb_uninstallwebsak = new System.Windows.Forms.CheckBox();
            this.cb_variables = new System.Windows.Forms.CheckBox();
            this.cb_installwebsak = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_startInstall
            // 
            this.btn_startInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_startInstall.Location = new System.Drawing.Point(14, 358);
            this.btn_startInstall.Name = "btn_startInstall";
            this.btn_startInstall.Size = new System.Drawing.Size(264, 36);
            this.btn_startInstall.TabIndex = 0;
            this.btn_startInstall.Text = "Start Installasjon";
            this.btn_startInstall.UseVisualStyleBackColor = true;
            this.btn_startInstall.Click += new System.EventHandler(this.btn_startInstall_Click);
            // 
            // cb_websak
            // 
            this.cb_websak.AutoSize = true;
            this.cb_websak.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_websak.Location = new System.Drawing.Point(6, 19);
            this.cb_websak.Name = "cb_websak";
            this.cb_websak.Size = new System.Drawing.Size(105, 19);
            this.cb_websak.TabIndex = 1;
            this.cb_websak.Text = "ACOS Websak";
            this.cb_websak.UseVisualStyleBackColor = true;
            // 
            // cb_ansettelse
            // 
            this.cb_ansettelse.AutoSize = true;
            this.cb_ansettelse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ansettelse.Location = new System.Drawing.Point(141, 19);
            this.cb_ansettelse.Name = "cb_ansettelse";
            this.cb_ansettelse.Size = new System.Drawing.Size(117, 19);
            this.cb_ansettelse.TabIndex = 1;
            this.cb_ansettelse.Text = "ACOS Ansettelse";
            this.cb_ansettelse.UseVisualStyleBackColor = true;
            // 
            // version
            // 
            this.version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(11, 402);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(41, 13);
            this.version.TabIndex = 2;
            this.version.Text = "versjon";
            // 
            // loadingLog
            // 
            this.loadingLog.BackColor = System.Drawing.SystemColors.ControlLight;
            this.loadingLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadingLog.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLog.Location = new System.Drawing.Point(298, 12);
            this.loadingLog.Multiline = true;
            this.loadingLog.Name = "loadingLog";
            this.loadingLog.ReadOnly = true;
            this.loadingLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.loadingLog.Size = new System.Drawing.Size(263, 401);
            this.loadingLog.TabIndex = 3;
            // 
            // cb_trace
            // 
            this.cb_trace.AutoSize = true;
            this.cb_trace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_trace.Location = new System.Drawing.Point(6, 44);
            this.cb_trace.Name = "cb_trace";
            this.cb_trace.Size = new System.Drawing.Size(92, 19);
            this.cb_trace.TabIndex = 1;
            this.cb_trace.Text = "ACOS Trace";
            this.cb_trace.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_websak);
            this.groupBox1.Controls.Add(this.cb_trace);
            this.groupBox1.Controls.Add(this.cb_ansettelse);
            this.groupBox1.Location = new System.Drawing.Point(14, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 80);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ACOS Snarveier";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_apen);
            this.groupBox2.Controls.Add(this.cb_citrix);
            this.groupBox2.Controls.Add(this.cb_chrome);
            this.groupBox2.Location = new System.Drawing.Point(12, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 77);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Åpen Sone";
            // 
            // cb_apen
            // 
            this.cb_apen.AutoSize = true;
            this.cb_apen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_apen.Location = new System.Drawing.Point(6, 44);
            this.cb_apen.Name = "cb_apen";
            this.cb_apen.Size = new System.Drawing.Size(86, 19);
            this.cb_apen.TabIndex = 1;
            this.cb_apen.Text = "Åpen Sone";
            this.cb_apen.UseVisualStyleBackColor = true;
            // 
            // cb_citrix
            // 
            this.cb_citrix.AutoSize = true;
            this.cb_citrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_citrix.Location = new System.Drawing.Point(140, 19);
            this.cb_citrix.Name = "cb_citrix";
            this.cb_citrix.Size = new System.Drawing.Size(53, 19);
            this.cb_citrix.TabIndex = 1;
            this.cb_citrix.Text = "Citrix";
            this.cb_citrix.UseVisualStyleBackColor = true;
            // 
            // cb_chrome
            // 
            this.cb_chrome.AutoSize = true;
            this.cb_chrome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_chrome.Location = new System.Drawing.Point(6, 19);
            this.cb_chrome.Name = "cb_chrome";
            this.cb_chrome.Size = new System.Drawing.Size(113, 19);
            this.cb_chrome.TabIndex = 1;
            this.cb_chrome.Text = "Google Chrome";
            this.cb_chrome.UseVisualStyleBackColor = true;
            // 
            // cb_uninstallwebsak
            // 
            this.cb_uninstallwebsak.AutoSize = true;
            this.cb_uninstallwebsak.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_uninstallwebsak.Location = new System.Drawing.Point(20, 12);
            this.cb_uninstallwebsak.Name = "cb_uninstallwebsak";
            this.cb_uninstallwebsak.Size = new System.Drawing.Size(164, 19);
            this.cb_uninstallwebsak.TabIndex = 1;
            this.cb_uninstallwebsak.Text = "Avinstaller Websak pakke";
            this.cb_uninstallwebsak.UseVisualStyleBackColor = true;
            // 
            // cb_variables
            // 
            this.cb_variables.AutoSize = true;
            this.cb_variables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_variables.Location = new System.Drawing.Point(20, 62);
            this.cb_variables.Name = "cb_variables";
            this.cb_variables.Size = new System.Drawing.Size(159, 19);
            this.cb_variables.TabIndex = 1;
            this.cb_variables.Text = "Sjekk db/server variabler";
            this.cb_variables.UseVisualStyleBackColor = true;
            // 
            // cb_installwebsak
            // 
            this.cb_installwebsak.AutoSize = true;
            this.cb_installwebsak.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_installwebsak.Location = new System.Drawing.Point(20, 37);
            this.cb_installwebsak.Name = "cb_installwebsak";
            this.cb_installwebsak.Size = new System.Drawing.Size(152, 19);
            this.cb_installwebsak.TabIndex = 5;
            this.cb_installwebsak.Text = "Installer Websak pakke";
            this.cb_installwebsak.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 424);
            this.Controls.Add(this.cb_installwebsak);
            this.Controls.Add(this.cb_variables);
            this.Controls.Add(this.cb_uninstallwebsak);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loadingLog);
            this.Controls.Add(this.version);
            this.Controls.Add(this.btn_startInstall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "IT Installer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_startInstall;
        private System.Windows.Forms.CheckBox cb_websak;
        private System.Windows.Forms.CheckBox cb_ansettelse;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.TextBox loadingLog;
        private System.Windows.Forms.CheckBox cb_trace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_apen;
        private System.Windows.Forms.CheckBox cb_citrix;
        private System.Windows.Forms.CheckBox cb_chrome;
        private System.Windows.Forms.CheckBox cb_uninstallwebsak;
        private System.Windows.Forms.CheckBox cb_variables;
        private System.Windows.Forms.CheckBox cb_installwebsak;
    }
}

