using System.ComponentModel.DataAnnotations;
namespace Biblioteca_uts.Models
{
    public class PrestamosModels
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public int IdPrestamo { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public int Identificador { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public DateTime Fecha_prestamo { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public DateTime Fecha_devolucion { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public int No_Adquisicion { get; set; }
    }
}
