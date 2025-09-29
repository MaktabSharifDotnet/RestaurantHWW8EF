using HWW8WithEF.DataAccess;
using HWW8WithEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWW8WithEF.Repositories
{
    public class OrderRepository
    {
        
        public void AddOrder(Order order) 
        {
            using(AppDbContext _context = new AppDbContext()) 
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
          

        }

    }
}
