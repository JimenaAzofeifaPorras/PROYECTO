using Entities.Entities;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ServicioHelper : IServicioHelper
    {
        IServiceRepository ServiceRepository;

        public ServicioHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        public ServicioViewModel AddServicio(ServicioViewModel servicio)
        {

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Servicio", Convertir(servicio));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  servicioAPI = JsonConvert.DeserializeObject<Servicio>(content);
            }

            return servicio;
        }


        Servicio Convertir(ServicioViewModel servicio)
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

        ServicioViewModel Convertir(Servicio servicio)
        {
            return new ServicioViewModel
            {
                IdServicio = servicio.IdServicio,
                Nombre = servicio.Nombre,
                Precio = servicio.Precio,
                Estado = servicio.Estado,
                Imagen = servicio.Imagen
            };
        }


        public ServicioViewModel DeleteServicio(int id)
        {

            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Servicio/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return new ServicioViewModel();
        }

        public List<ServicioViewModel> GetServicios()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/servicio");
            List<Servicio> resultado = new List<Servicio>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Servicio>>(content);
            }
            List<ServicioViewModel> lista = new List<ServicioViewModel>();

            if (resultado != null && resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;



        }

        public ServicioViewModel GetServicio(int id)
        {
            ServicioViewModel servicio = new ServicioViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Servicio/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                servicio = Convertir(JsonConvert.DeserializeObject<Servicio>(content));
            }

            return servicio;
        }

        public ServicioViewModel UpdateServicio(ServicioViewModel servicio)
        {
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Servicio", Convertir(servicio));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  servicioAPI = JsonConvert.DeserializeObject<Servicio>(content);
            }

            return servicio;
        }
    }
}