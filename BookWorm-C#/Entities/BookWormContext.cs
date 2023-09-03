using BookWorm_C_.Entities;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_C_.Entities;

    public class BookWormContext : DbContext
    {
        public BookWormContext()
        {
        }

        public BookWormContext(DbContextOptions<BookWormContext> options)
            : base(options)
        {
        }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<AttributeMaster> AttributeMasters { get; set; }

        public virtual DbSet<Beneficiary> Beneficiarys { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public virtual DbSet<InvoiceTable> InvoiceTables { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<MyShelf> MyShelves { get; set; }

        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

        public virtual DbSet<ProductBen> ProductBens { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductType> ProductTypes { get; set; }

        public virtual DbSet<Publisher> Publishers { get; set; }

        public virtual DbSet<RoyaltyCalculation> RoyaltyCalculations { get; set; }
    }

