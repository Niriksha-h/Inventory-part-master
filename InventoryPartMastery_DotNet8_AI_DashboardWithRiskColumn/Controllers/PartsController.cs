
using InventoryPartMastery.Data;
using InventoryPartMastery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryPartMastery.Controllers
{
    public class PartsController : Controller
    {
        private readonly AppDbContext _db;
        public PartsController(AppDbContext db) => _db = db;

        // GET: Parts
        public async Task<IActionResult> Index(string? search)
        {
            var query = _db.Parts.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(p =>
                    p.PartNumber.ToLower().Contains(search) ||
                    p.PartName.ToLower().Contains(search) ||
                    p.PartLocation.ToLower().Contains(search) ||
                    p.PartBin.ToLower().Contains(search));
            }
            return View(await query.OrderBy(p => p.PartName).ToListAsync());
        }

        // GET: Parts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var part = await _db.Parts.FindAsync(id);
            if (part == null) return NotFound();
            return View(part);
        }

        // GET: Parts/Create
        public IActionResult Create() => View();

        // POST: Parts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartNumber,PartName,PartLocation,PartBin,StockQuantity")] Part part)
        {
            if (ModelState.IsValid)
            {
                _db.Add(part);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(part);
        }

        // GET: Parts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var part = await _db.Parts.FindAsync(id);
            if (part == null) return NotFound();
            return View(part);
        }

        // POST: Parts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PartNumber,PartName,PartLocation,PartBin,StockQuantity")] Part part)
        {
            if (id != part.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(part);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.Parts.Any(e => e.Id == part.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(part);
        }

        // GET: Parts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var part = await _db.Parts.FindAsync(id);
            if (part == null) return NotFound();
            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var part = await _db.Parts.FindAsync(id);
            if (part != null)
            {
                _db.Parts.Remove(part);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
