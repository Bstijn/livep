using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modellen;
using Dal;

namespace Logic.Tests
{
    [TestClass()]
    public class ToepassenLogicTests
    {
        [TestMethod()]
        public void NieuweUitslagTest()
        {
            //assemble
            ToepassenLogic logic = new ToepassenLogic(new ToepassenDalLocal());
            Uitslag uitslag = new Uitslag();
            uitslag.verkiezing.totZetels = 200;
            uitslag.TotaalStemmen = 1000;
            Partij[] partijen =
            {
                new Partij(),
                new Partij(),
                new Partij(),
                new Partij()

            };
            uitslag.meerderheid.Partijen = partijen.ToList<Partij>();
            //act
            Uitslag u = logic.Kijkmeerderheid(uitslag);
            u.meerderheid.Berekenmeerderheid(uitslag.TotaalStemmen);
            //assert
            Assert.AreEqual(u.meerderheid.EchtMeerderheid, true);
                
            
            
        }
    }
}