using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
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
        /// 开课表主键id
        /// </summary>
        [Key]
        public int cor_cid { get; set; }
        /// <summary>
        /// 课程号
        /// </summary>
        public string cor_id { get; set; }
        ///// <summary>
        ///// 课程名
        ///// </summary>
        //public string cor_name { get; set; }
        ///// <summary>
        ///// 学分
        ///// </summary>
        //public string cor_xuefen { get; set; }
        /// <summary>
        /// 教师代号
        /// </summary>
        public string cor_tec_id { get; set; }
        
        /// <summary>
        /// 上课节次
        /// </summary>
        public string cor_time { get; set; }
        /// <summary>
        /// 上课地点
        /// </summary>
        public string cor_iddr { get; set; }
        /// <summary>
        ///  学年 学期
        /// </summary>
        public string cor_trem { get; set; }
        /// <summary>
        /// 课程类别
        /// </summary>
        public string cor_type { get; set; }
        
    }
}