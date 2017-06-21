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
        //weergeeft alle velden die je moet invullen voor een uitslag te maken
        [HttpGet]
        public ActionResult NieuweUitslag(Verkiezing verkiezing)
        {
            Uitslag uitslag = new Uitslag();
            uitslag.verkiezing = verkiezing;
            uitslag.verkiezing.Partijen = overzichtlogic.Partijvan(verkiezing);
            return View(uitslag);
        }
        //voert de actie uit om een nieuwe uitslag te maken
        [HttpPost]
        public ActionResult NieuweUitslag(Uitslag uitslag)
        {
            bool b = true;
            foreach(Partij p in uitslag.verkiezing.Partijen)
            {
                if(p.Stemmen <= 0)
                {
                    b = false;
                }
            }
            if (uitslag.Naam != null && uitslag.TotaalStemmen != 0 && uitslag.Datum  != null && uitslag.Datum != DateTime.MinValue && b == true)
            {
                toepassenlogic.NieuweUitslag(uitslag);
                return RedirectToAction("Index","Verkiezing",new { id = uitslag.verkiezing.Id });
            }
            else
            {
                TempData["nieuwe uitslag error"] = "error";
                return RedirectToAction("NieuweUitslag",uitslag.verkiezing);
            }
        }
        //weergeft één uitslag
        [HttpGet]
        public ActionResult Uitslagvanverkiezing(string naam, int stemmen,DateTime datum,int zetels,int id)
        {
            Uitslag uitslag = new Uitslag() { Naam = naam, TotaalStemmen =stemmen,Datum = datum,Id = id};
            uitslag.verkiezing.totZetels = zetels;
            uitslag.verkiezing.Partijen = overzichtlogic.uitslagpartijen(uitslag.Naam);
            return View(uitslag);
        }
        //post voor het kijken of er een mogelijkheid mogelijk is.
        [HttpPost]
        public ActionResult Uitslagvanverkiezing(Uitslag uitslag)
        {
            uitslag = toepassenlogic.Kijkmeerderheid(uitslag);
            int totzelets = 0;
            foreach(Partij p in uitslag.meerderheid.Partijen)
            {
                totzelets += p.Zetels;
            }
            uitslag.meerderheid.Aantalstemmen = totzelets;
            if (totzelets > uitslag.verkiezing.totZetels)
            {
                TempData["meerderheid"] = "";
            }
            else
            {
                
            }
            Session["uitslag"] = uitslag;
            return RedirectToAction("KanMeerderheid", uitslag);
        }
        //gaat naar de pagina waar je informatie krijgt over de mogelijkheid van een meerderheid.
        public ActionResult KanMeerderheid(Uitslag uitslag)
        {
            uitslag = (Session["uitslag"] as Uitslag);
            return View(uitslag);
        }
    }
}