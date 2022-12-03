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
    public class InscripcionEquipoesController : Controller
    {
        private ProyectoFenipoContainer db = new ProyectoFenipoContainer();

        // GET: InscripcionEquipoes
        public ActionResult Index()
        {
            var inscripcionEquipos = db.InscripcionEquipos.Include(i => i.Equipo).Include(i => i.Competencia);
            return View(inscripcionEquipos.ToList());
        }

        // GET: InscripcionEquipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscripcionEquipo inscripcionEquipo = db.InscripcionEquipos.Find(id);
            if (inscripcionEquipo == null)
            {
                return HttpNotFound();
            }
            return View(inscripcionEquipo);
        }

        // GET: InscripcionEquipoes/Create
        public ActionResult Create()
        {
            
            ViewBag.EquipoId = new SelectList(db.Equipos, "Id", "NombreEquipo");
            ViewBag.CompetenciaId = new SelectList(db.Competencias, "Id", "Nombre");
            return View();
        }

    

        // POST: InscripcionEquipoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EquipoId,DelegadoEquipo,CompetenciaId")] InscripcionEquipo inscripcionEquipo)
        {
            foreach(var team in db.InscripcionEquipos.Where(x=>x.CompetenciaId == inscripcionEquipo.CompetenciaId))
            {
                if(team.EquipoId == inscripcionEquipo.EquipoId)
                {
                    return Content("<script>alert('El equipo ya fue Inscrito con enterioridad') </script>"); 
                }
                
            }
            if (ModelState.IsValid)
            {
                db.InscripcionEquipos.Add(inscripcionEquipo);
                db.SaveChanges();
                return RedirectToAction("ListaEquipos/" + inscripcionEquipo.CompetenciaId, "Competencias");
            }


            ViewBag.EquipoId = new SelectList(db.Equipos, "Id", "NombreEquipo", inscripcionEquipo.EquipoId);
            //ViewBag.CompetenciaId = new SelectList(db.Competencias, "Id", "Nombre", inscripcionEquipo.CompetenciaId);
            return View(inscripcionEquipo);
        }

   

        // GET: InscripcionEquipoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscripcionEquipo inscripcionEquipo = db.InscripcionEquipos.Find(id);
            if (inscripcionEquipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipoId = new SelectList(db.Equipos, "Id", "NombreEquipo", inscripcionEquipo.EquipoId);
            ViewBag.CompetenciaId = new SelectList(db.Competencias, "Id", "Nombre", inscripcionEquipo.CompetenciaId);
            return View(inscripcionEquipo);
        }

        // POST: InscripcionEquipoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EquipoId,DelegadoEquipo,CompetenciaId")] InscripcionEquipo inscripcionEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcionEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaEquipos/" + inscripcionEquipo.CompetenciaId, "Competencias");
            }
            ViewBag.EquipoId = new SelectList(db.Equipos, "Id", "NombreEquipo", inscripcionEquipo.EquipoId);
            ViewBag.CompetenciaId = new SelectList(db.Competencias, "Id", "Nombre", inscripcionEquipo.CompetenciaId);
            return View(inscripcionEquipo);
        }
        // GET: InscripcionEquipoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscripcionEquipo inscripcionEquipo = db.InscripcionEquipos.Find(id);
            if (inscripcionEquipo == null)
            {
                return HttpNotFound();
            }
            return View(inscripcionEquipo);
        }
        // POST: InscripcionEquipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InscripcionEquipo inscripcionEquipo = db.InscripcionEquipos.Find(id);
            db.InscripcionEquipos.Remove(inscripcionEquipo);
            db.SaveChanges();
            return RedirectToAction("ListaEquipos/" + inscripcionEquipo.CompetenciaId, "Competencias");
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
