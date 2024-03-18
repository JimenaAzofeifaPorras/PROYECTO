using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IProductoService
    {
        IEnumerable<ProductoModel> GetProductos();
        ProductoModel GetById(int id);
        bool AddProducto(ProductoModel producto);
        bool UpdateProducto(ProductoModel producto);
        bool DeleteProducto(ProductoModel producto);


    }
}