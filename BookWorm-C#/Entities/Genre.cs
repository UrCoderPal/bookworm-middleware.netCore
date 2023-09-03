using BookWorm_C_.Entities;
using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities;

public partial class Genre
{
    public long GenreId { get; set; }

    public string? GenreDesc { get; set; }

    public long? LanguageId { get; set; }

    public virtual Language? Language { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}