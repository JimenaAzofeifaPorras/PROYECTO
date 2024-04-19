using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ISolicitarServicioService
    {
        IEnumerable<SolicitarServicioModel> GetSolicitarServicios();
        SolicitarServicioModel GetById(int id);
        bool AddSolicitarServicio(SolicitarServicioModel solicitarServicio);


    }
}