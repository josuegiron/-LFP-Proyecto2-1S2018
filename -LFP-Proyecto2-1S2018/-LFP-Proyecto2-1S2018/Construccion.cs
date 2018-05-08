using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LFP_Proyecto2_1S2018
{
    public class Terreno
    {
        public string ancho { get; set; }
        public string largo { get; set; }
    }

    public class Pared
    {
        public string nombre { get; set; }
        public string color { get; set; }
        public string alto { get; set; }
        public string inicio { get; set; }
        public string fin { get; set;}
    }

    public class Ventana
    {
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string longitud { get; set; }
        public string radio { get; set; }
        public string pared_asociada { get; set; }
    }

    public class Puerta
    {
        public string nombre { get; set; }
        public string alto { get; set; }
        public string ancho { get; set; }
        public string color { get; set; }
        public string pared_asociada { get; set; }
    }
    public class Suelo
    {
        public string nombre { get; set; }
        public string color { get; set; }
    }

}
