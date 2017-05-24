namespace Movil_RIDA
{
    partial class Partidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Partidas));
            this.label5 = new System.Windows.Forms.Label();
            this.lbMultiploEmpaque = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.lbClave = new System.Windows.Forms.Label();
            this.txtCB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCantRecibida = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.lbCantOrdenada = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnEliminarUltimaPartida = new System.Windows.Forms.Button();
            this.lbOC = new System.Windows.Forms.Label();
            this.lbFactura = new System.Windows.Forms.Label();
            this.pbInspeccion = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(92, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.Text = "Empaque con:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Visible = false;
            // 
            // lbMultiploEmpaque
            // 
            this.lbMultiploEmpaque.BackColor = System.Drawing.Color.Black;
            this.lbMultiploEmpaque.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbMultiploEmpaque.ForeColor = System.Drawing.Color.Yellow;
            this.lbMultiploEmpaque.Location = new System.Drawing.Point(187, 147);
            this.lbMultiploEmpaque.Name = "lbMultiploEmpaque";
            this.lbMultiploEmpaque.Size = new System.Drawing.Size(52, 20);
            this.lbMultiploEmpaque.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbMultiploEmpaque.Visible = false;
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.BackColor = System.Drawing.Color.Black;
            this.lbDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbDescripcion.ForeColor = System.Drawing.Color.Yellow;
            this.lbDescripcion.Location = new System.Drawing.Point(8, 87);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(231, 32);
            this.lbDescripcion.Text = "DESCRIPCION";
            // 
            // lbClave
            // 
            this.lbClave.BackColor = System.Drawing.Color.Black;
            this.lbClave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbClave.ForeColor = System.Drawing.Color.Yellow;
            this.lbClave.Location = new System.Drawing.Point(8, 67);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(231, 20);
            this.lbClave.Text = "CLAVE";
            // 
            // txtCB
            // 
            this.txtCB.ForeColor = System.Drawing.Color.Blue;
            this.txtCB.Location = new System.Drawing.Point(46, 41);
            this.txtCB.MaxLength = 30;
            this.txtCB.Name = "txtCB";
            this.txtCB.Size = new System.Drawing.Size(193, 23);
            this.txtCB.TabIndex = 20;
            this.txtCB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCB_KeyUp);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(124, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.Text = "Recibido:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.Text = "Solicitado:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbCantRecibida
            // 
            this.lbCantRecibida.BackColor = System.Drawing.Color.Lime;
            this.lbCantRecibida.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lbCantRecibida.Location = new System.Drawing.Point(141, 186);
            this.lbCantRecibida.Name = "lbCantRecibida";
            this.lbCantRecibida.Size = new System.Drawing.Size(98, 20);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.Yellow;
            this.txtCantidad.ForeColor = System.Drawing.Color.Blue;
            this.txtCantidad.Location = new System.Drawing.Point(187, 122);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(52, 23);
            this.txtCantidad.TabIndex = 38;
            this.txtCantidad.Visible = false;
            this.txtCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyUp);
            // 
            // lbCantidad
            // 
            this.lbCantidad.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbCantidad.Location = new System.Drawing.Point(65, 124);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(116, 16);
            this.lbCantidad.Text = "Total de empaques:";
            this.lbCantidad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbCantidad.Visible = false;
            // 
            // lbCantOrdenada
            // 
            this.lbCantOrdenada.BackColor = System.Drawing.Color.Yellow;
            this.lbCantOrdenada.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lbCantOrdenada.Location = new System.Drawing.Point(8, 186);
            this.lbCantOrdenada.Name = "lbCantOrdenada";
            this.lbCantOrdenada.Size = new System.Drawing.Size(98, 20);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.Black;
            this.btnFinalizar.ForeColor = System.Drawing.Color.Yellow;
            this.btnFinalizar.Location = new System.Drawing.Point(8, 244);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(231, 30);
            this.btnFinalizar.TabIndex = 57;
            this.btnFinalizar.Text = "Finalizar Recepción";
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnEliminarUltimaPartida
            // 
            this.btnEliminarUltimaPartida.BackColor = System.Drawing.Color.Red;
            this.btnEliminarUltimaPartida.ForeColor = System.Drawing.Color.Yellow;
            this.btnEliminarUltimaPartida.Location = new System.Drawing.Point(8, 210);
            this.btnEliminarUltimaPartida.Name = "btnEliminarUltimaPartida";
            this.btnEliminarUltimaPartida.Size = new System.Drawing.Size(231, 26);
            this.btnEliminarUltimaPartida.TabIndex = 68;
            this.btnEliminarUltimaPartida.Text = "Eliminar Ultima Partida";
            this.btnEliminarUltimaPartida.Click += new System.EventHandler(this.btnEliminarUltimaPartida_Click);
            // 
            // lbOC
            // 
            this.lbOC.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbOC.Location = new System.Drawing.Point(11, 11);
            this.lbOC.Name = "lbOC";
            this.lbOC.Size = new System.Drawing.Size(95, 20);
            this.lbOC.Text = "OC:";
            // 
            // lbFactura
            // 
            this.lbFactura.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbFactura.Location = new System.Drawing.Point(112, 11);
            this.lbFactura.Name = "lbFactura";
            this.lbFactura.Size = new System.Drawing.Size(122, 27);
            this.lbFactura.Text = "F:";
            this.lbFactura.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbInspeccion
            // 
            this.pbInspeccion.Image = ((System.Drawing.Image)(resources.GetObject("pbInspeccion.Image")));
            this.pbInspeccion.Location = new System.Drawing.Point(8, 41);
            this.pbInspeccion.Name = "pbInspeccion";
            this.pbInspeccion.Size = new System.Drawing.Size(32, 23);
            this.pbInspeccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.lbOC);
            this.panel1.Controls.Add(this.pbInspeccion);
            this.panel1.Controls.Add(this.lbClave);
            this.panel1.Controls.Add(this.lbFactura);
            this.panel1.Controls.Add(this.lbDescripcion);
            this.panel1.Controls.Add(this.lbMultiploEmpaque);
            this.panel1.Controls.Add(this.btnEliminarUltimaPartida);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnFinalizar);
            this.panel1.Controls.Add(this.txtCB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbCantOrdenada);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbCantidad);
            this.panel1.Controls.Add(this.lbCantRecibida);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 295);
            // 
            // Partidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Partidas";
            this.Text = "Registro de Partidas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Partidas_Load);
            this.Closed += new System.EventHandler(this.Partidas_Closed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbMultiploEmpaque;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.TextBox txtCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCantRecibida;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lbCantidad;
        private System.Windows.Forms.Label lbCantOrdenada;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnEliminarUltimaPartida;
        private System.Windows.Forms.Label lbOC;
        private System.Windows.Forms.Label lbFactura;
        private System.Windows.Forms.PictureBox pbInspeccion;
        private System.Windows.Forms.Panel panel1;
    }
}