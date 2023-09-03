﻿using BookWorm_C_.Entities;
using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities;

public partial class InvoiceTable
{
    public long InvoiceTableId { get; set; }

    public double InvoiceAmount { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public long? CustId { get; set; }

    public virtual Customer? Cust { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<RoyaltyCalculation> RoyaltyCalculations { get; set; } = new List<RoyaltyCalculation>();
}