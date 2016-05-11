using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XK.Tools
{
    public class ToolKit
    {
		/// <summary>
		/// 是否发生时间冲突	
		/// </summary>
		/// <param name="existsTime">已经选过课的时间</param>
		/// <param name="applyTime">申请选课的时间</param>
		/// <returns></returns>
		public static bool timeClash(string existsTime , string applyTime)
		{
			//如果不是同一天, 说明不冲突
			if (existsTime.Substring(0, 1) != applyTime.Substring(0, 1))
				return false;
			//例如: exists: 1-3, apply: 4-5  3<4; 反之亦然, 即 y1<x2 或者 y2<x1即认为没有冲突
			string[] extsts = existsTime.Substring(1).Split('-');
			string[] apply = applyTime.Substring(1).Split('-');
			if (int.Parse(apply[1]) < int.Parse(extsts[0]) || int.Parse(extsts[1]) < int.Parse(apply[0]))
				return false;
			return true;
		}
		/// <summary>
		/// 分割学期字符串
		/// </summary>
		/// <param name="term">学期字符串, 如2012-2013冬季</param>
		/// <returns>字符串数组如{{2012-2013},{冬季}}</returns>
		public static string[] SplitTerm(string term)
        {
            string[] a = new string[2];
            a[0] = term.Substring(0, 9);
            a[1] = term.Substring(9, 2);
            return a;
        }

        /// <summary>
        /// 返回当前学期
        /// </summary>
        /// <returns></returns>
        public static string CurrentTerm()
        {
            string ct="";
            ct += DateTime.Now.Year;
            switch(DateTime.Now.Month)
            {
                case 2:
                    ct += "春季";break;
                case 4:
                    ct += "夏季";break;
                case 6:
                    ct += "秋季";break;
                case 11:
                    ct += "冬季";break;
                default:
                    ct += "";break;
            }
            Console.WriteLine(ct);
            return ct;
           
        }
    }
}