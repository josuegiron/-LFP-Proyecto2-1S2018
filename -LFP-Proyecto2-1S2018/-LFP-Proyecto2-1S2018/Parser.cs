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
        int indicador = 0;
        Lexema lexemaActual;
        public Parser(Pestania Proyecto)
        {
            this.Proyecto = Proyecto;
            this.EjecutarFuncion = new Ejecutar();  //    Aca se debe meter algo
        }

        private void continuar()
        {
            try
            {
                if (lexemaActual.idToken == "30")
                {
                    indicador++;
                    continuar();
                }
            }
            catch { }

        }
       private void Avanzar()
        {
            try
            {
                lexemaActual = Proyecto.tablaDeSimbolos[indicador];
                indicador++;
            }catch{ }
        }

        public Boolean CompararLexema(String lexema) {

            continuar();
            try
            {
                lexemaActual = Proyecto.tablaDeSimbolos[indicador];
                if (lexema == lexemaActual.idToken)
                {
                    indicador++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
            

            
        }
        


        public void Inicio()
        {
            if (CompararLexema("24"))
            {
                if (CompararLexema("3"))
                {
                    if (CompararLexema("25"))
                    {
                        Variables();
                        //Construccion();
                        if (CompararLexema("24"))
                        {
                            if (CompararLexema("29"))
                            {
                                if (CompararLexema("3"))
                                {
                                    if (CompararLexema("25"))
                                    {
                                        Proyecto.EscribirEnConsola("SE COMPILA CORRECTAMENTE EL DISEÑO...");
                                    }
                                    else
                                    {
                                        Proyecto.EscribirEnConsola("Error: Falta cierre de etiqueta");
                                    }
                                }
                                else
                                {
                                    Proyecto.EscribirEnConsola("Error: Falta diseño cierre de etiqueta");
                                }
                            }
                            else
                            {
                                Proyecto.EscribirEnConsola("Error: Falta indicador cierre de etiqueta '/' ");
                            }
                        }
                        else
                        {
                            Proyecto.EscribirEnConsola("Error: Falta apertura de etiqueta");
                        }
                    }
                    else
                    {
                        Proyecto.EscribirEnConsola("Error: Falta apertura de etiqueta");
                    }
                }
                else
                {
                    Proyecto.EscribirEnConsola("Error: Falta diseño cierre de etiqueta");
                }
            }
            else
            {
                Proyecto.EscribirEnConsola("Error: Falta cierre de etiqueta");
            }
        }

        private void Variables()
        {
            if (CompararLexema("24"))
            {
                if (CompararLexema("4"))
                {
                    if (CompararLexema("25"))
                    {
                        CuerpoVariable();
                        if (CompararLexema("24"))
                        {
                            if (CompararLexema("29"))
                            {
                                if (CompararLexema("4"))
                                {
                                    if (CompararLexema("25"))
                                    {
                                        Proyecto.EscribirEnConsola("Se complila correctamente el diseño...");
                                    }
                                    else
                                    {
                                        Proyecto.EscribirEnConsola("Error: Falta cierre de etiqueta '>'");
                                    }
                                }
                                else
                                {
                                    Proyecto.EscribirEnConsola("Error: Falta palabra reservada 'variable'");
                                }
                            }
                            else
                            {
                                Proyecto.EscribirEnConsola("Error: Falta indicador cierre de etiqueta");
                            }
                        }
                        else
                        {
                            Proyecto.EscribirEnConsola("Error: Falta apertura de etiqueta");
                        }
                    }
                    else
                    {
                        Proyecto.EscribirEnConsola("Error: Falta apertura de etiqueta");
                    }
                }
                else
                {
                    Proyecto.EscribirEnConsola("Error: Falta variable");
                }
            }
            else
            {
                Proyecto.EscribirEnConsola("Error: Falta cierre de etiqueta");
            }
        }


        private void CuerpoVariable()
        {
            Variable();
            OtraVariable();
        }
        private void Variable()
        {
            Nombre();
            Tipo();
            Valor();
        }
        private void Nombre()
        {
            if (CompararLexema("6"))
            {
                if (CompararLexema("28"))
                {
                    if (CompararLexema("2"))
                    {

                    }
                    else
                    {
                        Error("6");
                    }
                }
                else
                {
                    Error("28");
                }
            }
            else
            {
                Error("2");
            }
        }

        private void Tipo()
        {
            if (CompararLexema("7"))
            {
                if (CompararLexema("28"))
                {
                    if (CompararLexema("2"))
                    {

                    }
                    else
                    {
                        Error("2");
                    }
                }
                else
                {
                    Error("28");
                }
            }
            else
            {
                Error("7");
            }
        }
        private void Valor()
        {
            if (CompararLexema("8"))
            {
                if (CompararLexema("28"))
                {
                    Avanzar();
                    switch (lexemaActual.idToken)
                    {
                        case "1":
                            Expresion();
                            break;
                        case "2":
                            break;
                        case "31":
                            Proyecto.EscribirEnConsola("pasa");
                            break;
                        default:
                            Proyecto.EscribirEnConsola("Error, no se reconoce lo que viene");
                            break;
                    }
                }
                else
                {
                    Error("28");
                }
            }
            else
            {
                Error("8");
            }
        }
       

        private void Expresion()
        {
            if (CompararLexema("22") || CompararLexema("29"))
            {
                if (CompararLexema("1"))
                {
                    Expresion();
                }
                else
                {
                    Error("1");
                }
            }
        }

        private void OtraVariable()
        {
            if (CompararLexema("23"))
            {
                Variable();
                OtraVariable();
            }
        }
        private void Error(string tokenId)
        {
           
            Proyecto.EscribirEnConsola("Error 0: Falta '" + Proyecto.token[Convert.ToInt16(tokenId), 1] + "' " + Proyecto.token[Convert.ToInt16(tokenId), 2] + " en fila "+ lexemaActual.fila +" y columna "+ lexemaActual.columna);
            
        }

    }
}
