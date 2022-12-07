using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(a =>
            {
                a.ToTable("Brands").HasKey(a => a.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.Name).HasColumnName("Name");

                a.HasMany(a => a.Models);
            });

            modelBuilder.Entity<Model>(b =>
            {
                b.ToTable("Modals").HasKey(a => a.Id);
                b.Property(b => b.Id).HasColumnName("Id");
                b.Property(b => b.BrandId).HasColumnName("BrandId");
                b.Property(b => b.Name).HasColumnName("Name");
                b.Property(b => b.DailyPrice).HasColumnName("DailyPrice");
                b.Property(b => b.ImageUrl).HasColumnName("ImageUrl");

                b.HasOne(b => b.Brand);
            });


            Brand[] brandSeedData = { new(1, "BMW"), new(2, "Mercedes") };
            modelBuilder.Entity<Brand>().HasData(brandSeedData);

            Model[] modelSeedData = { new(1, 1, "Series 1", 1500, ""), new(2, 1, "Series 2", 1200, ""), new(3, 2, "A180", 1000, "") };
            modelBuilder.Entity<Model>().HasData(modelSeedData);
        }
    }
}
