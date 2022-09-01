using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Computer_Store.Models;

namespace Computer_Store.Controllers
{
    public class ExpedisiController : Controller
    {
        //Ubah nama database yang baru di restore
        private CompStoreEntitiesDB db = new CompStoreEntitiesDB();

        // GET: Expedisi
        public ActionResult Index()
        {
            return View(db.Expedisis.ToList());
        }

        // GET: Expedisi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expedisi expedisi = db.Expedisis.Find(id);
            if (expedisi == null)
            {
                return HttpNotFound();
            }
            return View(expedisi);
        }

        // GET: Expedisi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expedisi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDExpedisi,NamaExpedisi,NamaKurir,Telepon")] Expedisi expedisi)
        {
            if (ModelState.IsValid)
            {
                db.Expedisis.Add(expedisi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expedisi);
        }

        // GET: Expedisi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expedisi expedisi = db.Expedisis.Find(id);
            if (expedisi == null)
            {
                return HttpNotFound();
            }
            return View(expedisi);
        }

        // POST: Expedisi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDExpedisi,NamaExpedisi,NamaKurir,Telepon")] Expedisi expedisi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expedisi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expedisi);
        }

        // GET: Expedisi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expedisi expedisi = db.Expedisis.Find(id);
            if (expedisi == null)
            {
                return HttpNotFound();
            }
            return View(expedisi);
        }

        // POST: Expedisi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expedisi expedisi = db.Expedisis.Find(id);
            db.Expedisis.Remove(expedisi);
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
