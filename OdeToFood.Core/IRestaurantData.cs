using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Domain;

namespace OdeToFood.Core
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name = null);

        Restaurant GetById(int id);

        Restaurant Update(Restaurant updatedRestaurant);

        Restaurant Add(Restaurant newRestaurant);

        Restaurant Delete(int id);

        int Commit();
    }
}
