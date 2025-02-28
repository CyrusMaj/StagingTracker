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
    public class DispatchingController : Controller
    {
        private readonly StagingTrackerDbContext _context;

        public DispatchingController(StagingTrackerDbContext context)
        {
            _context = context;
        }

        // GET: Dispatching
        public async Task<IActionResult> Index()
        {
            var stagingTrackerDbContext = _context.Dispatchings.Include(d => d.Order).Include(d => d.Product);
            return View(await stagingTrackerDbContext.ToListAsync());
        }

        // GET: Dispatching/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispatching = await _context.Dispatchings
                .Include(d => d.Order)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DispatchId == id);
            if (dispatching == null)
            {
                return NotFound();
            }

            return View(dispatching);
        }

        // GET: Dispatching/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.OrderManagements, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: Dispatching/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DispatchId,OrderId,ProductId,QuantityDispatched,DispatchDate,CarrierId")] Dispatching dispatching)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dispatching);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.OrderManagements, "OrderId", "OrderId", dispatching.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", dispatching.ProductId);
            return View(dispatching);
        }

        // GET: Dispatching/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispatching = await _context.Dispatchings.FindAsync(id);
            if (dispatching == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.OrderManagements, "OrderId", "OrderId", dispatching.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", dispatching.ProductId);
            return View(dispatching);
        }

        // POST: Dispatching/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DispatchId,OrderId,ProductId,QuantityDispatched,DispatchDate,CarrierId")] Dispatching dispatching)
        {
            if (id != dispatching.DispatchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dispatching);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DispatchingExists(dispatching.DispatchId))
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
            ViewData["OrderId"] = new SelectList(_context.OrderManagements, "OrderId", "OrderId", dispatching.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", dispatching.ProductId);
            return View(dispatching);
        }

        // GET: Dispatching/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispatching = await _context.Dispatchings
                .Include(d => d.Order)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DispatchId == id);
            if (dispatching == null)
            {
                return NotFound();
            }

            return View(dispatching);
        }

        // POST: Dispatching/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dispatching = await _context.Dispatchings.FindAsync(id);
            if (dispatching != null)
            {
                _context.Dispatchings.Remove(dispatching);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DispatchingExists(int id)
        {
            return _context.Dispatchings.Any(e => e.DispatchId == id);
        }
    }
}
