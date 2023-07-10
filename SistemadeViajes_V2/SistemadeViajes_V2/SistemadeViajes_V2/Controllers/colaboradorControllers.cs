using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<colaborador>> Get()
        {
            return new List<colaborador>
            {
                new colaborador() { id = 1, nombre = "Nelson" },
                new colaborador() { id = 2, nombre = "Francisco" }
            };
        }

        [HttpPost]
        public async Task<ActionResult> Post(colaborador colaborador)
        {
            context.Add(colaborador);
                await context.SaveChangesAsync();
            return Ok();
        }
    }
}
