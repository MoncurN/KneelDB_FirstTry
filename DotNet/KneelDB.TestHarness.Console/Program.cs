using KneelDB.Core;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Dynamic;
using System.Linq;

namespace KneelDB.TestHarness.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var test = new List<ExpandoObject>();
            dynamic o1 = new ExpandoObject();
            o1.Id = 1;
            o1.Name = "First Test Object";
            o1.Wealth = 1000000;

            dynamic o2 = new ExpandoObject();
            o2.Id = 2;
            o2.Name = "The Second Test Object";
            o2.Height = 6.1;

            dynamic o3 = new ExpandoObject();
            o3.Id = 3;
            o3.Name = "Third";
            o3.Wealth = "Wisdom";

            test.Add(o1);
            test.Add(o2);
            test.Add(o3);

            var blah = test.FirstOrDefault(t => {
                t.
            });


            Query query = new Query();

            var blah = new {  
                foo = "bar", 
                now = System.DateTime.Now, 
                cash = 25.4M, 
                age = 42
             };

            query.Insert(blah);

            // var result = query.Select<TheType>();

            // var changed = new {
            //     Id = 3, 
            //     foo = "Now I'm something else"
            // };

            // query.Update<dynamic>(changed);

            var i = 1;
        }
    }

    public class TheType
    {
        public string foo { get; set; }
        public DateTime now { get; set; }
    }
}
