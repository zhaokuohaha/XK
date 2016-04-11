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
            string result = "<div class=\"panel panel-info\"><div class=\"panel-heading\">" +
           "查询结果: </div><div class=\"panel-body\"> 一共有 : " +
           count + " 名学生 </div></div >";
            return result;
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
            string result = "<div class=\"panel panel-info\"><div class=\"panel-heading\">" +
           "查询结果</div><div class=\"panel-body\"> 平均成绩: " +
           count + "</div></div >";
            return result;
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
            string qcontent = Request.Form["quotecontent"];
            string user = Session["username"] as string;
            string text = Request.Form["text"];
            Models.xk_quote q = new Models.xk_quote
            {
                q_user = user,
                q_content = qcontent
            };
            Models.ModelDbContext qdb = new Models.ModelDbContext();
            qdb.xk_quotes.Add(q);
            qdb.SaveChanges();
            string result = "<div class=\"panel panel-info\"><div class=\"panel-heading\">" +
           "您("+ user + ")成功留言</div><div class=\"panel-body\"> " +
           qcontent + "</div></div >";
            return result;
        }
    }
}
