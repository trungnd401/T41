using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T41.Areas.Admin.Model.BusinessModel;

namespace T41.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        DTPowerDBContext db = new DTPowerDBContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["fullname"] = null;
            Session["avatar"] = null;
            return  RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult Login(string userid, string password)
        {
            //admin 123123
            string passwordMd5 = Common.Security.CreatPassWordHash(userid + password + "6688");
            var user = db.Administrator.SingleOrDefault(x => x.UserName == userid && x.PassWord == passwordMd5 && x.Active == 1);
            if (user != null)
            {
                Session["userid"] = user.UserId;
                Session["username"] = user.UserName;
                Session["fullname"] = user.FullName;
                Session["avatar"] = user.Avatar;
                //  Response.Redirect("Index");
                return RedirectToAction("Index");
            }
            ViewBag.error = "Đăng nhập sai hoặc không có quyền truy cập";
            // Truy vấn username and password
            //if (userid == "Admin" && password == "1111")
            //{
            //    Session["userid"] = "Admin";
            //    Session["username"] = "Admin";
            //    Session["fullname"] = "Lucy Tran";
            //    Session["avatar"] = "";
            //    return RedirectToAction("Index");
            //}
            //else
            //    ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu.";
            return View();
        }
        public ActionResult NotificationAuthorize()
        {
            return View();
        }
        public EmptyResult Alive()
        {
            return new EmptyResult();
        }
    }
}