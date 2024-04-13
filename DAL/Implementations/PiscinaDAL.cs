using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class PiscinaDAL : DALGenerico<Piscina>, IPiscinaDAL
    {
        ProyectoContext _context;

        public PiscinaDAL(ProyectoContext context) : base(context)
        {
            _context = context;
        }
    }
}
