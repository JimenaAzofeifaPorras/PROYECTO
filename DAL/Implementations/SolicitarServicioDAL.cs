using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class SolicitarServicioDALImpl : DALGenerico<SolicitarServicio>, ISolicitarServicioDAL
    {
        ProyectoContext _context;

        public SolicitarServicioDALImpl(ProyectoContext context) : base(context)
        {
            _context = context;
        }


    }
}