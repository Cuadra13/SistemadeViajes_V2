using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemadeViajes_V2.Entidades;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemadeViajes_V2.Controllers
{
    [ApiController]
    [Route("api/viajes")]
    public class ViajesController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public ViajesController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarViaje(ViajeModel model)
        {
            // a. Verificar el perfil del usuario
            if (!EsUsuarioGerenteDeTienda())
            {
                return Forbid();
            }

            // b. Registrar el usuario que registra el viaje
            string usuarioRegistrador = ObtenerUsuarioRegistrador();

            // c. Seleccionar la sucursal y mostrar los colaboradores asignados
            var sucursal = await context.sucursales
                .Include(s => s.colaborador)
                .FirstOrDefaultAsync(s => s.IdSucursal == model.SucursalId);

            if (sucursal == null)
            {
                return NotFound("La sucursal seleccionada no existe");
            }

            // d. Seleccionar los colaboradores que viajarán
            var colaboradoresSeleccionados = sucursal.Colaboradores
                .Where(c => model.ColaboradoresIds.Contains(c.IdColaborador));

            // e. Seleccionar el transportista
            string transportista = model.Transportista;

            // f. La tarifa que cobra el colaborador no puede ser modificada (suponiendo que está en la clase Colaborador)
            var colaboradores = await context.colaborador
                .Where(c => colaboradoresSeleccionados.Contains(c))
                .ToListAsync();

            // g. La distancia de la sucursal a la casa del colaborador no puede ser modificada desde este formulario
            
            double distanciaTotal = sucursal.Distancia * colaboradoresSeleccionados.Count();

            if (distanciaTotal > 100)
            {
                return BadRequest("La distancia total del viaje supera los 100 km");
            }

            // h. Un colaborador solo puede viajar una vez por cada día
            var fechaViaje = model.FechaViaje.Date;
            bool viajeDuplicado = await context.Viajes
                .AnyAsync(v => v.FechaViaje.Date == fechaViaje && colaboradores.Contains(v.Colaborador));

            if (viajeDuplicado)
            {
                return BadRequest("Un colaborador solo puede viajar una vez por cada día");
            }

            // Crear el objeto Viaje y guardarlo en la base de datos
            var viaje = new Viaje
            {
                FechaViaje = model.FechaViaje,
                Sucursal = sucursal,
                Colaboradores = colaboradoresSeleccionados.ToList(),
                Transportista = transportista,
                Registrador = usuarioRegistrador
            };

            context.Viajes.Add(viaje);
            await context.SaveChangesAsync();

            return Ok();
        }

        // Otras acciones y métodos necesarios

        private bool EsUsuarioGerenteDeTienda()
        {
            // Lógica para verificar si el usuario actual es un gerente de tienda
            // Retornar true si el usuario es gerente de tienda, false en caso contrario

            // Ejemplo de lógica ficticia
            var perfilUsuario = ObtenerPerfilUsuarioActual();
            return perfilUsuario == "Gerente de tienda";
        }

        private string ObtenerUsuarioRegistrador()
        {
            // Lógica para obtener el usuario que registra el viaje
           

            // Ejemplo de lógica ficticia
            return ObtenerUsuarioActual();
        }

        // Otros métodos de utilidad

    }
}
