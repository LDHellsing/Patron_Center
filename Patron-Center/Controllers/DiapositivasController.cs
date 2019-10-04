using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Nombre = HttpContext.Session.GetString("_Nombre");
                ViewBag.IdUsuario = HttpContext.Session.GetInt32("_IdUsuario");
                ViewBag.TipoUsuario = HttpContext.Session.GetString("_TipoUsuario");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio. Por favor Ingrese con un usuario Administrador, ";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            var patron_CenterContext = _context.Diapositiva.Include(d => d.Unidad).Where(d => d.UnidadId == UnidadId).OrderBy(d => d.Id).OrderBy(d => d.Orden);

            var Unidad = await _context.Unidad
                .FirstOrDefaultAsync(m => m.Id == UnidadId);

            ViewBag.UnidadId = UnidadId;
            ViewBag.CursoId = Unidad.CursoId;
            return View(await patron_CenterContext.ToListAsync());
        }


        // GET: Diapositivas/Create
        public IActionResult Create(int UnidadId)
        {
            int NextOrder;

            var SlidesCount = _context.Diapositiva
                .Where(d => d.UnidadId == UnidadId)
                .Count();

            if (SlidesCount == 0)
            {
                NextOrder = 1;
            }
            else
            {

                NextOrder = _context.Diapositiva
                .Where(d => d.UnidadId == UnidadId)
                .Max(d => d.Orden);

                NextOrder = NextOrder + 1;
            }


            ViewBag.NextOrder = NextOrder;
            ViewBag.UnidadId_ = UnidadId;
            ViewData["UnidadId"] = new SelectList(_context.Unidad.Where(u => u.Id == UnidadId), "Id", "Nombre");
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
                return RedirectToAction("Index", "Diapositivas", new { UnidadId = diapositiva.UnidadId });
            }

            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Nombre", diapositiva.UnidadId);
            return View(diapositiva);
        }

        // GET: Diapositivas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Nombre = HttpContext.Session.GetString("_Nombre");
                ViewBag.IdUsuario = HttpContext.Session.GetInt32("_IdUsuario");
                ViewBag.TipoUsuario = HttpContext.Session.GetString("_TipoUsuario");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio. Por favor Ingrese con un usuario Administrador, ";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            if (id == null)
            {
                return NotFound();
            }

            var diapositiva = await _context.Diapositiva.FindAsync(id);
            if (diapositiva == null)
            {
                return NotFound();
            }
            ViewBag.UnidadId_ = diapositiva.UnidadId;
            ViewData["UnidadId"] = new SelectList(_context.Unidad.Where(u => u.Id == diapositiva.UnidadId), "Id", "Nombre", diapositiva.UnidadId);
            return View(diapositiva);
        }

        // POST: Diapositivas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Texto,UrlVideo,Orden,Eliminado,UnidadId")] Diapositiva diapositiva)
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Nombre = HttpContext.Session.GetString("_Nombre");
                ViewBag.IdUsuario = HttpContext.Session.GetInt32("_IdUsuario");
                ViewBag.TipoUsuario = HttpContext.Session.GetString("_TipoUsuario");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio. Por favor Ingrese con un usuario Administrador, ";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

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
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Diapositivas", new { UnidadId = diapositiva.UnidadId });
            }
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Nombre", diapositiva.UnidadId);
            return View(diapositiva);
        }

        // GET: Diapositivas
        public async Task<IActionResult> ViewSlides(int UnidadId)
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Nombre = HttpContext.Session.GetString("_Nombre");
                ViewBag.IdUsuario = HttpContext.Session.GetInt32("_IdUsuario");
                ViewBag.TipoUsuario = HttpContext.Session.GetString("_TipoUsuario");
            }

            var Unidad = await _context.Unidad
                .FirstOrDefaultAsync(m => m.Id == UnidadId);

            ViewBag.CursoId = Unidad.CursoId;
            var patron_CenterContext = _context.Diapositiva.Include(d => d.Unidad).Where(d => d.UnidadId == UnidadId && d.Eliminado == false).OrderBy(d => d.Id).OrderBy(d => d.Orden);
            //Nuevo registro para mostrar al final de la diapositiva.
            var slides = patron_CenterContext.Concat(new Diapositiva[] { new Diapositiva { Id = 9999999, Texto = "Fin de diapositiva.", Orden = 999999,Eliminado = false } });
            return View(await slides.ToListAsync());
        }

        private bool DiapositivaExists(int id)
        {
            return _context.Diapositiva.Any(e => e.Id == id);
        }
    }
}
