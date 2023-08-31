using Microsoft.EntityFrameworkCore;
using Product_Easa_Models.Core;

namespace Product_easa_Database.SQLConnection;

public class ProductEasaDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public ProductEasaDbContext(DbContextOptions<ProductEasaDbContext> options) : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
}
