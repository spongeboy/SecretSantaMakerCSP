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
            //r = s.MakeNextDraw(BaileyTestData.GetFamilies(), BaileyTestData.GetPreviousDraws());

            var families = BaileyTestData.GetFamilies();
            //var previousDraws = BaileyTestData.GetPreviousDraws();
            var previousDraws = BaileyTestData.GetPreviousHandmadeDraws();

            //var families = MaleBuffoonCartoonTestData.GetFamilies();
            //var previousDraws = MaleBuffoonCartoonTestData.GetPreviousDraws();

            int max = 10;
            for (int i = 0; i < max; i++)
            {
                r = s.MakeNextDraw(families, previousDraws);
                if (r != null)
                {
                    Console.WriteLine(FormatDraw.GetShortDescription(r));
                } else
                {
                    Console.WriteLine("No draw found.");
                    break;
                }

                previousDraws.Add(r);

            }

        }



    }
}
