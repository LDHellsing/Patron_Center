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
                    System.Collections.ArrayList result;
                    result = await _context.ValidarUsuario(usuario);

                    if ((bool) result[0] == false)
                    {
                        return NotFound(usuario);
                    }
                    /*
                     * Puede que sea mejor que el metodo de vaidar usuario solo retorne algunos
                     * valores en ves del objeto entero
                     */
                    Usuario user = (Usuario) result[1];
                    HttpContext.Session.SetInt32("_IdUsuario", user.Id);
                    HttpContext.Session.SetString("_Documento", user.Documento);
                    //O nombre completo
                    HttpContext.Session.SetString("_Nombre", user.Nombre);
                    HttpContext.Session.SetString("_TipoUsuario", user.TipoUsuario.ToString());
                    HttpContext.Session.GetString("_Nombre");
                    /*
                     * creo que para validar si una sesion fue inicializada vamos a tener que 
                     * hacer algo como:
                     * if (HttpContext.Session.GetInt32("_IdUsuario") == null)
                    {
                        //Redireccionamos al login 
                    }
                     */

                    return RedirectToAction("Index", "HomeController");
                }
                return View(usuario);

            }
            catch
            {
                return View();
            }
        }

    }
}