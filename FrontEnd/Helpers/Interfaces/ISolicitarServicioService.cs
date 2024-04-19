using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ISolicitarServicioHelper
    {
        List<SolicitarServicioViewModel> GetSolicitarServicios();
        SolicitarServicioViewModel GetSolicitarServicio(int id);
        SolicitarServicioViewModel AddSolicitarServicio(SolicitarServicioViewModel solicitarServicio);

    }
}