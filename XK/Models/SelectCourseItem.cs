using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XK.Models
{
    public class SelectCourseItem
    {
        /// <summary>
        /// 课程表id ,  可以唯一确定一条数据
        /// </summary>
        public string ccid { get; set; }

		/// <summary>
		/// 课程号
		/// </summary>
		public string cid { get; set; }
        /// <summary>
        /// 课名
        /// </summary>
        public string cname { get; set; }
        /// <summary>
        /// 任课教师号
        /// </summary>
        public string  ctec{ get; set; }
        /// <summary>
        /// 上课时间
        /// </summary>
        public string ctime { get; set; }
        /// <summary>
        /// 上课地点
        /// </summary>
        public string caddr { get; set; }
    }
}