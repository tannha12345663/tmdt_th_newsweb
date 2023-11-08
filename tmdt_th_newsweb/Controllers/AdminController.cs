using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tmdt_th_newsweb.App_Start;
using tmdt_th_newsweb.Models;

namespace tmdt_th_newsweb.Controllers
{
    [Authentication(MaChucVu = "Admin",MaChucVu2 ="NV")]
    public class AdminController : Controller
    {
        TMDT_TH_newsWebEntities db = new TMDT_TH_newsWebEntities();
        // GET: Admin
        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult DSTT()
        {
            var usnv = (NhanVien)Session["userNV"];
            if(usnv.MaCV != "Admin")
            {
                var dsbv = db.BaiViets.Where(s=>s.MaNV == usnv.MaNV || s.MaNV == null);
                return View(dsbv);
            }
            else
            {
                var dsbv = db.BaiViets.ToList();
                return View(dsbv);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemTT([Bind(Include = "TieuDe,NoiDung")] BaiViet bv)
        {
            var user = (NhanVien)Session["userNV"];
            if (ModelState.IsValid)
            {
                try
                {
                    db.sp_ThemBV(bv.TieuDe, bv.NoiDung, System.DateTime.Now, null, 0, user.MaNV, null);
                    db.SaveChanges();
                    TempData["messageAlert"] = "success0";
                    TempData["tieude"] = bv.TieuDe;
                }
                catch(Exception e)
                {
                    TempData["messageAlert"] = "error0";
                    TempData["tieude"] = bv.TieuDe;
                    TempData["mess"] = e.InnerException.Message;
                }
                return RedirectToAction("DSTT");
            }
            return HttpNotFound();
        }
        //Kiểm tra tên tiêu đề
        [HttpPost]
        public ActionResult KTTieuDe(string TenTD)
        {
            var user = (NhanVien)Session["userNV"];
            var check = db.BaiViets.Where(s => s.TieuDe == TenTD && s.MaNV == user.MaNV).FirstOrDefault();
            if (check is null)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        //Chỉnh sửa tin tức
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChinhSuaTT([Bind(Include = "MaBV,TieuDe,NoiDung")] BaiViet bv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.sp_ChinhSuaBV(bv.MaBV,bv.TieuDe,bv.NoiDung,System.DateTime.Now);
                    db.SaveChanges();
                    TempData["messageAlert"] = "success1";
                    TempData["mabv"] = bv.MaBV;
                }
                catch (Exception e)
                {
                    TempData["messageAlert"] = "error1";
                    TempData["mabv"] = bv.MaBV;
                    TempData["messER"] = e.InnerException.Message;
                }
                return RedirectToAction("DSTT");
            }
            return HttpNotFound();
        }
        //Duyệt bài viết
        [HttpPost]
        public ActionResult DuyetTT(string MaBV)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.sp_LockTT(MaBV, 1);
                    db.SaveChanges();
                    return Json(new { success = true, mabv = MaBV }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json(new { success = false, nd = e.InnerException.Message, mabv = MaBV }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        //Từ chối bài viết
        [HttpPost]
        public ActionResult TuchoiTT(string MaBV)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.sp_LockTT(MaBV, 2);
                    db.SaveChanges();
                    return Json(new { success = true, mabv = MaBV }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json(new { success = false, nd = e.InnerException.Message, mabv = MaBV }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult XoaTT(string MaBV)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.sp_XoaBV(MaBV);
                    db.SaveChanges();
                    return Json(new { success = true, mabv = MaBV }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json(new { success = false, nd = e.InnerException.Message, mabv = MaBV }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        //Danh sách nhân viên
        public ActionResult DSNV()
        {
            var dsnv = db.NhanViens.ToList();
            return View(dsnv);
        }
        //Thêm nhân viên
        [HttpPost]
        public ActionResult ThemNV([Bind(Include = "TenNV,DiaChi,Email,SDT,UserName,Password,MaCV,HinhAnh ")] NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.sp_ThemNV(nv.TenNV,nv.DiaChi,nv.Email,nv.SDT,nv.UserName,nv.MaCV,nv.HinhAnh);
                    db.SaveChanges();
                    TempData["messageAlert"] = "success0";
                    TempData["tennv"] = nv.TenNV;

                }
                catch (Exception e)
                {
                    TempData["messageAlert"] = "error0";
                    TempData["tennv"] = nv.TenNV;
                    TempData["mess"] = e.InnerException.Message;
                }
                return RedirectToAction("DSNV");
            }
            return HttpNotFound();
        }
        //Chỉnh sửa nhân viên
        [HttpPost]
        public ActionResult ChinhSuaNV([Bind(Include = "MaNV,TenNV,DiaChi,Email,SDT,UserName,Password,MaCV,HinhAnh ")] NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ha = db.NhanViens.Where(s => s.MaNV == nv.MaNV).FirstOrDefault();
                    if(nv.HinhAnh == null)
                    {
                        db.sp_ChinhSuaNV(nv.MaNV, nv.TenNV, nv.DiaChi, nv.Email, nv.SDT, nv.UserName, nv.Password, nv.MaCV,ha.HinhAnh);
                    }
                    else
                    {
                        db.sp_ChinhSuaNV(nv.MaNV, nv.TenNV, nv.DiaChi, nv.Email, nv.SDT, nv.UserName, nv.Password, nv.MaCV, nv.HinhAnh);
                    }
                    db.SaveChanges();
                    TempData["messageAlert"] = "success0";
                    TempData["tennv"] = nv.TenNV;

                }
                catch (Exception e)
                {
                    TempData["messageAlert"] = "error0";
                    TempData["tennv"] = nv.TenNV;
                    TempData["mess"] = e.InnerException.Message;
                }
                return RedirectToAction("DSKH");
            }
            return HttpNotFound();
        }
        //Xóa nhân viên
        [HttpPost]
        public ActionResult XoaNV(string MaNV)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.sp_XoaNV(MaNV);
                    db.SaveChanges();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json(new { success = false, nd = e.InnerException.Message}, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}