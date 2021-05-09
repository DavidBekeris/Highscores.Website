using Highscores.Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highscores.Website.Controllers
{
    public class GamesController : Controller
    {
        private readonly HighscoreContext context;

        public GamesController(HighscoreContext context)
        {
            this.context = context;
        }

        //[Route(Name = "category")]
        public IActionResult Games()
        {
            var gameCategory = context.GameCategories.ToList();
            return View(gameCategory);
        }

        //[Route("/games/{urlSlug}", Name = "game")]
        //public IActionResult Games()
        //{
        //    return View();
        //}

        // GET /ProductCategories/Details/5
        [Route("/games/{urlSlug}", Name = "games")]
        public async Task<IActionResult> Details(string urlSlug)
        {
            var game = await context.GameCategories
                //.Include(x => x.Products)
                .FirstOrDefaultAsync(m => m.UrlSlug == urlSlug);

            return View(game);
        }
    }
}
