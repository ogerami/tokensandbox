using System;
using System.Collections.Generic;
using System.Linq;

namespace TokenSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = "1[1[cma]],2[1[cma],2[100,200],3[xxx,xxx]],3,4";

            var split = token.Split(',');

            var tokenlist = new List<string>();
            var stringitem = "";

            foreach (var s in split)
            {
                if (s.Length > 1)
                {
                    stringitem += s;
                    if (!s.EndsWith("]]"))
                    {
                        stringitem += ",";
                        continue;
                    };
                    tokenlist.Add(stringitem);
                    stringitem = "";
                }
                else
                {
                    tokenlist.Add(s);
                }
            }
            
            var transformedToken = string.Join("|", tokenlist.Select(s => s.Replace("],", "]^")));

            Console.WriteLine(transformedToken);

            var tokenEqual = "1[1[cma]]|2[1[cma]^2[100,200]^3[xxx,xxx]]|3|4";

            Console.WriteLine(transformedToken == tokenEqual);

            
            Console.Read();
        }
    }
}
