using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;


namespace BackEnd.Services.Implementations
{
    public class ProductoService : IProductoService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ProductoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddProducto(ProductoModel producto)
        {
            Producto entity = Convertir(producto);
            _unidadDeTrabajo._productoDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        ProductoModel Convertir(Producto producto)
        {
            return new ProductoModel
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Estado = producto.Estado,
                Imagen = producto.Imagen,
                Precio = producto.Precio
            };
        }

        Producto Convertir(ProductoModel producto)
        {
            return new Producto
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Estado = producto.Estado,
                Imagen = producto.Imagen,
                Precio = producto.Precio
            };
        }
        public bool DeleteProducto(ProductoModel producto)
        {
            Producto entity = Convertir(producto);
            _unidadDeTrabajo._productoDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public ProductoModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._productoDAL.Get(id);

            ProductoModel productoModel = Convertir(entity);
            return productoModel;
        }

        public IEnumerable<ProductoModel> GetProductos()
        {

            var result = _unidadDeTrabajo._productoDAL.GetAll();
            List<ProductoModel> lista = new List<ProductoModel>();
            foreach (var producto in result)
            {
                lista.Add(Convertir(producto));


            }
            return lista;
        }

        public bool UpdateProducto(ProductoModel producto)
        {
            Producto entity = Convertir(producto);
            _unidadDeTrabajo._productoDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}