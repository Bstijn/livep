using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modellen;

namespace Dal
{
    public class ToepassenDalLocal : IToepassenDal
    {
        public Partij geefPartij(string naam, int id)
        {
           return new Partij() { Stemmen = 150 };
        }

        public FileStyleUriParser maakExport(Uitslag uitslag)
        {
            throw new NotImplementedException();
        }

        public void NieuweUitslag(Uitslag uitslag)
        {
            Console.Write("");
        }

        public bool PasPartijAan(Partij partij)
        {
            throw new NotImplementedException();
        }

        public void SlaCoalitieOp(Coalitie coalitie)
        {
            throw new NotImplementedException();
        }

        public bool UitslagAanpassen(int Uitslag_id, Uitslag aangepasteUitslag)
        {
            throw new NotImplementedException();
        }

        public bool VerkiezingVoegPartijToe(Verkiezing verkiezing, Partij partij)
        {
            throw new NotImplementedException();
        }

        public void verwijderPartij(Partij partij)
        {
            throw new NotImplementedException();
        }

        public bool VoegPartijToe(Partij partij)
        {
            throw new NotImplementedException();
        }
    }
}
