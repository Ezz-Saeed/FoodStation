using FoodCorner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace FoodCorner.Data
{
    public class AppDbContext : IdentityDbContext<TypeUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<IdentityUserLogin<string>>().HasKey(p => p.UserId);

            //builder.Entity<IdentityUserRole<string>>(b =>
            //{
            //    b.HasKey(ur => new { ur.UserId, ur.RoleId });
            //    b.ToTable("AspNetUserRoles"); // You can specify the table name here if needed
            //});
            //builder.Entity<IdentityUserToken<string>>().HasKey(p => p.UserId);

            builder.Entity<IdentityRole>()
                .HasData
                (
                    new IdentityRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "User",
                        NormalizedName = "User".ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    },
                     new IdentityRole()
                     {
                         Id = Guid.NewGuid().ToString(),
                         Name = "Admin",
                         NormalizedName = "Admin".ToUpper(),
                         ConcurrencyStamp = Guid.NewGuid().ToString(),
                     }

                );


            //builder.Entity<Cart>()
            //    .HasMany(c => c.Items)
            //    .WithOne(Items => Items.Cart)
            //    .HasForeignKey(i => i.CartId);
            builder.Entity<Cart>()
                .HasMany(c => c.Items)
                .WithMany(i => i.Carts)
                .UsingEntity<OrderedItem>
                (
                    oi =>
                        oi.HasOne(oi => oi.Item)
                        .WithMany(i => i.OrderedItems)
                        .HasForeignKey(oi => oi.ItemId),
                    oi =>
                        oi.HasOne(oi => oi.Cart)
                        .WithMany(c => c.OrderedItems)
                        .HasForeignKey(oi => oi.CartId),
                    oi => oi.HasKey(oi => new { oi.ItemId, oi.CartId})
                );
            
            base.OnModelCreating(builder);

            
        }
        public  DbSet<Item> Items { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Cart> Carts { get; set; }
        public DbSet<OrderedItem> OrderedItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
