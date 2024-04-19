using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {

        public IClienteDAL _clienteDAL { get; }
        public IEmpleadoDAL _empleadoDAL { get; }
        public IProductoDAL _productoDAL { get; }
        public IServicioDAL _servicioDAL { get; }
        public IPiscinaDAL _piscinaDAL { get; }
        public ISolicitarProductoDAL _solicitarProductoDAL { get; }

        private readonly ProyectoContext _context;

        public UnidadDeTrabajo(ProyectoContext proyectoContext,
                                IClienteDAL clienteDAL,
                                IEmpleadoDAL empleadoDAL,
                                IProductoDAL productoDAL,
                                IServicioDAL servicioDAL,
                                IPiscinaDAL piscinaDAL,
                                ISolicitarProductoDAL solicitarProductoDAL

                                )
        {
            _context = proyectoContext;
            _clienteDAL = clienteDAL;
            _empleadoDAL = empleadoDAL;
            _productoDAL = productoDAL;
            _servicioDAL = servicioDAL;
            _piscinaDAL = piscinaDAL;
        }

        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}