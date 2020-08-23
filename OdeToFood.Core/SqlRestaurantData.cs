using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Domain;

namespace OdeToFood.Core
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodContext _context;

        public SqlRestaurantData(OdeToFoodContext context)
        {
            _context = context;
        }

        #region Implementation of IRestaurantData

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return _context.Restaurants
                           .Where(r => string.IsNullOrEmpty(name) || r.Name.Contains(name))
                           .OrderBy(r => r.Name);
        }

        public Restaurant GetById(int id)
        {
            return _context.Restaurants.Find(id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = _context.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        #endregion
    }
}