using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ServicioController : Controller
    {
        IServicioHelper ServicioHelper;

        public ServicioController(IServicioHelper servicioHelper)
        {
            ServicioHelper = servicioHelper;
        }


        // GET: ServicioController
        public ActionResult Index()
        {
            List<ServicioViewModel> lista = ServicioHelper.GetServicios();
            return View(lista);
        }

        // GET: ServicioController/Details/5
        public ActionResult Details(int id)
        {
            ServicioViewModel servicio = ServicioHelper.GetServicio(id);
            return View(servicio);
        }

        // GET: ServicioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicioViewModel servicio)
        {
            try
            {
                ServicioHelper.AddServicio(servicio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicioController/Edit/5
        public ActionResult Edit(int id)
        {

            ServicioViewModel servicio = ServicioHelper.GetServicio(id);
            return View(servicio);
        }

        // POST: ServicioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServicioViewModel servicio)
        {
            try
            {
                ServicioHelper.UpdateServicio(servicio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicioController/Delete/5
        public ActionResult Delete(int id)
        {

            ServicioViewModel servicio = ServicioHelper.GetServicio(id);
            return View(servicio);
        }

        // POST: ServicioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ServicioViewModel servicio)
        {
            try
            {
                ServicioHelper.DeleteServicio(servicio.IdServicio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}