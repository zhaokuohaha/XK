using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace XK.Models
{
    /// <summary>
    /// 成绩表
    /// </summary>
    public class xk_Score
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [Key]
        public int sco_id { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public string sco_stu_id { get; set; }
        /// <summary>
        /// 上课学期
        /// </summary>
        public string sco_cor_term { get; set; }
        /// <summary>
        /// 教师id
        /// </summary>
        public string sco_tea_id { get; set; }
        ///// <summary>
        ///// 课程名称
        ///// </summary>
        //public string sco_cor_name { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public double sco_value { get; set; }
    }
        
    /// <summary>
    /// 成绩表上下文
    /// </summary>
    public class xk_ScoreDBContext : DbContext
    {
        public DbSet<Models.xk_Score> xk_Scores { get; set; }
        /// <summary>
        /// 绑定数据库表
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<xk_Score>().ToTable("xk_scores"));
            base.OnModelCreating(modelBuilder);
        }
    }
}