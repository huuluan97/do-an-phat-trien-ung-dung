using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyNhaAn.Models;

namespace WebsiteQuanLyNhaAn.Controllers
{
    public class LoginAdminController : Controller
    {

        // GET: LoginAdmin
        private QuanLyNhaAnEntities db = new QuanLyNhaAnEntities();
        // GET: LoginAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherzie(WebsiteQuanLyNhaAn.Models.TaiKhoan maModel)
        {
            var maDetails = db.TaiKhoans.Include(t => t.NhanVien).Where(x => x.MaNV == maModel.MaNV && x.Pass == maModel.Pass && x.NhanVien.CapChucVu == 1).FirstOrDefault();

            //var kiemtraNV = db.TaiKhoans.Include(t=>t.NhanVien).Where(x => x.MaNV == maModel.MaNV && x.Pass == maModel.Pass && ).FirstOrDefault();


            if (maDetails == null)
            {
                maModel.LoginErrorMessage = "Nhập Sai!!! Vui lòng kiểm tra lại Tài Khoản";
                return View("Login", maModel);
            }
            else
            {
                Session["MaNV"] = maDetails.NhanVien.TenNV;
                return RedirectToAction("Index", "MonAn");

            }
        }

        public ActionResult DanhSach()
        {
            return View(db.TaiKhoans.ToList());
        }
    }
}
