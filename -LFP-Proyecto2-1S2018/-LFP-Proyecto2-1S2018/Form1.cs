using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto2_1S2018
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public Pestania nuevaPestania()
        {
            int NewTabCount = Contenedor.TabCount;
            Pestania NewTab;
            NewTab = new Pestania(this.Contenedor);
            NewTab.Name = "Nuevo proyecto " + NewTabCount;
            NewTab.Padding = new System.Windows.Forms.Padding(3);
            NewTab.TabIndex = NewTabCount;
            NewTab.Text = "Nuevo proyecto " + NewTabCount;
            NewTab.UseVisualStyleBackColor = true;
            Contenedor.Controls.Add(NewTab);
            Contenedor.SelectedIndex = NewTab.TabIndex;

            return NewTab;
        }
        //----  FUNCION COMPARAR

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

        //----  ANALIZAR EL LENGUAJE

        private void analizarLenguaje(string cadena)
        {
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
            Pestania selectTab = Contenedor.SelectedTab as Pestania;
            selectTab.tablaDeSimbolos.Add(new lexema() { id = num, idToken = idToken, nombre = lexema, fila = fila, columna = columna, token = token });
            num++;
        }
        private void agregarError(string caracter, int fila, int columna)
        {
            Pestania selectTab = Contenedor.SelectedTab as Pestania;
            selectTab.tablaDeErrores.Add(new error() { id = numError, caracter = caracter, fila = fila, columna = columna });
            numError++;
        }

        private void agregarVariable(string nombre, int valor)
        {
            Pestania selectTab = Contenedor.SelectedTab as Pestania;
            variable var = selectTab.valorVariable.Find(x => x.nombre.Contains(nombre));
            if (var == null)
            {
               
                selectTab.valorVariable.Add(new variable() { id = num, nombre = nombre, valor = valor });
            }
            else
            {
                var.valor = valor;
            }

            num++;

        }

        private string obrenerVariable(string nombre)
        {
            Pestania selectTab = Contenedor.SelectedTab as Pestania;
            variable var = selectTab.valorVariable.Find(x => x.nombre.Contains(nombre));
            if (var == null)
            {
                return nombre;
            }
            else
            {
                return Convert.ToString(var.valor);
            }

        }
        //******************************************************************************************************

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

        private void Entrada_TextChanged(object sender, EventArgs e)
        {

        }
        string rutaArchivo = null;
        public string guardarComo(string texto)
        {
            Pestania selectTab = Contenedor.SelectedTab as Pestania;

            SaveFileDialog sFD = new SaveFileDialog();
            sFD.Title = "Guardar proyecto Design " + selectTab.Text;
            sFD.Filter = "Cualquier proyecto Design(*.design*) |*.design";

            sFD.DefaultExt = "design";
            sFD.AddExtension = true;
            sFD.RestoreDirectory = true;
            sFD.InitialDirectory = @"H:\LO DEL ESCRITORIO";

            if (sFD.ShowDialog() == DialogResult.OK)
            {
                selectTab.rutaArchivo = sFD.FileName;

                StreamWriter fichero = new StreamWriter(selectTab.rutaArchivo);
                fichero.Write(texto);
                fichero.Close();
                selectTab.Text = sFD.FileName.Substring(sFD.FileName.LastIndexOf("\\") + 1);
                return selectTab.rutaArchivo;
            }
            else
            {
                sFD.Dispose();
                sFD = null;
                return null;
            }

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pestania selectTab = Contenedor.SelectedTab as Pestania;
            string texto = selectTab.Entrada.Text;
            guardarComo(texto);
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pestania selectTab = Contenedor.SelectedTab as Pestania;
            string texto = selectTab.Entrada.Text;
            if (selectTab.rutaArchivo == null)
            {
                selectTab.rutaArchivo = guardarComo(texto);
            }
            else
            {
                StreamWriter fichero = new StreamWriter(selectTab.rutaArchivo);
                fichero.WriteLine(texto);
                fichero.Close();
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Title = "Abrir proyecto de Design";
            oFD.Filter = "Proyecto de Design (*.design)|*.design" +
            "|Todos los archivos (*.*)|*.*";

            if (oFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Pestania NewTab = nuevaPestania();
                NewTab.rutaArchivo = oFD.FileName;
                NewTab.Entrada.Text = System.IO.File.ReadAllText(NewTab.rutaArchivo);

                NewTab.Text = oFD.SafeFileName;
            }
        }

        private void Contenedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevaPestania();
        }

        public void Compilar(Pestania selectTab)
        {
            selectTab.tablaDeSimbolos.Clear();
            selectTab.tablaDeErrores.Clear();
            string cadena = selectTab.Entrada.Text + "\n";
            analizarLenguaje(cadena);
            
        }

        Pestania tabActual;
        private void compilarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            num = 1;
            numError = 1;
            tabActual = Contenedor.SelectedTab as Pestania;
            Compilar(tabActual);
        }

        private void erroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabActual = Contenedor.SelectedTab as Pestania;
            tabActual.generarTablaDeErrores();
        }

        private void tokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabActual = Contenedor.SelectedTab as Pestania;
            tabActual.generarTablaDeSimbolos();
        }
    }


}


public class lexema
{
    public int id { get; set; }
    public string idToken { get; set; }
    public string nombre { get; set; }
    public int fila { get; set; }
    public int columna { get; set; }
    public string token { get; set; }
}

public class variable
{
    public int id { get; set; }
    public string nombre { get; set; }
    public int valor { get; set; }
}


public class error
{
    public int id { get; set; }
    public int fila { get; set; }
    public int columna { get; set; }
    public string caracter { get; set; }

}
