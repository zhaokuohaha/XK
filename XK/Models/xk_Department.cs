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

    /// <summary>
    /// 系 表上下文
    /// </summary>
    public class xk_DepartmentDBContext : DbContext
    {
       public DbSet<xk_Department> Department { get; set; }
        /// <summary>
        /// 绑定数据库表
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<xk_Teacher>().ToTable("xk_scores"));
            base.OnModelCreating(modelBuilder);
        }
    }
}