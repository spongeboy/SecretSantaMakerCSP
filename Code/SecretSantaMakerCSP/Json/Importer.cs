using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecretSantaMakerCSP.DomainObjects;
using System.IO;
using Newtonsoft.Json;

namespace SecretSantaMakerCSP.Json
{
    public class PersonImporter
    {
        public List<Person> Import(string json)
        {
            return JsonConvert.DeserializeObject<List<Person>>(json);
        }

        public List<Person> ImportFromFile(string path)
        {
            using (StreamReader file = File.OpenText(path))
            {
                return Import(file.ReadToEnd());
            }
        }
    }

    public class SecretSantaDrawImporter
    {
        public List<SecretSantaDraw> Import(string json)
        {
            return JsonConvert.DeserializeObject<List<SecretSantaDraw>>(json);
        }

        public List<SecretSantaDraw> ImportFromFile(string path)
        {
            using (StreamReader file = File.OpenText(path))
            {
                return Import(file.ReadToEnd());
            }
        }
    }
}
