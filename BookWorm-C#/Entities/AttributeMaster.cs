using BookWorm_C_.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BookWorm_C_.Entities;
public partial class AttributeMaster
{
    
    public long AttributeMasterId { get; set; }

    public string? AttributeDesc { get; set; }

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();
}