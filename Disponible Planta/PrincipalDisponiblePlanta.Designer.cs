namespace Movil_RIDA
{
    partial class PrincipalDisponiblePlanta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalDisponiblePlanta));
            this.lbSeleccionado = new System.Windows.Forms.Label();
            this.dgDisponible = new System.Windows.Forms.DataGrid();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lbColocar = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSeleccionar = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSeleccionado
            // 
            this.lbSeleccionado.BackColor = System.Drawing.Color.Yellow;
            this.lbSeleccionado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbSeleccionado.ForeColor = System.Drawing.Color.Blue;
            this.lbSeleccionado.Location = new System.Drawing.Point(11, 148);
            this.lbSeleccionado.Name = "lbSeleccionado";
            this.lbSeleccionado.Size = new System.Drawing.Size(226, 18);
            this.lbSeleccionado.Text = "SEL.:";
            // 
            // dgDisponible
            // 
            this.dgDisponible.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgDisponible.Location = new System.Drawing.Point(11, 46);
            this.dgDisponible.Name = "dgDisponible";
            this.dgDisponible.Size = new System.Drawing.Size(226, 98);
            this.dgDisponible.TabIndex = 24;
            this.dgDisponible.CurrentCellChanged += new System.EventHandler(this.dgDisponible_CurrentCellChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Black;
            this.btnSalir.ForeColor = System.Drawing.Color.Red;
            this.btnSalir.Location = new System.Drawing.Point(11, 260);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(226, 30);
            this.btnSalir.TabIndex = 23;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.Black;
            this.btnIniciar.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnIniciar.Location = new System.Drawing.Point(127, 227);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(110, 30);
            this.btnIniciar.TabIndex = 22;
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lbColocar
            // 
            this.lbColocar.BackColor = System.Drawing.Color.Yellow;
            this.lbColocar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbColocar.ForeColor = System.Drawing.Color.Blue;
            this.lbColocar.Location = new System.Drawing.Point(11, 204);
            this.lbColocar.Name = "lbColocar";
            this.lbColocar.Size = new System.Drawing.Size(226, 20);
            this.lbColocar.Text = "A  COLOCAR:";
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.BackColor = System.Drawing.Color.Yellow;
            this.lbDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbDescripcion.ForeColor = System.Drawing.Color.Blue;
            this.lbDescripcion.Location = new System.Drawing.Point(11, 169);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(226, 31);
            this.lbDescripcion.Text = "DESC.";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnActualizar);
            this.panel1.Controls.Add(this.txtSeleccionar);
            this.panel1.Controls.Add(this.dgDisponible);
            this.panel1.Controls.Add(this.lbDescripcion);
            this.panel1.Controls.Add(this.btnIniciar);
            this.panel1.Controls.Add(this.lbColocar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.lbSeleccionado);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 295);
            // 
            // txtSeleccionar
            // 
            this.txtSeleccionar.Location = new System.Drawing.Point(11, 14);
            this.txtSeleccionar.Name = "txtSeleccionar";
            this.txtSeleccionar.Size = new System.Drawing.Size(188, 23);
            this.txtSeleccionar.TabIndex = 28;
            this.txtSeleccionar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSeleccionar_KeyUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(205, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Black;
            this.btnActualizar.ForeColor = System.Drawing.Color.Yellow;
            this.btnActualizar.Location = new System.Drawing.Point(11, 227);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 30);
            this.btnActualizar.TabIndex = 33;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // PrincipalDisponiblePlanta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrincipalDisponiblePlanta";
            this.Text = "Disponible Planta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrincipalDisponible_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbSeleccionado;
        private System.Windows.Forms.DataGrid dgDisponible;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lbColocar;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSeleccionar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnActualizar;
    }
}