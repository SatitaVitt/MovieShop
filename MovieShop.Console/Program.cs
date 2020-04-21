using MovieShop1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NLog.Web;

namespace MovieShop.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //will always execute it?
            using (var db = new MovieShopDBContext())
            {
                //var genres = db.Genres.ToList();
                var movies = db.Movies.Where(m => m.Title.StartsWith("a")).ToList();

            }
            /*
            NLogBuilder.ConfigureNLog("nlog.config");
            try
            {
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseNLog()
                    .UseStartup<Startup>()
                    .Build();

                host.Run();
            }
            finally
            {
                LogManager.Shutdown();
            }
            */
        }
    }
}
