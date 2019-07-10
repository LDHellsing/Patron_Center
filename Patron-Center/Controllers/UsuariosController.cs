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
    public class UsuariosController : Controller
    {
        private readonly Patron_CenterContext _context;

        public UsuariosController(Patron_CenterContext context)
        {
            _context = context;
        }


        // GET: Usuarios
        public async Task<IActionResult> Index()      
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                HttpContext.Session.Clear();
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            return View(await _context.Usuario.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                HttpContext.Session.Clear();
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                HttpContext.Session.Clear();
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Documento,Nombre,Apellido,Email,Password,TipoUsuario,Eliminado")] Usuario usuario)
        {

            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                HttpContext.Session.Clear();
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            //Busco si ya existe un usuario con el documento a ingresar
            var patron_CenterContext = _context.Usuario.Where(u => u.Documento == usuario.Documento);
            //Si no existe creo el usuario
            if (patron_CenterContext.Count() == 0)
            { 
                if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(usuario);
            }
            else
            {
                ViewBag.UsuarioDuplicado = string.Format("El usuario con el documento: {0} ya se encuentra en el sistema",usuario.Documento);
                return View(usuario);
            }
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                HttpContext.Session.Clear();
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Documento,Nombre,Apellido,Email,Password,TipoUsuario,Eliminado")] Usuario usuario)
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                HttpContext.Session.Clear();
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            if (id != usuario.Id)
            {
                return NotFound();
            }

            //Busco si ya existe un usuario con el documento a ingresar
            var patron_CenterContext = _context.Usuario.Where(u => u.Documento == usuario.Documento);
            //Si no existe creo el usuario
            if (patron_CenterContext.Count() == 0)
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(usuario);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UsuarioExists(usuario.Id))
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
                ViewBag.UsuarioDuplicado = string.Format("El usuario con el documento: {0} ya se encuentra en el sistema", usuario.Documento);
                return View(usuario);
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                HttpContext.Session.Clear();
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetInt32("_IdUsuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (HttpContext.Session.GetString("_TipoUsuario") == "Alumno")
            {
                HttpContext.Session.Clear();
                ViewBag.InvalidUserMessage = "Usted no tiene permiso para acceder a este sitio";
                return View("Views/Shared/UnauthorisedUserError.cshtml");
            }

            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //No estoy seguro si a este metodo hay que añadirle las validaciones de tipo de usuario...
        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
