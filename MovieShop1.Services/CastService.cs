using MovieShop1.Data;
using MovieShop1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop1.Services
{
    public class CastService : ICastService
    {
        private ICastRepository _castRepository;

        public CastService()
        {
            _castRepository = new CastRepository(new MovieShopDBContext());
        }
        public void AddCast(Cast cast)
        {
            _castRepository.Add(cast);
        }
        public Cast GetCastWithMovie(int id)
        {
            var cast = _castRepository.GetCastWithMovies(id);
            return cast;
        }
        public Cast GetCastDetails(int castId)
        {
            var cast = _castRepository.GetCastWithMovies(castId);
            return cast;
        }
    }

    public interface ICastService
    {
        Cast GetCastDetails(int castId);
        Cast GetCastWithMovie(int id);
        void AddCast(Cast cast);
    }
}
