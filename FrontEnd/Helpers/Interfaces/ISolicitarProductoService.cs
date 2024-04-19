using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ISolicitarProductoHelper
    {
        List<SolicitarProductoViewModel> GetSolicitarProductos();
        SolicitarProductoViewModel GetSolicitarProducto(int id);
        SolicitarProductoViewModel AddSolicitarProducto(SolicitarProductoViewModel solicitarProducto);

    }
}