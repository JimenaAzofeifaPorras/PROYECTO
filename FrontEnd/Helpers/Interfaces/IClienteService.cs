using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IClienteHelper
    {
        List<ClienteViewModel> GetClientes();
        ClienteViewModel GetCliente(int id);
        ClienteViewModel AddCliente(ClienteViewModel cliente);
        ClienteViewModel DeleteCliente(int id);
        ClienteViewModel UpdateCliente(ClienteViewModel cliente);

    }
}