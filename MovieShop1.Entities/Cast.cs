using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop1.Entities
{
    [Table("Cast")]
    public class Cast
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]//normally
        public string Name { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Gender { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string TmdbUrl { get; set; }

        [Required]
        [StringLength(2084)]
        public string ProfilePath { get; set; }

        public ICollection<Movie> Movies { get; set; }
        //public string Character { get; set; }
    }
}
