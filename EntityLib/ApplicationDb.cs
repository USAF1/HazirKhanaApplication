using EntityLib.AddOnManagment;
using EntityLib.CuisineManagment;
using EntityLib.LocationManagment;
using EntityLib.ProductsManagment;
using EntityLib.RestaurantCuisineManagment;
using EntityLib.RestaurantManagment;
using EntityLib.UserManagment;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib
{
    public class ApplicationDb : IdentityDbContext
    {

        public DbSet<Cuisine> Cuisines { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductVaration> ProductVarations { get; set; }

        public DbSet<AddOnProduct> AddOnProducts { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Provience> Proviences { get; set; }

        public DbSet<RestaurantCuisine> RestaurantCuisines { get; set; }

        public DbSet<CuisineRestaurant> CuisineRestaurants { get; set; }

        public DbSet<AddOn> AddOns { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<RestaurantManager> RestaurantManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>()
        .HasIndex(u => new { u.Name, u.PostalCode })
        .IsUnique();
            modelBuilder.Entity<Provience>()
        .HasIndex(u => u.Name)
        .IsUnique();


            modelBuilder.Entity<CuisineRestaurant>(entity =>
            {
                entity.HasKey(e => new { e.CuisinesId, e.RestaurantsId });

                entity.ToTable("CuisineRestaurant");

                entity.HasIndex(e => e.RestaurantsId, "IX_CuisineRestaurant_RestaurantsId");

                entity.HasOne(d => d.Cuisines)
                    .WithMany(p => p.CuisineRestaurants)
                    .HasForeignKey(d => d.CuisinesId);

                entity.HasOne(d => d.Restaurants)
                    .WithMany(p => p.CuisineRestaurants)
                    .HasForeignKey(d => d.RestaurantsId);
            });


            modelBuilder.Entity<AddOnProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.AddOnId });

                entity.ToTable("AddOnProduct");

                //entity.HasIndex(e => e.RestaurantsId, "IX_CuisineRestaurant_RestaurantsId");

                entity.HasOne(d => d.AddOns)
                    .WithMany(p => p.AddOnProducts)
                    .HasForeignKey(d => d.AddOnId);

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.AddOnProducts)
                    .HasForeignKey(d => d.ProductId);
            });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.; user id=sa; password=Charli1122#; Initial Catalog=HazirKhana");
        }

    }
}
