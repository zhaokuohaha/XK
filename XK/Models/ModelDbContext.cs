using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace XK.Models
{
    public class ModelDbContext : DbContext
    {
        /// <summary>
        /// 教师表 上下文
        /// </summary>
        public DbSet<xk_Teacher> xk_Teachers { get; set; }

        /// <summary>
        /// 选课课表上下文
        /// </summary>
        public DbSet<Models.xk_Course> xk_Courses { get; set; }

        /// <summary>
        /// 班级表上下文
        /// </summary>
        DbSet<Models.xk_Class> xk_Classes { get; set; }

        /// <summary>
        /// 普通用户上下文
        /// </summary>
        public DbSet<Models.User> xk_Users { get; set; }

        /// <summary>
        /// 开课表上下文
        /// </summary>
        public DbSet<xk_CourseItem> xk_CourseItems { get; set; }

        /// <summary>
        /// 系表上下文
        /// </summary>
        public DbSet<xk_Department> xk_Departments { get; set; }

        /// <summary>
        /// 留言表上下文
        /// </summary>
        public DbSet<xk_quote> xk_quotes { get; set; }

        /// <summary>
        /// 成绩表上下文
        /// </summary>
        public DbSet<Models.xk_Score> xk_Scores { get; set; }

        /// <summary>
        /// 学生表上下文
        /// </summary>
        public DbSet<xk_Stu> xk_Stus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<xk_Teacher>().ToTable("xk_teachers"));
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<xk_Course>().ToTable("xk_courses"));
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<xk_Class>().ToTable("xk_classs"));
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<User>().ToTable("users"));
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<xk_CourseItem>().ToTable("xk_courseitems"));
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<xk_quote>().ToTable("xk_quote"));
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<xk_Score>().ToTable("xk_scores"));
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<xk_Stu>().ToTable("xk_stus"));
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<xk_Department>().ToTable("xk_departments"));
            base.OnModelCreating(modelBuilder);
        }
    }
}