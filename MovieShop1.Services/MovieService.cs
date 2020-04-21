using MovieShop1.Data;
using MovieShop1.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop1.Services
{
    public class MovieService : IMovieService //going to implement IMoiveService
    {
        //based on the business requirements (how many methods to put inside it)

        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            //_movieRepository = new MovieRepository(new MovieShopDBContext());
        }
        
        public Movie GetMovieDetails(int id)
        {
            //throw new NotImplementedException();
            var movie = _movieRepository.GetById(id);
            return movie;
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            return _movieRepository.GetMoviesByGenre(genreId);
        }

        public IEnumerable<Movie> GetTopGrossingMovies()
        {
            //throw new NotImplementedException();
            //Top 20 movies by revenue 
            
            return _movieRepository.GetTopGrossingMovies();
        }
    }

    public interface IMovieService
    {
        IEnumerable<Movie> GetTopGrossingMovies();
        IEnumerable<Movie> GetMoviesByGenre(int genreId);
        Movie GetMovieDetails(int id);
    }
}
