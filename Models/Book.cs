using System;
using System.Collections.Generic;

namespace BookClub.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
    }
}
