using KneelDB.Core;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace KneelDB.TestHarness.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Query query = new Query();

            var blah = new { 
                foo = "bar", 
                now = System.DateTime.Now, 
                cash = 25.4M, 
                age = 42
             };

            // query.Insert<dynamic>(blah);

            var result = query.Select<TheType>();

            var changed = new {
                Id = 3, 
                foo = "Now I'm something else"
            };

            query.Update<dynamic>(changed);

            var i = 1;
        }
    }

    public class TheType
    {
        public string foo { get; set; }
        public DateTime now { get; set; }
    }
}
