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

            var patron_CenterContext = _context.CursoUsuario.Include(c => c.Curso).Include(c => c.Usuario);
            return View(await patron_CenterContext.ToListAsync());
        }

        // GET: CursoUsuarios/VerCursosUsuario
        public async Task<IActionResult> ViewUserLessons()
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
                // Si el usuario es alumno muestro solo los cursos que tiene asignado.
                var patron_CenterContextFiltrado = _context.CursoUsuario.Include(c => c.Curso).Include(c => c.Usuario).Where(c => c.UsuarioId == HttpContext.Session.GetInt32("_IdUsuario"));
                ViewBag.Nombre = HttpContext.Session.GetString("_Nombre");
                ViewBag.IdUsuario = HttpContext.Session.GetString("_IdUsuario");
                return View(await patron_CenterContextFiltrado.ToListAsync());
            }

            var patron_CenterContext = _context.CursoUsuario.Include(c => c.Curso).Include(c => c.Usuario);
            return View(await patron_CenterContext.ToListAsync());
        }




        // GET: CursoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
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

            var cursoUsuario = await _context.CursoUsuario
                .Include(c => c.Curso)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoUsuario == null)
            {
                return NotFound();
            }

            return View(cursoUsuario);
        }

        // GET: CursoUsuarios/Create
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

            ViewData["CursoId"] = new SelectList(_context.Curso.Where(x => !x.Eliminado), "Id", "Nombre");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario.Where(x => x.TipoUsuario.Equals(TipoUsuario.Alumno) && !x.Eliminado), "Id", "NombreCompleto");
            return View();
        }

        // POST: CursoUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,CursoId")] CursoUsuario cursoUsuario)
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

            //Busco si ya existe la asociacion curso usuario
            var patron_CenterContext = _context.CursoUsuario.Where(c => c.CursoId == cursoUsuario.CursoId && c.UsuarioId == cursoUsuario.UsuarioId);
            //Si no existe creo la asociacion curso usuario
            if (patron_CenterContext.Count() == 0)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cursoUsuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Create));
                }
                ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Id", cursoUsuario.CursoId);
                ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", cursoUsuario.UsuarioId);
                return View(cursoUsuario);
            }
            else
            {
                ViewBag.UsuarioYaEnCurso = "El Alumno ya se encuentra inscripto en el Curso";
                //Cargo nuevamente los combobox
                Create();
                return View(cursoUsuario);
            }
        }

        // GET: CursoUsuarios/Edit/5
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

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio. Por favor Ingrese con un usuario Administrador, ";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

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
            ViewData["UsuarioId"] = new SelectList(_context.Usuario.Where(x => x.TipoUsuario.Equals(TipoUsuario.Alumno) && !x.Eliminado), "Id", "NombreCompleto");
            return View(cursoUsuario);
        }

        // POST: CursoUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,CursoId")] CursoUsuario cursoUsuario)
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

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio. Por favor Ingrese con un usuario Administrador, ";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            if (id != cursoUsuario.Id)
            {
                return NotFound();
            }
            //Busco si ya existe la asociacion curso usuario
            var patron_CenterContext = _context.CursoUsuario.Where(c => c.CursoId == cursoUsuario.CursoId && c.UsuarioId == cursoUsuario.UsuarioId);
            //Si no existe creo la asociacion curso usuario
            if (patron_CenterContext.Count() == 0)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(cursoUsuario);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CursoUsuarioExists(cursoUsuario.Id))
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
            }
            else
            {
                ViewBag.UsuarioYaEnCurso = "El Alumno ya se encuentra inscripto en el Curso";
                //Cargo nuevamente los combobox
                Create();
                return View(cursoUsuario);
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Id", cursoUsuario.CursoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", cursoUsuario.UsuarioId);
            return View(cursoUsuario);
        }

        private bool CursoUsuarioExists(int id)
        {
            return _context.CursoUsuario.Any(e => e.Id == id);
        }
    }
}
