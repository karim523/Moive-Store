using MovieStore;
using System.Data;

namespace MoviesStoreApis.Dtos
{
    public  class  CustomerDetailsDto
    {
        public  string Name { get; set; }
        public string Email { get; set; }
        public  int Customerid { get; set; }
        public List<PurchaseMovieDto>PurchaseMovies { get; set; }

    }
    public class PurchaseMovieDto
    {
        public DateTime PurchaseDate { get; set; }
        public int MovieId { get; set; }
    }
}
