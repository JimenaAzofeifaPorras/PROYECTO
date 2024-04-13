using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ServicioDAL : DALGenerico<Servicio>, IServicioDAL
    {
        ProyectoContext _context;

        public ServicioDAL(ProyectoContext context) : base(context)
        {
            _context = context;
        }


    }
}