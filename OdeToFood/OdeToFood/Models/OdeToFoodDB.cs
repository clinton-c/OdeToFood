using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace OdeToFood.Models
{  
    public class OdeToFoodDB : DbContext, IDbContext
    {
        public DbSet<Restaurant> Restaurants { get; set;  }
        public DbSet<Review> Reviews { get; set; }

        IQueryable<Restaurant> IDbContext.Restaurants
        {
            get { return Restaurants; }                
        }

        IQueryable<Review> IDbContext.Reviews
        {
            get { return Reviews; }            
        }

        int IDbContext.SaveChanges()
        {
            return SaveChanges();
        }

        T IDbContext.Add<T>(T entity) 
        {
            return Set<T>().Add(entity);
        }

        T IDbContext.Delete<T>(T entity) 
        {
            return Set<T>().Remove(entity);            
        }

        T IDbContext.Attach<T>(T entity)
        {                      
            var entry = Entry(entity);
            entry.State = System.Data.EntityState.Modified;
            return entity;
        }
    }
}