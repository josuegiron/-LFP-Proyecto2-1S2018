using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto2_1S2018
{
    public class Pestania : TabPage
    {


        public string[,] token = new string[,] {
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
                { "28", ":", "Dos puntos"},
                { "29", "/", "Operador de division o indicador de cierre de estiqueta..."},
                { "30", "Comentario", "Comentarios"},
                { "31", "Cadena", "Cadena"},
                { "32", "Longitud", "Palabra reservada"}
            };

        public string[,] palabrasReservadas = new string[,] {
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
                { "22", "+"},{ "22", "-"},{ "22", "*"},{ "22", "^"},
                { "23", ";"},
                { "24", "<"},
                { "25", ">"},
                { "26", ","},
                { "27", "="},
                { "28", ":"},
                { "29", "/"},
                { "32", "longitud"}
            };




        public System.Windows.Forms.RichTextBox Entrada;
        public System.Windows.Forms.RichTextBox Consola;
        public System.Windows.Forms.TabControl Control;
        public string rutaArchivo = null;
        string rutaTablaDeSimbolos = " ";
        string rutaTablaDeErrores = "";

        public List<Lexema> tablaDeSimbolos = new List<Lexema>();
        public List<Error> tablaDeErrores = new List<Error>();
        public List<Variable> valorVariable = new List<Variable>();

        public Pestania(TabControl Control)
        {
            InitializeComponent(Control);
        }
        private void InitializeComponent(TabControl Control)
        {
            this.Entrada = new System.Windows.Forms.RichTextBox();

            this.Entrada.Location = new System.Drawing.Point(6, 20);
            this.Entrada.Name = "Entrada";
            this.Entrada.Size = new System.Drawing.Size(350, 450);
            this.Entrada.TabIndex = 0;
            this.Entrada.Text = "";


            this.Consola = new System.Windows.Forms.RichTextBox();

            
           
            
            this.Consola.TabIndex = 0;

            this.Consola.BackColor = System.Drawing.SystemColors.MenuText;
            this.Consola.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Consola.ForeColor = System.Drawing.Color.White;
            this.Consola.Location = new System.Drawing.Point(6, 490);
            this.Consola.Margin = new System.Windows.Forms.Padding(5);
            this.Consola.Multiline = true;
            this.Consola.Name = "Consola";
            this.Consola.Size = new System.Drawing.Size(350, 130);
            this.Consola.TabIndex = 0;
            this.Consola.TabStop = false;
            this.Consola.Text = " DESIGN# ";
            this.Controls.Add(this.Consola);
            this.Controls.Add(this.Entrada);
            // 
        }
        public void generarTablaDeSimbolos()
        {

            string html = "<center><h1 style=\'text-align: center;\'>" + this.Text + "</h1><h2 style=\'text-align: center;\'>Tabla de simbolos:</h2><hr /><p>​&nbsp;</p><table style=\'width: 800px;\' border=\'1\' cellspacing=\'1\' cellpadding=\'1\'><thead><tr><th scope=\'col\'><span style=\'color: #000000;\'>#</span></th><th scope=\'col\'><span style=\'color: #000000;\'>Lexema</span></th>"
            + "<th scope=\'col\'><span style=\'color: #000000;\'>Fila</span></th><th scope=\'col\'><span style=\'color: #000000;\'>Columna</span></th>"
            + "<th scope=\'col\'><span style=\'color: #000000;\'>Id Token</span></th><th scope=\'col\'><span style=\'color: #000000;\'>Token</span></th>"
            + "</tr></thead><tbody>";

            for (int i = 0; i < tablaDeSimbolos.Count; i++)
            {
                string lexemas = "<tr><td style=\'text-align: center;\'> " + tablaDeSimbolos[i].id + "</td><td style=\'text-align: center;\'> " + tablaDeSimbolos[i].nombre + "</td><td style=\'text-align: center;\'>" + tablaDeSimbolos[i].fila + "</td><td style=\'text-align: center;\'>" + tablaDeSimbolos[i].columna + "</td><td style=\'text-align: center;\'>" + tablaDeSimbolos[i].idToken + "</td><td>" + tablaDeSimbolos[i].token + "</td></tr>";
                html += lexemas;
            }

            html += "</tbody></table><p>&nbsp;</p><hr /><p>&nbsp;</p></center>";

            rutaTablaDeSimbolos = rutaArchivo + "-TablaDeSimbolos.html";

            StreamWriter fichero = new StreamWriter(rutaTablaDeSimbolos);
            fichero.Write(html);
            fichero.Close();
            Process.Start(rutaTablaDeSimbolos);

        }
        public void generarTablaDeErrores()
        {

            string html = "<center><h1 style=\'text-align: center;\'>" + this.Text + "</h1><h2 style=\'text-align: center;\'>Tabla de errores:</h2><hr /><p>​&nbsp;</p><table style=\'width: 800px;\' border=\'1\' cellspacing=\'1\' cellpadding=\'1\'><thead><tr><th scope=\'col\'><span style=\'color: #000000;\'>#</span></th><th scope=\'col\'><span style=\'color: #000000;\'>Fila</span></th>"
            + "<th scope=\'col\'><span style=\'color: #000000;\'>Columna</span></th><th scope=\'col\'><span style=\'color: #000000;\'>Caracter</span></th>"
            + "<th scope=\'col\'><span style=\'color: #000000;\'>Id Descripcion</span>"
            + "</tr></thead><tbody>";

            for (int i = 0; i < tablaDeErrores.Count; i++)
            {
                string lexemas = "<tr><td style=\'text-align: center;\'> " + tablaDeErrores[i].id + "</td><td style=\'text-align: center;\'> " + tablaDeErrores[i].fila + "</td><td style=\'text-align: center;\'>" + tablaDeErrores[i].columna + "</td><td style=\'text-align: center;\'>" + tablaDeErrores[i].caracter + "</td><td>Desconocido</td></tr>";
                html += lexemas;
            }

            html += "</tbody></table><p>&nbsp;</p><hr /><p>&nbsp;</p></center>";

            rutaTablaDeErrores = rutaArchivo + "-TablaDeErrores.html";
            StreamWriter fichero = new StreamWriter(rutaTablaDeErrores);
            fichero.Write(html);
            fichero.Close();
            Process.Start(rutaTablaDeErrores);


        }

        public void EscribirEnConsola(string texto)
        {
            Consola.Text += texto + "\r\n DESIGN# ";

            Consola.SelectionStart = Consola.Text.Length;
            Consola.Focus();
            Consola.ScrollToCaret();
            Consola.ReadOnly = true;
        }
        private void Lineas_Click(object sender, EventArgs e)
        {

        }
    }

}
