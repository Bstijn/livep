using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modellen;

namespace Dal
{
    public interface IToepassenDal
    {
        Boolean VoegPartijToe(Partij partij);
        Boolean VerkiezingVoegPartijToe(Verkiezing verkiezing, Partij partij);
        void NieuweUitslag(Uitslag uitslag);
        void SlaCoalitieOp(Coalitie coalitie);
        Boolean UitslagAanpassen(int Uitslag_id, Uitslag aangepasteUitslag);
        void verwijderPartij(Partij partij);
        FileStyleUriParser maakExport(Uitslag uitslag);
        bool PasPartijAan(Partij partij);
        Partij geefPartij(string naam,int id);
    }
}
