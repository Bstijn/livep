using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modellen;
using Dal;
using System.IO;

namespace Logic
{
    public class ToepassenLogic
    {
        private IToepassenDal dal;
        public ToepassenLogic(IToepassenDal dal)
        {
            this.dal = dal;
        }

        public bool VoegPartijToe(Partij partij)
        {
            return dal.VoegPartijToe(partij);
        }

        public bool PasPartijAan(Partij partij)
        {
            return dal.PasPartijAan(partij); 
        }
        public void NieuweUitslag(Uitslag uitslag)
        {
            foreach(Partij p in uitslag.verkiezing.Partijen)
            {
                double pstemmen = p.Stemmen;
                double totstemmen = uitslag.TotaalStemmen;
                double percentage = pstemmen / totstemmen;
                double zetelspartij = percentage * uitslag.verkiezing.totZetels;
                p.Zetels = Convert.ToInt32(zetelspartij);
            }
            dal.NieuweUitslag(uitslag);
        }

        public Uitslag Kijkmeerderheid(Uitslag uitslag)
        {
            int totaalstemmen = 0;
            List<Partij> partijen = new List<Partij>();
            foreach(Partij p in uitslag.meerderheid.Partijen)
            {
                partijen.Add(dal.geefPartij(p.Naam, uitslag.Id));
                
            }
            uitslag.meerderheid.Partijen = partijen;
            return uitslag;
          
        }
        public FileStream MaakExport(Uitslag uitslag)
        {
            throw new NotImplementedException();
        }
        public void VerwijderPartij(Partij partij)
        {
            throw new NotImplementedException();
        }
        public void UitslagAanpassen(int uitslag_id, Uitslag aangapsteUitslag)
        {
            throw new NotImplementedException();
        }
        public Boolean VerkiezingVoegPartijToe(Verkiezing verkiezing,Partij partij)
        {
            throw new NotImplementedException();
        }
    }
}
