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

        ModelDbContext udb = new ModelDbContext();
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
            string uid = f["studyid"];
            string psw = f["password"];
			string utype = f["u_type"];
			switch (utype)
			{
				
				case "student":
					var user = udb.xk_Stus.FirstOrDefault(s => s.stu_id == uid && udb.xk_Users.FirstOrDefault(u=>u.u_name==s.stu_name).u_password == psw);break;
				case "teacher":
					user = udb.xk_Stus.FirstOrDefault(s => s.stu_id == uid); break;
				case "admin":
					user = udb.xk_Stus.FirstOrDefault(s => s.stu_id == uid); break;
				case "user":
					user = udb.xk_Stus.FirstOrDefault(s => s.stu_id == uid); break;
			default:
					TempData["info"] = "发生未知错误";
					return View("Index");

					Session["username"] = usr;
           
            if (user.Count<User>() == 0)
            {
                TempData["info"] = "登录失败,用户名或者密码错误";
                return RedirectToAction("Index");
            }
            else
            {
                userEntity = user.First<User>();
				//将用户信息写入session
				System.Web.HttpContext.Current.Session.Add("uid", userEntity.u_id);
				TempData["value"] = userEntity.u_name;
                
                }
            }                
        }  
    }
}
