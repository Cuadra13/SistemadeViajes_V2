using System.ComponentModel.DataAnnotations;

namespace SistemadeViajes_V2.Entidades
{
    public class sucursales
    {
        [Key]
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public double Distancia { get; set; }
        public int idcolaborador {get; set; }   
        public colaborador colaborador { get; set; }    
    }
}
