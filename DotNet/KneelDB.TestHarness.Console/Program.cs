using KneelDB.Core;
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
                Id = 1,
                Name = "Kaladin",
                Order = "Wind Runners",
                DateAdded = DateTime.Now
            };

            Dictionary<string,string> thing = new Dictionary<string, string>();
            thing.Add("Id", "1");
            thing.Add("Name", "Kaladin");
            thing.Add("Order", "Wind Runners");
            thing.Add("DateAdded", DateTime.Now.ToString());

            var processor = new Processor();

            processor.Insert(thing);
        }
    }
}
