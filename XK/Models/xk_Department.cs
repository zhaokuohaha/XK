using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace XK.Models
{
    /// <summary>
    /// 系
    /// </summary>
    public class xk_Department
    {
        /// <summary>
        /// 系号
        /// </summary>
        [Key]
        [Required]
        public string dpt_id { get; set; }
        /// <summary>
        /// 系名
        /// </summary>
        [Required]
        public string dpt_name { get; set; }
    }
}