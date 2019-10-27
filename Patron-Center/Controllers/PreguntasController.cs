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
            var patron_CenterContext = _context.Pregunta.Include(p => p.Quiz).Where(p => p.QuizId == QuizId);
            var UnidadId = patron_CenterContext.Select(u => u.Quiz.UnidadId).FirstOrDefault();
            ViewBag.QuizType = patron_CenterContext.Select(p => p.Quiz.Ejercicio).FirstOrDefault();
            ViewBag.QuizId = QuizId;
            ViewBag.UnidadId = UnidadId;
            return View(await patron_CenterContext.ToListAsync());
        }

        // GET: Preguntas/Create
        public IActionResult Create(int QuizId)
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

            int NextOrder;

            var QuestionCount = _context.Pregunta
                .Where(p => p.QuizId == QuizId)
                .Count();

            if (QuestionCount == 0)
            {
                NextOrder = 1;
            }
            else
            {

                NextOrder = _context.Pregunta
                .Where(d => d.QuizId == QuizId)
                .Max(d => d.Orden);

                NextOrder = NextOrder + 1;
            }

            ViewBag.NextOrder = NextOrder;
            ViewBag.QuizId_ = QuizId;
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

            ViewBag.QuizId_ = pregunta.QuizId;

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

            var pregunta = await _context.Pregunta.FindAsync(id);
            if (pregunta == null)
            {
                return NotFound();
            }
            ViewBag.QuizId_ = pregunta.QuizId;
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
            ViewBag.QuizId_ = pregunta.QuizId;

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
                return RedirectToAction("Index", "Preguntas", new { QuizId = pregunta.QuizId });
            }
            ViewData["QuizId"] = new SelectList(_context.Quiz, "Id", "Nombre", pregunta.QuizId);
            return View(pregunta);
        }

        private bool PreguntaExists(int id)
        {
            return _context.Pregunta.Any(e => e.Id == id);
        }
    }
}
