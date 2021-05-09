using Highscores.Website.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Highscores.Website.Data
{
    public class GameCategory
    {
        public int Id { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; protected set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(200)]
        public string Genre { get; protected set; }

        [MaxLength(30)]
        public string ReleaseYear { get; protected set; }

        [MaxLength(250)]
        public Uri ImageUrl { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string UrlSlug { get; protected set; }

        public ICollection<Highscore> Highscores { get; protected set; }
    = new List<Highscore>();

        public GameCategory(string name)
        {
            Name = name;
            UrlSlug = name.Slugify();
        }

        public GameCategory(int id, string name)
            : this(name)
        {
            Id = id;
        }
    }
}
