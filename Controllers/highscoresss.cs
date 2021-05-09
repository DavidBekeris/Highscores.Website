using Highscores.Website.Data;
using Highscores.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highscores.Website.Controllers
{
    public class highscoresss : Controller
    {
        private readonly HighscoreContext context;

        public highscoresss(HighscoreContext context)
        {
            this.context = context;
        }

        public IActionResult Error()
        {
            return View();
        }

        [Route("highscores/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddHighscoreViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var highscore = new Highscore(
                    viewModel.Name,
                    viewModel.Score,
                    viewModel.Date);

                context.Add(highscore);

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            //.\Areas\Admin\Views\Products\Create.cshtml
            return View(viewModel);
        }

        public async Task<IActionResult> Index()
        {
            // .\Areas\Admin\Views\Products\Index.cshtml
            return View(await context.Highscores.ToListAsync());
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var highscore = await context.Highscores
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (highscore == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(highscore);
        //}


    }
}
