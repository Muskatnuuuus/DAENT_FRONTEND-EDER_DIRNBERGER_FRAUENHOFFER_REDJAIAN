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
    public class JoinController : Controller
    {
        private Model1 db = new Model1();

       public ActionResult Index()
        { 
             var artGrp = (from a in db.artikel
                           join g in db.artikelgruppen on a.gruppe equals g.artgr
                           select (new
                           {
                               id = a.artnr,
                               artikelname = a.bezeichnung,
                               artikelgruppe = g.grtext
                           })).ToList();

        // neue leere Liste
        List<artgrp> list = new List<artgrp>();
        artgrp tempObj;

            // eine Schleife, damit jeder Datensatz in eine neue Liste geschrieben wird
            foreach (var a in artGrp)
            {
                // neue Instanz
                tempObj = new artgrp();

        // Werte setzen
        tempObj.id = a.id;
                tempObj.artikelname = a.artikelname;
                tempObj.artikelgruppe = a.artikelgruppe;

                list.Add(tempObj);
            }

            // Liste zurückgeben
            return View(list);
}
    }
}
