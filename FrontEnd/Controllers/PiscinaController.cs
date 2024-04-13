using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class PiscinaController : Controller
    {
        IPiscinaHelper PiscinaHelper;

        public PiscinaController(IPiscinaHelper piscinaHelper) 
        {
           PiscinaHelper = piscinaHelper;
        }

        // GET: PiscinaController
        public ActionResult Index()
        {
            List<PiscinaViewModel> lista = PiscinaHelper.GetPiscinas();
            return View(lista);
        }

        // GET: PiscinaController/Details/5
        public ActionResult Details(int id)
        {
            PiscinaViewModel piscina = PiscinaHelper.GetPiscina(id);
            return View(piscina);
        }

        // GET: PiscinaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PiscinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PiscinaViewModel piscina)
        {
            try
            {
                PiscinaHelper.AddPiscina(piscina);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PiscinaController/Edit/5
        public ActionResult Edit(int id)
        {
            PiscinaViewModel piscina = PiscinaHelper.GetPiscina(id);
            return View(piscina);
        }

        // POST: PiscinaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PiscinaViewModel piscina)
        {
            try
            {
                PiscinaHelper.UpdatePiscina(piscina);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PiscinaController/Delete/5
        public ActionResult Delete(int id)
        {
            PiscinaViewModel piscina = PiscinaHelper.GetPiscina(id);
            return View(piscina);
        }

        // POST: PiscinaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PiscinaViewModel piscina)
        {
            try
            {
                PiscinaHelper.DeletePiscina(piscina.PiscinaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
