using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore
{
    public class CustomerRepository
    {
        private readonly AppDbcontext _context;
        public CustomerRepository(AppDbcontext context)
        {
            _context = context;
        }
        public Customer GetCustomer(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            _context.Entry(customer).Collection(p => p.PurchasedMovies).Load();
             return customer;

        }
    }
    
}
