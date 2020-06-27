using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static OdeToFood.Core.Restaurant;
 
namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ID=1,Name="Scott's Pizza",Location="Maryland",Cuisine=CuisineType.Italian } ,
                new Restaurant{ID=2,Name="Cinnamon Club",Location="London",Cuisine=CuisineType.Mexican } ,
                new Restaurant{ID=3,Name="La Cost",Location="California",Cuisine=CuisineType.Indian } ,
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(a => a.ID == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return restaurants
                .Where(a => string.IsNullOrEmpty(name) || a.Name.ToLower().StartsWith(name.ToLower()))
                .OrderBy(a => a.Name);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(a => a.ID == updatedRestaurant.ID);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.ID = restaurants.Max(a => a.ID) + 1;
            restaurants.Add(newRestaurant);
            
            return newRestaurant;
        }

        public Restaurant Delete(int restayrantId)
        {
            var restaurant= restaurants.FirstOrDefault(a => a.ID == restayrantId);
            if (restaurant != null)
                restaurants.Remove(restaurant);
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count;
        }
    }
}
