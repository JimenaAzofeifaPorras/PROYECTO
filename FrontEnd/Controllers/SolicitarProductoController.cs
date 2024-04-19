using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class SolicitarProductoController : Controller
    {
        ISolicitarProductoHelper SolicitarProductoHelper;

        public SolicitarProductoController(ISolicitarProductoHelper solicitarProductoHelper)
        {
            SolicitarProductoHelper = solicitarProductoHelper;
        }


        // GET: SolicitarProductoController
        public ActionResult Index()
        {
            List<SolicitarProductoViewModel> lista = SolicitarProductoHelper.GetSolicitarProductos();
            return View(lista);
        }

        // GET: SolicitarProductoController/Details/5
        public ActionResult Details(int id)
        {
            SolicitarProductoViewModel solicitarProducto = SolicitarProductoHelper.GetSolicitarProducto(id);
            return View(solicitarProducto);
        }

        // GET: SolicitarProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitarProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SolicitarProductoViewModel solicitarProducto)
        {
            try
            {
                SolicitarProductoHelper.AddSolicitarProducto(solicitarProducto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SolicitarProductoController/Edit/5
        public ActionResult Edit(int id)
        {

            SolicitarProductoViewModel solicitarProducto = SolicitarProductoHelper.GetSolicitarProducto(id);
            return View(solicitarProducto);
        }

        // GET: SolicitarProductoController/Delete/5
        public ActionResult Delete(int id)
        {

            SolicitarProductoViewModel solicitarProducto = SolicitarProductoHelper.GetSolicitarProducto(id);
            return View(solicitarProducto);
        }
    }
}