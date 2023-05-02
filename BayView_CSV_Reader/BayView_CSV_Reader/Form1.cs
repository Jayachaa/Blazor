using System;
using System.Windows.Forms;

namespace BayView_CSV_Reader
{
	public partial class Form1 : Form
	{
		#region Fields
		private CSVReadingBO _CSVReadingBO;
		private CSVWaterReadingExport _CSVWaterReadingExport;
		#endregion

		#region Constructors
		public Form1()
		{
			InitializeComponent();
		}
		#endregion

		#region Privates
		private void btnSelectFolder_Click(object sender, EventArgs e)
		{
			if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				txtBxFolder.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void btnReadCSV_Click(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(txtBxFolder.Text))
			{
				MessageBox.Show("Please select file folder");
				return;
			}

			this.UseWaitCursor = true;
			_CSVReadingBO = new CSVReadingBO();
			_CSVReadingBO.CreateReading(txtBxFolder.Text);

			this.UseWaitCursor = false;
			MessageBox.Show("Reading is finished.");
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			if(_CSVReadingBO == null || _CSVReadingBO.CSV_Info.Count == 0)
			{
				MessageBox.Show("Please read the CSV files, before exporting.");
				return;
			}

			this.UseWaitCursor = true;
			_CSVWaterReadingExport = new CSVWaterReadingExport();
			_CSVWaterReadingExport.CSV_Info = _CSVReadingBO.CSV_Info;
			_CSVWaterReadingExport.IncludeDays = chkBoxIncludeDays.Checked;
			_CSVWaterReadingExport.ExportCSV(txtBxFolder.Text);
			this.UseWaitCursor = false;

			MessageBox.Show("Exporting is finished.");
		}
		#endregion
	}
}