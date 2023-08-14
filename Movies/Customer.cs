using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using MovieStore;

namespace Movies
{
    public class Customer
    {
        private Customer( string name)
        {           
            SetName(name); 
            PurchasedMovies = new List<PurchasedMovie>();
        }
     

        public int Id { get;private set; }
        public string Name { get;private set; }
        public string Email{ get;private set; }
        public List<PurchasedMovie> PurchasedMovies { get; private set; }
        public static Customer SignUp(string name, string email )
        {
            Customer customer = new Customer( name);
            customer.SetEmail(email);            
            return customer;
        }

        public static Customer SignUp(string name, string email,List<PurchasedMovie>purchasedMovies)
        {
            Customer customer = new Customer( name);
            customer.SetEmail(email);
            customer.SetPurchaseMovies(purchasedMovies); 
            return customer;
        }

        public string Purchase(Movie movie)
        {
         
            if ( PurchasedMovies.Count() == 0)
            {
                AddPurchasedMovieToList();
            }

            else 
            {
              
                var purchaseMoviesForCustomerAndMovie = PurchasedMovies.Where(p => p.MovieId == movie.Id )
                                                        .OrderByDescending(p => p.PurchaseDate)
                                                        .Select(p => p.PurchaseDate).ToList();


                if (purchaseMoviesForCustomerAndMovie.Count == 0)
                {
                        AddPurchasedMovieToList();
                }
               else
               {                    

                    if( movie.GetExpirationDate() > purchaseMoviesForCustomerAndMovie.First()) 
                    {
                        return($"You can not buy now!\n ");
                    }
                    else 

                    {
                        AddPurchasedMovieToList();
                        
                    }
                   
               }
            }
                void AddPurchasedMovieToList()
                {
                var purchasedMovie = PurchasedMovie.CreatePurchaseMovie(movie.Id);                 
                PurchasedMovies.Add(purchasedMovie);
                }
            return $"" ;
        }
        
        private  void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Invalid Name");

            if (!(name.Length >= 3 && name.Length <= 150))throw new ArgumentException("Invalid Name");
            this.Name = name;
        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException("Invalid Email");
            this.Email = email;
        }
        
        private  void SetId(int id)
        {
            if (id < 0) throw new ArgumentNullException("Invalid Id");
            this.Id = id;        
        }
        
        private void SetPurchaseMovies(List<PurchasedMovie> purchasedMovies2)
        {
            if (purchasedMovies2 is not null)
                this.PurchasedMovies = purchasedMovies2;
        }
        
        public override string ToString()
        {
            Console.Write($"Name: {Name}\nEmail:{Email}\nId: {Id}\nPurchaseMovies => ");
            foreach (var purchased in PurchasedMovies)
            {
                Console.WriteLine(purchased);
            }
            return $"\n";                  
        }
    }
}