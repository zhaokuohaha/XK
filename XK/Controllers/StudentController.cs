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
		/// <summary>
		/// 执行选课动作
		/// </summary>
		/// <returns></returns>
		public ActionResult doSelectCourse(string c_id)
		{
			string currentTerm = Tools.ToolKit.CurrentTerm();

			ViewBag.Term = currentTerm;
			/*选课逻辑:
			1. 必须是当前学期的课程
			2. 选过的课不能再选
			3. 有时间冲突的课不能再选
			4. 达到人数上限的课不能再选
			*/

			var course = mdb.xk_Courses.FirstOrDefault(m => m.cor_id == c_id);
			//学期, 人数
			if (!course.cor_trem.Equals(currentTerm) || course.cor_currentnum>course.cor_maxnum)
			{
				ViewBag.result = "false";
				return PartialView();
			}
			int uid = int.Parse(System.Web.HttpContext.Current.Session["uid"].ToString());
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
							cid = ress.cor_id,
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
