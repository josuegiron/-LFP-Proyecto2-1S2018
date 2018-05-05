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
        


        public void Design()
        {
            if (CompararLexema("24"))
            {
                if (CompararLexema("3"))
                {
                    if (CompararLexema("25"))
                    {
                        Variables();
                        Construccion();
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
                                        Error("25");
                                    }
                                }
                                else
                                {
                                    Error("3");
                                }
                            }
                            else
                            {
                                Error("29");
                            }
                        }
                        else
                        {
                            Error("24");
                        }
                    }
                    else
                    {
                        Error("25");
                    }
                }
                else
                {
                    Error("3");
                }
            }
            else
            {
                Error("24");
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
                                        ///******************************************************************
                                    }
                                    else
                                    {
                                        Error("25");
                                    }
                                }
                                else
                                {
                                    Error("4");
                                }
                            }
                            else
                            {
                                Error("29");
                            }
                        }
                        else
                        {
                            Error("24");
                        }
                    }
                    else
                    {
                        Error("25");
                    }
                }
                else
                {
                    Error("4");
                }
            }
            else
            {
                Error("24");
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
                Error("6");
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
        private void Construccion()
        {
            if (CompararLexema("24"))
            {
                if (CompararLexema("5"))
                {
                    if (CompararLexema("25"))
                    {
                        Terreno();
                        Pared_s();
                        Ventana_s();
                        Puerta_s();
                        Suelo_s();
                        if (CompararLexema("24"))
                        {
                            if (CompararLexema("29"))
                            {
                                if (CompararLexema("5"))
                                {
                                    if (CompararLexema("25"))
                                    {
                                        ///******************************************************************
                                    }
                                    else
                                    {
                                        Error("25");
                                    }
                                }
                                else
                                {
                                    Error("5");
                                }
                            }
                            else
                            {
                                Error("29");
                            }
                        }
                        else
                        {
                            Error("24");
                        }
                    }
                    else
                    {
                        Error("25");
                    }
                }
                else
                {
                    Error("5");
                }
            }
            else
            {
                Error("24");
            }
        }

        private void Terreno()
        {
            if (CompararLexema("24"))
            {
                if (CompararLexema("9"))
                {
                    if (CompararLexema("25"))
                    {
                        Ancho();
                        Largo();
                        if (CompararLexema("24"))
                        {
                            if (CompararLexema("29"))
                            {
                                if (CompararLexema("9"))
                                {
                                    if (CompararLexema("25"))
                                    {
                                        ///******************************************************************
                                    }
                                    else
                                    {
                                        Error("25");
                                    }
                                }
                                else
                                {
                                    Error("9");
                                }
                            }
                            else
                            {
                                Error("29");
                            }
                        }
                        else
                        {
                            Error("24");
                        }
                    }
                    else
                    {
                        Error("25");
                    }
                }
                else
                {
                    Error("9");
                }
            }
            else
            {
                Error("24");

            }
        }
        private void Ancho()
        {
            if (CompararLexema("14"))
            {
                if (CompararLexema("27") || CompararLexema("28"))
                {
                    if (CompararLexema("1"))
                    {

                    }
                    else
                    {
                        Error("1");
                    }
                }
                else
                {
                    Error("27");
                }
            }
            else
            {
                Error("14");
            }
        }
        private void Largo()
        {
            if (CompararLexema("15"))
            {
                if (CompararLexema("27"))
                {
                    if (CompararLexema("1"))
                    {

                    }
                    else
                    {
                        Error("1");
                    }
                }
                else
                {
                    Error("27");
                }
            }
            else
            {
                Error("15");
            }
        }

        private void Pared_s()
        {
            if (CompararLexema("24"))
            {
                if (CompararLexema("10"))
                {
                    if (CompararLexema("25"))
                    {
                        Pared();
                        OtraPared();
                        if (CompararLexema("24"))
                        {
                            if (CompararLexema("29"))
                            {
                                if (CompararLexema("10"))
                                {
                                    if (CompararLexema("25"))
                                    {
                                        ///******************************************************************
                                    }
                                    else
                                    {
                                        Error("25");
                                    }
                                }
                                else
                                {
                                    Error("10");
                                }
                            }
                            else
                            {
                                Error("29");
                            }
                        }
                        else
                        {
                            Error("24");
                        }
                    }
                    else
                    {
                        Error("25");
                    }
                }
                else
                {
                    Error("10");
                }
            }
            else
            {
                Error("24");

            }
        }
        private void Pared()
        {
            Nombre();
            Color();
            Alto();
            Inicio();
            Fin();
        }
        private void Color()
        {
            if (CompararLexema("16"))
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
                Error("16");
            }
        }
        private void Alto()
        {
            if (CompararLexema("17"))
            {
                if (CompararLexema("28"))
                {
                    if (CompararLexema("1"))
                    {

                    }
                    else
                    {
                        Error("1");
                    }
                }
                else
                {
                    Error("28");
                }
            }
            else
            {
                Error("17");
            }
        }
        private void Inicio()
        {
            if (CompararLexema("18"))
            {
                if (CompararLexema("28"))
                {
                    if (CompararLexema("1"))
                    {
                        if (CompararLexema("26"))
                        {
                            if (CompararLexema("1"))
                            {

                            }
                            else
                            {
                                Error("1");
                            }
                        }
                        else
                        {
                            Error("26");
                        }
                    }
                    else
                    {
                        Error("1");
                    }
                }
                else
                {
                    Error("28");
                }
            }
            else
            {
                Error("18");
            }
        }
        private void Fin()
        {
            if (CompararLexema("19"))
            {
                if (CompararLexema("28"))
                {
                    if (CompararLexema("1"))
                    {
                        if (CompararLexema("26"))
                        {
                            if (CompararLexema("1"))
                            {

                            }
                            else
                            {
                                Error("1");
                            }
                        }
                        else
                        {
                            Error("26");
                        }
                    }
                    else
                    {
                        Error("1");
                    }
                }
                else
                {
                    Error("28");
                }
            }
            else
            {
                Error("19");
            }
        }
        private void OtraPared()
        {
            if (CompararLexema("23"))
            {
                Pared();
                OtraPared();
            }
        }

        private void Ventana_s()
        {
            if (CompararLexema("24"))
            {
                if (CompararLexema("11"))
                {
                    if (CompararLexema("25"))
                    {
                        Ventana();
                        OtraVentana();
                        if (CompararLexema("24"))
                        {
                            if (CompararLexema("29"))
                            {
                                if (CompararLexema("11"))
                                {
                                    if (CompararLexema("25"))
                                    {
                                        ///******************************************************************
                                    }
                                    else
                                    {
                                        Error("25");
                                    }
                                }
                                else
                                {
                                    Error("11");
                                }
                            }
                            else
                            {
                                Error("29");
                            }
                        }
                        else
                        {
                            Error("24");
                        }
                    }
                    else
                    {
                        Error("25");
                    }
                }
                else
                {
                    Error("11");
                }
            }
            else
            {
                Error("24");

            }
        }
        private void Ventana()
        {
            Nombre();
            Tipo();
            Avanzar();
            switch (lexemaActual.idToken)
            {
                case "20":
                    Radio();
                    break;
                case "32":
                    Longitud();
                    break;
                default:
                    Proyecto.EscribirEnConsola("Error, se esperaba Radio o longitud");
                    break;
            }
            Pared_Asociada();
        }
        private void Longitud()
        {
            if (CompararLexema("28"))
            {
                if (CompararLexema("1"))
                {

                }
                else
                {
                    Error("1");
                }
            }
            else
            {
                Error("28");
            }
        }
        private void Radio()
        {
           if (CompararLexema("27"))
            {
                if (CompararLexema("1"))
                {

                }
                else
                {
                    Error("1");
                }
            }
            else
            {
                Error("28");
            }
            
        }
        private void Pared_Asociada()
        {
            if (CompararLexema("21"))
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
                Error("21");

            }
        }
        private void OtraVentana()
        {
            if (CompararLexema("23"))
            {
                Ventana();
                OtraVentana();
            }
        }

        private void Puerta_s()
        {
            if (CompararLexema("24"))
            {
                if (CompararLexema("12"))
                {
                    if (CompararLexema("25"))
                    {
                        Puerta();
                        OtraPuerta();
                        if (CompararLexema("24"))
                        {
                            if (CompararLexema("29"))
                            {
                                if (CompararLexema("12"))
                                {
                                    if (CompararLexema("25"))
                                    {
                                        ///******************************************************************
                                    }
                                    else
                                    {
                                        Error("25");
                                    }
                                }
                                else
                                {
                                    Error("12");
                                }
                            }
                            else
                            {
                                Error("29");
                            }
                        }
                        else
                        {
                            Error("24");
                        }
                    }
                    else
                    {
                        Error("25");
                    }
                }
                else
                {
                    Error("12");
                }
            }
            else
            {
                Error("24");

            }
        }
        private void Puerta()
        {
            Nombre();
            Alto();
            Ancho();
            Pared_Asociada();
            Color();
        }
        private void OtraPuerta()
        {
            if (CompararLexema("23"))
            {
                Puerta();
                OtraPuerta();
            }
        }

        private void Suelo_s()
        {
            if (CompararLexema("24"))
            {
                if (CompararLexema("13"))
                {
                    if (CompararLexema("25"))
                    {
                        Suelo();
                        OtroSuelo();
                        if (CompararLexema("24"))
                        {
                            if (CompararLexema("29"))
                            {
                                if (CompararLexema("13"))
                                {
                                    if (CompararLexema("25"))
                                    {
                                        ///******************************************************************
                                    }
                                    else
                                    {
                                        Error("25");
                                    }
                                }
                                else
                                {
                                    Error("13");
                                }
                            }
                            else
                            {
                                Error("29");
                            }
                        }
                        else
                        {
                            Error("24");
                        }
                    }
                    else
                    {
                        Error("25");
                    }
                }
                else
                {
                    Error("13");
                }
            }
            else
            {
                Error("24");

            }
        }

        private void Suelo()
        {
            Nombre();
            Color();
        }
        private void OtroSuelo()
        {
            if (CompararLexema("23"))
            {
                Suelo();
                OtroSuelo();
            }
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////


        private void Error(string tokenId)
        {
            Proyecto.EscribirEnConsola("Error 0: Falta '" + Proyecto.token[Convert.ToInt16(tokenId), 1] + "' " + Proyecto.token[Convert.ToInt16(tokenId), 2] + " en fila "+ lexemaActual.fila +" y columna "+ lexemaActual.columna);
            
        }

    }
}