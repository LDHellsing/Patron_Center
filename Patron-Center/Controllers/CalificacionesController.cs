
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
    public class CalificacionesController : Controller
    {
        private readonly Patron_CenterContext _context;

        public CalificacionesController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: Calificaciones
        public IActionResult Index()
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


            int idUsuario = (int) HttpContext.Session.GetInt32("_IdUsuario");
            var tipoUsuario = HttpContext.Session.GetString("_TipoUsuario");

            var calificaciones = _context.getCalificaciones(tipoUsuario, idUsuario);

            return View(calificaciones);
        }
        private bool CalificacionExists(int id)
        {
            return _context.Calificacion.Any(e => e.Id == id);
        }
    }
}
