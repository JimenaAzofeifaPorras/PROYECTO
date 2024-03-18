using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IProductoHelper
    {
        List<ProductoViewModel> GetProductos();
        ProductoViewModel GetProducto(int id);
        ProductoViewModel AddProducto(ProductoViewModel producto);
        ProductoViewModel DeleteProducto(int id);
        ProductoViewModel UpdateProducto(ProductoViewModel producto);

    }
}