using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modellen;


namespace Dal
{
    public interface IOverzichtDal
    {
        List<Verkiezing> geefAlleVerkiezingen();
        List<Uitslag> UitslagenVan(Verkiezing verkiezing);
        Uitslag UitslagDetails(string naam);
        List<Partij> geefAllePartijen();
        List<Partij> Partijenvan(Verkiezing verkiezing);
    }
}
