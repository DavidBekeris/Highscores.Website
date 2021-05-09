using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Highscores.Website.Data;
using Highscores.Website.Models.ViewModels;

namespace Highscores.Website.Controllers
{
    public class AddHighscoreController : Controller
    {
        private readonly HighscoreContext context;

        public AddHighscoreController(HighscoreContext context)
        {
            this.context = context;
        }

        // GET: AddHighscore
        public async Task<IActionResult> Index()
        {
            return View(await context.Highscores.ToListAsync());
        }

        //[Route("/highscores/new")]
        //public IActionResult Games()
        //{
        //    var gameCategory = context.GameCategories.ToList();
        //    return View(gameCategory);
        //}

        //[Route("/games/{urlSlug}", Name = "games")]
        //public ActionResult Details()
        //{
        //    var gameCategory = context.GameCategories.ToList();
        //    return View(gameCategory);
        //}

        // GET: AddHighscore/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscore = await context.Highscores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (highscore == null)
            {
                return NotFound();
            }

            return View(highscore);
        }

        // GET: AddHighscore/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}
        public async Task<IActionResult> Create()
        {
            return View(await context.Highscores.ToListAsync());
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

        // GET: AddHighscore/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscore = await context.Highscores.FindAsync(id);
            if (highscore == null)
            {
                return NotFound();
            }
            return View(highscore);
        }

        // POST: AddHighscore/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Score,Date,UrlSlug")] Highscore highscore)
        {
            if (id != highscore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(highscore);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HighscoreExists(highscore.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(highscore);
        }

        // GET: AddHighscore/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscore = await context.Highscores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (highscore == null)
            {
                return NotFound();
            }

            return View(highscore);
        }

        // POST: AddHighscore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var highscore = await context.Highscores.FindAsync(id);
            context.Highscores.Remove(highscore);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HighscoreExists(int id)
        {
            return context.Highscores.Any(e => e.Id == id);
        }
    }
}
