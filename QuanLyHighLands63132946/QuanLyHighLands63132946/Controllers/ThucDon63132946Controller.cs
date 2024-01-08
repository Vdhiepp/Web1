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
    public class ThucDon63132946Controller : Controller
    {
        private QUANLYQUANCAFE_63132946Entities db = new QUANLYQUANCAFE_63132946Entities();

        // GET: ThucDon63132946
        string LayMaMon()
        {
            var MaMax = db.THUCDONs.ToList().Select(n => n.maMon).Max();
            int MaMon = int.Parse(MaMax.Substring(2)) + 1;
            string Mon = String.Concat("00", MaMon.ToString());
            return "M" + Mon.Substring(MaMon.ToString().Length - 1);
        }
        [HttpGet]

        public ActionResult TimKiem63132946(string maMon = "", string tenMon = "", string maLoai = "", string maNCC = "")
        {
            ViewBag.maMon = maMon;
            ViewBag.tenMon = tenMon;
            ViewBag.maLoai = new SelectList(db.LOAIs, "maLoai", "tenLoai");
            ViewBag.maNCC = new SelectList(db.NHACUNGCAPs, "maNCC", "tenNCC");
            var thucDons = db.THUCDONs.SqlQuery("ThucDon_TimKiem'" + maMon + "','" + tenMon + "','" + maLoai + "','" 
                + maNCC + "'");
            if (thucDons.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(thucDons.ToList());
        }
        public ActionResult Index()
        {
            if (Session["HoTen"] == null || Session["HoTen"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "QuanTri63132946");
            }
            else
                return View(db.THUCDONs.ToList());
        }
        public ActionResult Menu63132946()
        {
            var tHUCDONs = db.THUCDONs.Include(t => t.LOAI).Include(t => t.NHACUNGCAP);
            return View(tHUCDONs.ToList());
        }
        public ActionResult COFFEE63132946()
        {
            var tHUCDONs = db.THUCDONs.Include(t => t.LOAI).Include(t => t.NHACUNGCAP);
            return View(tHUCDONs.ToList());
        }
        public ActionResult PHINDI63132946()
        {
            var tHUCDONs = db.THUCDONs.Include(t => t.LOAI).Include(t => t.NHACUNGCAP);
            return View(tHUCDONs.ToList());
        }
        public ActionResult ESPRESSO63132946()
        {
            var tHUCDONs = db.THUCDONs.Include(t => t.LOAI).Include(t => t.NHACUNGCAP);
            return View(tHUCDONs.ToList());
        }
        public ActionResult TEA63132946()
        {
            var tHUCDONs = db.THUCDONs.Include(t => t.LOAI).Include(t => t.NHACUNGCAP);
            return View(tHUCDONs.ToList());
        }
        public ActionResult FREEZE63132946()
        {
            var tHUCDONs = db.THUCDONs.Include(t => t.LOAI).Include(t => t.NHACUNGCAP);
            return View(tHUCDONs.ToList());
        }
        public ActionResult CAKE63132946()
        {
            var tHUCDONs = db.THUCDONs.Include(t => t.LOAI).Include(t => t.NHACUNGCAP);
            return View(tHUCDONs.ToList());
        }
        public ActionResult OTHER63132946()
        {
            var tHUCDONs = db.THUCDONs.Include(t => t.LOAI).Include(t => t.NHACUNGCAP);
            return View(tHUCDONs.ToList());
        }
        // GET: ThucDon63132946/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUCDON tHUCDON = db.THUCDONs.Find(id);
            if (tHUCDON == null)
            {
                return HttpNotFound();
            }
            return View(tHUCDON);
        }

        // GET: ThucDon63132946/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = LayMaMon();
            ViewBag.maLoai = new SelectList(db.LOAIs, "maLoai", "tenLoai");
            ViewBag.maNCC = new SelectList(db.NHACUNGCAPs, "maNCC", "tenNCC");
            return View();
        }

        // POST: ThucDon63132946/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maMon,tenMon,gia,hinhAnh,maNCC,maLoai")] THUCDON tHUCDON)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgMon = Request.Files["hinhAnh"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgMon.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgMon.SaveAs(path);

            if (ModelState.IsValid)
            {
                tHUCDON.maMon = LayMaMon();
                tHUCDON.hinhAnh = postedFileName;
                db.THUCDONs.Add(tHUCDON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maLoai = new SelectList(db.LOAIs, "maLoai", "tenLoai", tHUCDON.maLoai);
            ViewBag.maNCC = new SelectList(db.NHACUNGCAPs, "maNCC", "tenNCC", tHUCDON.maNCC);
            return View(tHUCDON);
        }

        // GET: ThucDon63132946/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUCDON tHUCDON = db.THUCDONs.Find(id);
            if (tHUCDON == null)
            {
                return HttpNotFound();
            }
            ViewBag.maLoai = new SelectList(db.LOAIs, "maLoai", "tenLoai", tHUCDON.maLoai);
            ViewBag.maNCC = new SelectList(db.NHACUNGCAPs, "maNCC", "tenNCC", tHUCDON.maNCC);
            return View(tHUCDON);
        }

        // POST: ThucDon63132946/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maMon,tenMon,gia,hinhAnh,maNCC,maLoai")] THUCDON tHUCDON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHUCDON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maLoai = new SelectList(db.LOAIs, "maLoai", "tenLoai", tHUCDON.maLoai);
            ViewBag.maNCC = new SelectList(db.NHACUNGCAPs, "maNCC", "tenNCC", tHUCDON.maNCC);
            return View(tHUCDON);
        }

        // GET: ThucDon63132946/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUCDON tHUCDON = db.THUCDONs.Find(id);
            if (tHUCDON == null)
            {
                return HttpNotFound();
            }
            return View(tHUCDON);
        }

        // POST: ThucDon63132946/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THUCDON tHUCDON = db.THUCDONs.Find(id);
            db.THUCDONs.Remove(tHUCDON);
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
