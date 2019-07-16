using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patron_Center.Models;

namespace Patron_Center.Controllers
{
    public class LoginController : Controller
    {
        private readonly Patron_CenterContext _context;

        public LoginController(Patron_CenterContext context)
        {
            _context = context;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("User,Password")] LoginViewModel usuario)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    
                   UsuarioValidoDTO result = await _context.ValidarUsuario(usuario);

                    if (result.UsuarioValido == false)
                    {
                        ViewBag.InvalidUserMessage = "Usuario o contraseña no valido";
                        return View(usuario);
                    }
                    
                    HttpContext.Session.SetInt32("_IdUsuario", result.IdUsuario);
                    HttpContext.Session.SetString("_Documento", result.Documento);
                    HttpContext.Session.SetString("_Nombre", result.NombreUsuario);
                    HttpContext.Session.SetString("_TipoUsuario", result.Rol);
                 

                    return RedirectToAction("Index", "Home");
                }

                return ValidationProblem();

            }
            catch
            {
                return ValidationProblem();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}