using Highscores.Website.Data;
using Highscores.Website.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Highscores.Website.Models.ViewModels
{
    public class AddHighscoreViewModel
    {
        private readonly HighscoreContext context;

        public AddHighscoreViewModel(HighscoreContext context)
        {
            this.context = context;
        }

        [Display(Name = "Player")]
        public string Name { get; set; }

        public int Score { get; set; }

        public string Date { get; set; }

        //public ICollection<GameCategory> GameCategory { get; set; }

        public ICollection<Highscore> Highscores { get; protected set; }
        = new List<Highscore>();

        public IEnumerable<SelectListItem>GameCategories { get; set; }


        //[HttpPost]
        //[Route("/highscores/new")]
        //public ActionResult Create(CreateHighscoreDto dto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var product = new Highscore(
        //            name: dto.Name,
        //            score: dto.Score,
        //            date: dto.Date);

        //        context.Highscores.Add(highscore);

        //        context.SaveChanges();
        //    }
        //    return View();
        //}
    }
}
