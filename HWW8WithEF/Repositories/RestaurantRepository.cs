using HWW8WithEF.DataAccess;
using HWW8WithEF.Entities;
using HWW8WithEF.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWW8WithEF.Repositories
{
    public class RestaurantRepository
    {
        AppDbContext _context = new AppDbContext();
        
        public void AddRestaurant(Restaurant restaurant) 
        {
          _context.Add(restaurant);
          _context.SaveChanges();
        }

        public List<Restaurant> GetRestaurants()
        {
            return _context.Restaurants.ToList();
        }
        
    }
}
