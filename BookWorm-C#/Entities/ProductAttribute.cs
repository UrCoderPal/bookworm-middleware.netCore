using BookWorm_C_.Entities;
using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities;

public partial class ProductAttribute
{
    public long ProductAttributeId { get; set; }

    public string? AttributeValue { get; set; }

    public long? AttributeId { get; set; }

    public long? ProductId { get; set; }

    public virtual AttributeMaster? AttributeMasters { get; set; }

    public virtual Product? Product { get; set; }
}
