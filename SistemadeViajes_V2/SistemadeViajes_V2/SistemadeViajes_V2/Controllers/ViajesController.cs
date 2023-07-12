using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemadeViajes_V2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemadeViajes_V2.Controllers
{
    [ApiController]
    [Route("api/viajes")]
    public class ViajesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ViajesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarViaje(Viaje viaje)
        {
 

            // Validar si el colaborador ya ha viajado en la fecha seleccionada
            var fechaViaje = viaje.FechaViaje.Date;
            var colaboradorViajeExistente = await _context.Viajes
                .AnyAsync(v => v.ColaboradorId == viaje.ColaboradorId && v.FechaViaje.Date == fechaViaje);

            if (colaboradorViajeExistente)
            {
                return BadRequest("El colaborador ya ha viajado en la fecha seleccionada.");
            }

            // Validar si la suma de distancias de los viajes acumulados supera los 100 km
            var distanciaAcumulada = await _context.Viajes
                .Where(v => v.ColaboradorId == viaje.ColaboradorId && v.FechaViaje.Date == fechaViaje)
                .SumAsync(v => v.Distancia);

            if (distanciaAcumulada + viaje.Distancia > 100)
            {
                return BadRequest("La distancia acumulada de los viajes supera los 100 km.");
            }

            _context.Viajes.Add(viaje);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
