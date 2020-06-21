using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    { 
        private readonly IRestaurantData restaurantData;
        private readonly IConfiguration configuration;

        public string Message { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearshTerm { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public ListModel(IRestaurantData restaurantData,IConfiguration configuration)
        {
             this.restaurantData = restaurantData;
             this.configuration = configuration;
        }


        public void OnGet()
        {
             Restaurants = restaurantData.GetRestaurantByName(SearshTerm);
        }
    }
}