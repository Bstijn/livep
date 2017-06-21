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
        public List<Verkiezing> geefAlleVerkiezingen()
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
    }
}
