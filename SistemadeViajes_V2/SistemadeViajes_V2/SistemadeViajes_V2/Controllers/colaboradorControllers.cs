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
    [Route("api/colaborador")]
    public class colaboradorControllers : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public colaboradorControllers(ApplicationDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<colaborador>>> Get()
        {
            return await context.colaborador.Include(x => x.sucursales).ToListAsync();
        }

        [HttpGet("Primero")]
        public async Task<ActionResult<colaborador>> PrimerColaborador()
        {
            return await context.colaborador.FirstOrDefaultAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<colaborador>> Get (int id)
        {
            var colaborador =  await context.colaborador.FirstOrDefaultAsync(x => x.id == id);
            if(colaborador == null)
            {
                return NotFound();
            }
            return colaborador;
            
        }


        [HttpPost]
        public async Task<ActionResult> Post(colaborador colaborador)
        {
            context.Add(colaborador);
                await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] //api/colaborador/algo
        public async Task<ActionResult> Put (colaborador colaborador, int id)
        {
            if(colaborador.id!= id)
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
            var existe = await context.colaborador.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new colaborador() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }

}
