using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modellen;
using Dal;

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
            dal.NieuweUitslag(uitslag);
        }
    }
}
