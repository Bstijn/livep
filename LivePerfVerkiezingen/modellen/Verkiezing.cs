using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modellen
{
    public class Verkiezing
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<Partij> Partijen { get; set; } = new List<Partij>();
        public List<Uitslag> Uitslagen { get; set; } = new List<Uitslag>();
        public int totZetels { get; set; }

    }
}
