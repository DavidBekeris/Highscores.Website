using Highscores.Website.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Highscores.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly HighscoreContext context;

        public HomeController(HighscoreContext context)
        {
            this.context = context;
        }

        //[Route(Name = "category")]
        public IActionResult Index()
        {
            var gameCategory = context.GameCategories.ToList();
            return View(gameCategory);
        }

        public IActionResult Error()
        {
            return View();
        }

        // GET /games/game name
        [Route("/games/{urlSlug}", Name = "games")]
        public ActionResult Details(string urlSlug)
        {
            var game = context.GameCategories.FirstOrDefault(game => game.UrlSlug == urlSlug);

            // .\Views\Products\Details.cshtml
            return View(game);
        }
    }
}
