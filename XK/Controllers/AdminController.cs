using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XK.Models;
using XK.Tools;
using Newtonsoft.Json.Linq;
using System.IO;
namespace XK.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// 上下文模型对象
        /// </summary>
        ModelDbContext mdb = new ModelDbContext();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View("~/Views/Home/adminLogin.cshtml");
        }
# region 查看学生, 返回前100条数据, 高级点说可以根据不同的情况返回不同的查询结果
        /// <summary>
        /// 查询学生
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        public ActionResult ShowStudent()
        {
            var res = from s in mdb.xk_Stus select s ;
            return PartialView(res);
        }
        #endregion

        /// <summary>
        /// 返回开通课程视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCourseItem()
        {
            return PartialView();
        }

        /// <summary>
        /// 处理开通课程请求
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        public string DoAddCourseItem(FormCollection fc)
        {
            string ciid = fc["ciid"];
            string ciname = fc["ciname"];
            string cidp = fc["cidp"];
            string cixf = fc["cixf"];
            var resc = from sci in mdb.xk_CourseItems
                       where sci.cori_id == ciid
                       select sci.cori_id;
            if(resc.Count() > 0)
            {
                return "课程已存在!";
            }
            xk_CourseItem ci = new xk_CourseItem
            {
                cori_id = ciid,
                cori_dpt_id = cidp,
                cori_name = ciname,
                cori_xuefen = cixf
            };
            mdb.xk_CourseItems.Add(ci);
            mdb.SaveChanges();
            return "课程" + ciname + "添加成功";
        }



        /// <summary>
        /// 返回添加课程视图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCourse()
        {
            return PartialView();
        }

        /// <summary>
        /// 处理添加课程请求
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        public string DoAddCourse(FormCollection fc)
        {
            string cid = fc["cid"].ToString();
            string tid = fc["ctch"].ToString();
            var istea = from t in mdb.xk_Teachers where t.tch_id.Equals(tid) select t.tch_id;
            if (istea.Count() <= 0)
            {
                return "教师号不存在, 请重新输入";
            }
            var iscor = from c in mdb.xk_CourseItems where c.cori_id.Equals(cid) select c.cori_id;
            if (iscor.Count() <= 0)
            {
                return "课程不存在, 请开通课程";
            }
            xk_Course xc = new xk_Course
            {
                cor_id = fc["cid"],
                cor_iddr = fc["ciddr"],
                cor_tec_id = fc["ctch"],
                cor_type = fc["ctype"],
                cor_time = fc["ctime"],
                cor_trem = fc["cterm"]
            };
            mdb.xk_Courses.Add(xc);
            mdb.SaveChanges();
            return "添加成功";
        }

        /// <summary>
        /// 返回删除课程视图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteCourse()
        {          
            return PartialView();
        }

        /// <summary>
        /// 选课课程, 返回一张课程列表, 管理员选择课程进行好删除
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        public ActionResult SelectDeleteCourse(FormCollection fc)
        {
            ViewBag.tname = fc["tname"];
            IEnumerable<string> tnames = from t in mdb.xk_Teachers
                           where t.tch_name == fc["tname"]
                           select t.tch_id;
            ModelDbContext cs = new ModelDbContext();
            foreach(string t in tnames)
            {
                var resc = from c in mdb.xk_Courses
                           where c.cor_tec_id == t
                           select c;
                cs.xk_Courses.AddRange(resc);
            }
            return PartialView(cs.xk_Courses);
        }

        /// <summary>
        /// 删除课表, 真正的动作在这里
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        public string DoDeleteCourse(FormCollection fc)
        {
            return "删除成功";
        }

        /// <summary>
        /// 修改课程
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateCourse()
        {
            return PartialView();
        }

        /// <summary>
        /// 权限设置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult PrivilegeSetting()
        {
           
            //是否可以选课
            var s = from r in mdb.xk_Settings where r.st_name == "CanSelectCourse" select r.st_value;
            string isS = s.FirstOrDefault();
            ViewBag.CanSelectCourse = (isS == null) ? false : true;

            //是否可以录入成绩
            s = from r in mdb.xk_Settings where r.st_name == "CanUpdateScore" select r.st_value;
            string isU = s.FirstOrDefault();
            ViewBag.CanUpdateScore = (isS == null) ? false : true;

            return PartialView();
        }

        /// <summary>
        /// 设置权限, 刷新选课/录入成绩权限
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        public PartialViewResult DoPrivilegeSetting(FormCollection fc)
        {
            //允许选课
            string CanSelectCourse = fc["CanSelectCourse"];
            //录入成绩
            string CanUpdateScore = fc["CanUpdateScore"];

            xk_Setting xs = mdb.xk_Settings.FirstOrDefault(m => m.st_name == CanSelectCourse);
            //数据库中是否存在记录
            if (xs==null)
            {
                mdb.xk_Settings.Add(new xk_Setting { st_name = "CanSelectCourse", st_value = CanSelectCourse });
                mdb.SaveChanges();
            }
            else
            {
                xs.st_value = CanSelectCourse;
                mdb.SaveChanges();
            }
            xs = mdb.xk_Settings.FirstOrDefault(m => m.st_name.Equals(CanUpdateScore));
            if (xs == null)
            {
                mdb.xk_Settings.Add(new xk_Setting { st_name = "CanUpdateScore", st_value = CanUpdateScore });
                mdb.SaveChanges();
            }
            else
            {
                xs.st_value = CanUpdateScore;
                mdb.SaveChanges();
            }
            return PartialView();
        }
    }
}
