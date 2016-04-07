using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamPowered.Data.DTOs
{
    public class GameDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string SystemRequirements { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public ICollection<string> ImageUrls { get; set; }
    }
}
