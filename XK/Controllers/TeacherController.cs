using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XK.Models;
using XK.Tools;
namespace XK.Controllers
{
    public class TeacherController : Controller
    {
		
		public ModelDbContext mdb;
		public string teacherid;
		public string currentTerm;
		public TeacherController()
		{
			if (mdb == null)
				mdb = new ModelDbContext();
			if (teacherid == null)
				teacherid = System.Web.HttpContext.Current.Session["uid"] as string;
				//teacherid = Session["uid"] as string;
			if (currentTerm == null)
				currentTerm = ToolKit.CurrentTerm();
			currentTerm = "2012-2013冬季";
		}
        //
        // GET: /Teacher/

        public ActionResult Index(User user)
        {
            return View(user);
        }

		/// <summary>
		/// 显示教师课表
		/// </summary>
		/// <returns></returns>
		public ActionResult ShowTimeTable()
		{
			/*思路:
			1. 按照教师号,学期分组,
			2. 按上课时间分组
			*/

			var times = from co in mdb.xk_Courses
						where co.cor_tec_id == teacherid && co.cor_trem == currentTerm
						select new SelectCourseItem()
						{
							cid = co.cor_id,
							cname = mdb.xk_CourseItems.FirstOrDefault(cori => cori.cori_id == co.cor_id).cori_name,
							caddr = co.cor_iddr,
							ctime = co.cor_time,
						};
			ViewBag.tableJson = Json(times);
			return View(times);
		}


	}
}
