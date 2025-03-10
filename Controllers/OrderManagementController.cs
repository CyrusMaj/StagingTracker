using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StagingTracker.Data;

namespace StagingTracker.Controllers
{
    public class OrderManagementController : Controller
    {
        private readonly StagingTrackerDbContext _context;

        public OrderManagementController(StagingTrackerDbContext context)
        {
            _context = context;
        }

        // GET: OrderManagement
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderManagements.ToListAsync());
        }

        // GET: OrderManagement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderManagement = await _context.OrderManagements
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderManagement == null)
            {
                return NotFound();
            }

            return View(orderManagement);
        }

        // GET: OrderManagement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,OrderDate,RequiredDispatchDate,Status")] OrderManagement orderManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderManagement);
        }

        // GET: OrderManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderManagement = await _context.OrderManagements.FindAsync(id);
            if (orderManagement == null)
            {
                return NotFound();
            }
            return View(orderManagement);
        }

        // POST: OrderManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,OrderDate,RequiredDispatchDate,Status")] OrderManagement orderManagement)
        {
            if (id != orderManagement.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderManagementExists(orderManagement.OrderId))
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
            return View(orderManagement);
        }

        // GET: OrderManagement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderManagement = await _context.OrderManagements
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderManagement == null)
            {
                return NotFound();
            }

            return View(orderManagement);
        }

        // POST: OrderManagement/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderManagement = await _context.OrderManagements.FindAsync(id);
            if (orderManagement != null)
            {
                _context.OrderManagements.Remove(orderManagement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderManagementExists(int id)
        {
            return _context.OrderManagements.Any(e => e.OrderId == id);
        }
    }
}
