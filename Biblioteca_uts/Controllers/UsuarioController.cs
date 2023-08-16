using Biblioteca_uts.Models;
using Biblioteca_uts.Datos;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_uts.Controllers
{
    public class UsuarioController : Controller
    {

        //Datos/ContactoDatos
        UsuarioDatos _Usuario = new UsuarioDatos();
        LibrosDatos _Libros = new LibrosDatos();
        public IActionResult Listar()
        {
            var lista2 = _Libros.Listar();
            ViewBag.Lista = lista2;

            var lista = _Usuario.Listar();
            return View(lista);
        }
        //##############################
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(UsariosModels model)
        {
            var UsuarioCreado = _Usuario.GuardarUsuario(model);
            if (UsuarioCreado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }

        }
        //##############################
        public IActionResult Editar(int Identificador)
        {
            UsariosModels _contacto = _Usuario.ObtenerUsuario(Identificador);
            return View(_contacto);
        }

        [HttpPost]
        public IActionResult Editar(UsariosModels model)
        {
            //para obtener los datos que se editadoen del formulario y enviarlos  en la base de datos 
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _Usuario.EditarUsuario(model);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int Identificador)
        {
            var _contacto = _Usuario.ObtenerUsuario(Identificador);
            return View(_contacto);
        }

        [HttpPost]
        public IActionResult Eliminar(UsariosModels mode)
        {
            var respuesta = _Usuario.EliminarUsuario(mode.Identificador);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();//ya que aregle el problemas borrarlo
            }

        }


    }
}