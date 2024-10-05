using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Anime
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Summary { get; set; }

        public Director Director { get; set; } = null!;

        public int DirectorId { get; set; }
    }
}
