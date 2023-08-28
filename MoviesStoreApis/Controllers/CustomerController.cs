using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesStoreApis.Dtos;
using MovieStore;
using System.Collections.Generic;


namespace MoviesStoreApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbcontext _context;
        private readonly IMapper _mapper;

        public CustomerController(AppDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {         
            var customers =  _context.Customers.Include(p=>p.PurchasedMovies).ToList();

            //List<CustomerDetailsDto> customerDetailsDto = new();

            //    foreach (var customer in customers)
            //    {
            //      var customerDto = new CustomerDetailsDto();

            //         customerDto.Customerid   = customer.Id;
            //         customerDto.Name         = customer.Name;
            //         customerDto.Email        = customer.Email;
            //         customerDto.PurchaseMovies=new List<PurchaseMovieDto> ();
            //    foreach (var item in customer.PurchasedMovies )
            //    {
            //        var purchaseMovie          =new PurchaseMovieDto();
            //        purchaseMovie.PurchaseDate = item.PurchaseDate;
            //        purchaseMovie.MovieId      = item.MovieId;
            //        customerDto.PurchaseMovies.Add(purchaseMovie);
            //    }

            //      customerDetailsDto.Add(customerDto); 

            //    }
            List<CustomerDetailsDto> customerDetailsDto = customers.Select(customer => new CustomerDetailsDto
            {
                Customerid = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PurchaseMovies = customer.PurchasedMovies.Select(item => new PurchaseMovieDto
                {
                    PurchaseDate = item.PurchaseDate,
                    MovieId = item.MovieId
                }).ToList()
            }).ToList();
           
            return Ok(customerDetailsDto);

        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpInputDto dto)
        {
            var customer = Customer.SignUp(dto.Name, dto.Email);
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<SignUpOutputDto>(customer));                                                                                                           
        }
        [HttpPost("SignUpOldCustomer")]
        public async Task<IActionResult> SignUpOldCustomer([FromBody] SignUpOldCustomerInputDto dto)
        {

            // var purchasedMovies = _mapper.Map<List<PurchasedMovie>>(dto.PurchasedMovies);
            var purchasedMovieDtos = new List<PurchasedMovie>();
            foreach (var item in dto.PurchasedMovies)
            {
                var purchasedMovieDto = new PurchasedMovie(item.PurchaseDate, item.MovieId);
                
                purchasedMovieDtos.Add(purchasedMovieDto);
            }
            Customer customer = Customer.SignUp(dto.Name, dto.Email, purchasedMovieDtos);
           
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<SignUpOutputDto>(customer));

        }

        [HttpPost("Purchase")]
        public async Task<IActionResult> Purchase([FromForm] PurchaseInputDto dto)
        {

            var customer = await _context.Customers.Include(p => p.PurchasedMovies).SingleOrDefaultAsync(c => c.Id == dto.CustomerId);
            
            var movie = await _context.Movies.SingleOrDefaultAsync(m => m.Id == dto.MovieId);
            
            var a =customer.Purchase(movie);
            
            if (a is null)
            {

                await _context.SaveChangesAsync();
                var PurchaseDto = new PurchaseOutputDto
                { 
                    PurchasedDate = customer.PurchasedMovies.Last().PurchaseDate,
                    PurchasedId = customer.PurchasedMovies.Last().Id
                };
          
                return Ok(PurchaseDto);
            }
            else
                return BadRequest($"Failed: {a}");
            
        }

    }
}
