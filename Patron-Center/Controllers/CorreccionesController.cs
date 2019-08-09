using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Patron_Center.Models;

namespace Patron_Center
{
    public class CorreccionesController : Controller
    {
        private readonly Patron_CenterContext _context;

        public CorreccionesController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: Correcciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Correccion.ToListAsync());
        }

        // GET: Correcciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correccion = await _context.Correccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (correccion == null)
            {
                return NotFound();
            }

            return View(correccion);
        }

        // GET: Correcciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Correcciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdQuiz,IdAlumno,Resultado")] Correccion correccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(correccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(correccion);
        }

        // GET: Correcciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correccion = await _context.Correccion.FindAsync(id);
            if (correccion == null)
            {
                return NotFound();
            }
            return View(correccion);
        }

        // POST: Correcciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdQuiz,IdAlumno,Resultado")] Correccion correccion)
        {
            if (id != correccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(correccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorreccionExists(correccion.Id))
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
            return View(correccion);
        }

        // GET: Correcciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correccion = await _context.Correccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (correccion == null)
            {
                return NotFound();
            }

            return View(correccion);
        }

        // POST: Correcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var correccion = await _context.Correccion.FindAsync(id);
            _context.Correccion.Remove(correccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorreccionExists(int id)
        {
            return _context.Correccion.Any(e => e.Id == id);
        }
    }
}
