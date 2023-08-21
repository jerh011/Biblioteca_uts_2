using System.ComponentModel.DataAnnotations;

namespace Biblioteca_uts.Models
{
    public class UsariosModels
    {
        //1
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public int Identificador { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string ApePa { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string ApeMa { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Calle { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Colonia { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string NroCasa { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string tipo { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Contraseña { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Usuario { get; set; }

    }
}
