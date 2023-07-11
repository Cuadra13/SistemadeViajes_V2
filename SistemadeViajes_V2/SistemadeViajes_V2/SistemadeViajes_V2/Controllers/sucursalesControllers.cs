using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemadeViajes_V2.Entidades;
using System.Threading.Tasks;

namespace SistemadeViajes_V2.Controllers
{
    [ApiController]
    [Route("api/sucursales")]
    public class SucursalesController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public SucursalesController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet("{idSucursal:int}")]
        public async Task<ActionResult<sucursales>> Get(int idSucursal)
        {
            var sucursal = await context.sucursales
                .Include(x => x.colaborador)
                .FirstOrDefaultAsync(x => x.IdSucursal == idSucursal);

            if (sucursal == null)
            {
                return NotFound();
            }

            return Ok(sucursal);
        }

        [HttpPost]
        public async Task<ActionResult> Post(sucursales sucursal)
        {
            var existecolaborador = await context.colaborador.AnyAsync(x => x.id == sucursal.idcolaborador);
            if (!existecolaborador)
            {
                return BadRequest($"No existe el colaborador de ID: {sucursal.idcolaborador}");
            }
            context.Add(sucursal);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
