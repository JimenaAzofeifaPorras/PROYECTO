using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        IProductoService ProductoService;

        public ProductoController(IProductoService productoService)
        {
            ProductoService = productoService;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<ProductoModel> Get()
        {
            return ProductoService.GetProductos();
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ProductoModel Get(int id)
        {
            return ProductoService.GetById(id);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public string Post([FromBody] ProductoModel producto)
        {
            var result = ProductoService.AddProducto(producto);

            if (result)
            {
                return "Producto Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<ProductoController>/5
        [HttpPut]
        public string Put([FromBody] ProductoModel producto)
        {
            var result = ProductoService.UpdateProducto(producto);

            if (result)
            {
                return "Producto Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            ProductoModel producto = new ProductoModel { IdProducto = id };
            var result = ProductoService.DeleteProducto(producto);

            if (result)
            {
                return "Producto Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}