using IleriWebFinalProjesi.Models;
using IleriWebFinalProjesi.Repo;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace IleriWebFinalProjesi.Controllers
{
    public class HomeController : Controller
    {     
        private readonly HttpClient _client;
		private readonly MyDbContext _context;
        public HomeController(MyDbContext dbContext)
        {
            _client = new HttpClient();
			_context = dbContext;
        }
        public IActionResult Index()
        {
			MovieRepo movieRepo = new MovieRepo();
			ViewBag.RandomMovies = movieRepo.GetRandomMovies();
			ViewBag.Movies = movieRepo.GetMovies(true);
			ViewBag.Series = movieRepo.GetSeries(true);
			ViewBag.Slider = movieRepo.SliderMovies();
			return View();
        }
        public async Task<IActionResult> Movies()
        {
            MovieRepo movieRepo = new MovieRepo();
			var movie =await movieRepo.GetMovies(false);
			ViewBag.Movies = movie;
			return View();
		}

        public async Task<IActionResult> GetMovie(string dataId)
        {
			MovieRepo movieRepo = new MovieRepo();
			var movie = await movieRepo.GetMovieById(dataId);
			var islem = await movieRepo.RecommendedMovies();
			ViewBag.RecommendMovies = islem;
			ViewBag.GetComment = _context.Comments.Where(a=>a.MovieDataId==dataId && a.MovieType==MovieType.movie).ToList();
			return View(movie);
		}

        public async Task<IActionResult> Series()
        {
			MovieRepo movieRepo = new MovieRepo();
			ViewBag.Series = await movieRepo.GetSeries(false);
            return View();
		}
        public async Task<IActionResult> GetSeries(string dataId)
        {
			MovieRepo movieRepo = new MovieRepo();
			var series = await movieRepo.GetSeriesById(dataId);
			ViewBag.RecommendSeries = await movieRepo.RecommendedSeries();
			ViewBag.GetComment = _context.Comments.Where(a => a.MovieDataId == dataId && a.MovieType == MovieType.series).ToList();
			return View(series);
		}

		[HttpPost]
		public IActionResult AddCommentMovie(Comment comment)
		{
			comment.MovieType = MovieType.movie;
			_context.Comments.Add(comment);
			_context.SaveChanges();
			return Redirect("/Home/GetMovie?dataId=" + comment.MovieDataId);
		}
		[HttpPost]
		public IActionResult AddCommentSeries(Comment comment)
		{
			comment.MovieType = MovieType.series;
			_context.Comments.Add(comment);
			_context.SaveChanges();
			return Redirect("/Home/GetSeries?dataId=" + comment.MovieDataId);
		}
	}
}
