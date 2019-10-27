using System;
using System.Collections;
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
            var CursoId = _context.Unidad.Select(c => c.CursoId).FirstOrDefault();
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
                if (quiz.Evaluacion == TipoQuiz.Ejercicio && quiz.Ejercicio == TipoEjercicio.Desarrollo)
                {
                    ViewBag.InvalidTypeQuiz = "Los ejercicios deben ser siempre Multiple Opción";
                    //Cargo nuevamente los combobox
                    Create(quiz.UnidadId);
                    return View(quiz);
                }

                if (quiz.Evaluacion == TipoQuiz.Evaluacion)
                {
                    var evaluationsCount = _context.Quiz.Where(q => q.UnidadId == quiz.UnidadId && q.Evaluacion == TipoQuiz.Evaluacion && q.Eliminado == false);

                    if (evaluationsCount.Count() > 0)
                    {
                        ViewBag.ExistingEvaluation = "Ya existe una evalución para esta unidad, no es posible crear una nueva.";
                        //Cargo nuevamente los combobox
                        Create(quiz.UnidadId);
                        return View(quiz);
                    }
                }
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
                if (quiz.Evaluacion == TipoQuiz.Ejercicio && quiz.Ejercicio == TipoEjercicio.Desarrollo)
                {
                    ViewBag.InvalidTypeQuiz = "Los ejercicios deben ser siempre Multiple Opción";
                    //Cargo nuevamente los combobox
                    await Edit(quiz.Id);
                    return View(quiz);
                }

                if (quiz.Evaluacion == TipoQuiz.Evaluacion)
                {
                    var evaluationsCount = _context.Quiz.Where(q => q.UnidadId == quiz.UnidadId && q.Evaluacion == TipoQuiz.Evaluacion && q.Eliminado == false);

                    if (evaluationsCount.Count() > 0)
                    {
                        ViewBag.ExistingEvaluation = "Ya existe una evalución para esta unidad, no es posible crear una nueva.";
                        //Cargo nuevamente los combobox
                        Create(quiz.UnidadId);
                        return View(quiz);
                    }
                }
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
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Quizes", new { UnidadId = quiz.UnidadId });
            }
            ViewData["UnidadId"] = new SelectList(_context.Unidad, "Id", "Descripcion", quiz.UnidadId);
            return View(quiz);
        }


        // Cursar quiz
        // GET: Quizes/AnswerQuiz
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

            if (quizAux.Evaluacion == TipoQuiz.Evaluacion)
            {
                HttpContext.Session.SetString("_Evaluacion", "true");
            }
            else
            {
                HttpContext.Session.SetString("_Evaluacion", "false");
            }

            if (quizAux.Ejercicio == TipoEjercicio.Multiple_Opcion)
            {
                RespuestaAlumnoMO quizMO = new RespuestaAlumnoMO();
                quizMO.IdQuiz = quizAux.Id;
                quizMO.QuizName = quizAux.Nombre;
                quizMO.IdUnidad = quizAux.UnidadId;

                //Ordenamos aleatoriamente las preguntas
                var preguntasAleatorias = MesclarPreguntas(quizAux.Preguntas);
                quizAux.Preguntas = preguntasAleatorias;

                foreach (var pregunta in quizAux.Preguntas)
                {
                    PreguntaViewModel preguntaViewModel = new PreguntaViewModel();
                    preguntaViewModel.IdPregunta = pregunta.Id;
                    preguntaViewModel.Enunciado = pregunta.Enunciado;

                    //Ordenamos aleatoriamenta las respuestas
                    var respuestasAleatroias = MesclarRespuestas(pregunta.Respuestas);
                    pregunta.Respuestas = respuestasAleatroias;

                    foreach (var respuesta in pregunta.Respuestas)
                    {
                        preguntaViewModel.Respuestas.Add(new RespuestaViewModel()
                        {
                            IdRespuesta = respuesta.Id,
                            Enunciado = respuesta.Enunciado
                        });
                    }
                    quizMO.Preguntas.Add(preguntaViewModel);
                }

                return View("AnswerQuiz", quizMO);
            }
            else
            {
                RespuestaAlumnoDesarrollo quizDesarrollo = new RespuestaAlumnoDesarrollo();
                quizDesarrollo.IdQuiz = quizAux.Id;
                quizDesarrollo.QuizName = quizAux.Nombre;
                quizDesarrollo.IdUnidad = quizAux.UnidadId;
                foreach (var pregunta in quizAux.Preguntas)
                {
                    PreguntaViewModelDesarrollo preguntaViewModelDesarrollo = new PreguntaViewModelDesarrollo();
                    preguntaViewModelDesarrollo.IdPregunta = pregunta.Id;
                    preguntaViewModelDesarrollo.Enunciado = pregunta.Enunciado;
                    quizDesarrollo.Preguntas.Add(preguntaViewModelDesarrollo);
                }
                return View("AnswerQuizDesarrollo", quizDesarrollo);
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
                var correcciones = await _context.GetCorrectAnswersAsync(respuestasSeleccionadas);

                int respuestasCorrectas = 0;
                int respuestasIncorrectas = 0;
                int puntajeObtenido = 0;
                int puntajeTotal = 0;
                int puntajeNota = 0;
                //promedio de respuestas en %
                foreach (var correccion in correcciones)
                {
                    if (correccion.RespuestaCorrecta)
                    {
                        respuestasCorrectas++;
                        puntajeTotal += correccion.Puntaje;
                        puntajeObtenido += correccion.Puntaje;
                    }
                    else
                    {
                        respuestasIncorrectas++;
                        puntajeTotal += correccion.Puntaje;
                    }
                }

                puntajeNota = CalcularResultado(puntajeTotal, puntajeObtenido);

                if (HttpContext.Session.GetString("_Evaluacion") == "true")
                {
                    var curso = await _context.GetCourseByUnitAsync(respuestaAlumnoMO.IdUnidad);
                    var calificacionEvaluacion = new Calificacion();
                    calificacionEvaluacion.IdCurso = curso.Id;
                    calificacionEvaluacion.IdUnidad = respuestaAlumnoMO.IdUnidad;
                    calificacionEvaluacion.IdAlumno = (int)HttpContext.Session.GetInt32("_IdUsuario");
                    calificacionEvaluacion.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
                    calificacionEvaluacion.Nota = puntajeNota;
                    _context.Calificacion.Add(calificacionEvaluacion);
                    await _context.SaveChangesAsync();
                }
                ViewBag.IdUnidad = respuestaAlumnoMO.IdUnidad;
                ViewBag.RespuestasCorrectas = respuestasCorrectas;
                ViewBag.RespuestasIncorrectas = respuestasIncorrectas;
                ViewBag.PuntajeTotal = puntajeNota;

                return View("QuizMoResult", correcciones);
            }
            ViewBag.MensajeError = "Debe responder todas las preguntas";
            return View("AnswerQuiz", respuestaAlumnoMO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuizCorrectionDesarrollo(RespuestaAlumnoDesarrollo respuestaAlumnoDesarrollo)
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

            var curso = new Curso();
            curso = await _context.GetCourseByUnitAsync(respuestaAlumnoDesarrollo.IdUnidad);

            foreach (var pregunta in respuestaAlumnoDesarrollo.Preguntas)
            {
                var respuestaAlumno = new RespuestaAlumno();
                respuestaAlumno.UsuarioId = (int)HttpContext.Session.GetInt32("_IdUsuario");
                respuestaAlumno.DocenteId = curso.DocenteId;
                respuestaAlumno.PreguntaId = pregunta.IdPregunta;
                respuestaAlumno.UnidadId = respuestaAlumnoDesarrollo.IdUnidad;
                respuestaAlumno.CursoId = curso.Id;
                respuestaAlumno.RespuestaDesarrollo = pregunta.Respuesta;
                respuestaAlumno.PuntajeObtenido = null;

                _context.RespuestaAlumno.Add(respuestaAlumno);
            }

            if (HttpContext.Session.GetString("_Evaluacion") == "true")
            {
                await _context.SaveChangesAsync();
                ViewBag.QuizDevMessage = "Su evalución fue enviada correctamente y será corregida por el docente en breve, ";
                ViewBag.IdUnidad = respuestaAlumnoDesarrollo.IdUnidad;
                return View("Views/Quizes/QuizDevFinished.cshtml");

            }
            else
            {
                ViewBag.QuizDevMessage = "Gracias por su participación, ";
                ViewBag.IdUnidad = respuestaAlumnoDesarrollo.IdUnidad;
                return View("Views/Quizes/QuizDevFinished.cshtml");
            }
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

            var patron_CenterContext = _context.Quiz.Include(q => q.Unidad).Include(c => c.Unidad.Curso).Where(q => q.UnidadId == UnidadId && q.Eliminado != true);
            // Detección de evaluciones que fueron cursadas o ya estan finalizadas.
            foreach (var quiz in patron_CenterContext)
            {
                if (quiz.Unidad.Curso.FechaFinalizacion < DateTime.Now)
                {
                    quiz.CursoFinalizado = true;
                }
                else
                {
                    //Evaluaciones con calificación
                    var calificacion = _context.Calificacion.Where(c => c.IdAlumno == HttpContext.Session.GetInt32("_IdUsuario") && c.IdUnidad == quiz.UnidadId && quiz.Evaluacion == TipoQuiz.Evaluacion);

                    if (calificacion.Count() > 0)
                    {
                        quiz.EvalucionCursada = true;
                    }
                    else
                    {
                        //Evaluaciones con respuestas
                        var respuestaAlumno = _context.RespuestaAlumno.Where(r => r.UsuarioId == HttpContext.Session.GetInt32("_IdUsuario") && r.UnidadId == quiz.UnidadId && quiz.Evaluacion == TipoQuiz.Evaluacion);

                        if (respuestaAlumno.Count() > 0)
                        {
                            quiz.EvalucionCursada = true;
                        }
                    }
                }
            }

            var CursoId = patron_CenterContext.Select(c => c.Unidad.CursoId).FirstOrDefault();
            ViewBag.UnidadId = UnidadId;
            ViewBag.CursoId = CursoId;
            return View(await patron_CenterContext.ToListAsync());
        }


        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.Id == id);
        }

        private int CalcularResultado(int puntajeTotal, int puntajeObtenido)
        {
            double puntaje = 0;
            if (puntajeObtenido == 0)
            {
                return (int)puntaje;
            }
            else
            {
                puntaje = (double)puntajeObtenido * 100 / puntajeTotal;
                return (int)Math.Round(puntaje);
            }
        }
        private List<Pregunta> MesclarPreguntas(List<Pregunta> preguntasQuiz)
        {
            var rng = new Random();
            int i = preguntasQuiz.Count;
            while (i > 1)
            {
                int j = rng.Next(i--);
                Pregunta temp = preguntasQuiz[i];
                preguntasQuiz[i] = preguntasQuiz[j];
                preguntasQuiz[j] = temp;
            }
            return preguntasQuiz;
        }
        private List<Respuesta> MesclarRespuestas(List<Respuesta> respuestasPregunta)
        {
            var rng = new Random();
            int i = respuestasPregunta.Count;
            while (i > 1)
            {
                int j = rng.Next(i--);
                Respuesta temp = respuestasPregunta[i];
                respuestasPregunta[i] = respuestasPregunta[j];
                respuestasPregunta[j] = temp;
            }
            return respuestasPregunta;
        }
    }
}
