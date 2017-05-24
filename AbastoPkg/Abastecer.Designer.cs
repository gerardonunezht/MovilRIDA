namespace Movil_RIDA
{
    partial class Abastecer
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
            this.lbNoTransferencia = new System.Windows.Forms.Label();
            this.lbConfirmarLocalizacion = new System.Windows.Forms.Label();
            this.lbConfirmarProducto = new System.Windows.Forms.Label();
            this.txtConfirmarLocalizacion = new System.Windows.Forms.TextBox();
            this.txtConfirmarProducto = new System.Windows.Forms.TextBox();
            this.tmLocalizacion = new System.Windows.Forms.Timer();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.lbRecolectado = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNoTransferencia
            // 
            this.lbNoTransferencia.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbNoTransferencia.Location = new System.Drawing.Point(8, 8);
            this.lbNoTransferencia.Name = "lbNoTransferencia";
            this.lbNoTransferencia.Size = new System.Drawing.Size(211, 20);
            this.lbNoTransferencia.Text = "Transferencia";
            this.lbNoTransferencia.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbConfirmarLocalizacion
            // 
            this.lbConfirmarLocalizacion.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lbConfirmarLocalizacion.ForeColor = System.Drawing.Color.Red;
            this.lbConfirmarLocalizacion.Location = new System.Drawing.Point(3, 65);
            this.lbConfirmarLocalizacion.Name = "lbConfirmarLocalizacion";
            this.lbConfirmarLocalizacion.Size = new System.Drawing.Size(200, 33);
            this.lbConfirmarLocalizacion.Text = "LOCALIZACION";
            this.lbConfirmarLocalizacion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbConfirmarProducto
            // 
            this.lbConfirmarProducto.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lbConfirmarProducto.ForeColor = System.Drawing.Color.Red;
            this.lbConfirmarProducto.Location = new System.Drawing.Point(3, 4);
            this.lbConfirmarProducto.Name = "lbConfirmarProducto";
            this.lbConfirmarProducto.Size = new System.Drawing.Size(200, 30);
            this.lbConfirmarProducto.Text = "PRODUCTO";
            this.lbConfirmarProducto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtConfirmarLocalizacion
            // 
            this.txtConfirmarLocalizacion.BackColor = System.Drawing.Color.Yellow;
            this.txtConfirmarLocalizacion.Location = new System.Drawing.Point(3, 101);
            this.txtConfirmarLocalizacion.Name = "txtConfirmarLocalizacion";
            this.txtConfirmarLocalizacion.Size = new System.Drawing.Size(200, 23);
            this.txtConfirmarLocalizacion.TabIndex = 4;
            this.txtConfirmarLocalizacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfirmarLocalizacion_KeyUp);
            // 
            // txtConfirmarProducto
            // 
            this.txtConfirmarProducto.BackColor = System.Drawing.Color.Yellow;
            this.txtConfirmarProducto.Location = new System.Drawing.Point(3, 39);
            this.txtConfirmarProducto.Name = "txtConfirmarProducto";
            this.txtConfirmarProducto.Size = new System.Drawing.Size(200, 23);
            this.txtConfirmarProducto.TabIndex = 5;
            this.txtConfirmarProducto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfirmarProducto_KeyUp);
            // 
            // tmLocalizacion
            // 
            this.tmLocalizacion.Interval = 1000;
            this.tmLocalizacion.Tick += new System.EventHandler(this.tmLocalizacion_Tick);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.Black;
            this.btnFinalizar.ForeColor = System.Drawing.Color.Red;
            this.btnFinalizar.Location = new System.Drawing.Point(8, 64);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(211, 33);
            this.btnFinalizar.TabIndex = 9;
            this.btnFinalizar.Text = "FINALIZAR";
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel.Controls.Add(this.lbConfirmarProducto);
            this.panel.Controls.Add(this.lbConfirmarLocalizacion);
            this.panel.Controls.Add(this.txtConfirmarProducto);
            this.panel.Controls.Add(this.txtConfirmarLocalizacion);
            this.panel.Location = new System.Drawing.Point(8, 101);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(211, 142);
            // 
            // lbRecolectado
            // 
            this.lbRecolectado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lbRecolectado.Location = new System.Drawing.Point(8, 31);
            this.lbRecolectado.Name = "lbRecolectado";
            this.lbRecolectado.Size = new System.Drawing.Size(215, 20);
            this.lbRecolectado.Text = "Tot. Recolectado";
            this.lbRecolectado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Abastecer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.lbRecolectado);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.lbNoTransferencia);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Abastecer";
            this.Text = "Abastecer";
            this.Load += new System.EventHandler(this.Abastecer_Load);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNoTransferencia;
        private System.Windows.Forms.Label lbConfirmarLocalizacion;
        private System.Windows.Forms.Label lbConfirmarProducto;
        private System.Windows.Forms.TextBox txtConfirmarLocalizacion;
        private System.Windows.Forms.TextBox txtConfirmarProducto;
        private System.Windows.Forms.Timer tmLocalizacion;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lbRecolectado;
    }
}