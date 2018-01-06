using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyNhaAn.Models;

namespace WebsiteQuanLyNhaAn.Controllers
{
    public class NguyenLieuController : Controller
    {
        private QuanLyNhaAnEntities db = new QuanLyNhaAnEntities();
        // GET: NguyenLieu
        public ActionResult Index()
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            return View();
        }
        public ActionResult GetList()
        {
            List<ThanhToanNguyenLieu> empList = new List<ThanhToanNguyenLieu>();
            using (QuanLyNhaAnEntities db = new QuanLyNhaAnEntities())
            {
                empList = db.ThanhToanNguyenLieux.ToList<ThanhToanNguyenLieu>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult TEST2()
        {
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            return View(db.ThanhToanNguyenLieux.ToList());
        }
    }
}