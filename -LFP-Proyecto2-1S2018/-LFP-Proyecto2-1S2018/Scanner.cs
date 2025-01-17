﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto2_1S2018
{
    class Scanner
    {
        Pestania Proyecto;
        public Scanner(Pestania Proyecto)
        {
            this.Proyecto = Proyecto;
        }

        private Boolean comparar(string[] matrizDeCaracteres, string caracter)
        {
            string caracterStr = caracter.ToString();
            for (int i = 0; i < matrizDeCaracteres.Length; i++)
            {
                if (caracterStr == matrizDeCaracteres[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void analizarLenguaje()
        {
            scanner(Proyecto.Entrada.Text + "\n");
        }
        //----  ANALIZAR EL LENGUAJE

        private void scanner(string cadena)
        {
            num = 1;
            Proyecto.numError = 1;
            int estadoInicial = 0;
            int estadoActual = 0;
            char caracterActual;
            string lexema = "";

            string[] L = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "\xD1", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "\xF1", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] N = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] I = { "=" };
            string[] P = { "." };
            string[] PC = { ";" };
            string[] m = { "<" };
            string[] M = { ">" };
            string[] C = { "," };
            string[] GB = { "_" };
            string[] O = { "+", "-", "*", "/", "^" };
            string[] SL = { "\n" };
            string[] D = { "/" };
            string[] G = { "-" };
            string[] DP = { ":" };
            string[] A = { "!" };
            string[] CN = { "\"" };

            int colActual = 0, filaActual = 1, fila = 0, columna = 0;

            //  INICIO DE LAS INTERACIONES

            for (estadoInicial = 0; estadoInicial < cadena.Length; estadoInicial++)
            {
                caracterActual = cadena[estadoInicial];
                string caracterActualStr = caracterActual.ToString();

                colActual++;
                //  AFD
                switch (estadoActual)
                {

                    case 0: //  ESTADO 0

                        fila = filaActual;
                        columna = colActual;
                        if (comparar(L, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 1;
                        }
                        else if (comparar(N, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 2;
                        }
                        else if (comparar(C, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else if (comparar(PC, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else if (comparar(M, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else if (comparar(DP, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else if (comparar(D, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else if (comparar(I, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else if (comparar(O, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else if (comparar(m, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 7;
                        }
                        else if (comparar(CN, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 14;
                        }
                        else
                        {
                            switch (caracterActual)
                            {
                                case ' ':
                                case '\t':
                                case '\b':
                                case '\f':
                                case '\r':
                                    estadoActual = 0;
                                    break;
                                case '\n':
                                    filaActual++;
                                    colActual = 0;
                                    estadoActual = 0;
                                    break;
                                default:

                                    lexema += caracterActual;
                                    estadoActual = -1;
                                    colActual--;
                                    break;
                            }

                        }
                        break;

                    case 1:     //-----  ESTADO 1   -----
                        if (comparar(L, caracterActualStr))
                        {
                            estadoActual = 1;
                            lexema += caracterActual;
                        }
                        else if (comparar(N, caracterActualStr))
                        {
                            estadoActual = 3;
                            lexema += caracterActual;
                        }
                        else if (comparar(GB, caracterActualStr))
                        {
                            estadoActual = 3;
                            lexema += caracterActual;
                        }
                        else
                        {
                            validarLexema(lexema, fila, columna, "reservado");
                            estadoActual = 0;
                            lexema = "";
                            estadoInicial--;
                            colActual--;
                        }
                        break;
                    case 2:     //-----  ESTADO 2   -----
                        if (comparar(N, caracterActualStr))
                        {
                            estadoActual = 2;
                            lexema += caracterActual;
                        }
                        else if (comparar(P, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 4;
                        }
                        else
                        {
                            validarLexema(lexema, fila, columna, "numero");
                            estadoActual = 0;
                            lexema = "";
                            estadoInicial--;
                            colActual--;
                        }
                        break;
                    case 3:     //-----  ESTADO 3   -----
                        if (comparar(L, caracterActualStr))
                        {
                            estadoActual = 3;
                            lexema += caracterActual;
                        }
                        else if (comparar(N, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 3;
                        }
                        else if (comparar(GB, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 3;
                        }
                        else
                        {
                            validarLexema(lexema, fila, columna, "reservado");
                            estadoActual = 0;
                            lexema = "";
                            estadoInicial--;
                            colActual--;
                        }
                        break;
                    case 4:     //-----  ESTADO 4   -----
                        if (comparar(N, caracterActualStr))
                        {
                            estadoActual = 5;
                            lexema += caracterActual;
                        }
                        else
                        {
                            lexema += caracterActual;
                            estadoActual = -1;
                            colActual--;
                        }
                        break;
                    case 5:     //-----  ESTADO 5   -----
                        if (comparar(N, caracterActualStr))
                        {
                            estadoActual = 5;
                            lexema += caracterActual;
                        }
                        else
                        {
                            validarLexema(lexema, fila, columna, "numero");
                            estadoActual = 0;
                            lexema = "";
                            estadoInicial--;
                            colActual--;
                        }
                        break;
                    case 6:     //-----  ESTADO 6   -----
                        validarLexema(lexema, fila, columna, "reservado");
                        estadoActual = 0;
                        lexema = "";
                        estadoInicial--;
                        colActual--;
                        break;
                    case 7:     //-----  ESTADO 7   -----
                        if (comparar(A, caracterActualStr))
                        {
                            estadoActual = 8;
                            lexema += caracterActual;
                        }
                        else
                        {
                            validarLexema(lexema, fila, columna, "reservado");
                            estadoActual = 0;
                            lexema = "";
                            estadoInicial--;
                            colActual--;
                        }
                        break;
                    case 8:     //-----  ESTADO 8   -----
                        if (comparar(G, caracterActualStr))
                        {
                            estadoActual = 9;
                            lexema += caracterActual;
                        }
                        break;
                    case 9:     //-----  ESTADO 9   -----
                        if (comparar(G, caracterActualStr))
                        {
                            estadoActual = 10;
                            lexema += caracterActual;
                        }
                        break;
                    case 10:     //-----  ESTADO 10   -----
                        if (comparar(G, caracterActualStr))
                        {
                            estadoActual = 11;
                            lexema += caracterActual;
                        }
                        else
                        {
                            estadoActual = 10;
                            lexema += caracterActual;
                        }
                        break;
                    case 11:     //-----  ESTADO 11   -----
                        if (comparar(G, caracterActualStr))
                        {
                            estadoActual = 12;
                            lexema += caracterActual;
                        }
                        break;
                    case 12:     //-----  ESTADO 12   -----
                        if (comparar(M, caracterActualStr))
                        {
                            estadoActual = 13;
                            lexema += caracterActual;
                        }
                        break;
                    case 13:     //-----  ESTADO 9   -----
                        validarLexema(lexema, fila, columna, "comentario");
                        estadoActual = 0;
                        lexema = "";
                        estadoInicial--;
                        colActual--;
                        break;
                    case 14:     //-----  ESTADO 14   -----
                        if (comparar(CN, caracterActualStr))
                        {
                            estadoActual = 15;
                            lexema += caracterActual;
                        }
                        else
                        {
                            estadoActual = 14;
                            lexema += caracterActual;
                        }
                        break;
                    case 15:     //-----  ESTADO 15   -----
                        validarLexema(lexema, fila, columna, "cadena");
                        estadoActual = 0;
                        lexema = "";
                        estadoInicial--;
                        colActual--;
                        break;
                    default:
                        Proyecto.agregarError("ERROR LEXICO: No se reconoce como parte del lenguaje a '"+lexema+"'", fila, columna);
                        estadoInicial--;
                        estadoActual = 0;
                        lexema = "";
                        break;
                }

            }
        }


        
        int num = 1;
        

        private void agregarLexema(string idToken, string lexema, int fila, int columna, string token)
        {
            Proyecto.tablaDeSimbolos.Add(new Lexema() { id = num, idToken = idToken, nombre = lexema, fila = fila, columna = columna, token = token });
            num++;
        }
        

       

        private string validarLexema(string lexema, int fila, int columna, string tipo)
        {
            // tokens y palabras reservadas
            if (tipo == "numero")   //  Si viene un numero:
            {
                lexema = lexema.Replace(" ", "");
                agregarLexema(Proyecto.token[1, 0], lexema, fila, columna, Proyecto.token[1, 2]);
                return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + Proyecto.token[1, 0] + "\tToken: " + Proyecto.token[1, 2];

            }
            else if (tipo == "reservado")   //   Si vienen ID o simbolos:
            {
                lexema = lexema.Replace(" ", "");
                for (int i = 0; i < Proyecto.palabrasReservadas.GetLength(0); i++)
                {
                    if (lexema == Proyecto.palabrasReservadas[i, 1])
                    {
                        int id = Int32.Parse(Proyecto.palabrasReservadas[i, 0]);
                        agregarLexema(Proyecto.token[id, 0], lexema, fila, columna, Proyecto.token[id, 2]);
                        return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + Proyecto.token[id, 0] + "\tToken: " + Proyecto.token[id, 2];

                    }
                }
                agregarLexema(Proyecto.token[2, 0], lexema, fila, columna, Proyecto.token[2, 2]);
                return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + Proyecto.token[2, 0] + "\tToken: " + Proyecto.token[2, 2];

            }
            else if (tipo == "comentario")   //  Si viene un comentario:
            {
                agregarLexema(Proyecto.token[30, 0], lexema, fila, columna, Proyecto.token[30, 2]);
                return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + Proyecto.token[2, 0] + "\tToken: " + Proyecto.token[2, 2];

            }
            else if (tipo == "cadena")   //  Si viene una cadena:
            {
                agregarLexema(Proyecto.token[31, 0], lexema, fila, columna, Proyecto.token[31, 2]);
                return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + Proyecto.token[31, 0] + "\tToken: " + Proyecto.token[31, 2];

            }
            return "ERROR INESPERADO...";
        }

    }
}
