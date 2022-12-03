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
    public class NumeroIntentoesController : Controller
    {
        private ProyectoFenipoContainer db = new ProyectoFenipoContainer();

        // GET: NumeroIntentoes
        public ActionResult Index()
        {
            return View(db.NumeroIntentos.ToList());
        }

        // GET: NumeroIntentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumeroIntento numeroIntento = db.NumeroIntentos.Find(id);
            if (numeroIntento == null)
            {
                return HttpNotFound();
            }
            return View(numeroIntento);
        }

        // GET: NumeroIntentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NumeroIntentoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numero")] NumeroIntento numeroIntento)
        {
            if (ModelState.IsValid)
            {
                db.NumeroIntentos.Add(numeroIntento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(numeroIntento);
        }

        // GET: NumeroIntentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumeroIntento numeroIntento = db.NumeroIntentos.Find(id);
            if (numeroIntento == null)
            {
                return HttpNotFound();
            }
            return View(numeroIntento);
        }

        // POST: NumeroIntentoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numero")] NumeroIntento numeroIntento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numeroIntento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(numeroIntento);
        }
        // GET: NumeroIntentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumeroIntento numeroIntento = db.NumeroIntentos.Find(id);
            if (numeroIntento == null)
            {
                return HttpNotFound();
            }
            return View(numeroIntento);
        }
        // POST: NumeroIntentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NumeroIntento numeroIntento = db.NumeroIntentos.Find(id);
            db.NumeroIntentos.Remove(numeroIntento);
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
