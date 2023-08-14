using Microsoft.EntityFrameworkCore;
using Movies;
using MovieStore;

var context= new ApplicationDBcontext();
RemovePurchasedMovie();
 
static void AddMovie()
{
    var context = new ApplicationDBcontext();

    Movie movie = new Movie( "John Wick3", MovieType.LongLife);
    context.Movies.Add(movie);
    context.SaveChanges();
}
static void AddCustomer()
{
    var context = new ApplicationDBcontext();

    Customer customer = Customer.SignUp("Samy", "Samy@gmail.com");
    context.Customers.Add(customer);
    context.SaveChanges();
    var customer1= context.Customers.Single(x=>x.Id==customer.Id);
    Console.WriteLine($"CustomerId:{customer1.Id} - Name:{customer1.Name} - Email:{customer1.Email}");
              
}
static void AddPurchasedMovies()
{
    var context = new ApplicationDBcontext();
    var customer1 = context.Customers.Include(p=>p.PurchasedMovies).Single(x => x.Id ==8 );
    var movie1 = context.Movies.Single(x => x.Id == 1);
   
   var a= customer1.Purchase(movie1);
    if (a == null) Console.WriteLine($"Passed");
    else Console.WriteLine($"Failed: {a}");
    context.SaveChanges();
  
}
static void UpdateCustomerEmail()
{
    var context = new ApplicationDBcontext();
    var customer = context.Customers.Find(1);
    customer.SetEmail("KarimKeshta@gmail.com");
    context.SaveChanges();

}
static void RemoveCustomer()
{
    var context = new ApplicationDBcontext();
    var customer = context.Customers.Find(9);
    context.Remove(customer);
    context.SaveChanges();

}
static void RemovePurchasedMovie()
{
    var context = new ApplicationDBcontext();
    var movie = context.Movies.First(c=>c.MovieType==MovieType.TwoDays);
    CustomerRepository customerRepository=new CustomerRepository();
    var customer = customerRepository.GetCustomer(8);
    var  purchasedMovies= customer.PurchasedMovies.OrderBy(p=>p.PurchaseDate).Where(m =>movie.Id==m.MovieId).LastOrDefault();
    context.Remove(purchasedMovies);
    context.SaveChanges();
}