using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CMS.Models.DTO;

namespace CMS.Client.DataServices
{
    public class WaveSimulatorDataService:IDataService
    {
        private IEnumerable<WaveValue> DataQueue;
        public dynamic GenTestData()
        {
            return GetValues("Waveform.txt");
        }

        private IEnumerable<WaveValue> GetValues(string filename)
        {
            var values = new List<decimal>();
            var asm = Assembly.GetExecutingAssembly();
            var resourceString = asm.GetManifestResourceNames().Single(x => x.Contains(filename));
            using (var stream = asm.GetManifestResourceStream(resourceString))
            using (var streamReader = new StreamReader(stream))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    values.Add(decimal.Parse(line, NumberFormatInfo.InvariantInfo));
                    line = streamReader.ReadLine();
                }
            }
            while (true)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    yield return new WaveValue()
                    {
                        ReceiveTime = DateTime.Now,
                        Value = values[i]
                    };
                    if (i == values.Count - 1)
                    {
                        i = 0;
                    }
                }
            }
        }
    }
}
