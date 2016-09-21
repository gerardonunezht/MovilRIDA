namespace Movil_RIDA
{
    partial class PrincipalAbastoPkg
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
            this.btnRecolectar = new System.Windows.Forms.Button();
            this.btnAbastecer = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lbClavesDelSemaforo = new System.Windows.Forms.Label();
            this.lbClavesEnRojo = new System.Windows.Forms.Label();
            this.lbClavesEnAmarillo = new System.Windows.Forms.Label();
            this.lbClavesEnVerde = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRecolectar
            // 
            this.btnRecolectar.BackColor = System.Drawing.Color.Black;
            this.btnRecolectar.ForeColor = System.Drawing.Color.Yellow;
            this.btnRecolectar.Location = new System.Drawing.Point(26, 187);
            this.btnRecolectar.Name = "btnRecolectar";
            this.btnRecolectar.Size = new System.Drawing.Size(163, 31);
            this.btnRecolectar.TabIndex = 0;
            this.btnRecolectar.Text = "MOSTRAR CLAVES";
            this.btnRecolectar.Click += new System.EventHandler(this.btnRecolectar_Click);
            // 
            // btnAbastecer
            // 
            this.btnAbastecer.BackColor = System.Drawing.Color.Black;
            this.btnAbastecer.ForeColor = System.Drawing.Color.Yellow;
            this.btnAbastecer.Location = new System.Drawing.Point(26, 223);
            this.btnAbastecer.Name = "btnAbastecer";
            this.btnAbastecer.Size = new System.Drawing.Size(163, 25);
            this.btnAbastecer.TabIndex = 1;
            this.btnAbastecer.Text = "REABASTO INCOMPLETO";
            this.btnAbastecer.Click += new System.EventHandler(this.btnAbastecer_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Black;
            this.btnSalir.ForeColor = System.Drawing.Color.Yellow;
            this.btnSalir.Location = new System.Drawing.Point(26, 264);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(163, 25);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lbClavesDelSemaforo
            // 
            this.lbClavesDelSemaforo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbClavesDelSemaforo.Location = new System.Drawing.Point(7, 9);
            this.lbClavesDelSemaforo.Name = "lbClavesDelSemaforo";
            this.lbClavesDelSemaforo.Size = new System.Drawing.Size(235, 50);
            this.lbClavesDelSemaforo.Text = "label2";
            this.lbClavesDelSemaforo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbClavesEnRojo
            // 
            this.lbClavesEnRojo.BackColor = System.Drawing.Color.Red;
            this.lbClavesEnRojo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lbClavesEnRojo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbClavesEnRojo.Location = new System.Drawing.Point(27, 65);
            this.lbClavesEnRojo.Name = "lbClavesEnRojo";
            this.lbClavesEnRojo.Size = new System.Drawing.Size(160, 30);
            this.lbClavesEnRojo.Text = "label2";
            this.lbClavesEnRojo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbClavesEnAmarillo
            // 
            this.lbClavesEnAmarillo.BackColor = System.Drawing.Color.Yellow;
            this.lbClavesEnAmarillo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lbClavesEnAmarillo.ForeColor = System.Drawing.Color.Black;
            this.lbClavesEnAmarillo.Location = new System.Drawing.Point(27, 106);
            this.lbClavesEnAmarillo.Name = "lbClavesEnAmarillo";
            this.lbClavesEnAmarillo.Size = new System.Drawing.Size(160, 30);
            this.lbClavesEnAmarillo.Text = "label3";
            this.lbClavesEnAmarillo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbClavesEnVerde
            // 
            this.lbClavesEnVerde.BackColor = System.Drawing.Color.LimeGreen;
            this.lbClavesEnVerde.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lbClavesEnVerde.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbClavesEnVerde.Location = new System.Drawing.Point(27, 151);
            this.lbClavesEnVerde.Name = "lbClavesEnVerde";
            this.lbClavesEnVerde.Size = new System.Drawing.Size(160, 30);
            this.lbClavesEnVerde.Text = "label1";
            this.lbClavesEnVerde.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.lbClavesEnVerde);
            this.panel1.Controls.Add(this.btnRecolectar);
            this.panel1.Controls.Add(this.lbClavesEnAmarillo);
            this.panel1.Controls.Add(this.btnAbastecer);
            this.panel1.Controls.Add(this.lbClavesEnRojo);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.lbClavesDelSemaforo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 295);
            // 
            // PrincipalAbastoPkg
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
            this.Name = "PrincipalAbastoPkg";
            this.Text = "Proceso de Abasto de Picking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRecolectar;
        private System.Windows.Forms.Button btnAbastecer;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lbClavesDelSemaforo;
        private System.Windows.Forms.Label lbClavesEnRojo;
        private System.Windows.Forms.Label lbClavesEnAmarillo;
        private System.Windows.Forms.Label lbClavesEnVerde;
        private System.Windows.Forms.Panel panel1;
    }
}

