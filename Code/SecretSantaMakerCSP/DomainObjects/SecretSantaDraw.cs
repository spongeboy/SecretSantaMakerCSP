using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaMakerCSP.DomainObjects
{
    public class SecretSantaDraw
    {
        public readonly string Title;
        public readonly Dictionary<string, string> Draw;

        public SecretSantaDraw(string title, Dictionary<string, string> draw)
        {
            this.Title = title;
            this.Draw = draw;
        }

    }
}
