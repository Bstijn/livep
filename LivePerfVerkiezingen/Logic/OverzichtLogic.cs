using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modellen;
using Dal;

namespace Logic
{
    public class OverzichtLogic
    {
        private IOverzichtDal overzichtdal;
        public OverzichtLogic(IOverzichtDal overzichtdal)
        {
            this.overzichtdal = overzichtdal;
        }

        public List<Verkiezing> geefAlleVerkiezingen()
        {
            return overzichtdal.geefAlleVerkiezingen();
        }
        public List<Partij> geefAllePartijen()
        {
            return overzichtdal.geefAllePartijen();
        }

        public List<Partij> Partijvan(Verkiezing verkiezing)
        {
           return overzichtdal.Partijenvan(verkiezing);
           
        }

        public List<Uitslag> UitslagenVan(int id)
        {
            List<Uitslag> uitslagen = overzichtdal.UitslagenVan(new Verkiezing() { Id = id });
            foreach(Uitslag u in uitslagen)
            {
                u.verkiezing.Id = id;
            }
            return uitslagen;
        }
    }
}
