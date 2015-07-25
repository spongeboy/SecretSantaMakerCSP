using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaMakerCSP.DomainObjects
{
    public class Person
    {
        public readonly string Name;
        public readonly Dictionary<string, string> Tags;

        public Person(string name, string familyGroup, string immediateFamily, bool isChild = false)
        {
            this.Name = name;
            this.Tags = new Dictionary<string, string>();
            this.Tags["FamilyGroup"] = familyGroup;
            this.Tags["ImmediateFamily"] = immediateFamily;
            this.Tags["IsChild"] = isChild.ToString();
        }

    }
}
