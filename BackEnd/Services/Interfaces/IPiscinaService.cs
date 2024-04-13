using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IPiscinaService
    {
        IEnumerable<PiscinaModel> GetPiscinas();
        PiscinaModel GetById(int id);
        bool AddPiscina(PiscinaModel piscina);
        bool UpdatePiscina(PiscinaModel piscina);
        bool DeletePiscina(PiscinaModel piscina);


    }
}