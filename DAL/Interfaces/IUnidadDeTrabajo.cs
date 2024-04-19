using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IClienteDAL _clienteDAL { get; }

        IEmpleadoDAL _empleadoDAL { get; }

        IProductoDAL _productoDAL { get; }

        IServicioDAL _servicioDAL { get; }
        IPiscinaDAL _piscinaDAL { get; }
        ISolicitarProductoDAL _solicitarProductoDAL { get; }
        ISolicitarServicioDAL _solicitarServicioDAL { get;  }
        bool Complete();
    }
}