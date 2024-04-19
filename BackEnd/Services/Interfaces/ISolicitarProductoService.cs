using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ISolicitarProductoService
    {
        IEnumerable<SolicitarProductoModel> GetSolicitarProductos();
        SolicitarProductoModel GetById(int id);
        bool AddSolicitarProducto(SolicitarProductoModel solicitarProducto);


    }
}