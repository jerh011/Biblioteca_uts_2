using Microsoft.AspNetCore.Mvc;
using Biblioteca_uts.Datos;
using Biblioteca_uts.Models;
using Biblioteca_uts.Recurso;
//referencias para el trabajo con autenticacion por cookies
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace Biblioteca_uts.Controllers
{
    public class LoginRController: Controller
    {
        LoginUsuarios LogR = new LoginUsuarios();
        UsuarioDatos LogR1 = new UsuarioDatos();

        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        //agregar un if por si el usuario contiene un "@" para no registrarse
        public IActionResult Registro(UsariosModels model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            model.Contraseña = utilidades.EncriptarClave(model.Contraseña);
            bool crearUsuario = LogR.Registro(model);
            if (!crearUsuario)
            {
                //retornar una alerta warning para aclarar que el correo ya esta existente
                ViewData["Mensaje"] = "El Coreo o El ID ya se encuentra en uso";
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }


        }
        public IActionResult Login()
        {
            return View();
        }



        //agregar un if por si el usuario contiene un "@" paara si quiere loguearse con correo o usuario 
        [HttpPost]
        public async Task<IActionResult> Login(string Usuario, string Contraseña)
        {
            UsariosModels usarios = LogR.ValidarUsuario(Usuario, utilidades.EncriptarClave(Contraseña));
            if (usarios.Identificador == 0)
            {
                ViewData["Mensaje"] = "El correo o clave son incorrecta";
                return View();
            }
            //
            //
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,usarios.Nombres)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties);

            return RedirectToAction("Index", "Home");


        }
        public IActionResult CambiarClave()
        {
            return View();
        }
        [HttpPost]

        public IActionResult CambiarClave(string Usuario, string contraseña)
        {
            bool respuesta = LogR.CambiarContraseña(Usuario, utilidades.EncriptarClave(contraseña));
            if (!respuesta)
            {
                ViewData["Mensaje"] = "El Usuario no existe";
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

    }





}



