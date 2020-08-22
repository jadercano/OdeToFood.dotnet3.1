using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
                           {
                               new Restaurant() { Id = 1, Name = "Jader's Pizza", Location = "Medellín, Colombia", CuisineType = CuisineType.Italian },
                               new Restaurant() { Id = 2, Name = "Julieta's Indian Food", Location = "Medellín, Colombia", CuisineType = CuisineType.Indian },
                               new Restaurant() { Id = 3, Name = "Natalia's Mexican", Location = "Medellín, Colombia", CuisineType = CuisineType.Mexican },
                               new Restaurant() { Id = 4, Name = "Cano's Restaurant", Location = "Medellín, Colombia", CuisineType = CuisineType.Italian }
                           };
        }

        #region Implementation of IRestaurantData

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return _restaurants
                       .Where(s => string.IsNullOrEmpty(name) || s.Name.Contains(name))
                       .OrderBy(r => r.Name);
        }

        public Restaurant GetById(int id)
        {
            return _restaurants.Find(r => r.Id.Equals(id));
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _restaurants.Find(r => r.Id.Equals(updatedRestaurant.Id));
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.CuisineType = updatedRestaurant.CuisineType;
            }
            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _restaurants.Add(newRestaurant);
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        #endregion
    }
}