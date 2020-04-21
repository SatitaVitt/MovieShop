using MovieShop1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieShop1.Data
{
    public class MovieShopDBContext : DbContext //control+. to add fixed item
    {
        //now represent our database
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        //to write small fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Movies)
                .WithMany(e => e.Genres)
                .Map(m => m.ToTable("MovieGenre").MapLeftKey("GenreId").MapRightKey("MovieId"));
            //where the primary key is GenreID and MovieID

            modelBuilder.Entity<Movie>()
                .Property(e => e.Price)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Review>()
                .Property(e => e.Rating)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Purchase>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRole").MapLeftKey("RoleId").MapRightKey("UserId"));
        }

        

      

    }
}
