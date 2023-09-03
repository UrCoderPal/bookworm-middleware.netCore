using BookWorm_C_.Entities;
using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities;

public partial class ProductBen
{
    public long ProductBenId { get; set; }

    public double ProdBenPercentage { get; set; }

    public long? ProdBenBenId { get; set; }

    public long? ProdBenProductId { get; set; }

    public virtual Beneficiary? ProdBenBen { get; set; }

    public virtual Product? ProdBenProduct { get; set; }
}
