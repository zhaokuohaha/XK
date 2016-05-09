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
		ModelDbContext mdb = new Models.ModelDbContext();
        //
        // GET: /SelectCourse/
      
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

		//多表查询--get
		[HttpPost]
		public ActionResult SelectItem(FormCollection fc)
		{
			string curname = fc["corname"];
			var query = from res in mdb.xk_CourseItems
						join ress in mdb.xk_Courses on res.cori_id equals ress.cor_id
						where res.cori_name == curname || res.cori_id == curname
						select new Models.SelectCourseItem()
						{
							cid = ress.cor_cid,
							cname = res.cori_name,
							caddr = ress.cor_iddr,
							ctec = ress.cor_tec_id,
							ctime = ress.cor_time
						};
			return PartialView(query);
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
            var res = from c in mdb.xk_Courses orderby c.cor_id descending select c.cor_trem;
            ViewBag.term = res.ToList();
            ViewBag.term.Sort();
            return View();
        }
    }
}
