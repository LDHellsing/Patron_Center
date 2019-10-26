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
        public async Task<IActionResult> Correciones()
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
            return View("CorreccionesPendientesUnidades", unidades);
        }

        // GET: RespuestaAlumnos/CorreccionesAlumnos
        public async Task<IActionResult> CorreccionesAlumnos(int UnidadId)
        {
            var alumnosIds = await _context.GetStudentsWithPendingCorrectionsAsync(UnidadId, (int)HttpContext.Session.GetInt32("_IdUsuario"));
            var alumnos = new List<Usuario>();

            foreach (var id in alumnosIds)
            {
                var aux = await _context.Usuario.FindAsync(id);
                alumnos.Add(aux);
            }
            return View("CorreccionesPendientesAlumnos", alumnos);
        }

        // GET: RespuestaAlumnos/Corregir
        public IActionResult Corregir(int AlumnoId)
        {
            var correccionPendiente = _context.GetPendingCorrection(AlumnoId, (int)HttpContext.Session.GetInt32("_IdUsuario"));

            return View("CorrecionDesarrollo", correccionPendiente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: RespuestaAlumnos/Corregir
        public async Task<IActionResult> Corregir(CorreccionDesarrolloViewModel correccionDesarrolloViewModel)
        {
            // Logica de validacion y guardado de correccion aca

            //puede que sea mejor redireccionar a una view donde le muestre un mensaje de confirmacion con los datos añadidos
            return RedirectToAction("Correciones", "RespuestaAlumnos");
        }

        private bool RespuestaAlumnoExists(int id)
        {
            return _context.RespuestaAlumno.Any(e => e.Id == id);
        }
    }
}
