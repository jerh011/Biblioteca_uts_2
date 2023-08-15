using System.ComponentModel.DataAnnotations;
namespace Biblioteca_uts.Models
{
    public class CMT_PrestamoModels
    {
        [Required(ErrorMessage="El campo Nombre es obligatorio")]
        public int Pre_Id_Prestamo { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public int Us_Identificador { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Us_Nombres { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Us_ApePa {get;set;}
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public DateTime Pre_Fecha_prestamo { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public DateTime Pre_Fecha_devolucion { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Lib_Titulo { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Lib_Clasificacion { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Lib_IBSN { get; set; }


    }
}
