using Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore
{
    public class CustomerRepository
    {
       public Customer GetCustomer(int customerId)
        {
            var context = new ApplicationDBcontext();
            var customer=  context.Customers.Find(customerId);
            context.Entry(customer).Collection(p => p.PurchasedMovies).Load();


            return customer ;
        }            

    }
}
