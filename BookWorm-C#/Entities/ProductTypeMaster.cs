using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities;

public partial class ProductTypeMaster
{
    public long ProductTypeId { get; set; }

    public string? TypeDesc { get; set; }

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
