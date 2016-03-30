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
        string dpt_id { get; set; }
        [Required]
        string dpt_name { get; set; }
        string dpt_header { get; set; }
    }

    /// <summary>
    /// 系 表上下文
    /// </summary>
    public class DepartmentDBContext : DbContext
    {
       public DbSet<Models.xk_Department> Department { get; set; }
    }
}