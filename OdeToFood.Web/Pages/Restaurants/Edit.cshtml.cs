using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Domain;

namespace OdeToFood.Web.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            Restaurant = restaurantId.HasValue ? _restaurantData.GetById(restaurantId.Value) : new Restaurant();
            if (Restaurant is null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            Restaurant = Restaurant.Id > 0 ? _restaurantData.Update(Restaurant) : _restaurantData.Add(Restaurant);
            _restaurantData.Commit();
            TempData["Message"] = "Restaurant Saved!";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}
