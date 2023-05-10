﻿

using ETicaretApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace ETicaretApi.Context
{
    public class ETicaretDbContext : DbContext
    {
        public DbSet<Banner> Banner { get; set; }
        public DbSet<BannerList> Banners { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products  { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Deneme;");
        }

    }
}




