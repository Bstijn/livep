using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modellen
{
    public class Uitslag
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime Datum { get; set; }
        public int TotaalStemmen { get; set; }
        public List<Zetel> Zetels { get; set; } = new List<Zetel>();
        public Meerderheid meerderheid { get; set; } = new Meerderheid();

    }
}
