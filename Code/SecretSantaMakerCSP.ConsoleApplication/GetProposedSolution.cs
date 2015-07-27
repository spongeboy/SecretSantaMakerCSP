using SecretSantaMakerCSP.Data;
using SecretSantaMakerCSP.DomainObjects;
using SecretSantaMakerCSP.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaMakerCSP.ConsoleApplication
{
    public static class ProposedSolution
    {
        public static void Get()
        {

            SecretSantaDraw r;
            //r = new SecretSantaDraw("Proposed 2015", BaileyTestData.cd2015);
            r = new SecretSantaDraw("Test", new Dictionary<string, string>());

            if (r != null)
            {
                Console.WriteLine(r.Title);

                Console.WriteLine(FormatDraw.GetFullDescription(r));

                Console.WriteLine("======================");

                Console.WriteLine(FormatDraw.GetChain(r));

                Console.WriteLine("======================");

                Console.WriteLine(FormatDraw.GetCSharpDataFormat(r));

                Console.WriteLine("======================");

                Console.WriteLine(FormatDraw.GetRevealJsFormat(r));

            }
            else
            {
                Console.WriteLine("No draw found.");
            }


        }
    }
}
