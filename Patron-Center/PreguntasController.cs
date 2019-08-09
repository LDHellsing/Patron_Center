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
    public class PreguntasController : Controller
    {
        private readonly Patron_CenterContext _context;

        public PreguntasController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: Preguntas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pregunta.ToListAsync());
        }

        // GET: Preguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Pregunta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return View(pregunta);
        }

        // GET: Preguntas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Preguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdQuiz,Puntaje,EsEliminado,ComentarioDocente,EsMultipleOpcion,Orden,Enunciado")] Pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pregunta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pregunta);
        }

        // GET: Preguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Pregunta.FindAsync(id);
            if (pregunta == null)
            {
                return NotFound();
            }
            return View(pregunta);
        }

        // POST: Preguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdQuiz,Puntaje,EsEliminado,ComentarioDocente,EsMultipleOpcion,Orden,Enunciado")] Pregunta pregunta)
        {
            if (id != pregunta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pregunta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreguntaExists(pregunta.Id))
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
            return View(pregunta);
        }

        // GET: Preguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Pregunta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return View(pregunta);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pregunta = await _context.Pregunta.FindAsync(id);
            _context.Pregunta.Remove(pregunta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreguntaExists(int id)
        {
            return _context.Pregunta.Any(e => e.Id == id);
        }
    }
}
