using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            Scanner Scaner = new Scanner(selectTab);
            Parser Parser = new Parser(selectTab);
            selectTab.tablaDeSimbolos.Clear();
            selectTab.tablaDeErrores.Clear();
            selectTab.variables.Clear();
            Scaner.analizarLenguaje();
            Parser.Design();
        }

        Pestania tabActual;
        private void compilarToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string info = "Autor: Josué Benjamín Girón Ramírez\nCarné: 201318631\r\n\nUniversidad San Carlos de Guatemala\r\n\nPrimer semestre del año 2018\nCurso: LENGUAJES FORMALES Y DE PROGRAMACION\nCódigo: 796 \nSección: A-\r\n\nCopyright © Todos los Derechos Reservados.";
            MessageBox.Show(info);
        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(Application.StartupPath, "Documentos\\Manual de usuario.pdf");
            Process.Start(pdfPath);
        }

        private void manualTecnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(Application.StartupPath, "Documentos\\Manual tecnico.pdf");
            Process.Start(pdfPath);
        }
    }


}
