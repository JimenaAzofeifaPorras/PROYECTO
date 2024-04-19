using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitarProductoController : ControllerBase
    {
        ISolicitarProductoService SolicitarProductoService;

        public SolicitarProductoController(ISolicitarProductoService solicitarProductoService)
        {
            SolicitarProductoService = solicitarProductoService;
        }

        // GET: api/<SolicitarProductoController>
        [HttpGet]
        public IEnumerable<SolicitarProductoModel> Get()
        {
            return SolicitarProductoService.GetSolicitarProductos();
        }

        // GET api/<SolicitarProductoController>/5
        [HttpGet("{id}")]
        public SolicitarProductoModel Get(int id)
        {
            return SolicitarProductoService.GetById(id);
        }

        // POST api/<SolicitarProductoController>
        [HttpPost]
        public string Post([FromBody] SolicitarProductoModel solicitarProducto)
        {
            var result = SolicitarProductoService.AddSolicitarProducto(solicitarProducto);

            if (result)
            {
                return "SolicitarProducto Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }
    }
}