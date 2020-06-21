using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext _db)
        {
            db = _db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int restayrantId)
        {
            var restaurant = GetById(restayrantId);
            if (restaurant != null)
                db.Remove(restaurant);
            return restaurant;
        }

        public Restaurant GetById(int Id)
        {
            return db.Restaurants.Find(Id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = db.Restaurants
                .Where(a => a.Name.Contains(name) || string.IsNullOrEmpty(name));
            return query;
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
