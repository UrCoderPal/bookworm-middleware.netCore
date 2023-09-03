using BookWorm_C_.Entities;
using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities;

public partial class MyShelf
{
    public long MyShelfId { get; set; }

    public ulong IsActive { get; set; }

    public DateTime? ProductExpiryDate { get; set; }

    public string? TranType { get; set; }

    public long? CustomerId { get; set; }

    public long? ProductId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
