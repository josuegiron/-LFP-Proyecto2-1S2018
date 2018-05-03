using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LFP_Proyecto2_1S2018
{
    class Parser
    {
        Pestania Proyecto;
        Ejecutar EjecutarFuncion;
        public Parser(Pestania Proyecto)
        {
            this.Proyecto = Proyecto;
            this.EjecutarFuncion = new Ejecutar();//aca se debe meter algo
        }

        public void AnalisarSintaxis()
        {
        }
    }
}
