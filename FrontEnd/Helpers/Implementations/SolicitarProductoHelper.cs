using Entities.Entities;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class SolicitarProductoHelper : ISolicitarProductoHelper
    {
        IServiceRepository ServiceRepository;

        public SolicitarProductoHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        public SolicitarProductoViewModel AddSolicitarProducto(SolicitarProductoViewModel solicitarProducto)
        {

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/SolicitarProducto", Convertir(solicitarProducto));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  solicitarProductoAPI = JsonConvert.DeserializeObject<SolicitarProducto>(content);
            }

            return solicitarProducto;
        }


        SolicitarProducto Convertir(SolicitarProductoViewModel solicitarProducto)
        {
            return new SolicitarProducto
            {
                IdProducto = solicitarProducto.IdProducto,
                Nombre = solicitarProducto.Nombre,
                Fecha = solicitarProducto.Fecha,
                NumeroTelefono = solicitarProducto.NumeroTelefono,
                Correo = solicitarProducto.Correo,
                TamanoPiscina = solicitarProducto.TamanoPiscina,
                Direccion = solicitarProducto.Direccion,
                TipoProducto = solicitarProducto.TipoProducto,
                DescripcionProblema = solicitarProducto.DescripcionProblema
            };
        }

        SolicitarProductoViewModel Convertir(SolicitarProducto solicitarProducto)
        {
            return new SolicitarProductoViewModel
            {
                IdProducto = solicitarProducto.IdProducto,
                Nombre = solicitarProducto.Nombre,
                Fecha = solicitarProducto.Fecha,
                NumeroTelefono = solicitarProducto.NumeroTelefono,
                Correo = solicitarProducto.Correo,
                TamanoPiscina = solicitarProducto.TamanoPiscina,
                Direccion = solicitarProducto.Direccion,
                TipoProducto = solicitarProducto.TipoProducto,
                DescripcionProblema = solicitarProducto.DescripcionProblema
            };
        }

        public List<SolicitarProductoViewModel> GetSolicitarProductos()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/solicitarProducto");
            List<SolicitarProducto> resultado = new List<SolicitarProducto>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<SolicitarProducto>>(content);
            }
            List<SolicitarProductoViewModel> lista = new List<SolicitarProductoViewModel>();

            if (resultado != null && resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;



        }

        public SolicitarProductoViewModel GetSolicitarProducto(int id)
        {
            SolicitarProductoViewModel solicitarProducto = new SolicitarProductoViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/SolicitarProducto/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                solicitarProducto = Convertir(JsonConvert.DeserializeObject<SolicitarProducto>(content));
            }

            return solicitarProducto;
        }
    }
}