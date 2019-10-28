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
    public class RespuestaAlumnosController : Controller
    {
        private readonly Patron_CenterContext _context;

        public RespuestaAlumnosController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: RespuestaAlumnos
        public async Task<IActionResult> Index()
        {
            return View(await _context.RespuestaAlumno.ToListAsync());
        }

        // GET: RespuestaAlumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuestaAlumno = await _context.RespuestaAlumno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (respuestaAlumno == null)
            {
                return NotFound();
            }

            return View(respuestaAlumno);
        }

        // GET: RespuestaAlumnos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RespuestaAlumnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,DocenteId,PreguntaId,RespuestaDesarrollo,PuntajeObtenido")] RespuestaAlumno respuestaAlumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respuestaAlumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(respuestaAlumno);
        }

        // GET: RespuestaAlumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuestaAlumno = await _context.RespuestaAlumno.FindAsync(id);
            if (respuestaAlumno == null)
            {
                return NotFound();
            }
            return View(respuestaAlumno);
        }

        // POST: RespuestaAlumnos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,DocenteId,PreguntaId,RespuestaDesarrollo,PuntajeObtenido")] RespuestaAlumno respuestaAlumno)
        {
            if (id != respuestaAlumno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respuestaAlumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespuestaAlumnoExists(respuestaAlumno.Id))
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
            return View(respuestaAlumno);
        }

        // GET: RespuestaAlumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuestaAlumno = await _context.RespuestaAlumno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (respuestaAlumno == null)
            {
                return NotFound();
            }

            return View(respuestaAlumno);
        }

        // POST: RespuestaAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respuestaAlumno = await _context.RespuestaAlumno.FindAsync(id);
            _context.RespuestaAlumno.Remove(respuestaAlumno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: RespuestaAlumnos/Correcciones
        public async Task<IActionResult> Correcciones()
        {
            var cursosIds = await _context.GetCoursesWithPendingCorrectionsAsync((int)HttpContext.Session.GetInt32("_IdUsuario"));
            var cursos = new List<Curso>();

            foreach (var id in cursosIds)
            {
                var aux = await _context.Curso.FindAsync(id);
                cursos.Add(aux);
            }
            return View("CorreccionesPendientesCursos", cursos);
        }

        // GET: RespuestaAlumnos/CorreccionesUnidades
        public async Task<IActionResult> CorreccionesUnidades(int CursoId)
        {
            var unidadesIds = await _context.GetUnitsWithPendingCorrectionsAsync(CursoId, (int)HttpContext.Session.GetInt32("_IdUsuario"));
            var unidades = new List<Unidad>();

            foreach (var id in unidadesIds)
            {
                var aux = await _context.Unidad.FindAsync(id);
                unidades.Add(aux);
            }
            HttpContext.Session.SetInt32("_IdCursoCorreccion", CursoId);
            return View("CorreccionesPendientesUnidades", unidades);
        }

        // GET: RespuestaAlumnos/CorreccionesAlumnos
        public async Task<IActionResult> CorreccionesAlumnos(int UnidadId)
        {
            HttpContext.Session.SetInt32("_UnidadIdCorreccion", UnidadId);
            var alumnosIds = await _context.GetStudentsWithPendingCorrectionsAsync(UnidadId, (int)HttpContext.Session.GetInt32("_IdUsuario"));
            var alumnos = new List<Usuario>();

            foreach (var id in alumnosIds)
            {
                var aux = await _context.Usuario.FindAsync(id);
                alumnos.Add(aux);
            }
            ViewBag.CursoId = HttpContext.Session.GetInt32("_IdCursoCorreccion");
            ViewBag.UnidadId = HttpContext.Session.GetInt32("_UnidadIdCorreccion");
            return View("CorreccionesPendientesAlumnos", alumnos);
        }

        // GET: RespuestaAlumnos/Corregir
        public IActionResult Corregir(int AlumnoId)
        {
            var idDocente = (int)HttpContext.Session.GetInt32("_IdUsuario");
            var idUnidad = (int)HttpContext.Session.GetInt32("_UnidadIdCorreccion");
            var correccionPendiente = _context.GetPendingCorrection(AlumnoId, idDocente, idUnidad);

            ViewBag.UnidadId = idUnidad;
            return View("CorrecionDesarrollo", correccionPendiente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: RespuestaAlumnos/Corregir
        public async Task<IActionResult> Corregir(CorreccionDesarrolloViewModel correccionDesarrolloViewModel)
        {
            if (ModelState.IsValid)
            {
                // Valida que el docente no ingrese una nota superior al máximo asignado a una pregunta
                foreach (var correccion in correccionDesarrolloViewModel.Correcciones)
                {
                    if(correccion.PuntajeAsignado > correccion.PuntajeMaximoPregunta)
                    {
                        ViewBag.MensajeError = "El puntaje asignado a una pregunta no puede superar el máximo de la misma";
                        return View("CorrecionDesarrollo", correccionDesarrolloViewModel);
                    }
                }

                var notaFinal = 0;

                foreach (var correccion in correccionDesarrolloViewModel.Correcciones)
                {
                    notaFinal += correccion.PuntajeAsignado;
                    var correccionAux = await _context.RespuestaAlumno.FindAsync(correccion.Id);
                    correccionAux.PuntajeObtenido = correccion.PuntajeAsignado;
                    _context.Update(correccionAux);
                    await _context.SaveChangesAsync();
                }

                // Creamos la calificación final de la evaluación
                var calificacion = new Calificacion();
                calificacion.IdAlumno = correccionDesarrolloViewModel.IdAlumno;
                calificacion.IdCurso = correccionDesarrolloViewModel.IdCurso;
                calificacion.IdUnidad = correccionDesarrolloViewModel.IdUnidad;
                calificacion.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
                calificacion.Nota = notaFinal;
                _context.Calificacion.Add(calificacion);
                await _context.SaveChangesAsync();

                return RedirectToAction("Correcciones", "RespuestaAlumnos");
            }

            ViewBag.MensajeError = "Todas las respuestas deben tener un puntaje y este debe estar entre cero y el puntaje máximo de la pregunta";
            return View("CorrecionDesarrollo", correccionDesarrolloViewModel);
        }

        private bool RespuestaAlumnoExists(int id)
        {
            return _context.RespuestaAlumno.Any(e => e.Id == id);
        }
    }
}
