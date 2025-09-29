using HWW8WithEF.DataAccess;
using HWW8WithEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWW8WithEF.Repositories
{
    public class Repository
    {
        

        public void AddFood(Food food) 
        {
            using(AppDbContext _context = new AppDbContext()) 
            {
                _context.Foods.Add(food);
                _context.SaveChanges();
            }
         
        }

        public Food? GetFoodByName(string name) 
        {
            using (AppDbContext _context = new AppDbContext()) 
            {
                return _context.Foods.FirstOrDefault(f => f.Name == name);
            }
                
        }

        public List<Food> GetFoodsByIds(List<int> foodIds)
        {
            using (AppDbContext _context = new AppDbContext()) 
            {
                return _context.Foods.Where(f => foodIds.Contains(f.Id)).ToList();
            }

                
        }

        public List<Food> GetFoods()
        {
             using (AppDbContext _context = new AppDbContext())
            {
                return _context.Foods.ToList();
            }

            
        }

        public List<Food> MenuByRestaurantId(int restaurantId)
        {
            using (AppDbContext _context = new AppDbContext())
            {
                return _context.Foods.Where(f => f.RestaurantId == restaurantId).ToList();
            }

            
        }

    }
}




