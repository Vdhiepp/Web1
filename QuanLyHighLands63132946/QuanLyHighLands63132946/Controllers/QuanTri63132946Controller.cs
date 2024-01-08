using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuanLyHighLands63132946.Models;

namespace QuanLyHighLands63132946.Controllers
{
    public class QuanTri63132946Controller : Controller
    {
        private QUANLYQUANCAFE_63132946Entities db = new QUANLYQUANCAFE_63132946Entities();

        // GET: QuanTri63132946
        public bool CheckUser(string username, string password)
        {
            var kq = db.QUANTRIs.Where(x => x.Email == username && x.Password == password).ToList();
            //string hoTen = kq.First().HoTen;
            if (kq.Count() > 0)
            {
                Session["HoTen"] = kq.First().HoTen;
                return true;
            }
            else
            {
                Session["HoTen"] = null;
                return false;
            }
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(QUANTRI qt)
        {
            if (ModelState.IsValid)
            {
                if (CheckUser(qt.Email, qt.Password))
                {
                    FormsAuthentication.SetAuthCookie(qt.Email, true);
                    return RedirectToAction("Index", "NhanVien63132946/Index");
                }
                else
                    ModelState.AddModelError("", "Tên đăng nhập hoặc tài khoản không đúng.");
            }
            return View(qt);
        }
        public ActionResult Index()
        {
            return View(db.QUANTRIs.ToList());
        }

        // GET: QuanTri63132946/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANTRI qUANTRI = db.QUANTRIs.Find(id);
            if (qUANTRI == null)
            {
                return HttpNotFound();
            }
            return View(qUANTRI);
        }

        // GET: QuanTri63132946/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanTri63132946/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Admin,HoTen,Password")] QUANTRI qUANTRI)
        {
            if (ModelState.IsValid)
            {
                db.QUANTRIs.Add(qUANTRI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUANTRI);
        }

        // GET: QuanTri63132946/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANTRI qUANTRI = db.QUANTRIs.Find(id);
            if (qUANTRI == null)
            {
                return HttpNotFound();
            }
            return View(qUANTRI);
        }

        // POST: QuanTri63132946/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Admin,HoTen,Password")] QUANTRI qUANTRI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUANTRI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUANTRI);
        }

        // GET: QuanTri63132946/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANTRI qUANTRI = db.QUANTRIs.Find(id);
            if (qUANTRI == null)
            {
                return HttpNotFound();
            }
            return View(qUANTRI);
        }

        // POST: QuanTri63132946/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QUANTRI qUANTRI = db.QUANTRIs.Find(id);
            db.QUANTRIs.Remove(qUANTRI);
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
