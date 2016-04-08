using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XK.Models;

namespace XK.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /SelectCourse/
        xk_CourseDBContext course = new xk_CourseDBContext();

        /// <summary>
        /// 主页, 这里还没用到, 估计到时候直接返回login, 或者写一个一样的页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 选课
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectCourse()
        {
            var res = from c in course.xk_Courses orderby c.cor_id descending select c.cor_trem;
            ViewBag.term = res.ToList();
            
            ViewBag.term.Sort();
            
            ViewBag.x = "testString";

            //UserDBContext cdb = new UserDBContext();
            //var res = from c in cdb.User select c.u_id;
            //ViewBag.term = res.ToList<int>();

            return View();
        }

        /// <summary>
        /// 退课
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteCourse()
        {
            return View();
        }

        /// <summary>
        /// 查看课程
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowCourse()
        {
            return View();
        }

        /// <summary>
        /// 查看课表
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowTimetable()
        {
            return View();
        }


        /// <summary>
        /// 查看成绩
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowScore()
        {
            return View();
        }
    }
}
