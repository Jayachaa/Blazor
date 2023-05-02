using System;

namespace BayView_CSV_Reader
{
	public class Reading : ICloneable
	{
		#region Properties
		public Guid ReadingId { get; set; }
		public int FlatNr { get; set; }
		public DateTime Date { get; set; }
		public decimal? Bath1 { get; set; }
		public decimal? Bath2 { get; set; }
		public decimal? Bath3 { get; set; }
		public decimal? Bath4 { get; set; }
		public decimal? Bath5 { get; set; }
		public decimal? Kitchen { get; set; } // add to bath - all are normal now
		public decimal? RO1 { get; set; } // add to bath - all are normal now
		public decimal? RO2 { get; set; } // add to bath - all are normal now
		public decimal? Tank1 { get; set; }
		public decimal? Tank2 { get; set; }
		public decimal? Garden1 { get; set; }
		public decimal? Garden2 { get; set; }
		public decimal? GasReading { get; set; }
		public decimal? Maintenance { get; set; }
		#endregion

		#region Publics
		public object Clone()
		{
			return MemberwiseClone();
		}
		#endregion
	}
}