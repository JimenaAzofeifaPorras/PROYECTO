using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IPiscinaHelper
    {
        List<PiscinaViewModel> GetPiscinas();
        PiscinaViewModel GetPiscina(int id);
        PiscinaViewModel AddPiscina(PiscinaViewModel piscina);
        PiscinaViewModel DeletePiscina(int id);
        PiscinaViewModel UpdatePiscina(PiscinaViewModel piscina);

    }
}