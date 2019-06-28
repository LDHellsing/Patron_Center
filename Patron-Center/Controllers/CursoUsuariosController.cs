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
    public class CursoUsuariosController : Controller
    {
        private readonly Patron_CenterContext _context;

        public CursoUsuariosController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: CursoUsuarios
        public async Task<IActionResult> Index()
        {
            var patron_CenterContext = _context.CursoUsuario.Include(c => c.Curso).Include(c => c.Usuario);
            return View(await patron_CenterContext.ToListAsync());
        }

        // GET: CursoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoUsuario = await _context.CursoUsuario
                .Include(c => c.Curso)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (cursoUsuario == null)
            {
                return NotFound();
            }   

            return View(cursoUsuario);
        }

        // GET: CursoUsuarios/Create
        public IActionResult Create()
        {

            ViewData["CursoId"] = new SelectList(_context.Curso.Where(x => !x.Eliminado), "Id", "Nombre");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario.Where(x => x.TipoUsuario.Equals(TipoUsuario.Alumno) && !x.Eliminado), "Id", "NombreCompleto");
            return View();
        }

        // POST: CursoUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,CursoId")] CursoUsuario cursoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Nombre", cursoUsuario.CursoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "NombreCompleto", cursoUsuario.UsuarioId);
            return View(cursoUsuario);
        }

        // GET: CursoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoUsuario = await _context.CursoUsuario.FindAsync(id);
            if (cursoUsuario == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Nombre", cursoUsuario.CursoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "NombreCompleto", cursoUsuario.UsuarioId);
            return View(cursoUsuario);
        }

        // POST: CursoUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,CursoId")] CursoUsuario cursoUsuario)
        {
            if (id != cursoUsuario.CursoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoUsuarioExists(cursoUsuario.CursoId))
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
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Nombre", cursoUsuario.CursoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "NombreCompleto", cursoUsuario.UsuarioId);
            return View(cursoUsuario);
        }

        // GET: CursoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoUsuario = await _context.CursoUsuario
                .Include(c => c.Curso)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (cursoUsuario == null)
            {
                return NotFound();
            }

            return View(cursoUsuario);
        }

        // POST: CursoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoUsuario = await _context.CursoUsuario.FindAsync(id);
            _context.CursoUsuario.Remove(cursoUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoUsuarioExists(int id)
        {
            return _context.CursoUsuario.Any(e => e.CursoId == id);
        }
    }
}
