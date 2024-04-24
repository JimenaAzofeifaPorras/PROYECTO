using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ClienteController : Controller
    {
        IClienteHelper ClienteHelper;

        public ClienteController(IClienteHelper clienteHelper)
        {
            ClienteHelper = clienteHelper;
        }


        // GET: ClienteController
        public ActionResult Index()
        {
            List<ClienteViewModel> lista = ClienteHelper.GetClientes();
            return View(lista);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            ClienteViewModel cliente = ClienteHelper.GetCliente(id);
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            try
            {
                ClienteHelper.AddCliente(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {

            ClienteViewModel cliente = ClienteHelper.GetCliente(id);
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            try
            {
                ClienteHelper.UpdateCliente(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {

            ClienteViewModel cliente = ClienteHelper.GetCliente(id);
            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClienteViewModel cliente)
        {
            try
            {
                ClienteHelper.DeleteCliente(cliente.IdCliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}