using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<PurchasedMovie>().ToTable("PurchasedMovie");

            modelBuilder.Entity<Customer>() 
                .HasKey(c => c.Id);
            modelBuilder.Entity<Customer>()
                .Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Customer>()
              .Property(c => c.Email).HasMaxLength(256);

            modelBuilder.Entity<Movie>()
                .HasKey(m => m.Id);
            modelBuilder.Entity<Movie>()
               .Property(c => c.Name).HasMaxLength(128).IsRequired();                        


            modelBuilder.Entity<PurchasedMovie>()
               .HasKey(p =>p.Id);

            modelBuilder.Entity<PurchasedMovie>()
                .HasOne<Customer>()
                .WithMany(c=>c.PurchasedMovies)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(p => p.CustomerId)
                .HasPrincipalKey(c=>c.Id);

            modelBuilder.Entity<PurchasedMovie>()
                .HasOne<Movie>()
                .WithMany()
                .HasForeignKey(p => p.MovieId)
                .HasPrincipalKey(m=>m.Id);
               
        }
        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Movie> Movies{ get; set; }  
        public DbSet<PurchasedMovie> purchasedMovies { get; set; }
    }
}
