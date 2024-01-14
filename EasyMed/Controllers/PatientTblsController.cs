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
    public class PatientTblsController : Controller
    {
        private readonly EasyMedDbContext _context;

        public PatientTblsController(EasyMedDbContext context)
        {
            _context = context;
        }

        // GET: PatientTbls
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientTbls.ToListAsync());
        }

        // GET: PatientTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientTbl = await _context.PatientTbls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientTbl == null)
            {
                return NotFound();
            }

            return View(patientTbl);
        }

        // GET: PatientTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Birthday,Address,PatientCode,Gender,BloodGroup,Organization")] PatientTbl patientTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientTbl);
        }

        // GET: PatientTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientTbl = await _context.PatientTbls.FindAsync(id);
            if (patientTbl == null)
            {
                return NotFound();
            }
            return View(patientTbl);
        }

        // POST: PatientTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Birthday,Address,PatientCode,Gender,BloodGroup,Organization")] PatientTbl patientTbl)
        {
            if (id != patientTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientTblExists(patientTbl.Id))
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
            return View(patientTbl);
        }

        // GET: PatientTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientTbl = await _context.PatientTbls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientTbl == null)
            {
                return NotFound();
            }

            return View(patientTbl);
        }

        // POST: PatientTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientTbl = await _context.PatientTbls.FindAsync(id);
            if (patientTbl != null)
            {
                _context.PatientTbls.Remove(patientTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientTblExists(int id)
        {
            return _context.PatientTbls.Any(e => e.Id == id);
        }
    }
}
