using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace XK.Models
{
    /// <summary>
    /// 班级
    /// 
    /// </summary>
    public class xk_Class
    {
        /// <summary>
        /// 班级号
        /// </summary>
        [Key]
        public string cla_id { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string cla_name { get; set; }
        /// <summary>
        /// 班级所在系号
        /// </summary>
        public string cla_dpt_id { get; set; }
        /// <summary>
        /// 班主任
        /// </summary>
        public string cla_header { get; set; }
    }

    /// <summary>
    /// 班级上下文
    /// </summary>
    public class xk_ClassDBContext : DbContext
    {
        DbSet<Models.xk_Class> xk_Classes { get; set; }
    }
}