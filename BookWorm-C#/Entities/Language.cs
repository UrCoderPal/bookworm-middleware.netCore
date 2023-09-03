using BookWorm_C_.Entities;
using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities;

public partial class Language
{
    public long LanguageId { get; set; }

    public string? LanguageDesc { get; set; }

    public long? TypeId { get; set; }

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ProductType? Type { get; set; }
}
