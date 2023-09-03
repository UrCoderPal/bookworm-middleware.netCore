using BookWorm_C_.Entities;
using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities;

public partial class Cart
{
    public long CartId { get; set; }

    public int Quantity { get; set; }

    public string? Type { get; set; }

    public long? CustomerCustomerId { get; set; }

    public long? ProductProductId { get; set; }

    public virtual Customer? CustomerCustomer { get; set; }

    public virtual Product? ProductProduct { get; set; }
}