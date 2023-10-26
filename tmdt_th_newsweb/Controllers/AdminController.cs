using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tmdt_th_newsweb.App_Start;
using tmdt_th_newsweb.Models;

namespace tmdt_th_newsweb.Controllers
{
    [Authentication(MaChucVu = "Admin")]
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
            var dsbv = db.BaiViets.ToList();
            return View(dsbv);
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
    }
}