using InventoryPartMastery.Data;
using Microsoft.AspNetCore.Mvc;
using InventoryPartMastery.Services;

namespace InventoryPartMastery.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly StockPredictionService _predictor;

        public HomeController(AppDbContext context, StockPredictionService predictor)
        {
            _context = context;
            _predictor = predictor;
        }

        public IActionResult Index()
        {
            var parts = _context.Parts.ToList();

            // Stock chart data
            ViewBag.PartNames = parts.Select(p => p.PartName).ToList();
            ViewBag.StockQuantities = parts.Select(p => p.StockQuantity).ToList();

            // Risk chart data
            ViewBag.SafeCount = parts.Count(p => p.StockQuantity > 30);
            ViewBag.MediumCount = parts.Count(p => p.StockQuantity >= 10 && p.StockQuantity <= 30);
            ViewBag.HighCount = parts.Count(p => p.StockQuantity < 10);

            return View(parts);
        }
    }
}
