using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFenipo.Controllers
{
    [Authorize]
    public class RecordsController : Controller
    {
        [AllowAnonymous]
        // GET: Records
        public ActionResult RecordsSentadilla()
        {

            return View();
        }
        [AllowAnonymous]
        public ActionResult RecordsPressBanca()
        {

            return View();
        }
        [AllowAnonymous]
        public ActionResult RecordsPesoMuerto()
        {

            return View();
        }
        [AllowAnonymous]
        // GET: Records/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Records/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Records/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Records/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Records/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: Records/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
