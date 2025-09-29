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
       
        
        public void AddRestaurant(Restaurant restaurant) 
        {
            
        
        }

        public List<Restaurant> GetRestaurants()
        {
            using (AppDbContext _context = new AppDbContext())
            {
                return _context.Restaurant.ToList();
            }
           
        }
        
    }
}
