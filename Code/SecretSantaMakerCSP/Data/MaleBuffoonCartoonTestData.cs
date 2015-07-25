using SecretSantaMakerCSP.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaMakerCSP.Data
{
    public static class MaleBuffoonCartoonTestData
    {
        public static List<Person> GetFamilies()
        {

            var result = new List<Person>();

            result.Add(new Person("Homer", "Simpsons", "742_Evergreen_Terrace"));
            result.Add(new Person("Marge", "Simpsons", "742_Evergreen_Terrace"));
            result.Add(new Person("Bart", "Simpsons", "742_Evergreen_Terrace", true));
            result.Add(new Person("Lisa", "Simpsons", "742_Evergreen_Terrace", true));
            result.Add(new Person("Maggie", "Simpsons", "742_Evergreen_Terrace", true));

            result.Add(new Person("Ned", "Simpsons", "744_Evergreen_Terrace"));
            result.Add(new Person("Rod", "Simpsons", "742_Evergreen_Terrace", true));
            result.Add(new Person("Todd", "Simpsons", "742_Evergreen_Terrace", true));

            result.Add(new Person("Peter", "Family_Guy", "31_Spooner_St"));
            result.Add(new Person("Lois", "Family_Guy", "31_Spooner_St"));
            result.Add(new Person("Meg", "Family_Guy", "31_Spooner_St", true));
            result.Add(new Person("Stewie", "Family_Guy", "31_Spooner_St", true));
            result.Add(new Person("Brian", "Family_Guy", "31_Spooner_St"));

            result.Add(new Person("Fred", "Flintsones", "301_Cobblestone_Way"));
            result.Add(new Person("Wilma", "Flintsones", "301_Cobblestone_Way"));
            result.Add(new Person("Pebbles", "Flintsones", "301_Cobblestone_Way", true));

            result.Add(new Person("Barney", "Flintsones", "303_Cobblestone_Way"));
            result.Add(new Person("Betty", "Flintsones", "303_Cobblestone_Way"));
            result.Add(new Person("Bam-Bam", "Flintsones", "303_Cobblestone_Way", true));

            return result;
        }

        public static List<SecretSantaDraw> GetPreviousDraws()
        {
            return new List<SecretSantaDraw>();
        }
    }
}
