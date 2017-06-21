using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using Dal;
using modellen;

namespace LivePerfVerkiezingen.Controllers
{
    public class VerkiezingController : Controller
    {
        static OverzichtLogic overzichtlogic = new OverzichtLogic(new OverzichtDalSQL());
        // GET: Verkiezing
        public ActionResult Index()
        {
            List<Verkiezing> verkiezingen = overzichtlogic.geefAlleVerkiezingen();
            return View(verkiezingen);
        }
    }
}