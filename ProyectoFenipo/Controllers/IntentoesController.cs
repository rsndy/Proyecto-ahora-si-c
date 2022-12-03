using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFenipo.Models;
using ProyectoFenipo.Controllers;
namespace ProyectoFenipo.Controllers
{
    [Authorize]
    public class IntentoesController : Controller
    {
        private ProyectoFenipoContainer db = new ProyectoFenipoContainer();

        // GET: Intentoes
        public ActionResult Index()
        {
            var intentos = db.Intentos.Include(i => i.InscripcionAtletas).Include(i => i.Movimiento1).Include(i => i.NumeroIntento1).Include(i => i.StatusMovimiento);
            return View(intentos.ToList());
        }

        // GET: Intentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intento intento = db.Intentos.Find(id);
            if (intento == null)
            {
                return HttpNotFound();
            }
            return View(intento);
        }

        // GET: Intentoes/Create
        public ActionResult Create()
        {
            ViewBag.InscripcionAtletasId = new SelectList(db.InscripcionAtletasSet, "Id", "Id");
            ViewBag.MovimientoId = new SelectList(db.Movimientos, "Id", "Nombre");
            ViewBag.NumeroIntentoId = new SelectList(db.NumeroIntentos, "Id", "Numero");
            ViewBag.StatusMovimientoId = new SelectList(db.StatusMovimientoSet, "Id", "Status");
            return View();
        }

        // POST: Intentoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InscripcionAtletasId,KilosMovimiento,MovimientoId,NumeroIntentoId,StatusMovimientoId")] Intento intento)
        {
            if (ModelState.IsValid)
            {
                db.Intentos.Add(intento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InscripcionAtletasId = new SelectList(db.InscripcionAtletasSet, "Id", "Id", intento.InscripcionAtletasId);
            ViewBag.MovimientoId = new SelectList(db.Movimientos, "Id", "Nombre", intento.MovimientoId);
            ViewBag.NumeroIntentoId = new SelectList(db.NumeroIntentos, "Id", "Numero", intento.NumeroIntentoId);
            ViewBag.StatusMovimientoId = new SelectList(db.StatusMovimientoSet, "Id", "Status", intento.StatusMovimientoId);
            return View(intento);
        }
        public void CreateInt(Intento intento)
        {
                db.Intentos.Add(intento);
                db.SaveChanges();
                          
        }

        // GET: Intentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intento intento = db.Intentos.Find(id);
            if (intento == null)
            {
                return HttpNotFound();
            }
            ViewBag.InscripcionAtletasId = new SelectList(db.InscripcionAtletasSet, "Id", "Id", intento.InscripcionAtletasId);
            ViewBag.MovimientoId = new SelectList(db.Movimientos, "Id", "Nombre", intento.MovimientoId);
            ViewBag.NumeroIntentoId = new SelectList(db.NumeroIntentos, "Id", "Numero", intento.NumeroIntentoId);
            ViewBag.StatusMovimientoId = new SelectList(db.StatusMovimientoSet, "Id", "Status", intento.StatusMovimientoId);
            return View(intento);
        }

        // POST: Intentoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InscripcionAtletasId,KilosMovimiento,MovimientoId,NumeroIntentoId,StatusMovimientoId")] Intento intento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intento).State = EntityState.Modified;
                db.SaveChanges();
                //var atleta = db.InscripcionAtletasSet.Where(x => x.Id == intento.InscripcionAtletasId).FirstOrDefault();
                //double total;
                //double sentadilla = 0;
                //double Banca = 0;
                //double Muerto = 0;
                //foreach (var mov in atleta.Intento.Where(x=>x.StatusMovimiento.Status == "Valido"))
                //{
                    
                //    if (mov.Movimiento1.Nombre == "Sentadilla" && (double)mov.KilosMovimiento > sentadilla)
                //        sentadilla = (double)mov.KilosMovimiento;
                //    if (mov.Movimiento1.Nombre == "Press de Banca" && (double)mov.KilosMovimiento > Banca)
                //        Banca = (double)mov.KilosMovimiento;
                //    if (mov.Movimiento1.Nombre == "Sentadilla" && (double)mov.KilosMovimiento > Muerto)
                //        Muerto = (double)mov.KilosMovimiento;

                //}
                //total = sentadilla + Banca + Muerto;
                //atleta.Total = total; 
                //InscripcionAtletasController controller = new InscripcionAtletasController();
                //controller.Editar(atleta); 

                return RedirectToAction("Details/" + intento.InscripcionAtletasId , "InscripcionAtletas");
            }
            ViewBag.InscripcionAtletasId = new SelectList(db.InscripcionAtletasSet, "Id", "Id", intento.InscripcionAtletasId);
            ViewBag.MovimientoId = new SelectList(db.Movimientos, "Id", "Nombre", intento.MovimientoId);
            ViewBag.NumeroIntentoId = new SelectList(db.NumeroIntentos, "Id", "Numero", intento.NumeroIntentoId);
            ViewBag.StatusMovimientoId = new SelectList(db.StatusMovimientoSet, "Id", "Status", intento.StatusMovimientoId);
            return View(intento);
        }
        // GET: Intentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intento intento = db.Intentos.Find(id);
            if (intento == null)
            {
                return HttpNotFound();
            }
            return View(intento);
        }
        // POST: Intentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Intento intento = db.Intentos.Find(id);
            db.Intentos.Remove(intento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public void DeleteConfirmado(int id)
        {
            Intento intento = db.Intentos.Find(id);
            db.Intentos.Remove(intento);
            db.SaveChanges();
            
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
