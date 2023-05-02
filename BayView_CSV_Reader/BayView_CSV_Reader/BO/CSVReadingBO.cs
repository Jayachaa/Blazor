using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BayView_CSV_Reader
{
	public class CSVReadingBO
	{
		#region Constants
		private const string DATE = "Date";
		private const string B1_TANK = "B1_TANK";
		private const string B2_TANK = "B2_TANK";
		private const string B3_TANK = "B3_TANK";
		private const string B4_TANK = "B4_TANK";
		private const string B5_TANK = "B5_TANK";
		private const string KIT_TANK = "KIT_TANK";
		private const string RO1_RO = "RO1_RO";
		private const string RO2_RO = "RO2_RO";
		private const string T1_TANK = "T1_TANK";
		private const string T2_TANK = "T2_TANK";
		private const string G1_TANK = "G1_TANK";
		private const string G2_TANK = "G2_TANK";
		#endregion

		#region Fields
		private readonly string[] _headers = { "Date", "B1_TANK", "B2_TANK", "B3_TANK", "B4_TANK", "B5_TANK", "KIT_TANK", "RO1_RO", "RO2_RO", "T1_TANK", "T2_TANK", "G1_TANK", "G2_TANK" };
		#endregion

		#region Properties
		public Dictionary<string, Dictionary<string, Reading>> CSV_Info { get; } = new Dictionary<string, Dictionary<string, Reading>>();
		#endregion

		#region Publics
		/*
	     * dict<PlatNr, dict<date,List<Reading>>>
	     Collect all CSV
	          Read file one by One
	          get -> platnr from file name
	            From the reader ouput
	            Get -> first header -> collect valid header position (to get value from it)
	                -> Collect unique flat's -> readings value from the files.
	    */

		public void CreateReading(string strRootPath)
		{
			this.CSV_Info.Clear();

			string[] paths = Directory.GetFiles(strRootPath);
			foreach(string strPath in paths)
			{
				string strFilename = Path.GetFileNameWithoutExtension(strPath);

				// TODO -> Regex reg = new Regex("{{[09].+}}");
				strFilename = strFilename.Replace("Month_consumption_", string.Empty);
				string strPlatNr = strFilename.Substring(0, 3);
				if(!string.IsNullOrEmpty(strPlatNr))
				{
					ParseCSV(strPath, strPlatNr);
				}
			}
		}
		#endregion

		#region Privates
		private void ParseCSV(string strPath, string strPlatNr)
		{
			byte[] byFile = File.ReadAllBytes(strPath);
			if(byFile == null) return;

			List<List<string>> records = CSVFileReader.ReadFile(byFile);
			if(records.Count == 0) return;

			Dictionary<string, Reading> dictDateReading;
			if(!this.CSV_Info.TryGetValue(strPlatNr, out dictDateReading))
			{
				dictDateReading = new Dictionary<string, Reading>();
				this.CSV_Info.Add(strPlatNr, dictDateReading);
			}

			List<Tuple<int, string>> positions = new List<Tuple<int, string>>();

			List<string> headers = records.First();
			for(int i = 0; i < headers.Count; i++)
			{
				string strHeader = headers[i].Replace(" ", string.Empty);
				if(_headers.Contains(strHeader))
				{
					positions.Add(new Tuple<int, string>(i, strHeader));
				}
			}

			for(int i = 1; i < records.Count; i++)
			{
				List<string> record = records[i];

				string strDate = record[0];

				// If record's first cell(date) is empty
				if(string.IsNullOrEmpty(strDate)) break;

				strDate = strDate.ToLower();

				Reading reading;
				if(!dictDateReading.TryGetValue(strDate, out reading))
				{
					reading = new Reading();
					dictDateReading.Add(strDate, reading);
				}

				foreach(Tuple<int, string> item in positions)
				{
					decimal? dVal;
					switch(item.Item2)
					{
						case DATE:
							reading.Date = Convert.ToDateTime(record[item.Item1]);
							break;
						case B1_TANK:
							reading.Bath1 = Convert.ToDecimal(record[item.Item1]);
							break;
						case B2_TANK:
							reading.Bath2 = Convert.ToDecimal(record[item.Item1]);
							break;
						case B3_TANK:
							reading.Bath3 = Convert.ToDecimal(record[item.Item1]);
							break;
						case B4_TANK:
							reading.Bath4 = Convert.ToDecimal(record[item.Item1]);
							break;
						case B5_TANK:
							reading.Bath5 = Convert.ToDecimal(record[item.Item1]);
							break;
						case KIT_TANK:
							reading.Kitchen = Convert.ToDecimal(record[item.Item1]);
							break;
						case RO1_RO:
							reading.RO1 = Convert.ToDecimal(record[item.Item1]);
							break;
						case RO2_RO:
							reading.RO2 = Convert.ToDecimal(record[item.Item1]);
							break;
						case T1_TANK:
							dVal = Convert.ToDecimal(record[item.Item1]);
							reading.Tank1 = (reading.Tank1 ?? 0) + (dVal ?? 0);
							break;
						case T2_TANK:
							dVal = Convert.ToDecimal(record[item.Item1]);
							reading.Tank2 = (reading.Tank2 ?? 0) + (dVal ?? 0);
							break;
						case G1_TANK:
							dVal = Convert.ToDecimal(record[item.Item1]);
							reading.Garden1 = (reading.Garden1 ?? 0) + (dVal ?? 0);
							break;
						case G2_TANK:
							dVal = Convert.ToDecimal(record[item.Item1]);
							reading.Garden2 = (reading.Garden2 ?? 0) + (dVal ?? 0);
							break;
					}
				}
			}
		}
		#endregion
	}
}