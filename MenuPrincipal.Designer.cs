namespace Movil_RIDA
{
    partial class MenuPrincipal
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
            this.btnInspeccion = new System.Windows.Forms.Button();
            this.btnRecepcion = new System.Windows.Forms.Button();
            this.btnDisponible = new System.Windows.Forms.Button();
            this.btnAbasto = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConteos = new System.Windows.Forms.Button();
            this.lbCompilacion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDisponiblePlanta = new System.Windows.Forms.Button();
            this.btnRcpPlanta = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInspeccion
            // 
            this.btnInspeccion.BackColor = System.Drawing.Color.Black;
            this.btnInspeccion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btnInspeccion.ForeColor = System.Drawing.Color.Yellow;
            this.btnInspeccion.Location = new System.Drawing.Point(11, 47);
            this.btnInspeccion.Name = "btnInspeccion";
            this.btnInspeccion.Size = new System.Drawing.Size(215, 35);
            this.btnInspeccion.TabIndex = 1;
            this.btnInspeccion.Text = "INSPECCION";
            this.btnInspeccion.Click += new System.EventHandler(this.btnInspeccion_Click);
            // 
            // btnRecepcion
            // 
            this.btnRecepcion.BackColor = System.Drawing.Color.Black;
            this.btnRecepcion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btnRecepcion.ForeColor = System.Drawing.Color.Yellow;
            this.btnRecepcion.Location = new System.Drawing.Point(11, 6);
            this.btnRecepcion.Name = "btnRecepcion";
            this.btnRecepcion.Size = new System.Drawing.Size(103, 35);
            this.btnRecepcion.TabIndex = 2;
            this.btnRecepcion.Text = "RECEPCION ";
            this.btnRecepcion.Click += new System.EventHandler(this.btnRecepcion_Click);
            // 
            // btnDisponible
            // 
            this.btnDisponible.BackColor = System.Drawing.Color.Black;
            this.btnDisponible.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btnDisponible.ForeColor = System.Drawing.Color.Yellow;
            this.btnDisponible.Location = new System.Drawing.Point(11, 88);
            this.btnDisponible.Name = "btnDisponible";
            this.btnDisponible.Size = new System.Drawing.Size(103, 35);
            this.btnDisponible.TabIndex = 3;
            this.btnDisponible.Text = "DISPONIBLE";
            this.btnDisponible.Click += new System.EventHandler(this.btnDisponible_Click);
            // 
            // btnAbasto
            // 
            this.btnAbasto.BackColor = System.Drawing.Color.Black;
            this.btnAbasto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btnAbasto.ForeColor = System.Drawing.Color.Yellow;
            this.btnAbasto.Location = new System.Drawing.Point(11, 129);
            this.btnAbasto.Name = "btnAbasto";
            this.btnAbasto.Size = new System.Drawing.Size(215, 35);
            this.btnAbasto.TabIndex = 4;
            this.btnAbasto.Text = "ABASTO PKG";
            this.btnAbasto.Click += new System.EventHandler(this.btnAbasto_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Black;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btnSalir.ForeColor = System.Drawing.Color.Red;
            this.btnSalir.Location = new System.Drawing.Point(11, 238);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(215, 32);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnConteos
            // 
            this.btnConteos.BackColor = System.Drawing.Color.Black;
            this.btnConteos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btnConteos.ForeColor = System.Drawing.Color.Yellow;
            this.btnConteos.Location = new System.Drawing.Point(11, 170);
            this.btnConteos.Name = "btnConteos";
            this.btnConteos.Size = new System.Drawing.Size(215, 35);
            this.btnConteos.TabIndex = 6;
            this.btnConteos.Text = "CONTEOS";
            this.btnConteos.Click += new System.EventHandler(this.btnConteos_Click);
            // 
            // lbCompilacion
            // 
            this.lbCompilacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbCompilacion.ForeColor = System.Drawing.Color.Blue;
            this.lbCompilacion.Location = new System.Drawing.Point(11, 273);
            this.lbCompilacion.Name = "lbCompilacion";
            this.lbCompilacion.Size = new System.Drawing.Size(215, 16);
            this.lbCompilacion.Text = "Compilación";
            this.lbCompilacion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnDisponiblePlanta);
            this.panel1.Controls.Add(this.btnRcpPlanta);
            this.panel1.Controls.Add(this.lbCompilacion);
            this.panel1.Controls.Add(this.btnInspeccion);
            this.panel1.Controls.Add(this.btnConteos);
            this.panel1.Controls.Add(this.btnRecepcion);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnDisponible);
            this.panel1.Controls.Add(this.btnAbasto);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 299);
            // 
            // btnDisponiblePlanta
            // 
            this.btnDisponiblePlanta.BackColor = System.Drawing.Color.Black;
            this.btnDisponiblePlanta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btnDisponiblePlanta.ForeColor = System.Drawing.Color.Yellow;
            this.btnDisponiblePlanta.Location = new System.Drawing.Point(123, 88);
            this.btnDisponiblePlanta.Name = "btnDisponiblePlanta";
            this.btnDisponiblePlanta.Size = new System.Drawing.Size(103, 35);
            this.btnDisponiblePlanta.TabIndex = 9;
            this.btnDisponiblePlanta.Text = "DISP. PLANTA";
            this.btnDisponiblePlanta.Click += new System.EventHandler(this.btnDisponiblePlanta_Click);
            // 
            // btnRcpPlanta
            // 
            this.btnRcpPlanta.BackColor = System.Drawing.Color.Black;
            this.btnRcpPlanta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btnRcpPlanta.ForeColor = System.Drawing.Color.Yellow;
            this.btnRcpPlanta.Location = new System.Drawing.Point(123, 6);
            this.btnRcpPlanta.Name = "btnRcpPlanta";
            this.btnRcpPlanta.Size = new System.Drawing.Size(103, 35);
            this.btnRcpPlanta.TabIndex = 7;
            this.btnRcpPlanta.Text = "REC. PLANTA";
            this.btnRcpPlanta.Click += new System.EventHandler(this.button1_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "MenuPrincipal";
            this.Text = "Movil RIDA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInspeccion;
        private System.Windows.Forms.Button btnRecepcion;
        private System.Windows.Forms.Button btnDisponible;
        private System.Windows.Forms.Button btnAbasto;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConteos;
        private System.Windows.Forms.Label lbCompilacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRcpPlanta;
        private System.Windows.Forms.Button btnDisponiblePlanta;
    }
}