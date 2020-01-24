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
    public class SuchenController : Controller
    {
        private Model1 db = new Model1();

        // GET: Suchen
        public ActionResult Index()
        {
            return View(db.artgrs.ToList());
        }

        // GET: Suchen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suche suche = db.artgrs.Find(id);
            if (suche == null)
            {
                return HttpNotFound();
            }
            return View(suche);
        }

        // GET: Suchen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suchen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "suchnr,searchstring")] suche suche)
        {
           string suchstring = suche.searchstring;


            
            return View("Index", db.artikel.Where(x => x.bezeichnung.Contains(suchstring)
                                             || x.artikelgruppen.grtext.Contains(suchstring)
                                           //  || x.aktiv.ToString().Contains(suchstring)
                                             || x.aktiv.ToString().Contains(suchstring)
                                           //  || x.lieferanten.firma1.Contains(searching)
                                             || x.vkpreis.ToString().Contains(suchstring)
                                             || x.ekpreis.ToString().Contains(suchstring)
                                             || x.lieferzeit.ToString().Contains(suchstring)
                                             || x.mindbestand.ToString().Contains(suchstring)
                                             || x.hinweis.Contains(suchstring)
                                             || x.mengebestellt.ToString().Contains(suchstring)
                                             || x.mwst.ToString().Contains(suchstring)
                                             || x.inaktivvon.ToString().Contains(suchstring)
                                             || x.inaktivam.ToString().Contains(suchstring)
                                             // || x.letzte_aenderung.ToString().Contains(searching)
                                             || suchstring == null).ToList()); 
            if (ModelState.IsValid)
            {
                db.artgrs.Add(suche);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suche);
        }

        // GET: Suchen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suche suche = db.artgrs.Find(id);
            if (suche == null)
            {
                return HttpNotFound();
            }
            return View(suche);
        }

        // POST: Suchen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "suchnr,searchstring")] suche suche)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suche).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suche);
        }

        // GET: Suchen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suche suche = db.artgrs.Find(id);
            if (suche == null)
            {
                return HttpNotFound();
            }
            return View(suche);
        }

        // POST: Suchen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            suche suche = db.artgrs.Find(id);
            db.artgrs.Remove(suche);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
