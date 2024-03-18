using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;


namespace BackEnd.Services.Implementations
{
    public class ServicioService : IServicioService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ServicioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddServicio(ServicioModel servicio)
        {
            Servicio entity = Convertir(servicio);
            _unidadDeTrabajo._servicioDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        ServicioModel Convertir(Servicio servicio)
        {
            return new ServicioModel
            {
                IdServicio = servicio.IdServicio,
                Nombre = servicio.Nombre,
                Precio = servicio.Precio,
                Estado = servicio.Estado,
                Imagen = servicio.Imagen
            };
        }

        Servicio Convertir(ServicioModel servicio)
        {
            return new Servicio
            {
                IdServicio = servicio.IdServicio,
                Nombre = servicio.Nombre,
                Precio = servicio.Precio,
                Estado = servicio.Estado,
                Imagen = servicio.Imagen
            };
        }
        public bool DeleteServicio(ServicioModel servicio)
        {
            Servicio entity = Convertir(servicio);
            _unidadDeTrabajo._servicioDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public ServicioModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._servicioDAL.Get(id);

            ServicioModel servicioModel = Convertir(entity);
            return servicioModel;
        }

        public IEnumerable<ServicioModel> GetServicios()
        {

            var result = _unidadDeTrabajo._servicioDAL.GetAll();
            List<ServicioModel> lista = new List<ServicioModel>();
            foreach (var servicio in result)
            {
                lista.Add(Convertir(servicio));


            }
            return lista;
        }

        public bool UpdateServicio(ServicioModel servicio)
        {
            Servicio entity = Convertir(servicio);
            _unidadDeTrabajo._servicioDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}