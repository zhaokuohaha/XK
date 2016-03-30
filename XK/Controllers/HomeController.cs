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
        FormCollection collection;
        public HomeController()
        {
            udb = new UserDBContext();
        }
        public ActionResult Index(FormCollection collection)
        {
            this.collection = collection;
            return View();
        }

        public ActionResult Login()
        {
            ViewData.Model = CheckUser();
            return View();
        }


        public object CheckUser()
        {
            string usr="";
            string psw="";

            var user = from u in udb.User
                       where u.u_name == usr || u.u_password == psw
                       select u;
            return user;
        }
    }
}
