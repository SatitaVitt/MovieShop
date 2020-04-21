using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop1.Entities
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]//normally
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
