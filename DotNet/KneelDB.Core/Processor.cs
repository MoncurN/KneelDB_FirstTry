using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.Core
{
    public class Processor
    {
        

        public static int Insert(Dictionary<string, string> values, string into = null)
        {
            var id = InsertProcessor.Insert(values, into);

            return id;
        }

        public static int Insert(dynamic record, string into = null)
        {

            var id = InsertProcessor.Insert(record, into);
            
            return id;
        }
    }
}
