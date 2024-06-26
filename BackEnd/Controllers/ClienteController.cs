﻿using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        IClienteService ClienteService;

        public ClienteController(IClienteService clienteService)
        {
            ClienteService = clienteService;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<ClienteModel> Get()
        {
            return ClienteService.GetClientes();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ClienteModel Get(int id)
        {
            return ClienteService.GetById(id);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public string Post([FromBody] ClienteModel cliente)
        {
            var result = ClienteService.AddCliente(cliente);

            if (result)
            {
                return "Cliente Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<ClienteController>/5
        [HttpPut]
        public string Put([FromBody] ClienteModel cliente)
        {
            var result = ClienteService.UpdateCliente(cliente);

            if (result)
            {
                return "Cliente Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            ClienteModel cliente = new ClienteModel { IdCliente = id };
            var result = ClienteService.DeleteCliente(cliente);

            if (result)
            {
                return "Cliente Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}