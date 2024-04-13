using Entities.Entities;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class PiscinaHelper : IPiscinaHelper
    {
        IServiceRepository ServiceRepository;

        public PiscinaHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        public PiscinaViewModel AddPiscina(PiscinaViewModel piscina)
        {

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Piscina", Convertir(piscina));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  clienteAPI = JsonConvert.DeserializeObject<Cliente>(content);
            }

            return piscina;
        }


        Piscina Convertir(PiscinaViewModel piscina)
        {
            return new Piscina
            {
                PiscinaId = piscina.PiscinaId,
                ClienteId = piscina.ClienteId,
                ServicioId = piscina.ServicioId,
                Nombre = piscina.Nombre,
                Imagen = piscina.Imagen,
                EmpleadoId = piscina.EmpleadoId,
                Comentario = piscina.Comentario,
                FechaHoraComentario = piscina.FechaHoraComentario
            };
        }

        PiscinaViewModel Convertir(Piscina piscina)
        {
            return new PiscinaViewModel
            {
                PiscinaId = piscina.PiscinaId,
                ClienteId = piscina.ClienteId,
                ServicioId = piscina.ServicioId,
                Nombre = piscina.Nombre,
                Imagen = piscina.Imagen,
                EmpleadoId = piscina.EmpleadoId,
                Comentario = piscina.Comentario,
                FechaHoraComentario = piscina.FechaHoraComentario
            };
        }


        public PiscinaViewModel DeletePiscina(int id)
        {

            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Piscina/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return new PiscinaViewModel();
        }

        public List<PiscinaViewModel> GetPiscinas()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/piscina");
            List<Piscina> resultado = new List<Piscina>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Piscina>>(content);
            }
            List<PiscinaViewModel> lista = new List<PiscinaViewModel>();

            if (resultado != null && resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;



        }

        public PiscinaViewModel GetPiscina(int id)
        {
            PiscinaViewModel piscina = new PiscinaViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Piscina/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                piscina = Convertir(JsonConvert.DeserializeObject<Piscina>(content));
            }

            return piscina;
        }

        public PiscinaViewModel UpdatePiscina(PiscinaViewModel piscina)
        {
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Piscina", Convertir(piscina));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  clienteAPI = JsonConvert.DeserializeObject<Cliente>(content);
            }

            return piscina;
        }
    }
}