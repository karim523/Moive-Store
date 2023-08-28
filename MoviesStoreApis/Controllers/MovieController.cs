using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesStoreApis.Dtos;
using MovieStore;

namespace MoviesStoreApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly AppDbcontext _context;
        private readonly IMapper _mapper;

        public MovieController(AppDbcontext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _context.Movies.ToList();
            var movieDto = _mapper.Map<IEnumerable<MovieDto>>(movies);
            
            return Ok(movieDto);
        }
    }
}
