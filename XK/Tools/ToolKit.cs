using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XK.Tools
{
    public class ToolKit
    {
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
    }
}