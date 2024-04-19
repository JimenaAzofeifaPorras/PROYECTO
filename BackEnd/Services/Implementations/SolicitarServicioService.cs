using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;


namespace BackEnd.Services.Implementations
{
    public class SolicitarServicioService : ISolicitarServicioService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public SolicitarServicioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddSolicitarServicio(SolicitarServicioModel solicitarServicio)
        {
            SolicitarServicio entity = Convertir(solicitarServicio);
            _unidadDeTrabajo._solicitarServicioDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        SolicitarServicioModel Convertir(SolicitarServicio solicitarServicio)
        {
            return new SolicitarServicioModel
            {
                IdServicio = solicitarServicio.IdServicio,
                Nombre = solicitarServicio.Nombre,
                Fecha = solicitarServicio.Fecha,
                NumeroTelefono = solicitarServicio.NumeroTelefono,
                Correo = solicitarServicio.Correo,
                TamanoPiscina = solicitarServicio.TamanoPiscina,
                Direccion = solicitarServicio.Direccion,
                TipoServicio = solicitarServicio.TipoServicio,
                DescripcionProblema = solicitarServicio.DescripcionProblema
            };
        }

        SolicitarServicio Convertir(SolicitarServicioModel solicitarServicio)
        {
            return new SolicitarServicio
            {
                IdServicio = solicitarServicio.IdServicio,
                Nombre = solicitarServicio.Nombre,
                Fecha = solicitarServicio.Fecha,
                NumeroTelefono = solicitarServicio.NumeroTelefono,
                Correo = solicitarServicio.Correo,
                TamanoPiscina = solicitarServicio.TamanoPiscina,
                Direccion = solicitarServicio.Direccion,
                TipoServicio = solicitarServicio.TipoServicio,
                DescripcionProblema = solicitarServicio.DescripcionProblema
            };
        }

        public SolicitarServicioModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._solicitarServicioDAL.Get(id);

            SolicitarServicioModel solicitarServicioModel = Convertir(entity);
            return solicitarServicioModel;
        }

        public IEnumerable<SolicitarServicioModel> GetSolicitarServicios()
        {

            var result = _unidadDeTrabajo._solicitarServicioDAL.GetAll();
            List<SolicitarServicioModel> lista = new List<SolicitarServicioModel>();
            foreach (var solicitarServicio in result)
            {
                lista.Add(Convertir(solicitarServicio));


            }
            return lista;
        }

    }
}