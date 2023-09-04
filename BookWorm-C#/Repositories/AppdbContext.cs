using Microsoft.EntityFrameworkCore;
using BookWorm_C_.Entities;

namespace BookWorm_C_.Repositories
{
    public class AppdbContext : DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
        {
        }
        public DbSet<ProductTypeMaster> productTypeMasters { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<AttributeMaster> AttributeMasters { get; set; }
        public virtual DbSet<BeneficiaryMaster> Beneficiarys { get; set; }

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
        public virtual DbSet<Publisher> Publishers { get; set; }

        public virtual DbSet<RoyaltyCalculation> RoyaltyCalculations { get; set; }

    }
    }
