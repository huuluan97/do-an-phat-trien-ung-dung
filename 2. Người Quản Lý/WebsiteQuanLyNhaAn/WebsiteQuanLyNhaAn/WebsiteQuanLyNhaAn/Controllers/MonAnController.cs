using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebsiteQuanLyNhaAn.Models;
using System.IO;


namespace WebsiteQuanLyNhaAn.Controllers
{
    public class MonAnController : Controller
    {
        // GET: MonAn
        private QuanLyNhaAnEntities db = new QuanLyNhaAnEntities();
        // GET: MonAn
        public ActionResult Index()
        {
            //ViewBag.Food = Session["MaNV"].ToString();
            ViewBag.Total = db.ChiTietBuaAns.Sum(x => x.DonGia);
            ViewBag.Count = db.TaiKhoans.Count();
            ViewBag.Food = db.MonAns.Count();
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllMonAn());
        }

        public ActionResult XemMonAn()
        {
            return View(db.MonAns.ToList());
        }
        IEnumerable<MonAn> GetAllMonAn()
        {
            using (QuanLyNhaAnEntities db = new QuanLyNhaAnEntities())
            {
                return db.MonAns.ToList<MonAn>();
            }
        }



        public ActionResult AddOrEdit(int id = 0)
        {
            MonAn mon = new MonAn();
            if (id != 0)
            {
                using (QuanLyNhaAnEntities db = new QuanLyNhaAnEntities())
                {
                    mon = db.MonAns.Where(x => x.MaMonAn == id).FirstOrDefault<MonAn>();
                }
            }
            return View(mon);
        }

        [HttpPost]
        public ActionResult AddOrEdit(MonAn mon)
        {
            try
            {
                if (mon.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(mon.ImageUpload.FileName);
                    string extension = Path.GetExtension(mon.ImageUpload.FileName);
                    fileName = fileName + mon.MaMonAn + extension;
                    mon.Images = "/Photos/" + fileName;
                    mon.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Photos/"), fileName));
                }
                using (QuanLyNhaAnEntities db = new QuanLyNhaAnEntities())
                {
                    if (mon.MaMonAn == 0)
                    {
                        db.MonAns.Add(mon);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(mon).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllMonAn()), message = "Thành Công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (QuanLyNhaAnEntities db = new QuanLyNhaAnEntities())
                {
                    MonAn mon = db.MonAns.Where(x => x.MaMonAn == id).FirstOrDefault<MonAn>();
                    db.MonAns.Remove(mon);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllMonAn()), message = "Xóa Thành Công" },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message },
                    JsonRequestBehavior.AllowGet);
            }
        }
    }
}