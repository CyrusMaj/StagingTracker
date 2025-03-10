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
    public class QualityControlController : Controller
    {
        private readonly StagingTrackerDbContext _context;

        public QualityControlController(StagingTrackerDbContext context)
        {
            _context = context;
        }

        // GET: QualityControl
        public async Task<IActionResult> Index()
        {
            var stagingTrackerDbContext = _context.QualityControls.Include(q => q.Receiving);
            return View(await stagingTrackerDbContext.ToListAsync());
        }

        // GET: QualityControl/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualityControl = await _context.QualityControls
                .Include(q => q.Receiving)
                .FirstOrDefaultAsync(m => m.Qcid == id);
            if (qualityControl == null)
            {
                return NotFound();
            }

            return View(qualityControl);
        }

        // GET: QualityControl/Create
        public IActionResult Create()
        {
            ViewData["ReceivingId"] = new SelectList(_context.Receivings, "ReceivingId", "ReceivingId");
            return View();
        }

        // POST: QualityControl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Qcid,ReceivingId,InspectionDate,InspectionResult,InspectorName")] QualityControl qualityControl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualityControl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReceivingId"] = new SelectList(_context.Receivings, "ReceivingId", "ReceivingId", qualityControl.ReceivingId);
            return View(qualityControl);
        }

        // GET: QualityControl/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualityControl = await _context.QualityControls.FindAsync(id);
            if (qualityControl == null)
            {
                return NotFound();
            }
            ViewData["ReceivingId"] = new SelectList(_context.Receivings, "ReceivingId", "ReceivingId", qualityControl.ReceivingId);
            return View(qualityControl);
        }

        // POST: QualityControl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Qcid,ReceivingId,InspectionDate,InspectionResult,InspectorName")] QualityControl qualityControl)
        {
            if (id != qualityControl.Qcid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qualityControl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualityControlExists(qualityControl.Qcid))
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
            ViewData["ReceivingId"] = new SelectList(_context.Receivings, "ReceivingId", "ReceivingId", qualityControl.ReceivingId);
            return View(qualityControl);
        }

        // GET: QualityControl/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualityControl = await _context.QualityControls
                .Include(q => q.Receiving)
                .FirstOrDefaultAsync(m => m.Qcid == id);
            if (qualityControl == null)
            {
                return NotFound();
            }

            return View(qualityControl);
        }

        // POST: QualityControl/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qualityControl = await _context.QualityControls.FindAsync(id);
            if (qualityControl != null)
            {
                _context.QualityControls.Remove(qualityControl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QualityControlExists(int id)
        {
            return _context.QualityControls.Any(e => e.Qcid == id);
        }
    }
}
