using KneelDB;
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

            query.Insert<dynamic>(blah);
        }
    }
}
