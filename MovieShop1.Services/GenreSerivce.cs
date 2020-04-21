/*
using MovieShop1.Data;
using MovieShop1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop1.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService()
        {
        }

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreRepository.GetAll();
        }
    }

    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
    }
}

*/


using MovieShop1.Data;
using MovieShop1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MovieShop1.Services
{
    public class GenreService : IGenreService
    {
        private GenreRepository _genreRepository;
        public GenreService()
        {
            _genreRepository = new GenreRepository(new MovieShopDBContext());
        }
        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreRepository.GetAll();
        }
    }
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
    }
}











