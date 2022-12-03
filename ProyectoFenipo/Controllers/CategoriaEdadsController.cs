using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFenipo.Models;

namespace ProyectoFenipo.Controllers
{
    [Authorize]
    public class CategoriaEdadsController : Controller
    {
        private ProyectoFenipoContainer db = new ProyectoFenipoContainer();

        // GET: CategoriaEdads
        public ActionResult Index()
        {
            return View(db.CategoriaEdades.ToList());
        }

        // GET: CategoriaEdads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaEdad categoriaEdad = db.CategoriaEdades.Find(id);
            if (categoriaEdad == null)
            {
                return HttpNotFound();
            }
            return View(categoriaEdad);
        }

        // GET: CategoriaEdads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaEdads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreCategoriaEdad")] CategoriaEdad categoriaEdad)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaEdades.Add(categoriaEdad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaEdad);
        }

        // GET: CategoriaEdads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaEdad categoriaEdad = db.CategoriaEdades.Find(id);
            if (categoriaEdad == null)
            {
                return HttpNotFound();
            }
            return View(categoriaEdad);
        }

        // POST: CategoriaEdads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreCategoriaEdad")] CategoriaEdad categoriaEdad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaEdad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaEdad);
        }
        // GET: CategoriaEdads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaEdad categoriaEdad = db.CategoriaEdades.Find(id);
            if (categoriaEdad == null)
            {
                return HttpNotFound();
            }
            return View(categoriaEdad);
        }
        // POST: CategoriaEdads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaEdad categoriaEdad = db.CategoriaEdades.Find(id);
            db.CategoriaEdades.Remove(categoriaEdad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
