using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    public class PurchasedMovie
    {
        public PurchasedMovie(int movieId,DateTime purchaseDate)
        {
            SetPurchaseDate(purchaseDate);
            SetMovieId(movieId);
        }

        public DateTime PurchaseDate { get;private set; }
        public int CustomerId { get; private set; }
        public int MovieId { get; private set; }
        public int Id { get; private set; } 
        public static PurchasedMovie CreatePurchaseMovie(int movieId) 
        {
            PurchasedMovie purchasedMovie = new PurchasedMovie(movieId,DateTime.Now);
            return purchasedMovie;
        }
        private void SetMovieId(int movieId)
        {
            if (movieId <= 0)throw new ArgumentOutOfRangeException("Invalid movieId");
            MovieId =movieId;
        }
        private void SetCustomerId(int customerId)
        {
            if (customerId <= 0) throw new ArgumentOutOfRangeException("Invalid customerId");
            CustomerId = customerId;
        }
        private void SetPurchaseDate(DateTime purchaseDate)
        {
            
            PurchaseDate =purchaseDate;
        }
        public override string ToString()
        {
            return $"\n\t\t Movie Id:{ MovieId }\n\t\t Purchase Date:{PurchaseDate}\n";
        }

    }
}
