namespace MovieShop1.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieShop1.Data.MovieShopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //false means we are using manual migration
        }

        protected override void Seed(MovieShop1.Data.MovieShopDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
