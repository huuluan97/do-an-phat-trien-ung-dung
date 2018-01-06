using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyNhaAn.Models;
using System.Data.Sql;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace WebsiteQuanLyNhaAn.Controllers
{
    public class UserChonMonController : Controller
    {
        // GET: UserChonMon
        private QuanLyNhaAnEntities db = new QuanLyNhaAnEntities();

        // GET: ThucDons
        public ActionResult ChonMon()
        {
            var thucDons = db.ThucDons.Include(t => t.MonAn);
            return View(thucDons.ToList());
        }

        // GET: ThucDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucDon thucDon = db.ThucDons.Find(id);
            if (thucDon == null)
            {
                return HttpNotFound();
            }
            return View(thucDon);
        }

        // GET: ThucDons/Create
        public ActionResult Create()
        {
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn");
            return View();
        }

        // POST: ThucDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMonAn,NgayLenThucDon,ThuTrongTuan")] ThucDon thucDon)
        {
            if (ModelState.IsValid)
            {
                db.ThucDons.Add(thucDon);
                db.SaveChanges();
                return RedirectToAction("ChonMon");
            }

            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", thucDon.MaMonAn);
            return View(thucDon);
        }
        // [HttpPost]
        public ActionResult SaveBuaAn(ChiTietBuaAn obj)
        {

            db.ChiTietBuaAns.Add(obj);
            db.SaveChanges();
            //return Json(new { success = true, message = "Thành Công" }, JsonRequestBehavior.AllowGet);
            return View(obj);

        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucDon thucDon = db.ThucDons.Find(id);
            if (thucDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", thucDon.MaMonAn);
            return View(thucDon);
        }

        // POST: ThucDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMonAn,NgayLenThucDon,ThuTrongTuan")] ThucDon thucDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thucDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChonMon");
            }
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", thucDon.MaMonAn);
            return View(thucDon);
        }

        // GET: ThucDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucDon thucDon = db.ThucDons.Find(id);
            if (thucDon == null)
            {
                return HttpNotFound();
            }
            return View(thucDon);
        }

        // POST: ThucDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThucDon thucDon = db.ThucDons.Find(id);
            db.ThucDons.Remove(thucDon);
            db.SaveChanges();
            return RedirectToAction("ChonMon");
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