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
    public class RespuestasController : Controller
    {
        private readonly Patron_CenterContext _context;

        public RespuestasController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: Respuestas
        public async Task<IActionResult> Index(int PreguntaId)
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
            var patron_CenterContext = _context.Respuesta.Include(r => r.Pregunta).Where(r => r.PreguntaId == PreguntaId);
            var QuizId = patron_CenterContext.Select(q => q.Pregunta.QuizId).FirstOrDefault();
            ViewBag.PreguntaId = PreguntaId;
            ViewBag.QuizId = QuizId;
            return View(await patron_CenterContext.ToListAsync());
        }

        // GET: Respuestas/Create
        public IActionResult Create(int PreguntaId)
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

            //Chequeo si existe otra respuesta correcta
            var patron_CenterContext = _context.Respuesta.Where(r => r.PreguntaId == PreguntaId && r.RespuestaCorrecta == true);
            //Si no existe otra respuesta correcta esta respuesta es correcta
            if (patron_CenterContext.Count() == 0)
            {
                ViewBag.RespuestaCorrecta = true;
            }

            ViewBag.PreguntaId_ = PreguntaId;
            ViewData["PreguntaId"] = new SelectList(_context.Pregunta.Where(p => p.Id == PreguntaId), "Id", "Enunciado", PreguntaId);
            return View();
        }

        // POST: Respuestas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PreguntaId,RespuestaCorrecta,Seleccionada,Eliminado,Enunciado")] Respuesta respuesta)
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
            //Chequeo si existe otra respuesta correcta
            var patron_CenterContext = _context.Respuesta.Where(r => r.PreguntaId == respuesta.PreguntaId && r.RespuestaCorrecta == true);

            //Si no existe otra respuesta correcta y esta respuesta es correcta
            if (patron_CenterContext.Count() == 0 && respuesta.RespuestaCorrecta == true || patron_CenterContext.Count() > 0 && respuesta.RespuestaCorrecta == false)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(respuesta);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Respuestas", new { PreguntaId = respuesta.PreguntaId });
                }
                ViewData["PreguntaId"] = new SelectList(_context.Pregunta, "Id", "Enunciado");
                return View(respuesta);
            }
            else
            {
                ViewBag.RespuestaCorrectaError = string.Format("Debe existir una y solo una respuesta correcta para cada pregunta.");
                Create(respuesta.PreguntaId);
                return View(respuesta);
            }

        }

        // GET: Respuestas/Edit/5
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

            var respuesta = await _context.Respuesta.FindAsync(id);
            if (respuesta == null)
            {
                return NotFound();
            }
            ViewBag.PreguntaCorrecta = respuesta.RespuestaCorrecta;
            ViewBag.PreguntaId_ = respuesta.PreguntaId;
            ViewData["PreguntaId"] = new SelectList(_context.Pregunta, "Id", "Enunciado", respuesta.PreguntaId);
            return View(respuesta);
        }

        // POST: Respuestas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PreguntaId,RespuestaCorrecta,Seleccionada,Eliminado,Enunciado")] Respuesta respuesta)
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

            if (id != respuesta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespuestaExists(respuesta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Respuestas", new { PreguntaId = respuesta.PreguntaId });
            }

            ViewData["PreguntaId"] = new SelectList(_context.Pregunta, "Id", "Enunciado", respuesta.PreguntaId);
            return View(respuesta);
        }

        private bool RespuestaExists(int id)
        {
            return _context.Respuesta.Any(e => e.Id == id);
        }
    }
}
