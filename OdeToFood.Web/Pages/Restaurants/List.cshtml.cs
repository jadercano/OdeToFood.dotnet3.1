using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Domain;

namespace OdeToFood.Web.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly ILogger<ListModel> logger;

        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            _restaurantData = restaurantData;
            this.logger = logger;
        }

        public void OnGet()
        {
            this.logger.LogInformation("Executing List Model");
            Restaurants = _restaurantData.GetRestaurantsByName(name: SearchTerm);
        }
    }
}
