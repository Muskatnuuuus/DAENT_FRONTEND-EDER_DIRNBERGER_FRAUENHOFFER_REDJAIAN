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
    public class artikelController : Controller
    {
        private Model1 db = new Model1();

        // GET: artikel
        public ActionResult Index()
        {
            var artikel = db.artikel.Include(a => a.artikelgruppen);
            return View(artikel.ToList());
        }

        // GET: artikel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            artikel artikel = db.artikel.Find(id);
            if (artikel == null)
            {
                return HttpNotFound();
            }
            return View(artikel);
        }

        // GET: artikel/Create
        public ActionResult Create()
        {
            ViewBag.gruppe = new SelectList(db.artikelgruppen, "artgr", "grtext");
            return View();
        }

        // POST: artikel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "artnr,bezeichnung,gruppe,vkpreis,lief,ekpreis,lieferzeit,mindbestand,hinweis,mengebestellt,mwst,aktiv,inaktivam,inaktivvon")] artikel artikel)
        {
            if (ModelState.IsValid)
            {
                db.artikel.Add(artikel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.gruppe = new SelectList(db.artikelgruppen, "artgr", "grtext", artikel.gruppe);
            return View(artikel);
        }

        // GET: artikel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            artikel artikel = db.artikel.Find(id);
            if (artikel == null)
            {
                return HttpNotFound();
            }
            ViewBag.gruppe = new SelectList(db.artikelgruppen, "artgr", "grtext", artikel.gruppe);
            return View(artikel);
        }

        // POST: artikel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "artnr,bezeichnung,gruppe,vkpreis,lief,ekpreis,lieferzeit,mindbestand,hinweis,mengebestellt,mwst,aktiv,inaktivam,inaktivvon")] artikel artikel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artikel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.gruppe = new SelectList(db.artikelgruppen, "artgr", "grtext", artikel.gruppe);
            return View(artikel);
        }

        // GET: artikel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            artikel artikel = db.artikel.Find(id);
            if (artikel == null)
            {
                return HttpNotFound();
            }
            return View(artikel);
        }

        // POST: artikel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            artikel artikel = db.artikel.Find(id);
            db.artikel.Remove(artikel);
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
