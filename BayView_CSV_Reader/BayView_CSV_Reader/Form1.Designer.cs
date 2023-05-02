namespace BayView_CSV_Reader
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
			if(disposing && (components != null))
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnSelectFolder = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBxFolder = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkBoxIncludeDays = new System.Windows.Forms.CheckBox();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnReadCSV = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnReadCSV);
			this.groupBox1.Controls.Add(this.btnSelectFolder);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtBxFolder);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(374, 114);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Read CSV";
			// 
			// btnSelectFolder
			// 
			this.btnSelectFolder.Location = new System.Drawing.Point(286, 43);
			this.btnSelectFolder.Name = "btnSelectFolder";
			this.btnSelectFolder.Size = new System.Drawing.Size(26, 23);
			this.btnSelectFolder.TabIndex = 3;
			this.btnSelectFolder.Text = "...";
			this.btnSelectFolder.UseVisualStyleBackColor = true;
			this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Select csv files path";
			// 
			// txtBxFolder
			// 
			this.txtBxFolder.Enabled = false;
			this.txtBxFolder.Location = new System.Drawing.Point(20, 45);
			this.txtBxFolder.Name = "txtBxFolder";
			this.txtBxFolder.Size = new System.Drawing.Size(260, 20);
			this.txtBxFolder.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkBoxIncludeDays);
			this.groupBox2.Controls.Add(this.btnExport);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(0, 114);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(374, 100);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Export CSV";
			// 
			// chkBoxIncludeDays
			// 
			this.chkBoxIncludeDays.AutoSize = true;
			this.chkBoxIncludeDays.Location = new System.Drawing.Point(108, 19);
			this.chkBoxIncludeDays.Name = "chkBoxIncludeDays";
			this.chkBoxIncludeDays.Size = new System.Drawing.Size(119, 17);
			this.chkBoxIncludeDays.TabIndex = 4;
			this.chkBoxIncludeDays.Text = "Include days details";
			this.chkBoxIncludeDays.UseVisualStyleBackColor = true;
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(108, 49);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(119, 23);
			this.btnExport.TabIndex = 3;
			this.btnExport.Text = "Export";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// btnReadCSV
			// 
			this.btnReadCSV.Location = new System.Drawing.Point(108, 75);
			this.btnReadCSV.Name = "btnReadCSV";
			this.btnReadCSV.Size = new System.Drawing.Size(119, 23);
			this.btnReadCSV.TabIndex = 4;
			this.btnReadCSV.Text = "Read CSV files";
			this.btnReadCSV.UseVisualStyleBackColor = true;
			this.btnReadCSV.Click += new System.EventHandler(this.btnReadCSV_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(374, 228);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BayView_CSV_Reader";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBxFolder;
		private System.Windows.Forms.Button btnSelectFolder;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chkBoxIncludeDays;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Button btnReadCSV;
	}
}

