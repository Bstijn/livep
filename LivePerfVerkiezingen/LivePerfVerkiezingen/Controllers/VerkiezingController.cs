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
        //weergeeft alle verkiezingen
        public ActionResult Index()
        {
            List<Verkiezing> verkiezingen = overzichtlogic.geefAlleVerkiezingen();
            return View(verkiezingen);
        }
        //weergeeft alle partijen
        public ActionResult Partijen()
        {
            List<Partij> partijen = overzichtlogic.geefAllePartijen();
            return View(partijen);
        }
        //laat velden zien die je kan aanpassen van een partij
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
        //past een partij aan
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
        //laat velden zien die je moet invullen om een nieuwe partij te maken
        [HttpGet]
        public ActionResult NieuwePartij()
        {
            Partij p = new Partij();
            return View(p);
        }
        //voert de actie uit nieuwe partij maken
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
        //laat alle uitslagen zien van één verkiezing
        public ActionResult UitslagenVerkiezing(int id, int zetels)
        {
            List<Uitslag> uitslagen = overzichtlogic.UitslagenVan(id);
            foreach(Uitslag u in uitslagen)
            {
                u.verkiezing.totZetels = zetels;
            }
            return View(uitslagen);
        }
    }
}