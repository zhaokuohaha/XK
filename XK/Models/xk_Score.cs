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
        /// 主键id
        /// </summary>
        [Key]
        public int sco_id { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public string sco_stu_id { get; set; }
        /// <summary>
        /// 上课学期
        /// </summary>
        public string sco_cor_term { get; set; }

		/// <summary>
		/// 课程号
		/// </summary>
		public string sco_cor_id { get; set; }
        /// <summary>
        /// 教师id
        /// </summary>
        public string sco_tea_id { get; set; }
        ///// <summary>
        ///// 课程名称
        ///// </summary>
        //public string sco_cor_name { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public double sco_value { get; set; }
    }
}