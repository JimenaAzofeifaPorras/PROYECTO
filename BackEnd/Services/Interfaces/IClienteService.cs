using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IClienteService
    {
        IEnumerable<ClienteModel> GetClientes();
        ClienteModel GetById(int id);
        bool AddCliente(ClienteModel cliente);
        bool UpdateCliente(ClienteModel cliente);
        bool DeleteCliente(ClienteModel cliente);


    }
}