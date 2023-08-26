using Microsoft.AspNetCore.Mvc;
using Biblioteca_uts.Datos;
using Biblioteca_uts.Models;
using Biblioteca_uts.Recurso;
//referencias para el trabajo con autenticacion por cookies
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
//parece que ya

namespace Biblioteca_uts.Controllers
{
    public class LoginRController : Controller
    {
        LoginUsuarios LogR = new LoginUsuarios();
     
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        //agregar un if por si el usuario contiene un "@" para no registrarse
        public IActionResult Registro(UsariosModels model)
        {
             if (model.Usuario.Count(c => c == '@')> 0)
            {
                ViewData["Mensaje"] = "El usuario por lo menos contiene un @";
                return View();

            }
            
            if (model.Correo.Count(c => c == '@') == 0 || model.Correo.Count(c => c == '@')>1)
            {
                ViewData["Mensaje"] = "El Correo no contiene un @ o tiene mas de un @";
                return View();
            }


            if (!ModelState.IsValid)
            {
                return View();
            }
            model.Contraseña = utilidades.EncriptarClave(model.Contraseña);
            bool crearUsuario = LogR.Registro(model);
            if (!crearUsuario)
            {
                //retornar una alerta warning para aclarar que el correo ya esta existente
                ViewData["Mensaje"] = "El Coreo, El ID o el Usuario ya se encuentra en uso";
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


            if (Usuario.IndexOf("@")>= 0)
            {//////////////////////////////////////////////

                UsariosModels usarios = LogR.ValidarCorreo(Usuario, utilidades.EncriptarClave(Contraseña));
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
                //////////////////////////////////////////////
            }
            else
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
            return RedirectToAction("Login");
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



