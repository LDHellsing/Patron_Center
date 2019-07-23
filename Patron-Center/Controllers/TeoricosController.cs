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
    public class TeoricosController : Controller
    {
        private readonly Patron_CenterContext _context;

        public TeoricosController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: Teoricos
        public async Task<IActionResult> Index()
        {
            var patron_CenterContext = _context.Teorico.Include(t => t.Unidad);
            return View(await patron_CenterContext.ToListAsync());
        }

        // GET: Teoricos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teorico = await _context.Teorico
                .Include(t => t.Unidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teorico == null)
            {
                return NotFound();
            }

            return View(teorico);
        }

        // GET: Teoricos/Create
        public IActionResult Create()
        {
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion");
            return View();
        }

        // POST: Teoricos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Eliminado,UnidadId")] Teorico teorico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teorico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion", teorico.UnidadId);
            return View(teorico);
        }

        // GET: Teoricos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teorico = await _context.Teorico.FindAsync(id);
            if (teorico == null)
            {
                return NotFound();
            }
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion", teorico.UnidadId);
            return View(teorico);
        }

        // POST: Teoricos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Eliminado,UnidadId")] Teorico teorico)
        {
            if (id != teorico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teorico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeoricoExists(teorico.Id))
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
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion", teorico.UnidadId);
            return View(teorico);
        }             

        private bool TeoricoExists(int id)
        {
            return _context.Teorico.Any(e => e.Id == id);
        }
    }
}
