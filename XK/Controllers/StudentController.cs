using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using XK.Models;

namespace XK.Controllers
{
    public class StudentController : Controller
    {
		/// <summary>
		/// 数据库上下文
		/// </summary>
		ModelDbContext mdb = new Models.ModelDbContext();
		/// <summary>
		/// 用户id---存在session中(角色id)
		/// </summary>
		string uid = System.Web.HttpContext.Current.Session["uid"].ToString();
		/// <summary>
		/// 当前学期
		/// </summary>
		string currentTerm = Tools.ToolKit.CurrentTerm();
		

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
		public ActionResult doSelectCourse(FormCollection fc)
		{
			//课表主键
			int c_cid = Convert.ToInt32(fc["item.ccid"]);
			ViewBag.Term = currentTerm;
			/*选课逻辑:
			1. 必须是当前学期的课程
			2. 选过的课不能再选
			3. 有时间冲突的课不能再选
			4. 达到人数上限的课不能再选
			*/
			//课程对象
			var course = mdb.xk_Courses.FirstOrDefault(m => m.cor_cid == c_cid);
			//开放选课
			string canSelect = mdb.xk_Settings.First(m => m.st_name == "CanSelectCourse").st_value.ToString();
			
			//是否已经选过并且没有挂科
			var validCourse = from sc in mdb.xk_Scores
							  where (sc.sco_stu_id == uid 
								&& sc.sco_cor_id == course.cor_id 
								&& sc.sco_cor_term != currentTerm 
								&& sc.sco_value >= 60.0)
							  select sc;
			//mdb.xk_Scores.FirstOrDefault(m => m.sco_stu_id == uid && m.sco_cor_id == course.cor_id && m.sco_value >= 60.0);
			//获取所有已经选择的课程的上课时间:本学期
			//给你学生的学号, 怎么找出这个学生本学期上的课程
			//1. 找出该学生选修过的课程的 [课程号,教师号] 
			//2. 遍历课程号, 找出学期为本学期的课程
			//-->实现: Linq多表联接
			var courseTimes = from sc in mdb.xk_Scores
							  join co in mdb.xk_Courses
							  on new { cor_id = sc.sco_cor_id, cor_tec = sc.sco_tea_id } equals new { cor_id = co.cor_id, cor_tec = co.cor_tec_id }
							  where sc.sco_stu_id == uid && sc.sco_cor_term == currentTerm
							  select co.cor_time;

			//是否是有效的选课时间
			bool validSelectTime = true;
			foreach (var time in courseTimes)
			{
				if (Tools.ToolKit.timeClash(time.ToString(), course.cor_time))
				{
					validSelectTime = false;
					break;
				}
			}
			#region 不允许选课的情况
			if ((course.cor_trem != currentTerm)            //不是本学期
				|| (course.cor_currentnum > course.cor_maxnum)    //选课人数已满
				|| (canSelect != "true" )                         //没有开放选课
				|| (validCourse.Count()>0)							//已经选过并且没有挂科
				|| (validSelectTime == false))                    //选课时间冲突
			{
				if (course.cor_trem != currentTerm)
				{
					ViewBag.resultInfo = "不是本学期的课程";
				}
				if (course.cor_currentnum > course.cor_maxnum)
				{
					ViewBag.resultInfo = "选课人数已满";
				}
				if (canSelect != "true")
				{
					ViewBag.resultInfo = "选课时间未到";
				}
				if (validCourse.Count()>0)
				{
					ViewBag.resultInfo = "已经选过该课程";
				}
				if (validSelectTime == false)
				{
					ViewBag.resultInfo = "选课时间冲突";
				}
				ViewBag.result = "false";
				return PartialView();
			}
			#endregion
			//写到数据库
			mdb.xk_Scores.Add(new xk_Score
			{
				//学号
				sco_stu_id = uid,
				//课程号
				sco_cor_id = course.cor_id,
				sco_cor_term = currentTerm,
				sco_tea_id = course.cor_tec_id,
			});
			mdb.SaveChanges(); 
			ViewBag.resultInfo = "选课成功";
			ViewBag.result = "true";
			return PartialView();
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
			string currentTerm = Tools.ToolKit.CurrentTerm();
			var query = from res in mdb.xk_CourseItems
						join ress in mdb.xk_Courses on res.cori_id equals ress.cor_id
						where (res.cori_name == curname || res.cori_id == curname) //&& ress.cor_trem == currentTerm
						select new Models.SelectCourseItem()
						{
							cid = ress.cor_id,
							ccid = ress.cor_cid,
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
			var res = from sc in mdb.xk_Scores
					  where sc.sco_stu_id == uid && sc.sco_cor_term == currentTerm
					  join coi in mdb.xk_CourseItems
					  on sc.sco_cor_id equals coi.cori_id
					  select new SelectCourseItem()
					  {
						  ccid = sc.sco_id,
						  cid = coi.cori_id,
						  cname = coi.cori_name,
						  ctec = sc.sco_tea_id,
					  };
			return View(res);
        }

		/// <summary>
		/// 执行退课
		/// </summary>
		/// <param name="fc"></param>
		/// <returns></returns>
		public ActionResult doDeleteCourse(FormCollection fc)
		{
			try { 
				int scid = Convert.ToInt32(fc["item.ccid"]);
				mdb.xk_Scores.Remove(mdb.xk_Scores.Find(scid));
				mdb.SaveChanges();
				ViewBag.resultInfo = "退课成功";
			}
			catch(Exception ex)
			{
				ViewBag.resultInfo = "退课失败";
			}

			return View("doSelectCourse");
		}


        /// <summary>
        /// 查看课表
        /// </summary>
        /// <returns></returns>
        public string ShowTimetable()
        {
			var times = from sc in mdb.xk_Scores
						where sc.sco_stu_id == uid && sc.sco_cor_term == currentTerm
						join co in mdb.xk_Courses
						on new { teacher = sc.sco_tea_id, term = sc.sco_cor_term, course = sc.sco_cor_id }
						equals new { teacher = co.cor_tec_id, term = co.cor_trem, course = co.cor_id }
						select new
						{
							cor = mdb.xk_CourseItems.FirstOrDefault(f => f.cori_id == sc.sco_cor_id).cori_name,
							tea = mdb.xk_Teachers.FirstOrDefault(f => f.tch_id == sc.sco_tea_id).tch_name,
							time = co.cor_time,
						};
			//var res = new JsonResult();
			//res.Data = times;
			//res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;//允许使用GET方式获取，否则用GET获取是会报错。
			//return res;
			//--------------以下是返回字符串的情况
			StringBuilder result = new StringBuilder("{\"course\":[");
			foreach (var time in times)
			{
				result.Append("{\"courseInfo\" : [\"" + time.cor + "\",\"" + time.tea + "\"],\"sksj\" : \"" + time.time + "\"},");
			}
			result.Remove(result.Length - 1, 1);
			result.Append("]}");
			return result.ToString();
			//return Json(result);
		}


        /// <summary>
        /// 查看成绩
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowScore()
        {
			var res = from sc in mdb.xk_Scores
					  where sc.sco_stu_id == uid && sc.sco_cor_term == currentTerm
					  join coi in mdb.xk_CourseItems
					  on sc.sco_cor_id equals coi.cori_id
					  select new SelectCourseItem()
					  {
						  ccid = sc.sco_id,
						  cid = coi.cori_id,
						  cname = coi.cori_name,
						  ctec = sc.sco_tea_id,
						  cscore = sc.sco_value,
					  };
			return View(res);
		}
    }
}
