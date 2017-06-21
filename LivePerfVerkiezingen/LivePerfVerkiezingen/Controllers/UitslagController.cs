using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using modellen;
using Dal;

namespace LivePerfVerkiezingen.Controllers
{
    public class UitslagController : Controller
    {
        static OverzichtLogic overzichtlogic = new OverzichtLogic(new OverzichtDalSQL());
        static ToepassenLogic toepassenlogic = new ToepassenLogic(new ToepassenDalSQL());
        [HttpGet]
        public ActionResult NieuweUitslag(Verkiezing verkiezing)
        {
            Uitslag uitslag = new Uitslag();
            uitslag.verkiezing = verkiezing;
            uitslag.verkiezing.Partijen = overzichtlogic.Partijvan(verkiezing);
            return View(uitslag);
        }
        [HttpPost]
        public ActionResult NieuweUitslag(Uitslag uitslag)
        {
            toepassenlogic.NieuweUitslag(uitslag);
            return RedirectToAction("UitslagenVerkiezing","Verkiezing",new { id = uitslag.verkiezing.Id });
        }
    }
}