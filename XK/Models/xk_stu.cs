using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace XK.Models
{
    /// <summary>
    /// 学生类
    /// </summary>
    public class xk_Stu
    {
        /// <summary>
        /// 学号
        /// </summary>
        [Key]
        public string stu_id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string stu_name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string stu_sex { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public string stu_major { get; set; }
        /// <summary>
        /// 出生日期 
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime stu_birth{ get; set; }
        /// <summary>
        /// 班级
        /// </summary>
        public string stu_Cla_id { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string stu_tel { get; set; }
    }

    /// <summary>
    /// 学生表上下文
    /// </summary>
    public class xk_StuDBContext : DbContext
    {
       public DbSet<xk_Stu> xk_Stus { get; set; }
        /// <summary>
        /// 绑定数据库表
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<xk_Stu>().ToTable("xk_stus"));
            base.OnModelCreating(modelBuilder);
        }
    }
}