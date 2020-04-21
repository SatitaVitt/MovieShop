using MovieShop1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MovieShop1.Data
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDBContext context) : base(context)
        {
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            //throw new NotImplementedException();
            return _context.Genres.Where(g=>g.Id == genreId).SelectMany(m => m.Movies).ToList();
        }

        public IEnumerable<Movie> GetTopGrossingMovies()
        {
            //throw new NotImplementedException();
            return _context.Movies.OrderByDescending(m => m.Revenue).Include(m => m.Genres).Take(20).ToList();
        }

        public override Movie GetById(int id)
        {
            //Get Movie by Id and also include Average Rating of that Movie
            //throw new NotImplementedException();

            //return base.GetById(id);

            //var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            var movie = _context.Movies.Include(m => m.MovieCasts.Select(c => c.Cast)).Include(m => m.Genres)
                                .FirstOrDefault(m => m.Id == id);
            if (movie == null) return null;
            //var movieRating = _context.Reviews.Where(r => r.MovieId == id).Average(r => r.Rating);
            //if (movieRating > 0) movie. = Math.Ceiling(movieRating * 100) / 100;

            //Get average rating also later
            return movie;
        }
    }

    public interface IMovieRepository:IRepository<Movie>//T can be replaced with the movie entity
    {
        IEnumerable<Movie> GetTopGrossingMovies();
        IEnumerable<Movie> GetMoviesByGenre(int genreId);
    }

   
}
