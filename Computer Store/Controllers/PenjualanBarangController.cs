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
    public class PenjualanBarangController : Controller
    {
        //Ubah nama database yang baru di restore
        private CompStoreEntitiesDB db = new CompStoreEntitiesDB();

        // GET: PenjualanBarang
        public ActionResult Index()
        {
            var penjualanBarangs = db.PenjualanBarangs.Include(p => p.Customer).Include(p => p.Expedisi).Include(p => p.Produk).Include(p => p.Staff);
            return View(penjualanBarangs.ToList());
        }

        // GET: PenjualanBarang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PenjualanBarang penjualanBarang = db.PenjualanBarangs.Find(id);
            if (penjualanBarang == null)
            {
                return HttpNotFound();
            }
            return View(penjualanBarang);
        }

        // GET: PenjualanBarang/Create
        public ActionResult Create()
        {
            ViewBag.IDCustomer = new SelectList(db.Customers, "IDCustomer", "NamaCustomer");
            ViewBag.IDExpedisi = new SelectList(db.Expedisis, "IDExpedisi", "NamaExpedisi");
            ViewBag.IDproduk = new SelectList(db.Produks, "IDProduk", "NamaProduk");
            ViewBag.IDStaff = new SelectList(db.Staffs, "IDStaff", "NamaStaff");
            return View();
        }

        // POST: PenjualanBarang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPenjualan,IDproduk,JumlahBarang,HargaProduk,TanggalPembelian,JenisPembayaran,IDCustomer,IDStaff,IDExpedisi")] PenjualanBarang penjualanBarang)
        {
            if (ModelState.IsValid)
            {
                db.PenjualanBarangs.Add(penjualanBarang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCustomer = new SelectList(db.Customers, "IDCustomer", "NamaCustomer", penjualanBarang.IDCustomer);
            ViewBag.IDExpedisi = new SelectList(db.Expedisis, "IDExpedisi", "NamaExpedisi", penjualanBarang.IDExpedisi);
            ViewBag.IDproduk = new SelectList(db.Produks, "IDProduk", "NamaProduk", penjualanBarang.IDproduk);
            ViewBag.IDStaff = new SelectList(db.Staffs, "IDStaff", "NamaStaff", penjualanBarang.IDStaff);
            return View(penjualanBarang);
        }

        // GET: PenjualanBarang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PenjualanBarang penjualanBarang = db.PenjualanBarangs.Find(id);
            if (penjualanBarang == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCustomer = new SelectList(db.Customers, "IDCustomer", "NamaCustomer", penjualanBarang.IDCustomer);
            ViewBag.IDExpedisi = new SelectList(db.Expedisis, "IDExpedisi", "NamaExpedisi", penjualanBarang.IDExpedisi);
            ViewBag.IDproduk = new SelectList(db.Produks, "IDProduk", "NamaProduk", penjualanBarang.IDproduk);
            ViewBag.IDStaff = new SelectList(db.Staffs, "IDStaff", "NamaStaff", penjualanBarang.IDStaff);
            return View(penjualanBarang);
        }

        // POST: PenjualanBarang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPenjualan,IDproduk,JumlahBarang,HargaProduk,TanggalPembelian,JenisPembayaran,IDCustomer,IDStaff,IDExpedisi")] PenjualanBarang penjualanBarang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(penjualanBarang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCustomer = new SelectList(db.Customers, "IDCustomer", "NamaCustomer", penjualanBarang.IDCustomer);
            ViewBag.IDExpedisi = new SelectList(db.Expedisis, "IDExpedisi", "NamaExpedisi", penjualanBarang.IDExpedisi);
            ViewBag.IDproduk = new SelectList(db.Produks, "IDProduk", "NamaProduk", penjualanBarang.IDproduk);
            ViewBag.IDStaff = new SelectList(db.Staffs, "IDStaff", "NamaStaff", penjualanBarang.IDStaff);
            return View(penjualanBarang);
        }

        // GET: PenjualanBarang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PenjualanBarang penjualanBarang = db.PenjualanBarangs.Find(id);
            if (penjualanBarang == null)
            {
                return HttpNotFound();
            }
            return View(penjualanBarang);
        }

        // POST: PenjualanBarang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PenjualanBarang penjualanBarang = db.PenjualanBarangs.Find(id);
            db.PenjualanBarangs.Remove(penjualanBarang);
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
