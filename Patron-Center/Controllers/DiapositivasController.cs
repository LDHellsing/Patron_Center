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
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio. Por favor Ingrese con un usuario Administrador, ";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            var patron_CenterContext = _context.Diapositiva.Include(d => d.Teorico);
            return View(await patron_CenterContext.ToListAsync());
        }

        // GET: Diapositivas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
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

            var diapositiva = await _context.Diapositiva
                .Include(d => d.Teorico)
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
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio. Por favor Ingrese con un usuario Administrador, ";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            ViewData["TeoricoId"] = new SelectList(_context.Teorico, "Id", "Nombre");
            return View();
        }

        // POST: Diapositivas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idy,Texto,Orden,Eliminado,TeoricoId")] Diapositiva diapositiva)
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio. Por favor Ingrese con un usuario Administrador, ";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            if (ModelState.IsValid)
            {
                _context.Add(diapositiva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeoricoId"] = new SelectList(_context.Teorico, "Id", "Nombre", diapositiva.TeoricoId);
            return View(diapositiva);
        }

        // GET: Diapositivas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
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
            ViewData["TeoricoId"] = new SelectList(_context.Teorico, "Id", "Nombre", diapositiva.TeoricoId);
            return View(diapositiva);
        }

        // POST: Diapositivas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idy,Texto,Orden,Eliminado,TeoricoId")] Diapositiva diapositiva)
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeoricoId"] = new SelectList(_context.Teorico, "Id", "Nombre", diapositiva.TeoricoId);
            return View(diapositiva);
        }


        public async Task<IActionResult> ViewSlides()
        {
            return View();
        }

        private bool DiapositivaExists(int id)
        {
            return _context.Diapositiva.Any(e => e.Id == id);
        }
    }
}
