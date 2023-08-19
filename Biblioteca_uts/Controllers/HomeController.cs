using Biblioteca_uts.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;//sea guego esto 
using Microsoft.AspNetCore.Authorization;
///using Microsoft.AspNetCore.Http;//sea guego esto 
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Biblioteca_uts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ClaimsPrincipal claimUser = HttpContext.User;
            string usuarioNombre = "";
            if (claimUser.Identity.IsAuthenticated) {
                usuarioNombre = claimUser.Claims.Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();
            }
            ViewData["Mesaje"] = usuarioNombre;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        public IActionResult Inicio()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> CerrarSesion() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","LoginR");
        }

    }
}