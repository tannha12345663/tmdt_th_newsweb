﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using tmdt_th_newsweb.Models;

namespace tmdt_th_newsweb.Controllers
{
    public class LoginUserController : Controller
    {
        TMDT_TH_newsWebEntities db = new TMDT_TH_newsWebEntities();
        // GET: LoginUser
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            var data = db.NhanViens.SingleOrDefault(s => s.UserName == User && s.Password == Pass);
            if (data == null)
            {
                TempData["error"] = "Tài khoản đăng nhập không đúng";
                return View("Login");
            }
            else
            {
                //add session
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["userNV"] = data;
                if (data.MaCV.ToString() == "Admin")
                {
                    TempData["error"] = "Đăng nhập thành công!";
                    //return View("Login");
                    return RedirectToAction("TrangChu", "Admin");
                }
                else
                {
                    TempData["error"] = "Chưa có chức vụ này trong hệ thông";
                    return View("Login");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginKH(string User, string Pass)
        {
            var data = db.KhachHangs.SingleOrDefault(s => s.UserName == User && s.Password == Pass);
            if (data == null)
            {
                TempData["messLG"] = "Tài khoản đăng nhập không đúng";
                return RedirectToAction("LRAccount", "KhachHang");
            }
            else
            {
                //add session
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["userKH"] = data;
                TempData["messLG"] = "Đăng nhập thành công!";
                //return View("Login");
                return RedirectToAction("TrangChu", "KhachHang");
            }
        }

        public ActionResult LogoutKH()
        {
            Session.Clear();//remove session
            FormsAuthentication.SignOut();
            return RedirectToAction("TrangChu", "KhachHang");
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult QuenMK()
        {
            return View();
        }
    }
}