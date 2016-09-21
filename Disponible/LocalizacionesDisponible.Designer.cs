namespace Movil_RIDA
{
    partial class LocalizacionesDisponible
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgLocalizaciones = new System.Windows.Forms.DataGrid();
            this.txtLocalizacion = new System.Windows.Forms.TextBox();
            this.btnLocalizaciones = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbColocar = new System.Windows.Forms.Label();
            this.lbSeleccionado = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgLocalizaciones
            // 
            this.dgLocalizaciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgLocalizaciones.Location = new System.Drawing.Point(9, 45);
            this.dgLocalizaciones.Name = "dgLocalizaciones";
            this.dgLocalizaciones.Size = new System.Drawing.Size(226, 129);
            this.dgLocalizaciones.TabIndex = 0;
            // 
            // txtLocalizacion
            // 
            this.txtLocalizacion.BackColor = System.Drawing.Color.Yellow;
            this.txtLocalizacion.Location = new System.Drawing.Point(9, 248);
            this.txtLocalizacion.Name = "txtLocalizacion";
            this.txtLocalizacion.Size = new System.Drawing.Size(226, 23);
            this.txtLocalizacion.TabIndex = 3;
            this.txtLocalizacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLocalizacion_KeyUp);
            // 
            // btnLocalizaciones
            // 
            this.btnLocalizaciones.BackColor = System.Drawing.Color.Black;
            this.btnLocalizaciones.ForeColor = System.Drawing.Color.Yellow;
            this.btnLocalizaciones.Location = new System.Drawing.Point(9, 11);
            this.btnLocalizaciones.Name = "btnLocalizaciones";
            this.btnLocalizaciones.Size = new System.Drawing.Size(226, 30);
            this.btnLocalizaciones.TabIndex = 5;
            this.btnLocalizaciones.Text = "Localizaciones";
            this.btnLocalizaciones.Click += new System.EventHandler(this.btnLocalizaciones_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 20);
            this.label1.Text = "Digite o escanee localización";
            // 
            // lbColocar
            // 
            this.lbColocar.BackColor = System.Drawing.Color.Yellow;
            this.lbColocar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbColocar.ForeColor = System.Drawing.Color.Blue;
            this.lbColocar.Location = new System.Drawing.Point(9, 205);
            this.lbColocar.Name = "lbColocar";
            this.lbColocar.Size = new System.Drawing.Size(226, 20);
            this.lbColocar.Text = "A  COLOCAR:";
            // 
            // lbSeleccionado
            // 
            this.lbSeleccionado.BackColor = System.Drawing.Color.Yellow;
            this.lbSeleccionado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbSeleccionado.ForeColor = System.Drawing.Color.Blue;
            this.lbSeleccionado.Location = new System.Drawing.Point(9, 181);
            this.lbSeleccionado.Name = "lbSeleccionado";
            this.lbSeleccionado.Size = new System.Drawing.Size(226, 18);
            this.lbSeleccionado.Text = "SEL.:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnLocalizaciones);
            this.panel1.Controls.Add(this.lbColocar);
            this.panel1.Controls.Add(this.dgLocalizaciones);
            this.panel1.Controls.Add(this.lbSeleccionado);
            this.panel1.Controls.Add(this.txtLocalizacion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 295);
            // 
            // LocalizacionesDisponible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.panel1);
            this.Name = "LocalizacionesDisponible";
            this.Text = "Localizaciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LocalizacionesDisponible_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dgLocalizaciones;
        private System.Windows.Forms.TextBox txtLocalizacion;
        private System.Windows.Forms.Button btnLocalizaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbColocar;
        private System.Windows.Forms.Label lbSeleccionado;
        private System.Windows.Forms.Panel panel1;
    }
}