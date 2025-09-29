using HWW8WithEF.DataAccess;
using HWW8WithEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HWW8WithEF.Repositories
{

    public class CustomerRepository
    {
        
        public Customer? GetCustomerByPhone(string phone) 
        {
            using (AppDbContext _context = new AppDbContext()) 
            {
                return _context.Customers
              .Include(c => c.Contact)
              .FirstOrDefault(c => c.Contact.Phone == phone);
            }
       
        
        }

        public void AddCustomer(Customer customer) 
        {
            using (AppDbContext _context = new AppDbContext()) 
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            
        
        }

        public Customer? GetCustomerByCustomerId(int customerId) 
        {

            using (AppDbContext _context = new AppDbContext())
            {
                return _context.Customers.FirstOrDefault(c => c.Id == customerId);
            }
            
        }

    }
}
