using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoFenipo.Models;


namespace ProyectoFenipo.Controllers
{
    public class Calculos
    {

        public decimal Glpoints (double total , double bw , string Sexo)
        {
            double a;
            double b;
            double c;
            double p;
            double cohe;
            if(Sexo == "Masculino")
            {
                a = 1199.72839;
                b = 1025.18162;
                c = 0.00921; 
            }
            else
            {
                a = 610.32796;
                b = 1045.59282;
                c = 0.03048;
            }

            p = a - b * (Math.Pow(Math.E, (-c * bw)));
            cohe = 100 / p; 
            return (decimal)(total * cohe);
        }
    }

    public class movimiento
    {
        public string nombre { get; set; }
        public decimal kilos { get; set;  }
    }
}