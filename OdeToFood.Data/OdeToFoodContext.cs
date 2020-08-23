using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Domain;

namespace OdeToFood.Data
{
    public class OdeToFoodContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public OdeToFoodContext(DbContextOptions<OdeToFoodContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #region Overrides of DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(
              new Restaurant() { Id = 1, Name = "Jader's Pizza", Location = "Medellín, Colombia", CuisineType = CuisineType.Italian },
              new Restaurant() { Id = 2, Name = "Julieta's Indian Food", Location = "Medellín, Colombia", CuisineType = CuisineType.Indian },
              new Restaurant() { Id = 3, Name = "Natalia's Mexican", Location = "Medellín, Colombia", CuisineType = CuisineType.Mexican },
              new Restaurant() { Id = 4, Name = "Cano's Restaurant", Location = "Medellín, Colombia", CuisineType = CuisineType.Italian });
        }

        #endregion
    }
}
