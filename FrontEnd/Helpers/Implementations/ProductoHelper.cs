using Entities.Entities;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ProductoHelper : IProductoHelper
    {
        IServiceRepository ServiceRepository;

        public ProductoHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        public ProductoViewModel AddProducto(ProductoViewModel producto)
        {

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Producto", Convertir(producto));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  productoAPI = JsonConvert.DeserializeObject<Producto>(content);
            }

            return producto;
        }


        Producto Convertir(ProductoViewModel producto)
        {
            return new Producto
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Estado = producto.Estado,
                Imagen = producto.Imagen ?? null,
                Precio = producto.Precio
            };
        }

        ProductoViewModel Convertir(Producto producto)
        {
            return new ProductoViewModel
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Estado = producto.Estado,
                Imagen = producto.Imagen ?? null,
                Precio = producto.Precio
            };
        }


        public ProductoViewModel DeleteProducto(int id)
        {

            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Producto/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return new ProductoViewModel();
        }

        public List<ProductoViewModel> GetProductos()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/producto");
            List<Producto> resultado = new List<Producto>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Producto>>(content);
            }
            List<ProductoViewModel> lista = new List<ProductoViewModel>();

            if (resultado != null && resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;



        }

        public ProductoViewModel GetProducto(int id)
        {
            ProductoViewModel producto = new ProductoViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Producto/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                producto = Convertir(JsonConvert.DeserializeObject<Producto>(content));
            }

            return producto;
        }

        public ProductoViewModel UpdateProducto(ProductoViewModel producto)
        {
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Producto", Convertir(producto));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  productoAPI = JsonConvert.DeserializeObject<Producto>(content);
            }

            return producto;
        }
    }
}