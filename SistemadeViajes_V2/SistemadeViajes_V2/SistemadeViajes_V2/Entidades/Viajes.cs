using SistemadeViajes_V2.Migrations;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemadeViajes_V2.Entidades
{
    public class Viaje
    {
        [Key]
        public int Id { get; set; }

        public DateTime FechaViaje { get; set; }

        public int SucursalId { get; set; }
        public sucursales Sucursal { get; set; }

        public int ColaboradorId { get; set; }
        public colaborador Colaborador { get; set; }

        public string Transportista { get; set; }
    }
}
