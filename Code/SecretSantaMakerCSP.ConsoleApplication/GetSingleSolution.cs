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
    public static class SingleSolution
    {
        public static void Get()
        {

            var s = new SecretSantaMakerCSP.DrawMaker();

            SecretSantaDraw r;
            //r = s.MakeNextDraw(BaileyTestData.GetFamilies(), BaileyTestData.GetPreviousDraws());
            r = s.MakeNextDraw(MaleBuffoonCartoonTestData.GetFamilies(), MaleBuffoonCartoonTestData.GetPreviousDraws());

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
