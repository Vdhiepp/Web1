using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThiGK_63132946.Models;

namespace ThiGK_63132946.Controllers
{
    public class QuanAos_63132946Controller : Controller
    {
        private Thi_63132946Entities db = new Thi_63132946Entities();

        // GET: QuanAos_63132946
        public ActionResult Index()
        {
            var qUANAOs = db.QUANAOs.Include(q => q.LOAIQUANAO);
            return View(qUANAOs.ToList());
        }
        public ActionResult GioiThieu_63132946()
        {
            return View();
        }
        [HttpGet]

        public ActionResult TimKiem_63132946(string MaQA = "", string TenQA = "")
        {
            ViewBag.MaQA = MaQA;
            ViewBag.TenQA = TenQA;
            var quanAos = db.QUANAOs.SqlQuery("QuanAo_TimKiem'" + MaQA + "','" + TenQA + "'");
            if (quanAos.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(quanAos.ToList());
        }
        // GET: QuanAos_63132946/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANAO qUANAO = db.QUANAOs.Find(id);
            if (qUANAO == null)
            {
                return HttpNotFound();
            }
            return View(qUANAO);
        }

        // GET: QuanAos_63132946/Create
        public ActionResult Create()
        {
            ViewBag.MaLQA = new SelectList(db.LOAIQUANAOs, "MaLQA", "TenLQA");
            return View();
        }

        // POST: QuanAos_63132946/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaQA,TenQA,MoTa,XuatXu,DonGia,AnhMH,MaLQA")] QUANAO qUANAO)
        {
            if (ModelState.IsValid)
            {
                db.QUANAOs.Add(qUANAO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLQA = new SelectList(db.LOAIQUANAOs, "MaLQA", "TenLQA", qUANAO.MaLQA);
            return View(qUANAO);
        }

        // GET: QuanAos_63132946/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANAO qUANAO = db.QUANAOs.Find(id);
            if (qUANAO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLQA = new SelectList(db.LOAIQUANAOs, "MaLQA", "TenLQA", qUANAO.MaLQA);
            return View(qUANAO);
        }

        // POST: QuanAos_63132946/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaQA,TenQA,MoTa,XuatXu,DonGia,AnhMH,MaLQA")] QUANAO qUANAO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUANAO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLQA = new SelectList(db.LOAIQUANAOs, "MaLQA", "TenLQA", qUANAO.MaLQA);
            return View(qUANAO);
        }

        // GET: QuanAos_63132946/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANAO qUANAO = db.QUANAOs.Find(id);
            if (qUANAO == null)
            {
                return HttpNotFound();
            }
            return View(qUANAO);
        }

        // POST: QuanAos_63132946/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QUANAO qUANAO = db.QUANAOs.Find(id);
            db.QUANAOs.Remove(qUANAO);
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
