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
    public class CursosController : Controller
    {
        private readonly Patron_CenterContext _context;

        public CursosController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
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

            if (HttpContext.Session.GetString("_TipoUsuario") == "Administrador")
            {
                var patron_CenterContext = _context.Curso.Include(c => c.Docente);
                return View(await patron_CenterContext.ToListAsync());
            }
            else
            {
                var patron_CenterContext = _context.Curso.Include(c => c.Docente).Where(c => c.DocenteId == HttpContext.Session.GetInt32("_IdUsuario") && c.Eliminado != true);

                foreach (var curso in patron_CenterContext)
                {
                    if (curso.FechaFinalizacion < DateTime.Today)
                    {
                        curso.Finalizado = true;
                    }
                }
                return View(await patron_CenterContext.ToListAsync());
            }

        }

        // GET: Cursos/Create
        public IActionResult Create()
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

            ViewData["DocenteId"] = new SelectList(_context.Usuario.Where(x => x.TipoUsuario.Equals(TipoUsuario.Docente) && !x.Eliminado), "Id", "NombreCompleto");
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,FechaFinalizacion,Eliminado,DocenteId")] Curso curso)
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

            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocenteId"] = new SelectList(_context.Usuario.Where(x => x.TipoUsuario.Equals(TipoUsuario.Docente) && !x.Eliminado), "Id", "NombreCompleto");
            return View(curso);
        }

        // GET: Cursos/Edit/5
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

            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            ViewData["DocenteId"] = new SelectList(_context.Usuario.Where(x => x.TipoUsuario.Equals(TipoUsuario.Docente) && !x.Eliminado), "Id", "NombreCompleto");
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,FechaFinalizacion,Eliminado,DocenteId")] Curso curso)
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

            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.Id))
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
            ViewData["DocenteId"] = new SelectList(_context.Usuario.Where(x => x.TipoUsuario.Equals(TipoUsuario.Docente) && !x.Eliminado), "Id", "NombreCompleto");
            return View(curso);
        }

        private bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.Id == id);
        }
    }
}
