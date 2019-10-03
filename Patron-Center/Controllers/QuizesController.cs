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
    public class QuizesController : Controller
    {
        private readonly Patron_CenterContext _context;

        public QuizesController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: Quizes
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

            var patron_CenterContext = _context.Quiz.Include(q => q.Unidad).Where(q => q.UnidadId == UnidadId);
            var CursoId = patron_CenterContext.Select(c => c.Unidad.CursoId).FirstOrDefault();
            ViewBag.UnidadId = UnidadId;
            ViewBag.CursoId = CursoId;
            return View(await patron_CenterContext.ToListAsync());
        }

        // GET: Quizes/Create
        public IActionResult Create(int UnidadId)
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

            ViewBag.UnidadId_ = UnidadId;
            ViewData["UnidadId"] = new SelectList(_context.Unidad.Where(u => u.Id == UnidadId), "Id", "Nombre", UnidadId);
            return View();
        }

        // POST: Quizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UnidadId,Puntaje,Evaluacion,Ejercicio,Eliminado,Nombre")] Quiz quiz)
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
                _context.Add(quiz);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Quizes", new { UnidadId = quiz.UnidadId });
            }
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Nombre", quiz.UnidadId);

            return View(quiz);
        }

        // GET: Quizes/Edit/5
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

            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            ViewBag.UnidadId_ = quiz.UnidadId;
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Nombre", quiz.UnidadId);
            
            return View(quiz);
        }

        // POST: Quizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UnidadId,Puntaje,Evaluacion,Ejercicio,Eliminado,Nombre")] Quiz quiz)
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

            if (id != quiz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizExists(quiz.Id))
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
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion", quiz.UnidadId);
            return View(quiz);
        }

  
        // Cursar quiz
        // GET
        // Quizes/AnswerQuiz
        public async Task<IActionResult> AnswerQuiz(int QuizId)
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

            var quizAux = await _context.CreateQuiz(QuizId);

            if (quizAux.Ejercicio == TipoEjercicio.Multiple_Opcion)
            {
                RespuestaAlumnoMO quiz = new RespuestaAlumnoMO();
                quiz.IdQuiz = quizAux.Id;
                quiz.QuizName = quizAux.Nombre;
                quiz.IdUnidad = quizAux.UnidadId;
                foreach (var pregunta in quizAux.Preguntas)
                {
                    PreguntaViewModel preguntaViewModel = new PreguntaViewModel();
                    preguntaViewModel.IdPregunta = pregunta.Id;
                    preguntaViewModel.Enunciado = pregunta.Enunciado;

                    foreach (var respuesta in pregunta.Respuestas)
                    {
                        preguntaViewModel.Respuestas.Add(new RespuestaViewModel()
                        {
                            IdRespuesta = respuesta.Id,
                            Enunciado = respuesta.Enunciado
                        });
                    }
                    quiz.Preguntas.Add(preguntaViewModel);
                }

                return View("AnswerQuiz", quiz);
            }
            else
            {
                // AÑADIR ACA LA CREACION DEL VIEW MODEL DE QUIZ DE DESARROLLO Y RETORNAR LA VISTA AnswerQuizDesarrollo
                return View("AnswerQuiz", quizAux);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Esta coleccion de ints tiene todos los ids de las respuestas
        public async Task<IActionResult> QuizCorrection(RespuestaAlumnoMO respuestaAlumnoMO)
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

            if (ModelState.IsValid)
            {
                List<int> respuestasSeleccionadas = new List<int>();
                // Las respuestas selccionadas desde la view vienen como strings este foreach lo que hace es crear una lista de ints con las respuestas seleccionadas
                foreach (var respuesta in respuestaAlumnoMO.Preguntas)
                {
                    respuestasSeleccionadas.Add(Int32.Parse(respuesta.Seleccionada));
                }
                // Me traigo una lista que contiene los datos de las respuestas seleccionadas por el alumno en la BD
                var correcciones = await _context.ObtenerRespuestasCorrectas(respuestasSeleccionadas);

                int respuestasCorrectas = 0;
                int respuestasIncorrectas = 0;
                int puntajeTotal = 0;
                //promedio de respuestas en %
                foreach (var correccion in correcciones)
                {
                    if (correccion.RespuestaCorrecta)
                    {
                        respuestasCorrectas++;
                        // Se asume que todos los quizes van a ser /100
                        puntajeTotal += correccion.Puntaje;
                    }
                    else
                    {
                        respuestasIncorrectas++;
                    }
                }

                // puntajeTotal = calcularResultado(puntajeTotal);

                ViewBag.IdUnidad = respuestaAlumnoMO.IdUnidad;
                ViewBag.RespuestasCorrectas = respuestasCorrectas;
                ViewBag.RespuestasIncorrectas = respuestasIncorrectas;
                ViewBag.PuntajeTotal = puntajeTotal;

                return View("QuizMoResult", correcciones);
            }
            ViewBag.MensajeError = "Debe responder todas las preguntas";
            return View("AnswerQuiz", respuestaAlumnoMO);
        }

        // GET: Quizes para alumnos
        public async Task<IActionResult> ViewQuizes(int UnidadId)
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

            var patron_CenterContext = _context.Quiz.Include(q => q.Unidad).Where(q => q.UnidadId == UnidadId && q.Eliminado != true);
            var CursoId = patron_CenterContext.Select(c => c.Unidad.CursoId).FirstOrDefault();
            ViewBag.UnidadId = UnidadId;
            ViewBag.CursoId = CursoId;
            return View(await patron_CenterContext.ToListAsync());
        }


        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.Id == id);
        }
    }
}
