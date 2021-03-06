﻿using System;
using System.Data.Entity;
using MySql.Data;
using MySql.Data.Entity;
using MySql.Web.Security;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace XK.Models
{
    /// <summary>
    /// 用户实体, 用户可以注册,登录,查看整体数据.没有个人数据
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [Key]
        public int u_id { get; set; }

		/// <summary>
		/// 用户的角色id: 即学号,工号等等
		/// </summary>
		public string u_rid { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string u_name { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string u_password { get; set; }
        /// <summary>
        /// 用户级别
        /// </summary>
        public int u_level { get; set; }
    }
}