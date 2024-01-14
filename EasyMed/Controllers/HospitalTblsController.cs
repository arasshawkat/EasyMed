using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyMed.DBModels;

namespace EasyMed.Controllers
{
    public class HospitalTblsController : Controller
    {
        private readonly EasyMedDbContext _context;

        public HospitalTblsController(EasyMedDbContext context)
        {
            _context = context;
        }

        // GET: HospitalTbls
        public async Task<IActionResult> Index()
        {
            return View(await _context.HospitalTbls.ToListAsync());
        }

        // GET: HospitalTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitalTbl = await _context.HospitalTbls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospitalTbl == null)
            {
                return NotFound();
            }

            return View(hospitalTbl);
        }

        // GET: HospitalTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HospitalTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HospitalName,IsVisible")] HospitalTbl hospitalTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospitalTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospitalTbl);
        }

        // GET: HospitalTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitalTbl = await _context.HospitalTbls.FindAsync(id);
            if (hospitalTbl == null)
            {
                return NotFound();
            }
            return View(hospitalTbl);
        }

        // POST: HospitalTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HospitalName,IsVisible")] HospitalTbl hospitalTbl)
        {
            if (id != hospitalTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospitalTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalTblExists(hospitalTbl.Id))
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
            return View(hospitalTbl);
        }

        // GET: HospitalTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitalTbl = await _context.HospitalTbls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospitalTbl == null)
            {
                return NotFound();
            }

            return View(hospitalTbl);
        }

        // POST: HospitalTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hospitalTbl = await _context.HospitalTbls.FindAsync(id);
            if (hospitalTbl != null)
            {
                _context.HospitalTbls.Remove(hospitalTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospitalTblExists(int id)
        {
            return _context.HospitalTbls.Any(e => e.Id == id);
        }
    }
}
