
using InventoryPartMastery.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryPartMastery.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Part> Parts => Set<Part>();
    }

    public static class SeedData
    {
        public static void Initialize(AppDbContext db)
        {
            if (!db.Parts.Any())
            {
                db.Parts.AddRange(
                    new Part { PartNumber = "V2-0001", PartName = "Bolt M6", PartLocation = "A01", PartBin = "B01", StockQuantity = 50 },
                    new Part { PartNumber = "V2-0002", PartName = "Nut M6",  PartLocation = "A01", PartBin = "B02", StockQuantity = 20 },
                    new Part { PartNumber = "V2-0003", PartName = "Washer",  PartLocation = "A02", PartBin = "B03", StockQuantity = 5 },
                    new Part { PartNumber = "V2-0004", PartName = "Bracket", PartLocation = "B01", PartBin = "C01", StockQuantity = 2 }
                );
                db.SaveChanges();
            }
        }
    }
}
