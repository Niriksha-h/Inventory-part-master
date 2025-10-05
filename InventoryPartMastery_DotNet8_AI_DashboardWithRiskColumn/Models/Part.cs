
using System.ComponentModel.DataAnnotations;

namespace InventoryPartMastery.Models
{
    public class Part
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string PartNumber { get; set; } = string.Empty; // V2(50) varchar

        [Required, StringLength(100)]
        public string PartName { get; set; } = string.Empty;   // V2(100)

        [Required, StringLength(10)]
        public string PartLocation { get; set; } = string.Empty; // V2(10)

        [Required, StringLength(5)]
        public string PartBin { get; set; } = string.Empty;      // V2(5)

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; } // NUMBER (int)
    }
}
