using BookWorm_C_.Entities;
using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities;

public partial class InvoiceDetail
{
    public long InvoiceDetailId { get; set; }

    public double BasePrice { get; set; }

    public int Quantity { get; set; }

    public int RentNoOfDays { get; set; }

    public string? TranType { get; set; }

    public long? InvoiceId { get; set; }

    public long? ProductId { get; set; }

    public virtual InvoiceTable? Invoice { get; set; }

    public virtual Product? Product { get; set; }
}
