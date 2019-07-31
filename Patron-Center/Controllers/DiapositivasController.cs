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
    public class DiapositivasController : Controller
    {
        private readonly Patron_CenterContext _context;

        public DiapositivasController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: Diapositivas
        public async Task<IActionResult> Index(int UnidadId)
        {
            var patron_CenterContext = _context.Diapositiva.Include(d => d.Unidad).Where(d => d.UnidadId == UnidadId);
            return View(await patron_CenterContext.ToListAsync());
        }

        // GET: Diapositivas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diapositiva = await _context.Diapositiva
                .Include(d => d.Unidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diapositiva == null)
            {
                return NotFound();
            }

            return View(diapositiva);
        }

        // GET: Diapositivas/Create
        public IActionResult Create()
        {
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion");
            return View();
        }

        // POST: Diapositivas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Texto,UrlVide,Orden,Eliminado,UnidadId")] Diapositiva diapositiva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diapositiva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion", diapositiva.UnidadId);
            return View(diapositiva);
        }

        // GET: Diapositivas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diapositiva = await _context.Diapositiva.FindAsync(id);
            if (diapositiva == null)
            {
                return NotFound();
            }
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion", diapositiva.UnidadId);
            return View(diapositiva);
        }

        // POST: Diapositivas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Texto,UrlVideo,Orden,Eliminado,UnidadId")] Diapositiva diapositiva)
        {
            if (id != diapositiva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diapositiva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiapositivaExists(diapositiva.Id))
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
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion", diapositiva.UnidadId);
            return View(diapositiva);
        }

        // GET: Diapositivas
        public async Task<IActionResult> ViewSlides(int UnidadId)
        {
            var patron_CenterContext = _context.Diapositiva.Include(d => d.Unidad).Where(d => d.UnidadId == UnidadId && d.Eliminado == false).OrderBy(d => d.Orden);
            return View(await patron_CenterContext.ToListAsync());
        }

        private bool DiapositivaExists(int id)
        {
            return _context.Diapositiva.Any(e => e.Id == id);
        }
    }
}
