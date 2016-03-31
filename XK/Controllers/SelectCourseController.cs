using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XK.Models;

namespace XK.Controllers
{
    public class SelectCourseController : Controller
    {
        //
        // GET: /SelectCourse/
        xk_CourseDBContext course = new xk_CourseDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult viewTimeTable(int u_id)
        {
           // var result = from c in  course.xk_Courses where c.
            return View();
        }

    }
}
