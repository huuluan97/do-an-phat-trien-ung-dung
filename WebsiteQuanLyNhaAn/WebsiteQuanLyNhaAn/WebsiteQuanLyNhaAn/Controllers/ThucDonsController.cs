using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyNhaAn.Models;
using System.Collections;
using System.Data.Sql;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace WebsiteQuanLyNhaAn.Controllers
{
    public class ThucDonsController : Controller
    {
        private QuanLyNhaAnEntities db = new QuanLyNhaAnEntities();

        // GET: ThucDons
        public ActionResult TEST()
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            var thucDons = db.ThucDons.Include(t => t.MonAn).Where(x => x.NgayLenThucDon == x.NgayLenThucDon).Distinct();
            return View(thucDons.ToList().OrderByDescending(c => c.NgayLenThucDon.Date).ThenBy(c => c.NgayLenThucDon.TimeOfDay));
        }
        public ActionResult TEST1()
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            var thucDons = db.ThucDons.Include(t => t.MonAn).Where(x => x.NgayLenThucDon == x.NgayLenThucDon).Distinct();
            return View(thucDons.ToList().OrderByDescending(c => c.NgayLenThucDon.Date).ThenBy(c => c.NgayLenThucDon.TimeOfDay));
        }
        public ActionResult TEST2()
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            var nowthucdon = db.ThucDons.Include(t => t.MonAn).Where(x => x.NgayLenThucDon == DateTime.Today).Distinct();
            return View(nowthucdon.ToList().OrderByDescending(c => c.NgayLenThucDon.Date).ThenBy(c => c.NgayLenThucDon.TimeOfDay));
        }
        public ActionResult ChonMonAn()
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            var thucDons = db.ThucDons.Include(t => t.MonAn).Where(x => x.NgayLenThucDon == x.NgayLenThucDon).Distinct();

            return View(thucDons.ToList().OrderByDescending(c => c.NgayLenThucDon.Date).ThenBy(c => c.NgayLenThucDon.TimeOfDay));
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
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn");
            return View();
        }

        // POST: ThucDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMonAn,NgayLenThucDon")] ThucDon thucDon)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ThucDons.Add(thucDon);
                    db.SaveChanges();
                    return RedirectToAction("TEST2");
                }

                ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", thucDon.MaMonAn);
                return View(thucDon);
            }
            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>" +
                               "function Redirect() {" +
                               "window.location.href='http://localhost:6537/ThucDons/TEST2';" +
                               "}" +
                               "setTimeout('Redirect()', 100);"
                               + "alert('Món ăn bị trùng! Vui lòng kiểm tra lại!');" +
                               "</script>");
            }
        }

        // GET: ThucDons/Edit/5
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
        public ActionResult Edit([Bind(Include = "MaMonAn,NgayLenThucDon")] ThucDon thucDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thucDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult ThongKeNguyenLieu()
        {
            using (QuanLyNhaAnEntities db = new QuanLyNhaAnEntities())
            {
                ViewBag.SumNguyenLieu = db.NguyenLieux.Sum(x => x.DonGiaNL).ToString();
                var nguyenlieu = db.NguyenLieux.ToList();
                //var thongke = db.NguyenLieux.RemoveRange(db.NguyenLieux.Where(c => c.MaNguyenLieu == MaNguyenLieu));
            }
            return View();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        //public ActionResult SaveBuaAn(ChiTietBuaAnTest a)
        //{

        //    db.ChiTietBuaAns.Add(a);
        //    db.SaveChanges();
        //    //return Json(new { success = true, message = "Thành Công" }, JsonRequestBehavior.AllowGet);
        //    return View(a);

        //}
    }
}