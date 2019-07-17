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
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio. Por favor Ingrese con un usuario Administrador, ";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            return View(await _context.Teorico.ToListAsync());
        }

        // GET: Teoricos/Details/5
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

            var teorico = await _context.Teorico
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
            return View();
        }

        // POST: Teoricos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Eliminado")] Teorico teorico)
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
                _context.Add(teorico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teorico);
        }

        // GET: Teoricos/Edit/5
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

            var teorico = await _context.Teorico.FindAsync(id);
            if (teorico == null)
            {
                return NotFound();
            }
            return View(teorico);
        }

        // POST: Teoricos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Eliminado")] Teorico teorico)
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
            return View(teorico);
        }

        private bool TeoricoExists(int id)
        {
            return _context.Teorico.Any(e => e.Id == id);
        }
    }
}
