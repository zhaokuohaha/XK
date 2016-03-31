using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XK.Tools;
using XK.Models;
using System.Linq;

namespace XK.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        UserDBContext udb;
        public HomeController()
        {
            udb = new UserDBContext();
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection f)
        {
            TempData["info"] = "注册失败,用户已存在";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string usr = f["studyid"];
            string psw = f["password"];

            var user = from u in udb.User
                       where u.u_name == usr && u.u_password == psw
                       select u;
            if (user.Count<User>() == 0)
            {
                TempData["info"] = "登录失败,用户名或者密码错误";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData.Model = user;
                return View(); 
            }                
        }
    }
}
