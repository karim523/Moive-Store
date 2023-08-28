using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore
{
    public class PurchasedMovie
    {
       
        public PurchasedMovie( DateTime purchaseDate , int movieId )
        {
            SetPurchaseDate(purchaseDate);
            SetMovieId(movieId);
        }

      

        public DateTime PurchaseDate { get; private set; }
        public int CustomerId { get; private set; }
        public int MovieId { get; private set; }
        public int Id { get; private set; }
        
        public static PurchasedMovie CreatePurchaseMovie(int movieId)
        {
            PurchasedMovie purchasedMovie = new PurchasedMovie( DateTime.Now, movieId);
            return purchasedMovie;
        }
      
        private void SetMovieId(int movieId)
        {
            if (movieId <= 0) throw new ArgumentOutOfRangeException("Invalid movieId");
            MovieId = movieId;
        }
           
        private void SetPurchaseDate(DateTime purchaseDate)
        {

            PurchaseDate = purchaseDate;
        }
        
        public override string ToString()
        {
            return $"\n\t\t Movie Id:{MovieId}\n\t\t Purchase Date:{PurchaseDate}\n";
        }

    }
}
