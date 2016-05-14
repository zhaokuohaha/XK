﻿using System;
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
			currentTerm = "2013-2014秋季";
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
			var times = from co in mdb.xk_Courses
						where co.cor_tec_id == teacherid && co.cor_trem == currentTerm
						select new SelectCourseItem()
						{
							ccid = co.cor_cid,
							cid = co.cor_id,
							cname = mdb.xk_CourseItems.FirstOrDefault(cori => cori.cori_id == co.cor_id).cori_name,
							caddr = co.cor_iddr,
							ctime = co.cor_time,
						};
			ViewBag.tableJson = Json(times);
			return View(times);
		}

		/// <summary>
		/// 查看选课学生母版页---选择课程
		/// </summary>
		/// <returns></returns>
		public ActionResult ShowStudentsIndex()
		{
			return View();
		}

		public PartialViewResult ShowStudents(xk_Course course)
		{
			string cor_id = mdb.xk_Courses.Find(course.cor_cid).cor_id;
			//课程名
			string corname = mdb.xk_CourseItems.Find(cor_id).cori_name;
			ViewBag.corid = cor_id;
			ViewBag.corname = corname;

			var res = from sc in mdb.xk_Scores
					  where sc.sco_tea_id == teacherid && sc.sco_cor_term == currentTerm && sc.sco_cor_id == cor_id
					  join stu in mdb.xk_Stus
					  on sc.sco_stu_id equals stu.stu_id
					  select new StudentInfoModel()
					  {
						  stu_id = stu.stu_id,
						  stu_name = stu.stu_name,
						  stu_score = sc.sco_value,
						  stu_major = stu.stu_major,
					  };
			return PartialView(res);
		}

		/// <summary>
		/// 录入成绩首页
		/// </summary>
		/// <returns></returns>
		public ActionResult InsertScoreIndex()
		{
			return View();
		}
		/// <summary>
		/// 录入成绩----显示学生名单
		/// </summary>
		/// <param name="course"></param>
		/// <returns></returns>
		public PartialViewResult InsertScore(xk_Course course)
		{
			//课程号
			string corid = mdb.xk_Courses.Find(course.cor_cid).cor_id;
			//课程名
			string corname = mdb.xk_CourseItems.Find(corid).cori_name;
			ViewBag.corid = corid;
			ViewBag.corname = corname;
			var res = from sc in mdb.xk_Scores
					  where sc.sco_tea_id == teacherid && sc.sco_cor_term == currentTerm && sc.sco_cor_id == corid
					  join stu in mdb.xk_Stus
					  on sc.sco_stu_id equals stu.stu_id
					  select new StudentInfoModel()
					  {
						  //cor_id = corid,
						  //cor_name = corname,
						  stu_id = stu.stu_id,
						  stu_name = stu.stu_name,
						  stu_score = sc.sco_value,
						  stu_major = stu.stu_major
					  };
			return PartialView(res);
		}

		/// <summary>
		/// 录入成绩----写入数据库
		/// </summary>
		/// <returns></returns>
		public ActionResult doInsertScore(IEnumerable<StudentInfoModel> stu)
		{
			return View(stu);
		}

		/// <summary>
		/// 修改成绩首页
		/// </summary>
		/// <returns></returns>
		public ActionResult UpdateScore()
		{
			return View();
		}
	}
}
