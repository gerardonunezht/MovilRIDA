namespace Movil_RIDA
{
    partial class ReAbastecer
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
            this.lbConfirmarProducto = new System.Windows.Forms.Label();
            this.lbConfirmarLocalizacion = new System.Windows.Forms.Label();
            this.txtConfirmarProducto = new System.Windows.Forms.TextBox();
            this.txtConfirmarLocalizacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNoTransferencia = new System.Windows.Forms.Label();
            this.lbTotReAbastecido = new System.Windows.Forms.Label();
            this.tmLocalizacion = new System.Windows.Forms.Timer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSinAbasto = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbConfirmarProducto
            // 
            this.lbConfirmarProducto.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lbConfirmarProducto.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbConfirmarProducto.Location = new System.Drawing.Point(22, 138);
            this.lbConfirmarProducto.Name = "lbConfirmarProducto";
            this.lbConfirmarProducto.Size = new System.Drawing.Size(213, 32);
            this.lbConfirmarProducto.Text = "PRODUCTO";
            this.lbConfirmarProducto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbConfirmarLocalizacion
            // 
            this.lbConfirmarLocalizacion.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lbConfirmarLocalizacion.ForeColor = System.Drawing.Color.Red;
            this.lbConfirmarLocalizacion.Location = new System.Drawing.Point(22, 54);
            this.lbConfirmarLocalizacion.Name = "lbConfirmarLocalizacion";
            this.lbConfirmarLocalizacion.Size = new System.Drawing.Size(213, 30);
            this.lbConfirmarLocalizacion.Text = "LOCALIZACION";
            this.lbConfirmarLocalizacion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtConfirmarProducto
            // 
            this.txtConfirmarProducto.BackColor = System.Drawing.Color.Yellow;
            this.txtConfirmarProducto.Location = new System.Drawing.Point(36, 173);
            this.txtConfirmarProducto.Name = "txtConfirmarProducto";
            this.txtConfirmarProducto.Size = new System.Drawing.Size(189, 23);
            this.txtConfirmarProducto.TabIndex = 2;
            this.txtConfirmarProducto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfirmarProducto_KeyUp);
            // 
            // txtConfirmarLocalizacion
            // 
            this.txtConfirmarLocalizacion.BackColor = System.Drawing.Color.Yellow;
            this.txtConfirmarLocalizacion.Location = new System.Drawing.Point(36, 88);
            this.txtConfirmarLocalizacion.Name = "txtConfirmarLocalizacion";
            this.txtConfirmarLocalizacion.Size = new System.Drawing.Size(189, 23);
            this.txtConfirmarLocalizacion.TabIndex = 5;
            this.txtConfirmarLocalizacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfirmarLocalizacion_KeyUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(62, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.Text = "Confirmar Localización";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(22, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 20);
            this.label2.Text = "Confirmar Producto (Cod. Barras)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbNoTransferencia
            // 
            this.lbNoTransferencia.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbNoTransferencia.Location = new System.Drawing.Point(22, 11);
            this.lbNoTransferencia.Name = "lbNoTransferencia";
            this.lbNoTransferencia.Size = new System.Drawing.Size(203, 20);
            this.lbNoTransferencia.Text = "Trnsfr:";
            // 
            // lbTotReAbastecido
            // 
            this.lbTotReAbastecido.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbTotReAbastecido.Location = new System.Drawing.Point(170, 263);
            this.lbTotReAbastecido.Name = "lbTotReAbastecido";
            this.lbTotReAbastecido.Size = new System.Drawing.Size(65, 20);
            this.lbTotReAbastecido.Text = "0";
            this.lbTotReAbastecido.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbTotReAbastecido.Visible = false;
            // 
            // tmLocalizacion
            // 
            this.tmLocalizacion.Interval = 1000;
            this.tmLocalizacion.Tick += new System.EventHandler(this.tmLocalizacion_Tick);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnSinAbasto);
            this.panel1.Controls.Add(this.lbNoTransferencia);
            this.panel1.Controls.Add(this.lbConfirmarProducto);
            this.panel1.Controls.Add(this.lbTotReAbastecido);
            this.panel1.Controls.Add(this.lbConfirmarLocalizacion);
            this.panel1.Controls.Add(this.txtConfirmarProducto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtConfirmarLocalizacion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 295);
            // 
            // btnSinAbasto
            // 
            this.btnSinAbasto.Location = new System.Drawing.Point(36, 209);
            this.btnSinAbasto.Name = "btnSinAbasto";
            this.btnSinAbasto.Size = new System.Drawing.Size(189, 37);
            this.btnSinAbasto.TabIndex = 7;
            this.btnSinAbasto.Text = "NO HAY ABASTO";
            this.btnSinAbasto.Click += new System.EventHandler(this.btnSinAbasto_Click);
            // 
            // ReAbastecer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReAbastecer";
            this.Text = "Re Abastecer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReAbastecer_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbConfirmarProducto;
        private System.Windows.Forms.Label lbConfirmarLocalizacion;
        private System.Windows.Forms.TextBox txtConfirmarProducto;
        private System.Windows.Forms.TextBox txtConfirmarLocalizacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNoTransferencia;
        private System.Windows.Forms.Label lbTotReAbastecido;
        private System.Windows.Forms.Timer tmLocalizacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSinAbasto;
    }
}