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
    }
}
