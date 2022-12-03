using ProyectoFenipo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProyectoFenipo
{
    /// <summary>
    /// Descripción breve de ProyectoFenipoServiceWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ProyectoFenipoServiceWeb : System.Web.Services.WebService
    {

        private ProyectoFenipoContainer db = new ProyectoFenipoContainer();

        [WebMethod]
        public List<vAtletas> GetAtletas()
        {
            var atleta = db.Atletas.ToList();
            List<vAtletas> vAtletas = new List<vAtletas>();
            if (atleta.Count > 0)
            {
                for (int i = 0; i < atleta.Count; i++)
                {
                    vAtletas vAtleta = new vAtletas();
                    vAtleta.NombreAtleta = atleta[i].NombreAtleta;
                    vAtleta.FechaNacimiento = Convert.ToString(atleta[i].FechaNacimiento);
                    vAtleta.Sexo = atleta[i].Sexo;
                    vAtleta.Id = atleta[i].Id;
                    vAtletas.Add(vAtleta);
                }
            }
            return vAtletas;
        }
        [WebMethod]
        public void PostAtletas(string nombre, string fecha, string sexo)
        {
            if (nombre != null && sexo != null && fecha != null)
            {
                db.Atletas.Add(new Atleta
                {
                    FechaNacimiento = Convert.ToDateTime(fecha),
                    NombreAtleta = nombre,
                    Sexo = sexo
                });
                db.SaveChanges();
            }

        }
        [WebMethod]
        public void PutAtletas(int id, string nombre, string fecha, string sexo)
        {
            if (id != 0 && nombre != null && sexo != null && fecha != null)
            {
                db.Entry(new Atleta { Id = id, NombreAtleta = nombre, FechaNacimiento = Convert.ToDateTime(fecha), Sexo = sexo }).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        [WebMethod]
        public void DeleteAtleta(int id)
        {
            if (id != 0)
            {
                db.Atletas.Remove(db.Atletas.Find(id));
                db.SaveChanges();
            }

        }

        [WebMethod]
        public List<vInscripcionEquipo> GetIncripcion()
        {

            var inscripcions = db.InscripcionEquipos.ToList();
            List<vInscripcionEquipo> vInscripcionEquipos = new List<vInscripcionEquipo>();
            if (inscripcions.Count > 0)
            {
                for (int i = 0; i < inscripcions.Count; i++)
                {
                    vInscripcionEquipo vinscripcion = new vInscripcionEquipo();
                    vinscripcion.Id = inscripcions[i].Id;
                    vinscripcion.EquipoId = inscripcions[i].EquipoId;
                    vinscripcion.DelegadoEquipo = inscripcions[i].DelegadoEquipo;
                    vinscripcion.CompetenciaId = inscripcions[i].CompetenciaId;
                    vInscripcionEquipos.Add(vinscripcion);
                }
            }
            return vInscripcionEquipos;

        }
        [WebMethod]
        public List<vEquipo> GetEquipo()
        {

            var equipos = db.Equipos.ToList();
            List<vEquipo> Equipos = new List<vEquipo>();
            if (equipos.Count > 0)
            {
                for (int i = 0; i < equipos.Count; i++)
                {
                    vEquipo vequipo = new vEquipo();
                    vequipo.NacionalidadEquipo = equipos[i].NacionalidadEquipo;
                    vequipo.NombreEquipo = equipos[i].NombreEquipo;
                    vequipo.Id = equipos[i].Id;
                    Equipos.Add(vequipo);

                }
            }
            return Equipos;

        }

        [WebMethod]
        public void PostEquipo(string nombre, string nacionalidad)
        {
            if (nombre != null && nacionalidad != null)
            {
                db.Equipos.Add(new Equipo
                {
                    NombreEquipo = nombre,
                    NacionalidadEquipo = nacionalidad,
                });
                db.SaveChanges();
            }

        }
        [WebMethod]
        public void PutEquipo(int id, string nombre, string nacionalidad)
        {
            if (id != 0 && nombre != null && nacionalidad != null)
            {
                db.Entry(new Equipo { Id = id, NombreEquipo = nombre, NacionalidadEquipo = nacionalidad }).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        [WebMethod]
        public void DeleteEquipo(int id)
        {
            if (id != 0)
            {
                db.Equipos.Remove(db.Equipos.Find(id));
                db.SaveChanges();
            }

        }
    }
    public class vAtletas
    {
        public int Id { get; set; }
        public string NombreAtleta { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
    }

    public class vInscripcionEquipo
    {
        public int Id { get; set; }
        public int EquipoId { get; set; }
        public string DelegadoEquipo { get; set; }
        public int CompetenciaId { get; set; }
    }


    public class vEquipo
    {
        public int Id { get; set; }
        public string NombreEquipo { get; set; }
        public string NacionalidadEquipo { get; set; }
    }

}

