using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace XK.Models
{
    public class xk_CourseItem
    {
        /// <summary>
        /// 课号
        /// </summary>
        [Key]
        public string cori_id { get; set; }
        /// <summary>
        /// 课名
        /// </summary>
        public string cori_name { get; set; }
        /// <summary>
        /// 学分
        /// </summary>
        public string cori_xuefen { get; set; }
        /// <summary>
        /// 开课院系
        /// </summary>
        public string cori_dpt_id { get; set; }

    }

    public class xk_CourseItemCDBContext : DbContext
    {
        public DbSet<xk_CourseItem> xk_CourseItems { get; set; }
    }
}