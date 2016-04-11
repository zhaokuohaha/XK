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
        ModelDbContext course = new ModelDbContext();

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
            ViewBag.Term = Tools.ToolKit.CurrentTerm();
            return View();
        }
        public ActionResult SelectItem()
        {
            
            ViewBag.name = "1";
            return View();
        }
        [HttpPost]
        public ActionResult SelectItem(FormCollection fc)
        {
            string curname = fc["corname"];
            ModelDbContext cidb = new ModelDbContext();
            ModelDbContext cdb = new ModelDbContext();

           var res = from c in cdb.xk_Courses where c.cor_id.Equals(curname) select c;
#warning 多表查询bug:The specified LINQ expression contains references to queries that are associated with different contexts
            #region 多表查询有bug, 未解决
            //查找用户输入对应的课程
            //List<SelectCourseItem> res = new List<SelectCourseItem>();
             //var res = from c in cdb.xk_Courses
             //      join ci in cidb.xk_CourseItems on c.cor_id equals ci.cori_id
             //      //where ci.cori_id.Equals(curname) || ci.cori_name.Equals(curname)
             //      select new SelectCourseItem
             //      {
             //          cid = ci.cori_id,
             //          cname = c.cor_id,
             //          ctec = c.cor_tec_id,
             //          ctime = c.cor_time,
             //          caddr = c.cor_iddr
             //      };
            #endregion
            return PartialView(res);
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
            var res = from c in course.xk_Courses orderby c.cor_id descending select c.cor_trem;
            ViewBag.term = res.ToList();
            ViewBag.term.Sort();
            return View();
        }
    }
}
