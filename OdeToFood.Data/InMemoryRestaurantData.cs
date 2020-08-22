﻿using System.Collections.Generic;
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

        #endregion
    }
}