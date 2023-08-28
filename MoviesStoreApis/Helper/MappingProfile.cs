using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using MoviesStoreApis.Dtos;
using MovieStore;

namespace MoviesStoreApis.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie,MovieDto>()
                .ForMember(x=>x.MovieType,c=>c.MapFrom(a=>a.MovieType.ToString()));                          

            CreateMap<Customer, SignUpOutputDto>();
            CreateMap< PurchasedMovieDto, PurchasedMovie>();

        }
    }
}
