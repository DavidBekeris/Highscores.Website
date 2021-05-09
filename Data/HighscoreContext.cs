using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highscores.Website.Data
{
    public class HighscoreContext : DbContext
    {
        public DbSet<Highscore> Highscores { get; set; }
        public DbSet<GameCategory> GameCategories { get; set; }

        public HighscoreContext(DbContextOptions<HighscoreContext> options)
            : base(options)
        {

        }
    }
}
