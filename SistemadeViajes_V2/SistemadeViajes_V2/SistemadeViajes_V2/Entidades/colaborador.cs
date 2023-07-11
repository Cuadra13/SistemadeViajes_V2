using Microsoft.EntityFrameworkCore;

namespace SistemadeViajes_V2.Entidades
{
    public class colaborador
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double casa {get; set; }
        public string Perfil { get; set; } // Agrega la propiedad Perfil
        public List<sucursales> sucursales { get; set; }
    }
}
