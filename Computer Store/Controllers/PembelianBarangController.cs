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
    public class PembelianBarangController : Controller
    {
        //Ubah nama database yang baru di restore
        private CompStoreEntitiesDB db = new CompStoreEntitiesDB();

        // GET: PembelianBarang
        public ActionResult Index()
        {
            var pembelianBarangs = db.PembelianBarangs.Include(p => p.Expedisi).Include(p => p.Produk).Include(p => p.Staff).Include(p => p.Supplier);
            return View(pembelianBarangs.ToList());
        }

        // GET: PembelianBarang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PembelianBarang pembelianBarang = db.PembelianBarangs.Find(id);
            if (pembelianBarang == null)
            {
                return HttpNotFound();
            }
            return View(pembelianBarang);
        }

        // GET: PembelianBarang/Create
        public ActionResult Create()
        {
            ViewBag.IDExpedisi = new SelectList(db.Expedisis, "IDExpedisi", "NamaExpedisi");
            ViewBag.IDproduk = new SelectList(db.Produks, "IDProduk", "NamaProduk");
            ViewBag.IDStaff = new SelectList(db.Staffs, "IDStaff", "NamaStaff");
            ViewBag.IDSupplier = new SelectList(db.Suppliers, "IDSupplier", "NamaSupplier");
            return View();
        }

        // POST: PembelianBarang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPembelian,IDproduk,JumlahBarang,HargaProduk,TanggalPembelian,JenisPembayaran,IDSupplier,IDStaff,IDExpedisi")] PembelianBarang pembelianBarang)
        {
            if (ModelState.IsValid)
            {
                db.PembelianBarangs.Add(pembelianBarang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDExpedisi = new SelectList(db.Expedisis, "IDExpedisi", "NamaExpedisi", pembelianBarang.IDExpedisi);
            ViewBag.IDproduk = new SelectList(db.Produks, "IDProduk", "NamaProduk", pembelianBarang.IDproduk);
            ViewBag.IDStaff = new SelectList(db.Staffs, "IDStaff", "NamaStaff", pembelianBarang.IDStaff);
            ViewBag.IDSupplier = new SelectList(db.Suppliers, "IDSupplier", "NamaSupplier", pembelianBarang.IDSupplier);
            return View(pembelianBarang);
        }

        // GET: PembelianBarang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PembelianBarang pembelianBarang = db.PembelianBarangs.Find(id);
            if (pembelianBarang == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDExpedisi = new SelectList(db.Expedisis, "IDExpedisi", "NamaExpedisi", pembelianBarang.IDExpedisi);
            ViewBag.IDproduk = new SelectList(db.Produks, "IDProduk", "NamaProduk", pembelianBarang.IDproduk);
            ViewBag.IDStaff = new SelectList(db.Staffs, "IDStaff", "NamaStaff", pembelianBarang.IDStaff);
            ViewBag.IDSupplier = new SelectList(db.Suppliers, "IDSupplier", "NamaSupplier", pembelianBarang.IDSupplier);
            return View(pembelianBarang);
        }

        // POST: PembelianBarang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPembelian,IDproduk,JumlahBarang,HargaProduk,TanggalPembelian,JenisPembayaran,IDSupplier,IDStaff,IDExpedisi")] PembelianBarang pembelianBarang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pembelianBarang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDExpedisi = new SelectList(db.Expedisis, "IDExpedisi", "NamaExpedisi", pembelianBarang.IDExpedisi);
            ViewBag.IDproduk = new SelectList(db.Produks, "IDProduk", "NamaProduk", pembelianBarang.IDproduk);
            ViewBag.IDStaff = new SelectList(db.Staffs, "IDStaff", "NamaStaff", pembelianBarang.IDStaff);
            ViewBag.IDSupplier = new SelectList(db.Suppliers, "IDSupplier", "NamaSupplier", pembelianBarang.IDSupplier);
            return View(pembelianBarang);
        }

        // GET: PembelianBarang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PembelianBarang pembelianBarang = db.PembelianBarangs.Find(id);
            if (pembelianBarang == null)
            {
                return HttpNotFound();
            }
            return View(pembelianBarang);
        }

        // POST: PembelianBarang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PembelianBarang pembelianBarang = db.PembelianBarangs.Find(id);
            db.PembelianBarangs.Remove(pembelianBarang);
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
