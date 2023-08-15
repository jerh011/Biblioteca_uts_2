using System.ComponentModel.DataAnnotations;
namespace Biblioteca_uts.Models
{
    public class LibrosModel
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public int No_Adquisicion { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Titulo { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public DateTime Fecha_adquisicion { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Ibsn { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Clasificacion { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public int No_Estante { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Estatus { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Procedencia { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? No_factura { get; set; }

    }




}
