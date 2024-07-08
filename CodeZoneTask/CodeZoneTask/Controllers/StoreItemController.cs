using CodeZoneTask.Data;
using CodeZoneTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeZoneTask.Controllers
{
    public class StoreItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoreItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var storeItems = _context.StoreItems.Include(si => si.Store).Include(si => si.Item);
            return View(await storeItems.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["StoreID"] = new SelectList(_context.Stores, "StoreID", "StoreName");
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreID,ItemID,Quantity")] StoreItem storeItem)
        {
            if (ModelState.IsValid)
            {
                if (storeItem.Quantity == null)
                {
                    storeItem.Quantity = 0;
                }

                var existingStoreItem = await _context.StoreItems
                    .FirstOrDefaultAsync(si => si.StoreID == storeItem.StoreID && si.ItemID == storeItem.ItemID);

                if (existingStoreItem != null)
                {
                    existingStoreItem.Quantity += storeItem.Quantity;
                    _context.Update(existingStoreItem);
                }
                else
                {
                    _context.Add(storeItem);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StoreID"] = new SelectList(_context.Stores, "StoreID", "StoreName", storeItem.StoreID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", storeItem.ItemID);
            return View(storeItem);
        }

        [HttpGet]
        public IActionResult GetQuantity(int storeID, int itemID)
        {
            var quantity = _context.StoreItems
                .Where(si => si.StoreID == storeID && si.ItemID == itemID)
                .Select(si => si.Quantity)
                .FirstOrDefault();

            return Json(quantity);
        }
    }
}
