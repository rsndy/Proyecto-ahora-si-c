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
    public class CategoriaPesoesController : Controller
    {
        private ProyectoFenipoContainer db = new ProyectoFenipoContainer();

        // GET: CategoriaPesoes
        public ActionResult Index()
        {
            return View(db.CategoriaPesos.ToList());
        }

        // GET: CategoriaPesoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaPeso categoriaPeso = db.CategoriaPesos.Find(id);
            if (categoriaPeso == null)
            {
                return HttpNotFound();
            }
            return View(categoriaPeso);
        }

        // GET: CategoriaPesoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaPesoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreCategoriaPeso,Genero")] CategoriaPeso categoriaPeso)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaPesos.Add(categoriaPeso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaPeso);
        }

        // GET: CategoriaPesoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaPeso categoriaPeso = db.CategoriaPesos.Find(id);
            if (categoriaPeso == null)
            {
                return HttpNotFound();
            }
            return View(categoriaPeso);
        }

        // POST: CategoriaPesoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreCategoriaPeso,Genero")] CategoriaPeso categoriaPeso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaPeso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaPeso);
        }

        // GET: CategoriaPesoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaPeso categoriaPeso = db.CategoriaPesos.Find(id);
            if (categoriaPeso == null)
            {
                return HttpNotFound();
            }
            return View(categoriaPeso);
        }

        // POST: CategoriaPesoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaPeso categoriaPeso = db.CategoriaPesos.Find(id);
            db.CategoriaPesos.Remove(categoriaPeso);
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
