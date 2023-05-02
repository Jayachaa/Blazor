using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BayView_CSV_Reader
{
	public class CSVWaterReadingExport
	{
		#region Fields
		private Dictionary<string, Dictionary<string, Reading>> _dictFlatReading = new Dictionary<string, Dictionary<string, Reading>>();
		#endregion

		#region Properties
		public Dictionary<string, Dictionary<string, Reading>> CSV_Info
		{
			set { _dictFlatReading = value; }
		}

		public bool IncludeDays { get; set; }
		#endregion

		#region Publics
		public void ExportCSV(string strFilePath)
		{
			strFilePath += "\\Output\\BayView_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".CSV";

			StreamWriter sw = new StreamWriter(strFilePath, false);
			//headers
			sw.Write("FlatNr,Date,BR1,BR2,BR3,BR4,BR5,Kitchen,Kitchen2,Commercial,Garden");
			sw.Write(sw.NewLine);

			foreach(KeyValuePair<string, Dictionary<string, Reading>> flatEntry in _dictFlatReading)
			{
				decimal dBR1 = 0, dBR2 = 0, dBR3 = 0, dBR4 = 0, dBR5 = 0, dKit1 = 0, dKit2 = 0, dCommercial =0, dGarden=0;
				DateTime dtDate = DateTime.Now;
				foreach(KeyValuePair<string, Reading> entry in flatEntry.Value)
				{
					if(this.IncludeDays)
					{
						sw.Write(flatEntry.Key);
						sw.Write(",");
						sw.Write(entry.Key);
						sw.Write(",");
						sw.Write(entry.Value.Bath1 ?? 0);
						sw.Write(",");
						sw.Write(entry.Value.Bath2 ?? 0);
						sw.Write(",");
						sw.Write(entry.Value.Bath3 ?? 0);
						sw.Write(",");
						sw.Write(entry.Value.Bath4 ?? 0);
						sw.Write(",");
						sw.Write(entry.Value.Bath5 ?? 0);
						sw.Write(",");
						sw.Write(entry.Value.Kitchen ?? 0);
						sw.Write(",");
						sw.Write((entry.Value.RO1 ?? 0) + (entry.Value.RO2 ?? 0));
						sw.Write(",");
						sw.Write((entry.Value.Tank1 ?? 0) + (entry.Value.Tank2 ?? 0));
						sw.Write(",");
						sw.Write((entry.Value.Garden1 ?? 0) + (entry.Value.Garden1 ?? 0));
						sw.Write(sw.NewLine);
						dtDate = entry.Value.Date;
					}

					dBR1 += entry.Value.Bath1 ?? 0;
					dBR2 += entry.Value.Bath2 ?? 0;
					dBR3 += entry.Value.Bath3 ?? 0;
					dBR4 += entry.Value.Bath4 ?? 0;
					dBR5 += entry.Value.Bath5 ?? 0;
					dKit1 += entry.Value.Kitchen ?? 0;
					dKit2 += ((entry.Value.RO1 ?? 0) + (entry.Value.RO2 ?? 0));
					dCommercial+= ((entry.Value.Tank1 ?? 0) + (entry.Value.Tank2 ?? 0));
					dGarden+= ((entry.Value.Garden1 ?? 0) + (entry.Value.Garden2 ?? 0));
				}

				sw.Write(flatEntry.Key);
				sw.Write(",");
				sw.Write(dtDate.ToString("MMMM", CultureInfo.InvariantCulture));
				sw.Write(",");
				sw.Write(dBR1);
				sw.Write(",");
				sw.Write(dBR2);
				sw.Write(",");
				sw.Write(dBR3);
				sw.Write(",");
				sw.Write(dBR4);
				sw.Write(",");
				sw.Write(dBR5);
				sw.Write(",");
				sw.Write(dKit1);
				sw.Write(",");
				sw.Write(dKit2);
				sw.Write(",");
				sw.Write(dCommercial);
				sw.Write(",");
				sw.Write(dGarden);

				sw.Write(sw.NewLine);
			}

			sw.Close();
		}
		#endregion
	}
}