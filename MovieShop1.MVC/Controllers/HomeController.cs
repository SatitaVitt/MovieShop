using MovieShop1.MVC.Filters;
using MovieShop1.MVC.NewFolder1;//??? model 吗
using MovieShop1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop1.MVC.Controllers
{
    [MovieShopExceptionFilter]
    public class HomeController : Controller
    {
        
        private readonly IMovieService _movieService;
        
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        //[LogActionFilter]
        public ActionResult Index()
        {
            int x = 1;
            int y = 0;
            int z = x / y;
            //get top revenue movies and show them in home page, use same Movie Card as you did for genres movies
            var topGrossingMovies = _movieService.GetTopGrossingMovies();
            return View(topGrossingMovies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}