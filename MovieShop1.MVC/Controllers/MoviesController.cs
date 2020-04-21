using MovieShop1.Entities;
using MovieShop1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop1.MVC.Controllers
{
    [RoutePrefix("movies")]
    public class MoviesController : Controller
    {
        // GET: Movies
        //routing
        //DI with constructor injection

        private readonly IMovieService _movieService;
        //MVC 5 requires parameterless contrcutor
        //for IMovieService movieService, we need to inject an implementation
        //we can pass any object/instance that implements IMovieService
        //in our project, MovieService class is implementing IMoveSerivce Interface
        //IOC should inject instance of MovieService for Constructor 
        //in .NET framework there are no built-in IOC, we need to download 3rd party IOC
        //popular 3rd party IOC's like NIbject, Autofac, Unity etc
        //in .Net Core or ASP .NET Core Dependency Injection is builtin, so we dont need any 3rd party IOC
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var movies = _movieService.GetTopGrossingMovies();
            return View(movies);
        }
        
       

        [HttpGet]
        [Route("genres/{genreId}")]
        public ActionResult GenreMovies(int genreId)
        {
            //take genre id from url and then call movie service to get list of movies belong to the genre
            //return movies to the View and display as Image tags inside the bootstrap card with image urls 
            //as posterUrl from Movie table column

            //create GetMoviesByGenre(int genreId) inside IMovieService and imlement that method call Movies 
            //Repository to get movies of that genre
            var movies = _movieService.GetMoviesByGenre(genreId).OrderBy(m => m.Title).ToList();
            return View("MoviesByGenre", movies);
        }
        
        /*
        [Route("")]
        public ActionResult GetMovies(string filter = null, int pageIndex = 1, int pageSize= 20)
        {
            var movies = _movieService.GetMoviesByPagination(pageIndex, filter, pageSize);
            var pagedMovies = new StaticPagedList<Movie>(Movie, pageIndex, pageSize, movies.TotalCount);
            return View("Index", pagedMovies);
        }
        */

        public ActionResult Details(int id)
        {
            var movie = _movieService.GetMovieDetails(id);
            return View(movie);
        }

        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(Movie movie)
        {
            return View("Index");
        }
    }
}