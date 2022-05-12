using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Pizza hut", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French },
                new Restaurant { Id = 3, Name = "Mano Groove", Cuisine = CuisineType.Indian }
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(restaurants => restaurants.Id) + 1;
        }

        public void Delete(int id)
        {
            var restuarant = Get(id);
            if (restuarant != null)
            {
                restaurants.Remove(restuarant);
            }
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(restaurants => restaurants.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }
    }
}
