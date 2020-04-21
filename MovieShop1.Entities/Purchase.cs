﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop1.Entities
{
    [Table("Purchase")]
    public class Purchase
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public Guid PurchaseNumber { get; set; }

        public decimal TotalPrice { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime PurchaseDateTime { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public User User { get; set; }
    }
}
