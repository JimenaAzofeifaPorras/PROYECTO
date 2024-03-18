using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        IServicioService ServicioService;

        public ServicioController(IServicioService servicioService)
        {
            ServicioService = servicioService;
        }

        // GET: api/<ServicioController>
        [HttpGet]
        public IEnumerable<ServicioModel> Get()
        {
            return ServicioService.GetServicios();
        }

        // GET api/<ServicioController>/5
        [HttpGet("{id}")]
        public ServicioModel Get(int id)
        {
            return ServicioService.GetById(id);
        }

        // POST api/<ServicioController>
        [HttpPost]
        public string Post([FromBody] ServicioModel servicio)
        {
            var result = ServicioService.AddServicio(servicio);

            if (result)
            {
                return "Servicio Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<ServicioController>/5
        [HttpPut]
        public string Put([FromBody] ServicioModel servicio)
        {
            var result = ServicioService.UpdateServicio(servicio);

            if (result)
            {
                return "Servicio Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<ServicioController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            ServicioModel servicio = new ServicioModel { IdServicio = id };
            var result = ServicioService.DeleteServicio(servicio);

            if (result)
            {
                return "Servicio Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}