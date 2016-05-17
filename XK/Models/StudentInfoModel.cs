using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace XK.Models
{
	public class StudentInfoModel
	{
		/// <summary>
		/// 成绩表id
		/// </summary>
		public string sco_id { get; set; }
		/// <summary>
		/// 课程号
		/// </summary>
		public string cor_id { get; set; }
		/// <summary>
		/// 课程名
		/// </summary>
		public string cor_name { get; set; }
		/// <summary>
		/// 当前学期
		/// </summary>
		public string cor_term { get; set; }
		/// <summary>
		/// 学生学号
		/// </summary>
		public string stu_id { get; set; }
		/// <summary>
		/// 学生姓名
		/// </summary>
		public string stu_name { get; set; }
		/// <summary>
		/// 学生专业
		/// </summary>
		public string stu_major { get; set; }
		/// <summary>
		/// 学生成绩
		/// </summary>
		public double stu_score { get; set; }
	}
}