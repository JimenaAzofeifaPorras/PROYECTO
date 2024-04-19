using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitarServicioController : ControllerBase
    {
        ISolicitarServicioService SolicitarServicioService;

        public SolicitarServicioController(ISolicitarServicioService solicitarServicioService)
        {
            SolicitarServicioService = solicitarServicioService;
        }

        // GET: api/<SolicitarServicioController>
        [HttpGet]
        public IEnumerable<SolicitarServicioModel> Get()
        {
            return SolicitarServicioService.GetSolicitarServicios();
        }

        // GET api/<SolicitarServicioController>/5
        [HttpGet("{id}")]
        public SolicitarServicioModel Get(int id)
        {
            return SolicitarServicioService.GetById(id);
        }

        // POST api/<SolicitarServicioController>
        [HttpPost]
        public string Post([FromBody] SolicitarServicioModel solicitarServicio)
        {
            var result = SolicitarServicioService.AddSolicitarServicio(solicitarServicio);

            if (result)
            {
                return "SolicitarServicio Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }
    }
}