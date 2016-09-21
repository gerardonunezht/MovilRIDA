namespace Movil_RIDA
{
    partial class RegistrarConteo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarConteo));
            this.pbInspeccion = new System.Windows.Forms.PictureBox();
            this.lbIdConteo = new System.Windows.Forms.Label();
            this.btnEliminarUltimaPartida = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.txtCB = new System.Windows.Forms.TextBox();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.lbClave = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.lbMultiplo = new System.Windows.Forms.Label();
            this.txtMultiplo = new System.Windows.Forms.TextBox();
            this.lbCantContada = new System.Windows.Forms.Label();
            this.lbLoc = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbInspeccion
            // 
            this.pbInspeccion.Image = ((System.Drawing.Image)(resources.GetObject("pbInspeccion.Image")));
            this.pbInspeccion.Location = new System.Drawing.Point(7, 81);
            this.pbInspeccion.Name = "pbInspeccion";
            this.pbInspeccion.Size = new System.Drawing.Size(32, 23);
            this.pbInspeccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // lbIdConteo
            // 
            this.lbIdConteo.BackColor = System.Drawing.Color.Yellow;
            this.lbIdConteo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbIdConteo.Location = new System.Drawing.Point(6, 11);
            this.lbIdConteo.Name = "lbIdConteo";
            this.lbIdConteo.Size = new System.Drawing.Size(231, 20);
            this.lbIdConteo.Text = "NO. CONTEO:";
            // 
            // btnEliminarUltimaPartida
            // 
            this.btnEliminarUltimaPartida.BackColor = System.Drawing.Color.Red;
            this.btnEliminarUltimaPartida.ForeColor = System.Drawing.Color.Yellow;
            this.btnEliminarUltimaPartida.Location = new System.Drawing.Point(6, 207);
            this.btnEliminarUltimaPartida.Name = "btnEliminarUltimaPartida";
            this.btnEliminarUltimaPartida.Size = new System.Drawing.Size(231, 26);
            this.btnEliminarUltimaPartida.TabIndex = 2;
            this.btnEliminarUltimaPartida.Text = "Eliminar Ultima Partida";
            this.btnEliminarUltimaPartida.Click += new System.EventHandler(this.btnEliminarUltimaPartida_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.Black;
            this.btnFinalizar.ForeColor = System.Drawing.Color.Yellow;
            this.btnFinalizar.Location = new System.Drawing.Point(6, 241);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(231, 30);
            this.btnFinalizar.TabIndex = 3;
            this.btnFinalizar.Text = "Finalizar Conteo Loc.";
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // txtCB
            // 
            this.txtCB.ForeColor = System.Drawing.Color.Blue;
            this.txtCB.Location = new System.Drawing.Point(47, 81);
            this.txtCB.MaxLength = 30;
            this.txtCB.Name = "txtCB";
            this.txtCB.Size = new System.Drawing.Size(190, 23);
            this.txtCB.TabIndex = 0;
            this.txtCB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCB_KeyUp);
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.BackColor = System.Drawing.Color.Black;
            this.lbDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbDescripcion.ForeColor = System.Drawing.Color.Yellow;
            this.lbDescripcion.Location = new System.Drawing.Point(6, 107);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(231, 32);
            this.lbDescripcion.Text = "DESCRIPCION";
            // 
            // lbClave
            // 
            this.lbClave.BackColor = System.Drawing.Color.Black;
            this.lbClave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbClave.ForeColor = System.Drawing.Color.Yellow;
            this.lbClave.Location = new System.Drawing.Point(7, 58);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(230, 20);
            this.lbClave.Text = "CLAVE";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(192, 146);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(42, 23);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyUp);
            // 
            // lbCantidad
            // 
            this.lbCantidad.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbCantidad.Location = new System.Drawing.Point(128, 148);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(62, 20);
            this.lbCantidad.Text = "Cantidad";
            // 
            // lbMultiplo
            // 
            this.lbMultiplo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbMultiplo.Location = new System.Drawing.Point(7, 148);
            this.lbMultiplo.Name = "lbMultiplo";
            this.lbMultiplo.Size = new System.Drawing.Size(57, 20);
            this.lbMultiplo.Text = "Múltiplo";
            // 
            // txtMultiplo
            // 
            this.txtMultiplo.BackColor = System.Drawing.Color.Black;
            this.txtMultiplo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtMultiplo.ForeColor = System.Drawing.Color.Yellow;
            this.txtMultiplo.Location = new System.Drawing.Point(70, 145);
            this.txtMultiplo.Name = "txtMultiplo";
            this.txtMultiplo.ReadOnly = true;
            this.txtMultiplo.Size = new System.Drawing.Size(43, 23);
            this.txtMultiplo.TabIndex = 96;
            this.txtMultiplo.Text = "Mult.";
            // 
            // lbCantContada
            // 
            this.lbCantContada.BackColor = System.Drawing.Color.Yellow;
            this.lbCantContada.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbCantContada.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbCantContada.Location = new System.Drawing.Point(6, 179);
            this.lbCantContada.Name = "lbCantContada";
            this.lbCantContada.Size = new System.Drawing.Size(228, 20);
            this.lbCantContada.Text = "UDS. CONTADAS:";
            this.lbCantContada.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbLoc
            // 
            this.lbLoc.BackColor = System.Drawing.Color.Yellow;
            this.lbLoc.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbLoc.ForeColor = System.Drawing.Color.Blue;
            this.lbLoc.Location = new System.Drawing.Point(7, 35);
            this.lbLoc.Name = "lbLoc";
            this.lbLoc.Size = new System.Drawing.Size(230, 20);
            this.lbLoc.Text = "LOC:";
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel.Controls.Add(this.lbIdConteo);
            this.panel.Controls.Add(this.lbLoc);
            this.panel.Controls.Add(this.lbClave);
            this.panel.Controls.Add(this.lbCantContada);
            this.panel.Controls.Add(this.lbDescripcion);
            this.panel.Controls.Add(this.txtCantidad);
            this.panel.Controls.Add(this.txtCB);
            this.panel.Controls.Add(this.lbCantidad);
            this.panel.Controls.Add(this.btnFinalizar);
            this.panel.Controls.Add(this.lbMultiplo);
            this.panel.Controls.Add(this.btnEliminarUltimaPartida);
            this.panel.Controls.Add(this.txtMultiplo);
            this.panel.Controls.Add(this.pbInspeccion);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(245, 295);
            // 
            // RegistrarConteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.panel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarConteo";
            this.Text = "Registrar Conteo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RegistrarConteo_Load);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbInspeccion;
        private System.Windows.Forms.Label lbIdConteo;
        private System.Windows.Forms.Button btnEliminarUltimaPartida;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.TextBox txtCB;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lbCantidad;
        private System.Windows.Forms.Label lbMultiplo;
        private System.Windows.Forms.TextBox txtMultiplo;
        private System.Windows.Forms.Label lbCantContada;
        private System.Windows.Forms.Label lbLoc;
        private System.Windows.Forms.Panel panel;

    }
}