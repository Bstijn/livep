using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modellen
{
    public class Meerderheid
    {
        public int Aantalstemmen { get; set; }
        public bool EchtMeerderheid { get; set; }
        public List<Partij> Partijen { get; set; } = new List<Partij>();
        public Coalitie coalitie { get; set; } = new Coalitie();
        
        public void Berekenmeerderheid(int aantalstemmen)
        {
            int aantalstemmenpartij = 0;
            foreach(Partij p in Partijen)
            {
                aantalstemmenpartij += p.Stemmen;
            }
            if(aantalstemmenpartij > (aantalstemmen/2))
            {
                EchtMeerderheid = true;
            }
            else
            {
                EchtMeerderheid = false;
            }
        }
    }
}
