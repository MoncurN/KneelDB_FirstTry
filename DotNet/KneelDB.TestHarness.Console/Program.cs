using KneelDB.Core;
using KneelDB.Core.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.TestHarness.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var blah = new
            {
                Name = "Kaladin",
                Order = "Windrunners",
                DateAdded = DateTime.Now, 
                CanFly = true, 
                Deep = new
                {
                    Depth = 7, 
                    Contents = "Nothing"
                }
            };

            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "Name", "Jasnah" },
                { "Order", "Elsecallers" },
                { "DateAdded", DateTime.Now.ToString() }
            };

            Config.QueryOptionNewColumns = QueryOptionNewColumns.Add;
            var id = Processor.Insert(dictionary);
            //var id2 = Processor.Insert(blah);

            //var records = Processor.Select();
        }
    }
}
