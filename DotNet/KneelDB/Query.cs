using System;
using System.Collections.Generic;
using System.Text.Json;

namespace KneelDB
{
    public class Query {

        public int Insert(Dictionary<string, string> values) 
        {
            Storage storage = new Storage();

            var table = storage.Read();

            

            throw new NotImplementedException();
        }

    }
}