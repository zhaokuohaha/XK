using System.Web.Mvc;
using System.Linq;
using System.Data.Linq;
namespace XK.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View("~/Views/Home/usrLogin.cshtml");
        }

        /// <summary>
        /// 查看学生人数
        /// </summary>
        /// <returns></returns>
        public string ShowNum()
        {
            Models.ModelDbContext sdb = new Models.ModelDbContext();
            var res = from s in sdb.xk_Stus select s.stu_name;
            int count = res.Count();
            return "共有" + count + "名学生";
        }

        /// <summary>
        /// 查看教师人数
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowTecNum()
        {
            Models.ModelDbContext tdb = new Models.ModelDbContext();
            var res = from s in tdb.xk_Teachers select s;
            ViewBag.count = res.Count();
            return PartialView(res);
        }

        /// <summary>
        /// 查看平均成绩
        /// </summary>
        /// <returns></returns>
        public string ShowAvgScore()
        {
            Models.ModelDbContext sdb = new Models.ModelDbContext();
            var res = from s in sdb.xk_Scores select s.sco_value;
            double count = res.Average();
            return "平均成绩: " + count;
        }

        /// <summary>
        /// 查看留言
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowQuote()
        {
            Models.ModelDbContext sdb = new Models.ModelDbContext();
            var res = from s in sdb.xk_quotes select s ;
            return View(res);
        }

        /// <summary>
        /// 留言
        /// </summary>
        /// <returns></returns>
        public string Quote(FormCollection fcq)
        {
            string qcontent = fcq["quotecontent"];
            Models.xk_quote q = new Models.xk_quote
            {
                q_user = "u12",
                q_content = qcontent
            };
            Models.ModelDbContext qdb = new Models.ModelDbContext();
            qdb.xk_quotes.Add(q);
            qdb.SaveChanges();
            return "success";
        }

        //public ActionResult ShowNum()
        //{
        //    return PartialView();
        //}

    }
}
