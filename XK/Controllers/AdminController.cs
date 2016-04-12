using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XK.Models;
using XK.Tools;

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
            var res = from s in mdb.xk_Stus select s;
            return PartialView(res);
        }
        #endregion

        /// <summary>
        /// 添加课程
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCourse()
        {
            return PartialView();
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteCourse()
        {
            return PartialView();
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
        public ActionResult PrivilegeSetting()
        {
            return PartialView();
        }
    }
}
