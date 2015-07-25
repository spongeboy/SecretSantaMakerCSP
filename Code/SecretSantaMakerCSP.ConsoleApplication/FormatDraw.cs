using SecretSantaMakerCSP.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaMakerCSP.ConsoleApplication
{
    public static class FormatDraw
    {
        public static string GetShortDescription(SecretSantaDraw s)
        {
            var firstPerson = s.Draw.First();
            return string.Format("{0}, {1} buys for {2}\n", s.Title, firstPerson.Key, firstPerson.Value);

        }

        public static string GetFullDescription(SecretSantaDraw s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string person in s.Draw.Keys)
            {
                sb.AppendFormat("{0} buys for {1}", person, s.Draw[person]);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static string GetChain(SecretSantaDraw s)
        {
            StringBuilder sb = new StringBuilder();

            string seedPerson = s.Draw.First().Key;

            string giftGiver = seedPerson;
            string recipient = s.Draw[giftGiver];



            //Print out chain, relies on "Make circuit" constraint
            while (true)
            {
                sb.AppendFormat("{0} buys for {1}", giftGiver, recipient);
                sb.AppendLine();

                giftGiver = recipient;
                recipient = s.Draw[giftGiver];

                if (giftGiver == seedPerson)
                    break;
            }

            return sb.ToString();
        }

        public static string GetCSharpDataFormat(SecretSantaDraw s)
        {
            StringBuilder sb = new StringBuilder();

            string seedPerson = s.Draw.First().Key;

            string giftGiver = seedPerson;
            string recipient = s.Draw[giftGiver];



            //Print out chain, relies on "Make circuit" constraint
            while (true)
            {
                sb.AppendFormat("{{\"{0}\",\"{1}\"}},", giftGiver, recipient);
                sb.AppendLine();

                giftGiver = recipient;
                recipient = s.Draw[giftGiver];

                if (giftGiver == seedPerson)
                    break;
            }

            return sb.ToString();
        }

    }
}
