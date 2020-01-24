using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAENT_FRONTEND.Models;
using System.Data.SqlClient;


namespace DAENT_FRONTEND.Controllers
{
    public class StoredProcedureController : Controller
    {
        
        private Model1 db = new Model1();

        // GET: SP
        public ActionResult Index()
        {
            // var artikel = db.artikel.Include(a => a.artikelgruppen);
            //  return View(artikel.ToList());
            return View(db.artikelgruppen.ToList());
        }

        
        // GET: SP/Details/5
        public ActionResult SP()
        {
           // ViewBag.gruppe = new SelectList(db.artikelgruppen, "artgr", "grtext");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult SP([Bind(Include = "artgr, grtext")] artikelgruppen artikelgruppen)
        {

            {
                if (ModelState.IsValid)
                {
                    //db.artikelgruppen.Add(artikelgruppen);
                    //db.SaveChanges();

                    string stmt = "[wawi].[sp_gruppe_neu_v2] @gruppe, @bezeichnung ";
                    SqlParameter grParam = new SqlParameter("@gruppe", artikelgruppen.artgr);
                    SqlParameter bezParam = new SqlParameter("@bezeichnung", artikelgruppen.grtext);
                    object[] parameters = { grParam, bezParam };

                    try
                    {
                        db.Database.ExecuteSqlCommand(stmt, parameters);
                    }
                    catch (ArgumentException e)
                    {
                        System.Diagnostics.Debug.WriteLine("Exception: " + e);
                    }
                    //    return RedirectToAction("Index");

                    //return RedirectToAction("Index");
                }

                return View(artikelgruppen);

            }

        }

       
    }
}
