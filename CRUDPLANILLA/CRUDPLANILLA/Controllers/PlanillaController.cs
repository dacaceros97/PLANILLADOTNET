using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDPLANILLA.Data;
using CRUDPLANILLA.Models;

namespace CRUDPLANILLA.Controllers
{
    public class PlanillaController : Controller
    {
        private readonly Context _context;

        public PlanillaController(Context context)
        {
            _context = context;
        }

        // GET: Planilla
        public async Task<IActionResult> Index()
        {
              return _context.Planilla != null ? 
                          View(await _context.Planilla.ToListAsync()) :
                          Problem("Entity set 'Context.Planilla'  is null.");
        }

        // GET: Planilla/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Planilla == null)
            {
                return NotFound();
            }

            var planilla = await _context.Planilla
                .FirstOrDefaultAsync(m => m.Id_Registro == id);
            if (planilla == null)
            {
                return NotFound();
            }

            return View(planilla);
        }

        // GET: Planilla/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planilla/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Registro,Id_Usuario,IGSS,IRTRA,SalarioTotal,SalarioLiquido")] Planilla planilla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planilla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planilla);
        }

        // GET: Planilla/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Planilla == null)
            {
                return NotFound();
            }

            var planilla = await _context.Planilla.FindAsync(id);
            if (planilla == null)
            {
                return NotFound();
            }
            return View(planilla);
        }

        // POST: Planilla/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Registro,Id_Usuario,IGSS,IRTRA,SalarioTotal,SalarioLiquido")] Planilla planilla)
        {
            if (id != planilla.Id_Registro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanillaExists(planilla.Id_Registro))
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
            return View(planilla);
        }

        // GET: Planilla/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Planilla == null)
            {
                return NotFound();
            }

            var planilla = await _context.Planilla
                .FirstOrDefaultAsync(m => m.Id_Registro == id);
            if (planilla == null)
            {
                return NotFound();
            }

            return View(planilla);
        }

        // POST: Planilla/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Planilla == null)
            {
                return Problem("Entity set 'Context.Planilla'  is null.");
            }
            var planilla = await _context.Planilla.FindAsync(id);
            if (planilla != null)
            {
                _context.Planilla.Remove(planilla);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanillaExists(int id)
        {
          return (_context.Planilla?.Any(e => e.Id_Registro == id)).GetValueOrDefault();
        }
    }
}
