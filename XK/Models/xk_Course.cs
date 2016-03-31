using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace XK.Models
{
    /// <summary>
    /// 开课表
    /// </summary>
    public class xk_Course
    {
        /// <summary>
        /// 课程号
        /// </summary>
        [Key]
        public string cor_id { get; set; }
        /// <summary>
        /// 课程名
        /// </summary>
        public string cor_name { get; set; }
        /// <summary>
        /// 学分
        /// </summary>
        public string cor_xuefen { get; set; }
        /// <summary>
        /// 教师代号
        /// </summary>
        public string cor_tec_id { get; set; }
        /// <summary>
        /// 开课系代号
        /// </summary>
        public string cor_dpt_id { get; set; }
        /// <summary>
        /// 上课节次
        /// </summary>
        public string cor_time { get; set; }
        /// <summary>
        /// 上课地点
        /// </summary>
        public string cor_iddr { get; set; }
        /// <summary>
        /// 学期
        /// </summary>
        public string cor_trem { get; set; }
        /// <summary>
        /// 学年
        /// </summary>
        public string cor_year { get; set; }
        /// <summary>
        /// 课程类别
        /// </summary>
        public string cor_type { get; set; }
        
    }

    /// <summary>
    /// 开课表上下文
    /// </summary>
    public class xk_CourseDBContext : DbContext
    {
        public DbSet<Models.xk_Course> xk_Courses { get; set; }
    }
}