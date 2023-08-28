using MovieStore;

namespace MoviesStoreApis.Dtos
{
    public class SignUpOldCustomerInputDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
      
       public List<PurchasedMovieDto> PurchasedMovies { get; set; }    
    }
    public class PurchasedMovieDto
    {
        public DateTime PurchaseDate { get; set; }
        public int MovieId { get; set; }
    }
}
