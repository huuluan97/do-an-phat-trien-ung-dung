using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyNhaAn.Models;

namespace WebsiteQuanLyNhaAn.Controllers
{
    public class ThongKeNguyenLieuController : Controller
    {
        // GET: ThongKeNguyenLieu
        public ActionResult Index()
        {
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
    }
}