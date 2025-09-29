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
        AppDbContext _context = new AppDbContext();
        public void AddOrder(Order order) 
        {
           _context.Orders.Add(order);
           _context.SaveChanges();

        }

    }
}
