using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainModels;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DataService
{
    public class SovaContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        ////    modelBuilder.Entity<Post>().ToTable("posts");
        ////    modelBuilder.Entity<Post>().Property(c => c.Id).HasColumnName("id");
        ////    modelBuilder.Entity<Post>().Property(c => c.Title).HasColumnName("title");

        ////    base.OnModelCreating(modelBuilder);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=wt-220.ruc.dk;database=jakhjo;uid=jakhjo;pwd=ugA7EpaN");
            //optionsBuilder.UseMySql("server=localhost;database=jakhjo;uid=jannik;pwd=password");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
