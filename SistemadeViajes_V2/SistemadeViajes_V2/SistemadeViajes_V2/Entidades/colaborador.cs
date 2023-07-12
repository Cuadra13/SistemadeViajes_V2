using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemadeViajes_V2.Entidades
{
    public class colaborador
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "La distancia desde la casa es requerida.")]
        [Range(0.1, 50, ErrorMessage = "La distancia debe estar entre 0.1 y 50 kilómetros.")]
        public double casa { get; set; }

        public string Perfil { get; set; }

        public List<sucursales> sucursales { get; set; }
    }
}
