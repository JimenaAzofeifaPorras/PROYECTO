using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ClienteDALImpl : DALGenerico<Cliente>, IClienteDAL
    {
        ProyectoContext _context;

        public ClienteDALImpl(ProyectoContext context) : base(context)
        {
            _context = context;
        }


    }
}