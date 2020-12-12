using KneelDB.Core;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KneelDB.TestHarness.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var od = new Dictionary<string, object>();
            od.Add("First", 1);
            od.Add("Second", 3.333);
            od.Add("Third", DateTime.Now);
            od.Add("Fourth", new
            {
                Id = 4,
                Name = "Kirk"
            });

            var json = JsonConvert.SerializeObject(od);
            dynamic o = JObject.Parse(json);
            var k = 1;

            dynamic d1 = new
            {
                Id = 1,
                Name = "Bill",
                Something = 42
            };

            dynamic d2 = new
            {
                Id = 2,
                Name = "Sue",
                Something = DateTime.Now
            };

            dynamic d3 = new
            {
                Id = 3,
                Name = "Bad",
                SomethingElse = 3.33333
            };

            var dl = new List<dynamic>();
            dl.Add(d1);
            dl.Add(d2);

            var d = dl.Where(d => d.Id == 2).ToList();
            var b = d;

            dynamic e1 = new ExpandoObject();
            e1.Id = 1;
            e1.Name = "Bill";
            e1.Something = 42;

            dynamic e2 = new ExpandoObject();
            e2.Id = 2;
            e2.Name = "Sue";
            e2.Something = DateTime.Now;

            var el = new List<ExpandoObject>();
            el.Add(e1);
            el.Add(e2);

            
            //var e = el.FirstOrDefault(e => e.FirstOrDefault(kv => kv.Key == "Id" && (int)kv.Value == 1).Value != null);
            //var a = e;

            //var e = el.FirstOrDefault(e => e.FirstOrDefault(kv => kv.Key == "Id" && (int)kv.Value.GetType().GetProperty("Id").GetValue(kv) == 2).Value != null);
            
            //foreach (var e in el)
            //{
            //    var a = e;
            //    e.FirstOrDefault(kv => kv.Key == "Id" && (int)kv.Value.GetType().GetProperty("Id").GetValue(kv) == 2);
            //    var j = 1;
            //}


            Query query = new Query();

            var blah = new {  
                foo = "bar", 
                now = System.DateTime.Now, 
                cash = 25.4M, 
                age = 42
             };

            // query.Insert(blah);

            var result = query.Select<dynamic>();

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
