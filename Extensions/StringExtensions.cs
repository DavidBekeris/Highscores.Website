using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highscores.Website.Extensions
{
    public static class StringExtensions
    {
        // "Black T-Shirt" > "black-tshirt"
        // "T-Shirts" > "tshirts
        // whitespace kan och fram ska tas bort, "   Black T-Shirt   "  >   "black-tshirt"
        public static string Slugify(this string name) => name.Trim()
            .Replace("-", "")
            .Replace(" ", "-")
            .ToLower();
    }
}
