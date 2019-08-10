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
    public class QuizesController : Controller
    {
        private readonly Patron_CenterContext _context;

        public QuizesController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: Quizes
        public async Task<IActionResult> Index(int UnidadId)
        {
            ViewBag.UnidadId = UnidadId;
            var patron_CenterContext = _context.Quiz.Include(q => q.Unidad).Where(q => q.UnidadId == UnidadId); ;
            return View(await patron_CenterContext.ToListAsync());
        }

        // GET: Quizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz
                .Include(q => q.Unidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // GET: Quizes/Create
        public IActionResult Create(int UnidadId)
        {
            ViewData["UnidadId"] = new SelectList(_context.Unidad.Where(c => c.Id == UnidadId), "Id", "Nombre", UnidadId);
            // ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion");
            return View();
        }

        // POST: Quizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UnidadId,Puntaje,EsEvaluacion,EsEliminado,Nombre")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quiz);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Quizes", new { UnidadId = quiz.UnidadId });
            }
            // ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion", quiz.UnidadId);
            // return View(quiz);
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Nombre");

            return View(quiz);
        }

        // GET: Quizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion", quiz.UnidadId);
            return View(quiz);
        }

        // POST: Quizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UnidadId,Puntaje,EsEvaluacion,EsEliminado,Nombre")] Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizExists(quiz.Id))
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
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion", quiz.UnidadId);
            return View(quiz);
        }

        // GET: Quizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz
                .Include(q => q.Unidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // POST: Quizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quiz = await _context.Quiz.FindAsync(id);
            _context.Quiz.Remove(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.Id == id);
        }
    }
}
