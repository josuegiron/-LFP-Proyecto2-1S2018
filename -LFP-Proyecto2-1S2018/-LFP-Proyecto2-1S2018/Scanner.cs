using System;
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
            numError = 0;
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
                        else if (comparar(G, caracterActualStr))
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
                        else if (comparar(G, caracterActualStr))
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
                        validarLexema(lexema, fila, columna, "comentario");
                        estadoActual = 0;
                        lexema = "";
                        estadoInicial--;
                        colActual--;
                        break;
                    default:
                        agregarError(lexema, fila, columna);
                        estadoInicial--;
                        estadoActual = 0;
                        lexema = "";
                        break;
                }

            }
        }


        string[,] token = new string[,] {
                { "ID", "Token", "Descripcion" },
                { "1", "Numero", "Secuencia de numeros" },
                { "2", "id", "Cadena de numeros y letras" },
                { "3", "diseño", "Palabra reservada, inicio de programa" },
                { "4", "variables", "Palabra reservda, indica seccion de variables" },
                { "5", "construccion", "Palabra reservada, indica seccion de construccion" },
                { "6", "nombre", "Palabra reservada" },
                { "7", "tipo", "Palabra reservada" },
                { "8", "valor", "Palabra reservada" },
                { "9", "terreno", "Palabra reservada" },
                { "10", "pared", "Palabra reservada" },
                { "11", "ventana", "Palabra reservada" },
                { "12", "puerta", "Palabra reservada" },
                { "13", "suelo", "Palabra reservada" },
                { "14", "ancho", "Palabra reservada" },
                { "15", "largo", "Palabra reservada" },
                { "16", "color", "Palabra reservada" },
                { "17", "alto", "Palabra reservada" },
                { "18", "inicio", "Palabra reservada"},
                { "19", "fin", "Palabra reservada"},
                { "20", "radio", "Palabra reservada"},
                { "21", "pared_asociada", "Palabra reservada"},
                { "22", "Operador", "Operador matematico"},
                { "23", ";", "Final de comando"},
                { "24", "<", "Signo menor"},
                { "25", ">", "Signo mayor"},
                { "26", ",", "Coma"},
                { "27", "=", "Signo igual, asignacion"},
                { "27", ":", "Dos puntos"}
            };

        string[,] palabrasReservadas = new string[,] {
                { "3", "diseño" },
                { "4", "variables" },
                { "5", "construccion" },
                { "6", "nombre" },
                { "7", "tipo" },
                { "8", "valor" },
                { "9", "terreno" },
                { "10", "pared" },
                { "11", "ventana" },
                { "12", "puerta" },
                { "13", "suelo" },
                { "14", "ancho" },
                { "15", "largo" },
                { "16", "color" },
                { "17", "alto" },
                { "18", "inicio"},
                { "19", "fin"},
                { "20", "radio"},
                { "21", "pared_asociada"},
                { "22", "Operador"},
                { "23", ";"},
                { "24", "<"},
                { "25", ">"},
                { "26", ","},
                { "27", "="},
                { "27", ":"}
            };


        int num = 1;
        int numError = 1;

        private void agregarLexema(string idToken, string lexema, int fila, int columna, string token)
        {
            Proyecto.tablaDeSimbolos.Add(new Lexema() { id = num, idToken = idToken, nombre = lexema, fila = fila, columna = columna, token = token });
            num++;
        }
        private void agregarError(string caracter, int fila, int columna)
        {
            Proyecto.tablaDeErrores.Add(new Error() { id = numError, caracter = caracter, fila = fila, columna = columna });
            numError++;
        }

        private void agregarVariable(string nombre, int valor)
        {
            Variable var = Proyecto.valorVariable.Find(x => x.nombre.Contains(nombre));
            if (var == null)
            {

                Proyecto.valorVariable.Add(new Variable() { id = num, nombre = nombre, valor = valor });
            }
            else
            {
                var.valor = valor;
            }

            num++;

        }

        private string obrenerVariable(string nombre)
        {
            Variable var = Proyecto.valorVariable.Find(x => x.nombre.Contains(nombre));
            if (var == null)
            {
                return nombre;
            }
            else
            {
                return Convert.ToString(var.valor);
            }

        }

        private string validarLexema(string lexema, int fila, int columna, string tipo)
        {
            // tokens y palabras reservadas
            if (tipo == "numero")   //  Si viene un numero:
            {
                lexema = lexema.Replace(" ", "");
                agregarLexema(token[1, 0], lexema, fila, columna, token[1, 2]);
                return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + token[1, 0] + "\tToken: " + token[1, 2];

            }
            else if (tipo == "reservado")   //   Si vienen ID o simbolos:
            {
                lexema = lexema.Replace(" ", "");
                for (int i = 0; i < palabrasReservadas.GetLength(0); i++)
                {
                    if (lexema == palabrasReservadas[i, 1])
                    {
                        int id = Int32.Parse(palabrasReservadas[i, 0]);
                        agregarLexema(token[id, 0], lexema, fila, columna, token[id, 2]);
                        return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + token[id, 0] + "\tToken: " + token[id, 2];

                    }
                }
                agregarLexema(token[2, 0], lexema, fila, columna, token[2, 2]);
                return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + token[2, 0] + "\tToken: " + token[2, 2];

            }
            else if (tipo == "comentario")   //  Si viene un comentario:
            {
                agregarLexema(token[2, 0], lexema, fila, columna, token[2, 2]);
                return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + token[2, 0] + "\tToken: " + token[2, 2];

            }
            return "ERROR INESPERADO...";
        }

    }
}
