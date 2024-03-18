using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class EmpleadoDALImpl : DALGenericoImpl<Empleado>, IEmpleadoDAL
    {
        ProyectoContext _context;

        public EmpleadoDALImpl(ProyectoContext context) : base(context)
        {
            _context = context;
        }


    }
}