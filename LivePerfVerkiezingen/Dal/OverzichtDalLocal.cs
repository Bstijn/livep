using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modellen;

namespace Dal
{
    public class OverzichtDalLocal : IOverzichtDal
    {
        public List<Partij> geefAllePartijen()
        {
            throw new NotImplementedException();
        }

        public List<Verkiezing> geefAlleVerkiezingen()
        {
            throw new NotImplementedException();
        }

        public List<Partij> Partijenvan(Verkiezing verkiezing)
        {
            throw new NotImplementedException();
        }

        public Uitslag UitslagDetails(string naam)
        {
            throw new NotImplementedException();
        }

        public List<Uitslag> UitslagenVan(Verkiezing verkiezing)
        {
            throw new NotImplementedException();
        }

        public List<Partij> UitslagPartijen(string naam)
        {
            throw new NotImplementedException();
        }
    }
}
