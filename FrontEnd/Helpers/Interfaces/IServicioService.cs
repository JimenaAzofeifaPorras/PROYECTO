using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IServicioHelper
    {
        List<ServicioViewModel> GetServicios();
        ServicioViewModel GetServicio(int id);
        ServicioViewModel AddServicio(ServicioViewModel servicio);
        ServicioViewModel DeleteServicio(int id);
        ServicioViewModel UpdateServicio(ServicioViewModel servicio);

    }
}