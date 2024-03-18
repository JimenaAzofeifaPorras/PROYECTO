using Entities.Entities;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ClienteHelper : IClienteHelper
    {
        IServiceRepository ServiceRepository;

        public ClienteHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        public ClienteViewModel AddCliente(ClienteViewModel cliente)
        {

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Cliente", Convertir(cliente));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  clienteAPI = JsonConvert.DeserializeObject<Cliente>(content);
            }

            return cliente;
        }


        Cliente Convertir(ClienteViewModel cliente)
        {
            return new Cliente
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                SegundoApellido = cliente.SegundoApellido,
                Correo = cliente.Correo,
                NumeroTelefonico = cliente.NumeroTelefonico,
                Contrasena = cliente.Contrasena,
            };
        }

        ClienteViewModel Convertir(Cliente cliente)
        {
            return new ClienteViewModel
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                SegundoApellido = cliente.SegundoApellido,
                Correo = cliente.Correo,
                NumeroTelefonico = cliente.NumeroTelefonico,
                Contrasena =cliente.Contrasena
            };
        }


        public ClienteViewModel DeleteCliente(int id)
        {

            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Cliente/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return new ClienteViewModel();
        }

        public List<ClienteViewModel> GetClientes()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/cliente");
            List<Cliente> resultado = new List<Cliente>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Cliente>>(content);
            }
            List<ClienteViewModel> lista = new List<ClienteViewModel>();

            if (resultado != null && resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;



        }

        public ClienteViewModel GetCliente(int id)
        {
            ClienteViewModel cliente = new ClienteViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Cliente/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                cliente = Convertir(JsonConvert.DeserializeObject<Cliente>(content));
            }

            return cliente;
        }

        public ClienteViewModel UpdateCliente(ClienteViewModel cliente)
        {
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Cliente", Convertir(cliente));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  clienteAPI = JsonConvert.DeserializeObject<Cliente>(content);
            }

            return cliente;
        }
    }
}