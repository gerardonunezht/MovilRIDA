namespace Movil_RIDA
{
    partial class PrincipalInspeccion
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
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.lbMultiploEmpaque = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.lbClave = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRecolectado = new System.Windows.Forms.Label();
            this.lbTamañoMuestra = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUtilerias = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(42, 11);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(187, 23);
            this.txtCodigoBarras.TabIndex = 0;
            this.txtCodigoBarras.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigoBarras_KeyUp);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.Black;
            this.btnFinalizar.ForeColor = System.Drawing.Color.Yellow;
            this.btnFinalizar.Location = new System.Drawing.Point(7, 229);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(227, 35);
            this.btnFinalizar.TabIndex = 1;
            this.btnFinalizar.Text = "FINALIZAR";
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // lbMultiploEmpaque
            // 
            this.lbMultiploEmpaque.BackColor = System.Drawing.Color.Black;
            this.lbMultiploEmpaque.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbMultiploEmpaque.ForeColor = System.Drawing.Color.Yellow;
            this.lbMultiploEmpaque.Location = new System.Drawing.Point(186, 105);
            this.lbMultiploEmpaque.Name = "lbMultiploEmpaque";
            this.lbMultiploEmpaque.Size = new System.Drawing.Size(43, 20);
            this.lbMultiploEmpaque.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.BackColor = System.Drawing.Color.Yellow;
            this.lbDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbDescripcion.Location = new System.Drawing.Point(7, 68);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(222, 32);
            this.lbDescripcion.Text = "DESCRIPCION";
            // 
            // lbClave
            // 
            this.lbClave.BackColor = System.Drawing.Color.Black;
            this.lbClave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbClave.ForeColor = System.Drawing.Color.Yellow;
            this.lbClave.Location = new System.Drawing.Point(7, 44);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(222, 20);
            this.lbClave.Text = "CLAVE";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(25, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.Text = "Recolectado:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(8, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.Text = "Tamaño Muestra:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbRecolectado
            // 
            this.lbRecolectado.BackColor = System.Drawing.Color.Lime;
            this.lbRecolectado.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lbRecolectado.Location = new System.Drawing.Point(140, 197);
            this.lbRecolectado.Name = "lbRecolectado";
            this.lbRecolectado.Size = new System.Drawing.Size(89, 20);
            // 
            // lbTamañoMuestra
            // 
            this.lbTamañoMuestra.BackColor = System.Drawing.Color.Yellow;
            this.lbTamañoMuestra.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lbTamañoMuestra.Location = new System.Drawing.Point(140, 168);
            this.lbTamañoMuestra.Name = "lbTamañoMuestra";
            this.lbTamañoMuestra.Size = new System.Drawing.Size(89, 20);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(93, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.Text = "Empaque con:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnUtilerias
            // 
            this.btnUtilerias.Location = new System.Drawing.Point(5, 11);
            this.btnUtilerias.Name = "btnUtilerias";
            this.btnUtilerias.Size = new System.Drawing.Size(32, 23);
            this.btnUtilerias.TabIndex = 9;
            this.btnUtilerias.Text = "...";
            this.btnUtilerias.Click += new System.EventHandler(this.btnUtilerias_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnUtilerias);
            this.panel1.Controls.Add(this.txtCodigoBarras);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnFinalizar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbClave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbDescripcion);
            this.panel1.Controls.Add(this.lbRecolectado);
            this.panel1.Controls.Add(this.lbMultiploEmpaque);
            this.panel1.Controls.Add(this.lbTamañoMuestra);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 270);
            // 
            // PrincipalInspeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrincipalInspeccion";
            this.Text = "Registro de Inspección";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrincipalInspeccion_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label lbMultiploEmpaque;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRecolectado;
        private System.Windows.Forms.Label lbTamañoMuestra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUtilerias;
        private System.Windows.Forms.Panel panel1;
    }
}

