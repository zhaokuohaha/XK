using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XK.Models
{
    /// <summary>
    /// 设置表, 提供给管理员做其他设置用, 存储格式为name-value
    /// </summary>
    public class xk_Setting
    {
        /// <summary>
        /// id  做主键用
        /// </summary>
        [Key]
        public int st_id { get; set; }
        /// <summary>
        /// 设置的名称
        /// </summary>
        public string st_name { get; set; }
        /// <summary>
        /// 设置的值
        /// </summary>
        public string st_value { get; set; }
    }
}