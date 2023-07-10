using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemadeViajes_V2.Entidades;

namespace SistemadeViajes_V2.Controllers
{
    [ApiController]
    [Route("api/sucursales")]
    public class sucursalesControllers : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public sucursalesControllers(ApplicationDBContext context)
        {
            this.context = context;
        }
        [HttpGet("{idSucursal:int}")]
        public async Task<ActionResult<sucursales>> Get(int idSucursal)
        {
            var sucursal = await context.sucursales.Include(x => x.colaborador).FirstOrDefaultAsync(x => x.IdSucursal == idSucursal);

            if (sucursal == null)
            {
                return NotFound();
            }

            return Ok(sucursal);
        }

        [HttpPost]
        public async Task<ActionResult> Post (sucursales sucursales)
        {
            var existecolaborador = await context.colaborador.AnyAsync(x => x.id == sucursales.idcolaborador);
            if(!existecolaborador)
            {
                return BadRequest($"No existe el colaborador de ID: {sucursales.idcolaborador}");
            }
            context.Add(sucursales);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}