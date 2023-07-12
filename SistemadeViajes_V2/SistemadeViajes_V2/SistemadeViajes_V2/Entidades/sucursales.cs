using System.ComponentModel.DataAnnotations;

namespace SistemadeViajes_V2.Entidades
{
    public class sucursales
    {
        [Key]
        public int IdSucursal { get; set; }

        [Required(ErrorMessage = "El nombre de la sucursal es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La distancia es requerida.")]
        [Range(0.1, 50, ErrorMessage = "La distancia debe estar entre 0.1 y 50 kilómetros.")]
        public double Distancia { get; set; }

        public int idcolaborador { get; set; }
        public colaborador colaborador { get; set; }
    }
}
