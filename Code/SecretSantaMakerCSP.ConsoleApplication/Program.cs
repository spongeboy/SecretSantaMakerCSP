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
    class Program
    {
        static void Main(string[] args)
        {

            var s = new SecretSantaMakerCSP.DrawMaker();

            SecretSantaDraw r;
            r = s.MakeNextDraw(BaileyTestData.GetFamilies(), BaileyTestData.GetPreviousDraws());
            r = s.MakeNextDraw(MaleBuffoonCartoonTestData.GetFamilies(), MaleBuffoonCartoonTestData.GetPreviousDraws());

            if (r != null)
            {
                Console.WriteLine(r.Title);
            }
            else
            {
                Console.WriteLine("No draw found.");
            }

            Console.ReadKey();


        }
    }
}
