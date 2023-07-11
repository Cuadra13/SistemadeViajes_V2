using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemadeViajes_V2.Entidades;
using System.Threading.Tasks;

namespace SistemadeViajes_V2.Controllers
{


    [ApiController]
    [Route("api/colaborador")]


    public class ColaboradorController : ControllerBase
    {


        private readonly ApplicationDBContext context;

        public ColaboradorController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<colaborador>>> Get()
        {
            return await context.colaborador.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<colaborador>> Get(int id)
        {
            var colaborador = await context.colaborador
                .FirstOrDefaultAsync(x => x.id == id);

            if (colaborador == null)
            {
                return NotFound();
            }

            return colaborador;
        }

        [HttpPost]
        public async Task<ActionResult> Post(colaborador colaborador)
        {
            if (colaborador.Perfil != "Gerente de tienda")
            {
                return BadRequest("Solo los usuarios con perfil 'Gerente de tienda' pueden registrar colaboradores.");
            }

            context.Add(colaborador);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(colaborador colaborador, int id)
        {
            if (colaborador.id != id)
            {
                return BadRequest("El id del colaborador no coincide con el id de la URL");
            }

            context.Update(colaborador);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var colaborador = await context.colaborador.FindAsync(id);

            if (colaborador == null)
            {
                return NotFound();
            }

            context.Remove(colaborador);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
