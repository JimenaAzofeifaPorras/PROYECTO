using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IServicioService
    {
        IEnumerable<ServicioModel> GetServicios();
        ServicioModel GetById(int id);
        bool AddServicio(ServicioModel servicio);
        bool UpdateServicio(ServicioModel servicio);
        bool DeleteServicio(ServicioModel servicio);
    }
}
