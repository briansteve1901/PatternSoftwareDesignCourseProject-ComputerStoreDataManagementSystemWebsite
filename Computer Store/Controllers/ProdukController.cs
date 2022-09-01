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
    public class ProdukController : Controller
    {
        //Ubah nama database yang baru di restore
        private CompStoreEntitiesDB db = new CompStoreEntitiesDB();

        // GET: Produk
        public ActionResult Index()
        {
            return View(db.Produks.ToList());
        }

        // GET: Produk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produk produk = db.Produks.Find(id);
            if (produk == null)
            {
                return HttpNotFound();
            }
            return View(produk);
        }

        // GET: Produk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProduk,NamaProduk,KategoriProduk,MerkProduk,StockProduk,HargaProduk")] Produk produk)
        {
            if (ModelState.IsValid)
            {
                db.Produks.Add(produk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produk);
        }

        // GET: Produk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produk produk = db.Produks.Find(id);
            if (produk == null)
            {
                return HttpNotFound();
            }
            return View(produk);
        }

        // POST: Produk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProduk,NamaProduk,KategoriProduk,MerkProduk,StockProduk,HargaProduk")] Produk produk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produk);
        }

        // GET: Produk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produk produk = db.Produks.Find(id);
            if (produk == null)
            {
                return HttpNotFound();
            }
            return View(produk);
        }

        // POST: Produk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produk produk = db.Produks.Find(id);
            db.Produks.Remove(produk);
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
