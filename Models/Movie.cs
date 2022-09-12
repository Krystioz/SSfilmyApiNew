using System;
using System.Collections.Generic;

namespace SSfilmyModels.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Director { get; set; }
        public int? Year { get; set; }
        public int? Rate { get; set; }
    }
}
