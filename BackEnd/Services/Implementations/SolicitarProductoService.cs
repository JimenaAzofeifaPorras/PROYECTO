using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;


namespace BackEnd.Services.Implementations
{
    public class SolicitarProductoService : ISolicitarProductoService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public SolicitarProductoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddSolicitarProducto(SolicitarProductoModel solicitarProducto)
        {
            SolicitarProducto entity = Convertir(solicitarProducto);
            _unidadDeTrabajo._solicitarProductoDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        SolicitarProductoModel Convertir(SolicitarProducto solicitarProducto)
        {
            return new SolicitarProductoModel
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

        SolicitarProducto Convertir(SolicitarProductoModel solicitarProducto)
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

        public SolicitarProductoModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._solicitarProductoDAL.Get(id);

            SolicitarProductoModel solicitarProductoModel = Convertir(entity);
            return solicitarProductoModel;
        }

        public IEnumerable<SolicitarProductoModel> GetSolicitarProductos()
        {

            var result = _unidadDeTrabajo._solicitarProductoDAL.GetAll();
            List<SolicitarProductoModel> lista = new List<SolicitarProductoModel>();
            foreach (var solicitarProducto in result)
            {
                lista.Add(Convertir(solicitarProducto));


            }
            return lista;
        }

    }
}