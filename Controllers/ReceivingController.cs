using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StagingTracker.Data;

namespace StagingTracker.Controllers
{
    public class ReceivingController : Controller
    {
        private readonly StagingTrackerDbContext _context;

        public ReceivingController(StagingTrackerDbContext context)
        {
            _context = context;
        }

        // GET: Receiving
        public async Task<IActionResult> Index()
        {
            var stagingTrackerDbContext = _context.Receivings.Include(r => r.Product);
            return View(await stagingTrackerDbContext.ToListAsync());
        }

        // GET: Receiving/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiving = await _context.Receivings
                .Include(r => r.Product)
                .FirstOrDefaultAsync(m => m.ReceivingId == id);
            if (receiving == null)
            {
                return NotFound();
            }

            return View(receiving);
        }

        // GET: Receiving/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: Receiving/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceivingId,PurchaseOrderId,ProductId,QuantityReceived,ReceivedDate,SupplierId")] Receiving receiving)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receiving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", receiving.ProductId);
            return View(receiving);
        }

        // GET: Receiving/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiving = await _context.Receivings.FindAsync(id);
            if (receiving == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", receiving.ProductId);
            return View(receiving);
        }

        // POST: Receiving/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceivingId,PurchaseOrderId,ProductId,QuantityReceived,ReceivedDate,SupplierId")] Receiving receiving)
        {
            if (id != receiving.ReceivingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceivingExists(receiving.ReceivingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", receiving.ProductId);
            return View(receiving);
        }

        // GET: Receiving/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiving = await _context.Receivings
                .Include(r => r.Product)
                .FirstOrDefaultAsync(m => m.ReceivingId == id);
            if (receiving == null)
            {
                return NotFound();
            }

            return View(receiving);
        }

        // POST: Receiving/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receiving = await _context.Receivings.FindAsync(id);
            if (receiving != null)
            {
                _context.Receivings.Remove(receiving);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceivingExists(int id)
        {
            return _context.Receivings.Any(e => e.ReceivingId == id);
        }
    }
}
