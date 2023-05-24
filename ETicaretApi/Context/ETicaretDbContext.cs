

using ETicaretApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace ETicaretApi.Context
{

    //EntityFrameowrkCore ORM yi kullanmak için DBContext classtan kalıtım alıyoruz
    public class ETicaretDbContext : DbContext
    {

        //Aşağıda Dbset propertysi ile Entity Classlarımızı veritabanı tabloları olarak kullanacağımzıı belirtiyoruz.
        //Eklediklerimizi veritabnında tablo olarak kullanacağız.
        //DBset den sonra gelen kısım tablonun adını belirleyecek.
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Banners> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        //Aşağıda Hangi veritabanına bağlanacağımızı belirtiyoruz ve ilgili connection stringi giriyoruz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Deneme;");
        }

    }
}





