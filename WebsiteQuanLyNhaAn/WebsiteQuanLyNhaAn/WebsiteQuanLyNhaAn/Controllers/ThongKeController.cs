using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyNhaAn.Models;
using System.Data.Entity;
using System.Data;

namespace WebsiteQuanLyNhaAn.Controllers
{
    public class ThongKeController : Controller
    {

        private QuanLyNhaAnEntities db = new QuanLyNhaAnEntities();
        // GET: ThongKe
        public ActionResult Index()
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            return View(db.ThanhToans.ToList());
        }

        public ActionResult ThongKe()
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            return View(db.ThanhToans.ToList());
        }
        // GET: ThongKe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ThongKe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThongKe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ThongKe/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            return View(db.ThanhToans.Where(x => x.maNV == id).FirstOrDefault());
        }

        // POST: ThongKe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ThanhToan tt)
        {
            try
            {
                using (QuanLyNhaAnEntities db = new QuanLyNhaAnEntities())
                {
                    db.Entry(tt).State = EntityState.Modified;
                    db.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ThongKe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ThongKe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}