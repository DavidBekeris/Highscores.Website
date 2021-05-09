using Highscores.Website.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Highscores.Website.Data
{
    public class Highscore
    {
        public Highscore(int id, string name, int score, string date)
        {
            Id = id;
            Name = name;
            Score = score;
            Date = date;
            UrlSlug = name.Slugify();
        }

        public Highscore(string name, int score, string date)
        {
            Name = name;
            Score = score;
            Date = date;
            UrlSlug = name.Slugify();
        }

        public int Id { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; protected set; }

        [Required]
        public int Score { get; protected set; }

        public string Date { get; protected set; }

        [MaxLength(500)]
        public string UrlSlug { get; protected set; }

        public ICollection<GameCategory> Categories { get; protected set; }
    }
}
