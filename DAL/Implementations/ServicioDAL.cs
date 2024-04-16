using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ServicioDALImpl : DALGenerico<Servicio>, IServicioDAL
    {
        ProyectoContext _context;

        public ServicioDALImpl(ProyectoContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Servicio> GetAll()
        {
            List<sp_GetAllServicios_Result> results;

            string sql = "[dbo].[sp_GetAllServicios]";

            results = _context.Sp_GetAllServicios_Results
                        .FromSqlRaw(sql)
                        .ToList();

            List<Servicio> servicios = new List<Servicio>();

            foreach (var item in results)
            {
                servicios.Add(
                    new Servicio
                    {
                        IdServicio = item.IdServicio,
                        Nombre = item.Nombre,
                        Precio = item.Precio,
                        Estado = item.Estado,
                        Imagen = item.Imagen
                    }
                    );
            }



            return servicios;
        }


        public bool Add(Servicio entity)
        {
            try
            {

                string sql = "exec [dbo].[sp_AddServicio] @Nombre, @Precio, @Estado, @Imagen";

                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName= "@Nombre",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.Nombre
                    },
                    new SqlParameter()
                    {
                        ParameterName= "@Precio",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.Precio
                    },
                    new SqlParameter()
                    {
                        ParameterName= "@Estado",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.Estado
                    },
                    new SqlParameter()
                    {
                        ParameterName= "@Imagen",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.Imagen
                    }

                };


                _Context.Database.ExecuteSqlRaw(sql, param);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
