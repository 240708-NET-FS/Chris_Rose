using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Project_1.Entities;

public class ApplicationDbContext : DbContext {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

    public ApplicationDbContext(){}

    public DbSet<OrderedItem> OrderedItems { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) {
            IConfigurationRoot config = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json")
                                            .Build();
            
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {

        modelBuilder.Entity<InventoryItem>()
                // .HasNoKey();
                .HasKey(i => i.product_id);

        modelBuilder.Entity<OrderedItem>()
                .HasKey(o => o.product_id);


        modelBuilder.Entity<InventoryItem>()
                .HasOne(i => i.ordered_item)
                .WithOne(o => o.inventory_item)
                .HasForeignKey<OrderedItem>(i => i.product_id);
    }
}