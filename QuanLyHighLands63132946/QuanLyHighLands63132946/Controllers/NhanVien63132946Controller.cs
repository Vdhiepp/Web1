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
    public class NhanVien63132946Controller : Controller
    {
        private QUANLYQUANCAFE_63132946Entities db = new QUANLYQUANCAFE_63132946Entities();

        // GET: NhanVien63132946
        string LayMaNV()
        {
            var MaMax = db.NHANVIENs.ToList().Select(n => n.maNV).Max();
            int MaNV = int.Parse(MaMax.Substring(2)) + 1;
            string NV = String.Concat("00", MaNV.ToString());
            return "NV" + NV.Substring(MaNV.ToString().Length - 1);
        }
        [HttpGet]

        public ActionResult TimKiem63132946(string maNV = "", string hoTen = "", string gioiTinh = "", 
            string luongMin = "", string luongMax = "", string diaChi = "", string maCV = "")
        {
            string min = luongMin, max = luongMax;
            if (gioiTinh != "1" && gioiTinh != "0")
                gioiTinh = null;
            ViewBag.maNV = maNV;
            ViewBag.hoTen = hoTen;
            ViewBag.gioiTinh = gioiTinh;
            if (luongMin == "")
            {
                ViewBag.luongMin = "";
                min = "0";
            }
            else
            {
                ViewBag.luongMin = luongMin;
                min = luongMin;
            }
            if (max == "")
            {
                max = Int32.MaxValue.ToString();
                ViewBag.luongMax = "";// Int32.MaxValue.ToString(); 
            }
            else
            {
                ViewBag.luongMax = luongMax;
                max = luongMax;
            }
            ViewBag.diaChi = diaChi;
            ViewBag.maCV = new SelectList(db.CHUCVUs, "maCV", "tenCV");
            var nhanViens = db.NHANVIENs.SqlQuery("NhanVien_TimKiem'" + maNV + "','" + hoTen + "','" + gioiTinh 
                + "','" + min + "','" + max + "',N'" + diaChi + "','" + maCV + "'");
            if (nhanViens.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(nhanViens.ToList());
        }
        public ActionResult Index()
        {           
            if (Session["HoTen"] == null || Session["HoTen"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "QuanTri63132946");
            }
            else
                return View(db.NHANVIENs.ToList());
        }

        // GET: NhanVien63132946/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: NhanVien63132946/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = LayMaNV();
            ViewBag.maCV = new SelectList(db.CHUCVUs, "maCV", "tenCV");
            return View();
        }

        // POST: NhanVien63132946/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maNV,hoNV,tenNV,gioiTinh,ngaySinh,luong,anhNV,diaChi,maCV")] NHANVIEN nHANVIEN)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgNV = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgNV.SaveAs(path);

            if (ModelState.IsValid)
            {
                nHANVIEN.maNV = LayMaNV();
                nHANVIEN.anhNV = postedFileName;
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maCV = new SelectList(db.CHUCVUs, "maCV", "tenCV", nHANVIEN.maCV);
            return View(nHANVIEN);
        }

        // GET: NhanVien63132946/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.maCV = new SelectList(db.CHUCVUs, "maCV", "tenCV", nHANVIEN.maCV);
            return View(nHANVIEN);
        }

        // POST: NhanVien63132946/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maNV,hoNV,tenNV,gioiTinh,ngaySinh,luong,anhNV,diaChi,maCV")] NHANVIEN nHANVIEN)
        {
            var imgNV = Request.Files["Avatar"];
            try
            {
                //Lấy thông tin từ input type=file có tên Avatar
                string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
                //Lưu hình đại diện về Server
                var path = Server.MapPath("/Images/" + postedFileName);
                imgNV.SaveAs(path);
            }
            catch
            { }
            
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maCV = new SelectList(db.CHUCVUs, "maCV", "tenCV", nHANVIEN.maCV);
            return View(nHANVIEN);
        }

        // GET: NhanVien63132946/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NhanVien63132946/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
        public ActionResult PrintList()
        {
            var nhanViens = db.NHANVIENs.Include(n => n.CHUCVU).OrderBy(n => n.tenNV);
            return PartialView(nhanViens.ToList());
        }
    }
}
