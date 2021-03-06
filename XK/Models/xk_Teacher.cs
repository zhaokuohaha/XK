﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace XK.Models
{
    /// <summary>
    /// 教师表
    /// </summary>
    public class xk_Teacher
    {
        /// <summary>
        /// 教师号
        /// </summary>
        [Key]
        public string tch_id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string tch_name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string tch_sex { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DataType(DataType.PhoneNumber)]
        public string tch_tel { get; set; }
        /// <summary>
        /// 系编号
        /// </summary>
        public string tch_dpt_id { get; set; }
        /// <summary>
        /// 教师职位
        /// </summary>
        public string tch_pos { get; set; }
    }
}