using MovieShop1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop1.MVC.Controllers
{
    public class GenresController : Controller
    {
        // GET: Genres

        //url would be: http:localhost:34234/Movies/Index
        //GET http:localhost:34234/Movies/Index
        //random port number

        //MVC has routing

        //[HttpGet]
        private IGenreService _genreService;
        public GenresController()
        {
            _genreService = new GenreService();
        }
        [HttpGet]
        public PartialViewResult Index()
        {
            var genre = _genreService.GetAllGenres().OrderBy(g => g.Name).ToList();
            return PartialView("GenresView", genre);
            //call service layer to get top 20 revenue movies
            //return View();
        }
    }
}