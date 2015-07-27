using SecretSantaMakerCSP.Data;
using SecretSantaMakerCSP.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaMakerCSP.ConsoleApplication
{
    public static class IterateSolutions
    {
        public static void Get()
        {

            var s = new SecretSantaMakerCSP.DrawMaker();

            SecretSantaDraw r;

            //var families = BaileyTestData.GetFamilies();
            //var previousDraws = BaileyTestData.GetPreviousDraws();
            //var previousDraws = BaileyTestData.GetPreviousHandmadeDraws();

            var families = MaleBuffoonCartoonTestData.GetFamilies();
            var previousDraws = MaleBuffoonCartoonTestData.GetPreviousDraws();

            int max = 10;
            for (int i = 0; i < max; i++)
            {
                r = s.MakeNextDraw(families, previousDraws);
                if (r != null)
                {
                    Console.WriteLine("======================================");
                    Console.WriteLine(string.Format("Solution number:{0}", i + 1));
                    Console.WriteLine("======================================");

                    Console.WriteLine(FormatDraw.GetChain(r));

                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("======================================");
                    Console.WriteLine("No draw found.");
                    Console.WriteLine("======================================");
                    break;
                }

                previousDraws.Add(r);

            }

        }



    }
}
