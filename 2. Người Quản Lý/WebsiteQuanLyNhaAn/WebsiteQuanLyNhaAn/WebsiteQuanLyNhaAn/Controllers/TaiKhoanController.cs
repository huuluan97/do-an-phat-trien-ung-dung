using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebsiteQuanLyNhaAn.Models;

namespace WebsiteQuanLyNhaAn.Controllers
{
    public class TaiKhoanController : Controller
    {

        private QuanLyNhaAnEntities db = new QuanLyNhaAnEntities();
        // GET: TaiKhoan

        public ActionResult Index()
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            return View(db.TaiKhoans.ToList());
        }

        IEnumerable<NhanVien> NoAccount()
        {
            using (QuanLyNhaAnEntities db = new QuanLyNhaAnEntities())
            {
                return db.NhanViens.Where(x => x.TinhTrangTaiKhoan == 0).ToList<NhanVien>();
            }
        }

        public ActionResult DanhSachNhanVien()
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            return View(NoAccount());
        }



        // GET: TaiKhoan/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            return View();
        }

        // GET: TaiKhoan/Create
        public ActionResult Create()
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            return View();
        }

        // POST: TaiKhoan/Create
        [HttpPost]
        public ActionResult Create(TaiKhoan tk)
        {
            try
            {
                // TODO: Add insert logic here
                using (QuanLyNhaAnEntities db = new QuanLyNhaAnEntities())
                {
                    db.TaiKhoans.Add(tk);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                //return Content("<script language='javascript' type='text/javascript'>" +
                //               "function Redirect() {" +
                //               "window.location='http://www.vietjack.com';" +
                //               "}" +
                //               "setTimeout('Redirect()', 10000);"+
                //               "</script>");
                //return Content("<script language='javascript' type='text/javascript'>" +
                //               "function Redirect() {" +
                //               "window.location=" + @Url.Action("DanhSachNhanVien", "TaiKhoan") + ";" +
                //               "}" +
                //               "setTimeout('Redirect()', 100);" +
                //              "</script>");
                //return Content("<script language='javascript' type='text/javascript'>" +
                //               "function Redirect() {" +
                //               "window.location='http://localhost:6537/TaiKhoan/DanhSachNhanVien';" +
                //               "}" +
                //               "setTimeout('Redirect()', 1000);" +
                //               "</script>");
                return Content("<script language='javascript' type='text/javascript'>" +
                               "function Redirect() {" +
                               "window.location='http://localhost:6537/TaiKhoan/DanhSachNhanVien';" +
                               "}" + 
                               "setTimeout('Redirect()', 100);" 
                               + "alert('Mã nhân viên đã được tạo tài khoản! Vui lòng kiểm tra lại!');" +
                               "</script>");
            }
        }

        // GET: TaiKhoan/Edit/5
        public ActionResult Edit(int id)
        {
            using (QuanLyNhaAnEntities db = new QuanLyNhaAnEntities())
            {
                ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
                ViewBag.Count = db.TaiKhoans.Count();
                ViewBag.Food = db.MonAns.Count();
                return View(db.TaiKhoans.Where(x => x.MaNV == id).FirstOrDefault());
            }
        }

        // POST: TaiKhoan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TaiKhoan tk)
        {
            try
            {
                // TODO: Add update logic here
                using (QuanLyNhaAnEntities db = new QuanLyNhaAnEntities())
                {
                    db.Entry(tk).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaiKhoan/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.TaiKhoans.Where(x => x.MaNV == id).FirstOrDefault());
        }

        // POST: TaiKhoan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            try
            {
                // TODO: Add delete logic here
                TaiKhoan tk = db.TaiKhoans.Where(x => x.MaNV == id).FirstOrDefault();
                db.TaiKhoans.Remove(tk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}