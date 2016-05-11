﻿using System;
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
			int ulevel = Convert.ToInt32(f["u_type"]);

			var user = udb.xk_Users.FirstOrDefault(u => u.u_rid == uid && u.u_password == psw && u.u_level == ulevel);

			if (user == null)
            {
                TempData["info"] = "登录失败,用户名或者密码错误";
                return RedirectToAction("Index");
            }
            else
            {
				//将用户信息写入session
				System.Web.HttpContext.Current.Session["uid"] = uid;
				TempData["value"] = user.u_name;
				switch (user.u_level)
				{
					case 0:
						return View("usrLogin", user);
					case 1:
						return View("stuLogin", user);
					case 2:
						return View("tecLogin", user);
					case 3:
						return View("adminLogin", user);
					default:
						TempData["info"] = "发生未知错误";
						return View("Index");
				}
            }                
        }  
    }
}
