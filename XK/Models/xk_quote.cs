using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Linq;
using System.Web;

namespace XK.Models
{
    public class xk_quote
    {
        [Key]
        public int q_id { get; set; }
        public string q_user { get; set; }
        public string q_content { get; set; }
    }

    public class xk_quoteDBContext : DbContext
    {
        public DbSet<xk_quote> xk_quotes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<xk_quote>().ToTable("xk_quote"));
            base.OnModelCreating(modelBuilder);
        }
    }
    
}