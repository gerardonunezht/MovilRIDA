namespace Movil_RIDA
{
    partial class RegistrarDisponiblePlanta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarDisponible));
            this.lbLoc = new System.Windows.Forms.Label();
            this.lbUnidades = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.lbMultiplo = new System.Windows.Forms.Label();
            this.txtMultiplo = new System.Windows.Forms.TextBox();
            this.pbInspeccion = new System.Windows.Forms.PictureBox();
            this.lbID = new System.Windows.Forms.Label();
            this.btnEliminarUltimaPartida = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.txtCB = new System.Windows.Forms.TextBox();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.lbClave = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbColocar = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLoc
            // 
            this.lbLoc.BackColor = System.Drawing.Color.Yellow;
            this.lbLoc.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbLoc.ForeColor = System.Drawing.Color.Blue;
            this.lbLoc.Location = new System.Drawing.Point(49, 37);
            this.lbLoc.Name = "lbLoc";
            this.lbLoc.Size = new System.Drawing.Size(190, 20);
            this.lbLoc.Text = "LOC:";
            // 
            // lbUnidades
            // 
            this.lbUnidades.BackColor = System.Drawing.Color.Yellow;
            this.lbUnidades.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbUnidades.ForeColor = System.Drawing.Color.Blue;
            this.lbUnidades.Location = new System.Drawing.Point(8, 168);
            this.lbUnidades.Name = "lbUnidades";
            this.lbUnidades.Size = new System.Drawing.Size(228, 20);
            this.lbUnidades.Text = "COLOCADAS: 0";
            this.lbUnidades.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(194, 142);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(42, 23);
            this.txtCantidad.TabIndex = 104;
            this.txtCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyUp);
            // 
            // lbCantidad
            // 
            this.lbCantidad.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbCantidad.Location = new System.Drawing.Point(130, 145);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(62, 20);
            this.lbCantidad.Text = "Cantidad";
            // 
            // lbMultiplo
            // 
            this.lbMultiplo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbMultiplo.Location = new System.Drawing.Point(9, 145);
            this.lbMultiplo.Name = "lbMultiplo";
            this.lbMultiplo.Size = new System.Drawing.Size(57, 20);
            this.lbMultiplo.Text = "Múltiplo";
            // 
            // txtMultiplo
            // 
            this.txtMultiplo.BackColor = System.Drawing.Color.Black;
            this.txtMultiplo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtMultiplo.ForeColor = System.Drawing.Color.Yellow;
            this.txtMultiplo.Location = new System.Drawing.Point(72, 142);
            this.txtMultiplo.Name = "txtMultiplo";
            this.txtMultiplo.ReadOnly = true;
            this.txtMultiplo.Size = new System.Drawing.Size(43, 23);
            this.txtMultiplo.TabIndex = 109;
            this.txtMultiplo.Text = "Mult.";
            // 
            // pbInspeccion
            // 
            this.pbInspeccion.Image = ((System.Drawing.Image)(resources.GetObject("pbInspeccion.Image")));
            this.pbInspeccion.Location = new System.Drawing.Point(8, 34);
            this.pbInspeccion.Name = "pbInspeccion";
            this.pbInspeccion.Size = new System.Drawing.Size(32, 23);
            this.pbInspeccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbInspeccion.Click += new System.EventHandler(this.pbInspeccion_Click);
            // 
            // lbID
            // 
            this.lbID.BackColor = System.Drawing.Color.Yellow;
            this.lbID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbID.Location = new System.Drawing.Point(9, 11);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(231, 20);
            this.lbID.Text = "ID RCP:";
            // 
            // btnEliminarUltimaPartida
            // 
            this.btnEliminarUltimaPartida.BackColor = System.Drawing.Color.Red;
            this.btnEliminarUltimaPartida.ForeColor = System.Drawing.Color.Yellow;
            this.btnEliminarUltimaPartida.Location = new System.Drawing.Point(8, 215);
            this.btnEliminarUltimaPartida.Name = "btnEliminarUltimaPartida";
            this.btnEliminarUltimaPartida.Size = new System.Drawing.Size(231, 26);
            this.btnEliminarUltimaPartida.TabIndex = 105;
            this.btnEliminarUltimaPartida.Text = "Eliminar Ultima Partida";
            this.btnEliminarUltimaPartida.Click += new System.EventHandler(this.btnEliminarUltimaPartida_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.Black;
            this.btnFinalizar.ForeColor = System.Drawing.Color.Yellow;
            this.btnFinalizar.Location = new System.Drawing.Point(8, 244);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(231, 30);
            this.btnFinalizar.TabIndex = 107;
            this.btnFinalizar.Text = "FINALIZAR";
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // txtCB
            // 
            this.txtCB.ForeColor = System.Drawing.Color.Blue;
            this.txtCB.Location = new System.Drawing.Point(49, 83);
            this.txtCB.MaxLength = 30;
            this.txtCB.Name = "txtCB";
            this.txtCB.Size = new System.Drawing.Size(190, 23);
            this.txtCB.TabIndex = 101;
            this.txtCB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCB_KeyUp);
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.BackColor = System.Drawing.Color.Black;
            this.lbDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbDescripcion.ForeColor = System.Drawing.Color.Yellow;
            this.lbDescripcion.Location = new System.Drawing.Point(8, 109);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(231, 32);
            this.lbDescripcion.Text = "DESCRIPCION";
            // 
            // lbClave
            // 
            this.lbClave.BackColor = System.Drawing.Color.Black;
            this.lbClave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbClave.ForeColor = System.Drawing.Color.Yellow;
            this.lbClave.Location = new System.Drawing.Point(9, 60);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(230, 20);
            this.lbClave.Text = "CLAVE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // lbColocar
            // 
            this.lbColocar.BackColor = System.Drawing.Color.Yellow;
            this.lbColocar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbColocar.ForeColor = System.Drawing.Color.Green;
            this.lbColocar.Location = new System.Drawing.Point(8, 193);
            this.lbColocar.Name = "lbColocar";
            this.lbColocar.Size = new System.Drawing.Size(228, 20);
            this.lbColocar.Text = "A COLOCAR:";
            this.lbColocar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.lbID);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.lbColocar);
            this.panel1.Controls.Add(this.lbClave);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lbDescripcion);
            this.panel1.Controls.Add(this.lbLoc);
            this.panel1.Controls.Add(this.txtCB);
            this.panel1.Controls.Add(this.lbUnidades);
            this.panel1.Controls.Add(this.btnFinalizar);
            this.panel1.Controls.Add(this.btnEliminarUltimaPartida);
            this.panel1.Controls.Add(this.lbCantidad);
            this.panel1.Controls.Add(this.pbInspeccion);
            this.panel1.Controls.Add(this.lbMultiplo);
            this.panel1.Controls.Add(this.txtMultiplo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 295);
            // 
            // RegistrarDisponible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarDisponible";
            this.Text = "Registrar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RegistrarDisponible_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbLoc;
        private System.Windows.Forms.Label lbUnidades;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lbCantidad;
        private System.Windows.Forms.Label lbMultiplo;
        private System.Windows.Forms.TextBox txtMultiplo;
        private System.Windows.Forms.PictureBox pbInspeccion;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Button btnEliminarUltimaPartida;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.TextBox txtCB;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbColocar;
        private System.Windows.Forms.Panel panel1;
    }
}