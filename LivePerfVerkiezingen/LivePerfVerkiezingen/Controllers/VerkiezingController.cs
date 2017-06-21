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
        static ToepassenLogic toepassenlogic = new ToepassenLogic(new ToepassenDalSQL());
        // GET: Verkiezing
        public ActionResult Index()
        {
            List<Verkiezing> verkiezingen = overzichtlogic.geefAlleVerkiezingen();
            return View(verkiezingen);
        }
        public ActionResult Partijen()
        {
            List<Partij> partijen = overzichtlogic.geefAllePartijen();
            return View(partijen);
        }
        [HttpGet]
        public ActionResult PartijAanpassen(int id)
        {
            List<Partij> partijen = overzichtlogic.geefAllePartijen();
            Partij partij = null;
            foreach(Partij p in partijen)
            {
                if  (p.Id == id)
                {
                    partij = p;
                    break;
                }
            }
            return View(partij);
        }
        [HttpPost]
        public ActionResult PartijAanpassen(Partij partij)
        {
            bool b = toepassenlogic.PasPartijAan(partij);
            if (b == true)
            {
                return RedirectToAction("Partijen");
            }
            else
            {
                TempData["paanpassen"] = "error";
                return RedirectToAction("PartijAanpassen",new { id = partij.Id});
            }
        }
        [HttpGet]
        public ActionResult NieuwePartij()
        {
            Partij p = new Partij();
            return View(p);
        }
        [HttpPost]
        public ActionResult NieuwePartij(Partij partij)
        {
            bool b = toepassenlogic.VoegPartijToe(partij);
            if (b == true)
            {
                return RedirectToAction("Partijen");
            }
            else
            {
                TempData["errornieuwepartij"] = "error";
                return RedirectToAction("NieuwePartij");
            }
        }
        public ActionResult UitslagenVerkiezing(int id)
        {
            List<Uitslag> uitslagen = overzichtlogic.UitslagenVan(id);
            return View(uitslagen);
        }
    }
}