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

        public System.Windows.Forms.RichTextBox Entrada;
        public System.Windows.Forms.TabControl Control;
        public string rutaArchivo = null;
        string rutaTablaDeSimbolos = " ";
        string rutaTablaDeErrores = "";

        public List<lexema> tablaDeSimbolos = new List<lexema>();
        public List<error> tablaDeErrores = new List<error>();

        public Pestania(TabControl Control)
        {
            InitializeComponent(Control);
        }
        private void InitializeComponent(TabControl Control)
        {
            this.Entrada = new System.Windows.Forms.RichTextBox();

            this.Entrada.Location = new System.Drawing.Point(6, 20);
            this.Entrada.Name = "Entrada";
            this.Entrada.Size = new System.Drawing.Size(350, 600);
            this.Entrada.TabIndex = 0;
            this.Entrada.Text = "";

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


        private void Lineas_Click(object sender, EventArgs e)
        {

        }
    }

}
