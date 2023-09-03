using BookWorm_C_.Entities;
using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities;

public partial class Product
{
    public long ProductId { get; set; }

    public ulong IsLibrary { get; set; }

    public ulong IsRentable { get; set; }

    public double MinRentDays { get; set; }

    public string? ProductAuthor { get; set; }

    public double ProductBasePrice { get; set; }

    public string? ProductDescriptionLong { get; set; }

    public string? ProductDescriptionShort { get; set; }

    public string? ProductEnglishName { get; set; }

    public string? Productisbn { get; set; }

    public string? ProductName { get; set; }

    public DateTime? ProductOffPriceExpiryDate { get; set; }

    public double ProductOfferPrice { get; set; }

    public double ProductSpCost { get; set; }

    public double RentPerDay { get; set; }

    public long? ProductGenre { get; set; }

    public long? ProductLang { get; set; }

    public long? ProductPublisher { get; set; }

    public long? TypeId { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<MyShelf> MyShelves { get; set; } = new List<MyShelf>();

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();

    public virtual ICollection<ProductBen> ProductBens { get; set; } = new List<ProductBen>();

    public virtual Genre? ProductGenreNavigation { get; set; }

    public virtual LanguageMaster? ProductLangNavigation { get; set; }

    public virtual Publisher? ProductPublisherNavigation { get; set; }

    public virtual ICollection<RoyaltyCalculation> RoyaltyCalculations { get; set; } = new List<RoyaltyCalculation>();

    public virtual ProductTypeMaster? Type { get; set; }
}
