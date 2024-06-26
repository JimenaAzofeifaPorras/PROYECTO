﻿using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{

    public class ProductoController : Controller
    {
        IProductoHelper ProductoHelper;

        public ProductoController(IProductoHelper productoHelper)
        {
            ProductoHelper = productoHelper;
        }


        // GET: ProductoController
        public ActionResult Index()
        {
            List<ProductoViewModel> lista = ProductoHelper.GetProductos();
            return View(lista);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            ProductoViewModel producto = ProductoHelper.GetProducto(id);
            return View(producto);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoViewModel producto, List<IFormFile> ListaImagenes)
        {
            try
            {
                if (ListaImagenes.Count > 0)
                {
                    foreach (var item in ListaImagenes)
                    {
                        using (var ms = new MemoryStream())
                        {
                            item.CopyTo(ms);
                            producto.Imagen = ms.ToArray();
                        }
                    }
                }


                ProductoHelper.AddProducto(producto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {

            ProductoViewModel producto = ProductoHelper.GetProducto(id);
            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoViewModel producto, List<IFormFile> ListaImagenes)
        {
            try
            {
                if (ListaImagenes.Count > 0)
                {
                    foreach (var item in ListaImagenes)
                    {
                        using (var ms = new MemoryStream())
                        {
                            item.CopyTo(ms);
                            producto.Imagen = ms.ToArray();
                        }
                    }
                }
                ProductoHelper.UpdateProducto(producto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {

            ProductoViewModel producto = ProductoHelper.GetProducto(id);
            return View(producto);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductoViewModel producto)
        {
            try
            {
                ProductoHelper.DeleteProducto(producto.IdProducto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}