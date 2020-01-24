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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ACOS", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Snarveier", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Applikasjoner", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.version = new System.Windows.Forms.Label();
            this.loadingLog = new System.Windows.Forms.TextBox();
            this.listviewinstalls = new System.Windows.Forms.ListView();
            this.cname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cdesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_newinstall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // version
            // 
            this.version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(12, 463);
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
            this.loadingLog.Location = new System.Drawing.Point(500, 12);
            this.loadingLog.Multiline = true;
            this.loadingLog.Name = "loadingLog";
            this.loadingLog.ReadOnly = true;
            this.loadingLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.loadingLog.Size = new System.Drawing.Size(297, 465);
            this.loadingLog.TabIndex = 3;
            // 
            // listviewinstalls
            // 
            this.listviewinstalls.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listviewinstalls.AllowColumnReorder = true;
            this.listviewinstalls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listviewinstalls.BackColor = System.Drawing.SystemColors.Menu;
            this.listviewinstalls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listviewinstalls.CheckBoxes = true;
            this.listviewinstalls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cname,
            this.cdesc});
            this.listviewinstalls.ForeColor = System.Drawing.SystemColors.InfoText;
            this.listviewinstalls.FullRowSelect = true;
            listViewGroup1.Header = "ACOS";
            listViewGroup1.Name = "acos";
            listViewGroup1.Tag = "";
            listViewGroup2.Header = "Snarveier";
            listViewGroup2.Name = "snarveier";
            listViewGroup3.Header = "Applikasjoner";
            listViewGroup3.Name = "apps";
            this.listviewinstalls.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.listviewinstalls.HideSelection = false;
            this.listviewinstalls.Location = new System.Drawing.Point(12, 12);
            this.listviewinstalls.MultiSelect = false;
            this.listviewinstalls.Name = "listviewinstalls";
            this.listviewinstalls.Size = new System.Drawing.Size(482, 422);
            this.listviewinstalls.TabIndex = 7;
            this.listviewinstalls.TileSize = new System.Drawing.Size(449, 30);
            this.listviewinstalls.UseCompatibleStateImageBehavior = false;
            this.listviewinstalls.View = System.Windows.Forms.View.Details;
            // 
            // cname
            // 
            this.cname.Text = "Name";
            this.cname.Width = 179;
            // 
            // cdesc
            // 
            this.cdesc.Text = "Description";
            this.cdesc.Width = 303;
            // 
            // btn_newinstall
            // 
            this.btn_newinstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_newinstall.Location = new System.Drawing.Point(310, 441);
            this.btn_newinstall.Name = "btn_newinstall";
            this.btn_newinstall.Size = new System.Drawing.Size(184, 36);
            this.btn_newinstall.TabIndex = 8;
            this.btn_newinstall.Text = "Start Installasjon";
            this.btn_newinstall.UseVisualStyleBackColor = true;
            this.btn_newinstall.Click += new System.EventHandler(this.Btn_newinstall_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(802, 488);
            this.Controls.Add(this.listviewinstalls);
            this.Controls.Add(this.btn_newinstall);
            this.Controls.Add(this.loadingLog);
            this.Controls.Add(this.version);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "IT Installer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.TextBox loadingLog;
        private System.Windows.Forms.ListView listviewinstalls;
        private System.Windows.Forms.ColumnHeader cname;
        private System.Windows.Forms.ColumnHeader cdesc;
        private System.Windows.Forms.Button btn_newinstall;
    }
}

