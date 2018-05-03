namespace _LFP_Proyecto2_1S2018
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Contenedor = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Entrada = new System.Windows.Forms.RichTextBox();
            this.Contenedor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Contenedor
            // 
            this.Contenedor.Controls.Add(this.tabPage1);
            this.Contenedor.Location = new System.Drawing.Point(21, 12);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.SelectedIndex = 0;
            this.Contenedor.Size = new System.Drawing.Size(1124, 662);
            this.Contenedor.TabIndex = 4;
            this.Contenedor.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Entrada);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1116, 636);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Entrada
            // 
            this.Entrada.Location = new System.Drawing.Point(6, 6);
            this.Entrada.Name = "Entrada";
            this.Entrada.Size = new System.Drawing.Size(348, 624);
            this.Entrada.TabIndex = 0;
            this.Entrada.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 728);
            this.Controls.Add(this.Contenedor);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Contenedor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Contenedor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox Entrada;
    }
}