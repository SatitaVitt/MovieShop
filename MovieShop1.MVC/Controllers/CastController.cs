using MovieShop1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop1.MVC.Controllers
{
    [RoutePrefix("cast")]
    public class CastController : Controller
    {
        // GET: Cast
        private readonly ICastService _castService;
        public CastController(ICastService castService)
        {
            _castService = castService;
        }
        public ActionResult Index()
        {
            //get top revenue movies and show them in home page, 
            //use same Movie Card as you did for genres movies 
            
            return View();

        }

        // step 1 create a action method that returns empty view to enter cast information
        //make sure to have to even the default is httpget

        //the url should be cast/create http get
        [HttpGet]
        //[Route("cast/create")]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(string castname, string profilePath, string gender, string tmdbURL)
        {
            // save this information to cast table 
            //_castService.AddCast(CastService);
            return View();
        }

        //or public ActionResult Create(Cast cast)
    }
}