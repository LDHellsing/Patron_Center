using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Patron_Center.Models;

namespace Patron_Center.Controllers
{
    public class PreguntasController : Controller
    {
        private readonly Patron_CenterContext _context;

        public PreguntasController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: Preguntas
        public async Task<IActionResult> Index(int QuizId)
        {
            ViewBag.QuizId = QuizId;
            var patron_CenterContext = _context.Pregunta.Include(p => p.Quiz).Where(p => p.QuizId == QuizId);
            return View(await patron_CenterContext.ToListAsync());
        }

        // GET: Preguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Pregunta
                .Include(p => p.Quiz)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return View(pregunta);
        }

        // GET: Preguntas/Create
        public IActionResult Create(int QuizId)
        {
            ViewData["QuizId"] = new SelectList(_context.Quiz.Where(q => q.Id == QuizId), "Id", "Nombre", QuizId);
            return View();
        }

        // POST: Preguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QuizId,Puntaje,Eliminado,ComentarioDocente,MultipleOpcion,Orden,Enunciado")] Pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                // Quiz quizPadre = await _context.Quiz.FindAsync(pregunta.QuizId);
                // quizPadre.Preguntas.Add(Pregunta)
                _context.Add(pregunta);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Preguntas", new { QuizId = pregunta.QuizId });
            }
            // ViewData["QuizId"] = new SelectList(_context.Quiz, "Id", "Nombre", pregunta.QuizId);
            // return View(pregunta);
            ViewData["QuizId"] = new SelectList(_context.Quiz, "Id", "Nombre");

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
            ViewData["QuizId"] = new SelectList(_context.Quiz, "Id", "Nombre", pregunta.QuizId);
            return View(pregunta);
        }

        // POST: Preguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuizId,Puntaje,Eliminado,ComentarioDocente,MultipleOpcion,Orden,Enunciado")] Pregunta pregunta)
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
            ViewData["QuizId"] = new SelectList(_context.Quiz, "Id", "Nombre", pregunta.QuizId);
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
                .Include(p => p.Quiz)
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
