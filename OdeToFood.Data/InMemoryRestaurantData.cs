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
                               new Restaurant() { Id = 1, Name = "Julieta's Indian Food", Location = "Medellín, Colombia", CuisineType = CuisineType.Indian },
                               new Restaurant() { Id = 1, Name = "Natalia's Mexican", Location = "Medellín, Colombia", CuisineType = CuisineType.Mexican },
                               new Restaurant() { Id = 1, Name = "Cano's Restaurant", Location = "Medellín, Colombia", CuisineType = CuisineType.Italian }
                           };
        }

        #region Implementation of IRestaurantData

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        #endregion
    }
}