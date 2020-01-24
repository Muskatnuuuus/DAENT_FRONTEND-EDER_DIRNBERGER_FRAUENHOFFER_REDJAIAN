using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAENT_FRONTEND.Models;

namespace DAENT_FRONTEND.Controllers
{
    public class WhereController : Controller
    {
       Model1 db = new Model1();

        public ActionResult Index()
        {
            return View(); // erzeugt die Ansicht um die Where-Funktion aufzurufen
        }

        public ActionResult Where([Bind(Include = "")] artikelgruppen artikelgruppen)
        {
            /* // sucht alle Datensätze mit dem Verkaufspreis größer 50 und kleiner 250 und dessen Bezeichnung mit 'E' anfängt
             var artikel = from a in db.artikel
                           where a.vkpreis > 50 && a.vkpreis < 250 && a.bezeichnung.StartsWith("E")
                           orderby a.bezeichnung ascending
                           select a;
                           */
            // Liste mit dem Resultat zurückgeben
            //  return View(artikel.ToList());

            /*
            return View(db.artikel.Where(x => x.bezeichnung.Contains(search)
                                              || x.artikelgruppen.grtext.Contains(searching)
                                              || x.aktiv.ToString().Contains(searching)
                                              || x.aktiv.ToString().Contains(searching)
                                              || x.lieferanten.firma1.Contains(searching)
                                              || x.vkpreis.ToString().Contains(searching)
                                              || x.ekpreis.ToString().Contains(searching)
                                              || x.lieferzeit.ToString().Contains(searching)
                                              || x.mindbestand.ToString().Contains(searching)
                                              || x.hinweis.Contains(searching)
                                              || x.mengebestellt.ToString().Contains(searching)
                                              || x.mwst.ToString().Contains(searching)
                                              || x.inaktivvon.ToString().Contains(searching)
                                              || x.inaktivam.ToString().Contains(searching)
                                             // || x.letzte_aenderung.ToString().Contains(searching)
                                              || searching == null).ToList());*/

            return View();
        }


    }
}
