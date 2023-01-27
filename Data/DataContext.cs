using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using sisu_olorin_api.Models.Access;
using sisu_olorin_api.Models.Product;
using sisu_olorin_api.Models.Sale;
using sisu_olorin_api.Models.Profile;

namespace sisu_olorin_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ProfileType> ProfileTypes { get; set; }
        public DbSet<AccessPermission> AccessPermissions { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStatus> ProductStatus { get; set; }
        public DbSet<ProductSale> ProductSales { get; set; }
        public DbSet<SaleStatus> SaleStatus { get; set; }
        public DbSet<SaleTracking> SaleTrackings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
