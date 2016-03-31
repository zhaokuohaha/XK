using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace XK.Models
{
    /// <summary>
    /// 成绩表
    /// </summary>
    public class xk_Score
    {
        /// <summary>
        /// 学号
        /// </summary>
        [Key]
        public string sco_stu_id { get; set; }
        /// <summary>
        /// 课程号
        /// </summary>
        public string sco_cor_id { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string sco_stu_name { get; set; }
        ///// <summary>
        ///// 课程名称
        ///// </summary>
        //public string sco_cor_name { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public double sco_value { get; set; }
    }

    /// <summary>
    /// 成绩表上下文
    /// </summary>
    public class xk_ScoreDBContext : DbContext
    {
        DbSet<Models.xk_Score> xk_Scores { get; set; }
    }
}