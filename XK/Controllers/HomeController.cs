using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XK.Tools;
using XK.Models;

namespace XK.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        UserDBContext udb= new UserDBContext();
        static User userEntity = new User();

        /// <summary>
        /// 主页面,处理用户登录和注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 处理用户注册
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(FormCollection f)
        {
            TempData["info"] = "注册失败,用户已存在";
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 处理用户登录, 根据不同的用户类型返回不同的页面视图
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
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
                userEntity = user.First<User>();
                TempData["value"] = userEntity.u_name;
                switch( userEntity.u_level){
                    case 0:
                        return View("usrLogin",userEntity);
                    case 1:
                        return View("stuLogin",userEntity);
                    case 2:
                        return View("tecLogin",userEntity);
                    case 3:
                        return View("adminLogin",userEntity);
                    default:
                        TempData["info"] = "发生未知错误";
                        return View("Index");
                }
            }                
        }   
    }
}
