using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities;

public partial class Publisher
{
    public long PublisherId { get; set; }

    public string? PublisherContactNo { get; set; }

    public string? PublisherName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
