using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ProductoDAL : DALGenerico<Producto>, IProductoDAL
    {
        ProyectoContext _context;

        public ProductoDAL(ProyectoContext context) : base(context)
        {
            _context = context;
        }


    }
}