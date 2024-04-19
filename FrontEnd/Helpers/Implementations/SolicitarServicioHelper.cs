using Entities.Entities;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class SolicitarServicioHelper : ISolicitarServicioHelper
    {
        IServiceRepository ServiceRepository;

        public SolicitarServicioHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        public SolicitarServicioViewModel AddSolicitarServicio(SolicitarServicioViewModel solicitarServicio)
        {

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/SolicitarServicio", Convertir(solicitarServicio));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  solicitarServicioAPI = JsonConvert.DeserializeObject<SolicitarServicio>(content);
            }

            return solicitarServicio;
        }


        SolicitarServicio Convertir(SolicitarServicioViewModel solicitarServicio)
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

        SolicitarServicioViewModel Convertir(SolicitarServicio solicitarServicio)
        {
            return new SolicitarServicioViewModel
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

        public List<SolicitarServicioViewModel> GetSolicitarServicios()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/solicitarServicio");
            List<SolicitarServicio> resultado = new List<SolicitarServicio>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<SolicitarServicio>>(content);
            }
            List<SolicitarServicioViewModel> lista = new List<SolicitarServicioViewModel>();

            if (resultado != null && resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;



        }

        public SolicitarServicioViewModel GetSolicitarServicio(int id)
        {
            SolicitarServicioViewModel solicitarServicio = new SolicitarServicioViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/SolicitarServicio/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                solicitarServicio = Convertir(JsonConvert.DeserializeObject<SolicitarServicio>(content));
            }

            return solicitarServicio;
        }
    }
}