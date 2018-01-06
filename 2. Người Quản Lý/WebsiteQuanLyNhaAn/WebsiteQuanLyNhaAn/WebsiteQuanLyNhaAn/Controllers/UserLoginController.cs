using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebsiteQuanLyNhaAn.Models;

namespace WebsiteQuanLyNhaAn.Controllers
{
    public class UserLoginController : Controller
    {

        // GET: UserLogin
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
            var maDetails = db.TaiKhoans.Where(x => x.MaNV == maModel.MaNV && x.Pass == maModel.Pass).FirstOrDefault();
            if (maDetails == null)
            {
                maModel.LoginErrorMessage = "Bạn Nhập Sai Mã Nhân Viên Hoặc Mật Khẩu";
                return View("Login", maModel);
            }
            else
            {
                Session["MaNV"] = maDetails.MaNV;
                return RedirectToAction("TrangChu", "TrangChu");
            }
        }

    }
}