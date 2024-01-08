using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyHighLands63132946.Models;

namespace QuanLyHighLands63132946.Controllers
{
    public class KhachHang63132946Controller : Controller
    {
        private QUANLYQUANCAFE_63132946Entities db = new QUANLYQUANCAFE_63132946Entities();

        // GET: KhachHang63132946
        string LayMaKH()
        {
            var MaMax = db.KHACHHANGs.ToList().Select(n => n.maKH).Max();
            int MaKH = int.Parse(MaMax.Substring(2)) + 1;
            string KH = String.Concat("00", MaKH.ToString());
            return "KH" + KH.Substring(MaKH.ToString().Length - 1);
        }
        [HttpGet]

        public ActionResult TimKiem63132946(string maKH = "", string hoTen = "", string diaChi = "", string maLoaiKH = "")
        {
            ViewBag.maKH = maKH;
            ViewBag.hoTen = hoTen;
            ViewBag.diaChi = diaChi;
            ViewBag.maLoaiKH = new SelectList(db.LOAIKHACHHANGs, "maLoaiKH", "tenLoaiKH");
            var khachHangs = db.KHACHHANGs.SqlQuery("KhachHang_TimKiem'" + maKH + "','" + hoTen + "','"  + diaChi +
                "','" + maLoaiKH + "'");
            if (khachHangs.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(khachHangs.ToList());
        }
        public ActionResult Index()
        {
            if (Session["HoTen"] == null || Session["HoTen"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "QuanTri63132946");
            }
            else
                return View(db.KHACHHANGs.ToList());
        }

        // GET: KhachHang63132946/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // GET: KhachHang63132946/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = LayMaKH();
            ViewBag.maLoaiKH = new SelectList(db.LOAIKHACHHANGs, "maLoaiKH", "tenLoaiKH");
            return View();
        }

        // POST: KhachHang63132946/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maKH,hoKH,tenKH,diaChi,diemTichLuy,maLoaiKH")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                kHACHHANG.maKH = LayMaKH();
                db.KHACHHANGs.Add(kHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maLoaiKH = new SelectList(db.LOAIKHACHHANGs, "maLoaiKH", "tenLoaiKH", kHACHHANG.maLoaiKH);
            return View(kHACHHANG);
        }

        // GET: KhachHang63132946/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.maLoaiKH = new SelectList(db.LOAIKHACHHANGs, "maLoaiKH", "tenLoaiKH", kHACHHANG.maLoaiKH);
            return View(kHACHHANG);
        }

        // POST: KhachHang63132946/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maKH,hoKH,tenKH,diaChi,diemTichLuy,maLoaiKH")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACHHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maLoaiKH = new SelectList(db.LOAIKHACHHANGs, "maLoaiKH", "tenLoaiKH", kHACHHANG.maLoaiKH);
            return View(kHACHHANG);
        }

        // GET: KhachHang63132946/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: KhachHang63132946/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            db.KHACHHANGs.Remove(kHACHHANG);
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
