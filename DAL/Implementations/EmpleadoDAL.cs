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
    public class EmpleadoDAL : DALGenerico<Empleado>, IEmpleadoDAL
    {
        ProyectoContext _context;

        public EmpleadoDAL(ProyectoContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Empleado> GetAll()
        {
            List<sp_GetAllEmpleados_Result> results;

            string sql = "[dbo].[sp_GetAllEmpleados]";

            results = _context.Sp_GetAllEmpleados_Results
                        .FromSqlRaw(sql)
                        .ToList();

            List<Empleado> empleados = new List<Empleado>();

            foreach (var item in results)
            {
                empleados.Add(
                    new Empleado
                    {
                        IdEmpleado = item.IdEmpleado,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        SegundoApellido = item.SegundoApellido,
                        Correo = item.Correo,
                        NumeroTelefonico = item.NumeroTelefonico,
                        Contrasena = item.Contrasena
                    }
                    );
            }



            return empleados;
        }
        public bool Add(Empleado entity)
        {
            try
            {

                string sql = "exec [dbo].[sp_AddEmpleado] @Nombre, @Apellido, @SegundoApellido, @Correo, @NumeroTelefonico, @Contrasena";

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
                        ParameterName= "@Apellido",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.Apellido
                    },

                    new SqlParameter()
                    {
                        ParameterName= "@SegundoApellido",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.SegundoApellido
                    },

                    new SqlParameter()
                    {
                        ParameterName= "@Correo",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.Correo
                    },

                    new SqlParameter()
                    {
                        ParameterName= "@NumeroTelefonico",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.NumeroTelefonico
                    },

                    new SqlParameter()
                    {
                        ParameterName= "@Contrasena",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.Contrasena
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