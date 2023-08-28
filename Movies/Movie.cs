using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore
{
    public class Movie
    {
        public Movie(int id)
        {
            SetId(id);
        }
        public Movie(int id, string name, MovieType movieType)
        {
            SetId(id);
            SetName(name);
            SetMovieType(movieType);
        }
        public Movie(string name, MovieType movieType)
        {

            SetName(name);
            SetMovieType(movieType);
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public MovieType MovieType { get; private set; }
        public void SetId(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException("Invalid Id");
            Id = id;
        }
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Invalid Name");

            if (!(name.Length >= 3 && name.Length <= 150)) throw new ArgumentException("Invalid Name");
            Name = name;
        }
        public void SetMovieType(MovieType movieType)
        {

            MovieType = movieType;

        }
        public bool CanBePurchased(DateTime lastPurchaseDate)
        {
            if (MovieType.LongLife == MovieType)
            {
                return false;
            }

            if (MovieType == MovieType.TwoDays && lastPurchaseDate >= DateTime.Now.AddDays(-2))
            {
                return false;
            }

            return true;
        }

        public DateTime GetExpirationDate()
        {
            if (MovieType.LongLife == MovieType)
            {
                return DateTime.MaxValue;
            }

            if (MovieType == MovieType.TwoDays)
            {
                return DateTime.Now.AddDays(2);
            }

            throw new Exception("Movie Type is invalid");
        }
        public override string ToString()
        {
            return $"Movie Id:{Id}\nMovie Name:{Name}\nMovie Type:{MovieType}";
        }
    }
    public enum MovieType
    {
        TwoDays,
        LongLife
    }
}
