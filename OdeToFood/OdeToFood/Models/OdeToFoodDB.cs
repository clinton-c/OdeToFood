using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace OdeToFood.Models
{
    public class OdeToFoodDB : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                        .Property(r => r.ID).HasColumnName("restaurant_id");

            modelBuilder.Entity<Restaurant>()
                        .Property(r => r.Name).HasColumnName("restaurant_name");
                 
            
            
            base.OnModelCreating(modelBuilder);
        }
    }
}