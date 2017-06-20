using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modellen
{
    public class Partij
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Lijsttrekker { get; set; }
        public int Stemmen { get; set; }
    }
}
