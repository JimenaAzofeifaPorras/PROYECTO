﻿using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;


namespace BackEnd.Services.Implementations
{
    public class PiscinaService : IPiscinaService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public PiscinaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddPiscina(PiscinaModel piscina)
        {
            Piscina entity = Convertir(piscina);
            _unidadDeTrabajo._piscinaDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        PiscinaModel Convertir(Piscina piscina)
        {
            return new PiscinaModel
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

        Piscina Convertir(PiscinaModel piscina)
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
        public bool DeletePiscina(PiscinaModel piscina)
        {
            Piscina entity = Convertir(piscina);
            _unidadDeTrabajo._piscinaDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public PiscinaModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._piscinaDAL.Get(id);

            PiscinaModel piscinaModel = Convertir(entity);
            return piscinaModel;
        }

        public IEnumerable<PiscinaModel> GetPiscinas()
        {

            var result = _unidadDeTrabajo._piscinaDAL.GetAll();
            List<PiscinaModel> lista = new List<PiscinaModel>();
            foreach (var piscina in result)
            {
                lista.Add(Convertir(piscina));


            }
            return lista;
        }

        public bool UpdatePiscina(PiscinaModel piscina)
        {
            Piscina entity = Convertir(piscina);
            _unidadDeTrabajo._piscinaDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}