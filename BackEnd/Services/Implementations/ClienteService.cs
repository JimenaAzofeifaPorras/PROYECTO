using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;


namespace BackEnd.Services.Implementations
{
    public class ClienteService : IClienteService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ClienteService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddCliente(ClienteModel cliente)
        {
            Cliente entity = Convertir(cliente);
            _unidadDeTrabajo._clienteDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        ClienteModel Convertir(Cliente cliente)
        {
            return new ClienteModel
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                SegundoApellido = cliente.SegundoApellido,
                Correo = cliente.Correo,
                NumeroTelefonico = cliente.NumeroTelefonico,
                Contrasena = cliente.Contrasena,
                Roles = cliente.Roles
            };
        }

        Cliente Convertir(ClienteModel cliente)
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
                Roles = cliente.Roles
            };
        }
        public bool DeleteCliente(ClienteModel cliente)
        {
            Cliente entity = Convertir(cliente);
            _unidadDeTrabajo._clienteDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public ClienteModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._clienteDAL.Get(id);

            ClienteModel clienteModel = Convertir(entity);
            return clienteModel;
        }

        public IEnumerable<ClienteModel> GetClientes()
        {

            var result = _unidadDeTrabajo._clienteDAL.GetAll();
            List<ClienteModel> lista = new List<ClienteModel>();
            foreach (var cliente in result)
            {
                lista.Add(Convertir(cliente));


            }
            return lista;
        }

        public bool UpdateCliente(ClienteModel cliente)
        {
            Cliente entity = Convertir(cliente);
            _unidadDeTrabajo._clienteDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}