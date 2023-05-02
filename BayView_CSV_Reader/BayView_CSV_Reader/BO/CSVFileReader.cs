using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BayView_CSV_Reader
{
    public class CSVFileReader
    {
        public static List<List<string>> ReadFile(byte[] byContent)
        {
            List<List<string>> fileContent = new List<List<string>>();

            using (var reader = new StreamReader(new MemoryStream(byContent)))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    fileContent.Add(values.ToList());
                }
            }
            return fileContent;
        }        
    }
}
