using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyWeb.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MyWebSiteDB") { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // OrderItem.SubTotal 為計算屬性，不對應欄位
            modelBuilder.Entity<OrderItem>().Ignore(x => x.SubTotal);

            // BlogPost → BlogCategory (單向導覽屬性)
            modelBuilder.Entity<BlogPost>()
                .HasRequired(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
