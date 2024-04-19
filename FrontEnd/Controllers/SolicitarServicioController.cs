using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class SolicitarServicioController : Controller
    {
        ISolicitarServicioHelper SolicitarServicioHelper;

        public SolicitarServicioController(ISolicitarServicioHelper solicitarServicioHelper)
        {
            SolicitarServicioHelper = solicitarServicioHelper;
        }


        // GET: SolicitarServicioController
        public ActionResult Index()
        {
            List<SolicitarServicioViewModel> lista = SolicitarServicioHelper.GetSolicitarServicios();
            return View(lista);
        }

        // GET: SolicitarServicioController/Details/5
        public ActionResult Details(int id)
        {
            SolicitarServicioViewModel solicitarServicio = SolicitarServicioHelper.GetSolicitarServicio(id);
            return View(solicitarServicio);
        }

        // GET: SolicitarServicioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitarServicioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SolicitarServicioViewModel solicitarServicio)
        {
            try
            {
                SolicitarServicioHelper.AddSolicitarServicio(solicitarServicio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SolicitarServicioController/Edit/5
        public ActionResult Edit(int id)
        {

            SolicitarServicioViewModel solicitarServicio = SolicitarServicioHelper.GetSolicitarServicio(id);
            return View(solicitarServicio);
        }

        // GET: SolicitarServicioController/Delete/5
        public ActionResult Delete(int id)
        {

            SolicitarServicioViewModel solicitarServicio = SolicitarServicioHelper.GetSolicitarServicio(id);
            return View(solicitarServicio);
        }
    }
}