using BookWorm_C_.Entities;
using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities;

public partial class Customer
{
    public long CustomerId { get; set; }

    public string? CustomerContactNo { get; set; }

    public string? CustomerEmail { get; set; }

    public string? CustomerName { get; set; }

    public ulong IsPremium { get; set; }

    public string? Password { get; set; }

    public DateTime? PremiumDate { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<InvoiceTable> InvoiceTables { get; set; } = new List<InvoiceTable>();

    public virtual ICollection<MyShelf> MyShelves { get; set; } = new List<MyShelf>();
}