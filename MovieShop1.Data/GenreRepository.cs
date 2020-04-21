using MovieShop1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop1.Data
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDBContext context) : base(context)
        {
        }
    }

    public interface IGenreRepository : IRepository<Genre>
    {
    }
}
