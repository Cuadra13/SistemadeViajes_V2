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
    public class ViajesControllers : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<colaborador>> Get()
        {
            return new List<colaborador>
            {
                new colaborador() { id = 1, nombre = "Nelson" },
                new colaborador() { id = 2, nombre = "Francisco" }
            };
        }
    }
}
