namespace Movil_RIDA
{
    partial class ExcepcionConteo
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
            this.oculto = new System.Windows.Forms.TextBox();
            this.btnExcepcion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoExp = new System.Windows.Forms.TextBox();
            this.txtLocalizacionExp = new System.Windows.Forms.TextBox();
            this.txtCantidadExp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbProductoExcepcion = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // oculto
            // 
            this.oculto.Location = new System.Drawing.Point(229, 232);
            this.oculto.Name = "oculto";
            this.oculto.Size = new System.Drawing.Size(11, 23);
            this.oculto.TabIndex = 2;
            this.oculto.Visible = false;
            // 
            // btnExcepcion
            // 
            this.btnExcepcion.BackColor = System.Drawing.Color.Black;
            this.btnExcepcion.ForeColor = System.Drawing.Color.Red;
            this.btnExcepcion.Location = new System.Drawing.Point(13, 232);
            this.btnExcepcion.Name = "btnExcepcion";
            this.btnExcepcion.Size = new System.Drawing.Size(214, 30);
            this.btnExcepcion.TabIndex = 3;
            this.btnExcepcion.Text = "EXCEPCION";
            this.btnExcepcion.Click += new System.EventHandler(this.btnExcepcion_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 20);
            this.label1.Text = "LOCALIZACION:";
            // 
            // txtCodigoExp
            // 
            this.txtCodigoExp.BackColor = System.Drawing.Color.Yellow;
            this.txtCodigoExp.Location = new System.Drawing.Point(13, 86);
            this.txtCodigoExp.Name = "txtCodigoExp";
            this.txtCodigoExp.Size = new System.Drawing.Size(214, 23);
            this.txtCodigoExp.TabIndex = 5;
            this.txtCodigoExp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigoExp_KeyUp);
            // 
            // txtLocalizacionExp
            // 
            this.txtLocalizacionExp.BackColor = System.Drawing.Color.Yellow;
            this.txtLocalizacionExp.Location = new System.Drawing.Point(13, 34);
            this.txtLocalizacionExp.Name = "txtLocalizacionExp";
            this.txtLocalizacionExp.Size = new System.Drawing.Size(214, 23);
            this.txtLocalizacionExp.TabIndex = 6;
            this.txtLocalizacionExp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLocalizacionExp_KeyUp);
            // 
            // txtCantidadExp
            // 
            this.txtCantidadExp.BackColor = System.Drawing.Color.Yellow;
            this.txtCantidadExp.Location = new System.Drawing.Point(13, 187);
            this.txtCantidadExp.Name = "txtCantidadExp";
            this.txtCantidadExp.Size = new System.Drawing.Size(214, 23);
            this.txtCantidadExp.TabIndex = 8;
            this.txtCantidadExp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCantidadExp_KeyUp);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 20);
            this.label2.Text = "CODIGO BARRAS:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(13, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 20);
            this.label3.Text = "CANTIDAD:";
            // 
            // lbProductoExcepcion
            // 
            this.lbProductoExcepcion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbProductoExcepcion.Location = new System.Drawing.Point(13, 116);
            this.lbProductoExcepcion.Name = "lbProductoExcepcion";
            this.lbProductoExcepcion.Size = new System.Drawing.Size(214, 48);
            this.lbProductoExcepcion.Text = "DESCRIPCION";
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.lbProductoExcepcion);
            this.panel.Controls.Add(this.oculto);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.btnExcepcion);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.txtCodigoExp);
            this.panel.Controls.Add(this.txtCantidadExp);
            this.panel.Controls.Add(this.txtLocalizacionExp);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(245, 295);
            // 
            // ExcepcionConteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.panel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcepcionConteo";
            this.Text = "ExcepcionConteo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ExcepcionConteo_Load);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox oculto;
        private System.Windows.Forms.Button btnExcepcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoExp;
        private System.Windows.Forms.TextBox txtLocalizacionExp;
        private System.Windows.Forms.TextBox txtCantidadExp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbProductoExcepcion;
        private System.Windows.Forms.Panel panel;
    }
}