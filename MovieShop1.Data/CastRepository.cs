using MovieShop1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop1.Data
{
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDBContext context) : base(context)
        {
        }

        public Cast GetCastWithMovies(int castId)
        {
           // var cast = _context.Casts.Where(c => c.Id == castId).Include(c => c.MovieCast.Select(m => m.Movie))
                               //.FirstOrDefault();
            var cast = _context.Casts.FirstOrDefault(c => c.Id == castId);
            return cast;
        }

        public override void Add(Cast cast)
        {
            base.Add(cast);
            _context.SaveChanges();
        }
    }

    public interface ICastRepository : IRepository<Cast>
    {
        Cast GetCastWithMovies(int castId);
    }
}
