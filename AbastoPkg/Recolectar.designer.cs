namespace Movil_RIDA
{
    partial class Recolectar
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
            this.btnLocalizaciones = new System.Windows.Forms.Button();
            this.lbCantRecolectar = new System.Windows.Forms.Label();
            this.lbClave = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.lbSemaforo = new System.Windows.Forms.Label();
            this.lbLockPkg = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lbBuffer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbNivelBuffer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNoTransferencia
            // 
            this.lbNoTransferencia.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbNoTransferencia.Location = new System.Drawing.Point(14, 8);
            this.lbNoTransferencia.Name = "lbNoTransferencia";
            this.lbNoTransferencia.Size = new System.Drawing.Size(220, 20);
            this.lbNoTransferencia.Text = "Trns:";
            // 
            // btnLocalizaciones
            // 
            this.btnLocalizaciones.BackColor = System.Drawing.Color.Black;
            this.btnLocalizaciones.ForeColor = System.Drawing.Color.Yellow;
            this.btnLocalizaciones.Location = new System.Drawing.Point(14, 211);
            this.btnLocalizaciones.Name = "btnLocalizaciones";
            this.btnLocalizaciones.Size = new System.Drawing.Size(220, 30);
            this.btnLocalizaciones.TabIndex = 5;
            this.btnLocalizaciones.Text = "Recolectar";
            this.btnLocalizaciones.Click += new System.EventHandler(this.btnLocalizaciones_Click);
            // 
            // lbCantRecolectar
            // 
            this.lbCantRecolectar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbCantRecolectar.Location = new System.Drawing.Point(14, 183);
            this.lbCantRecolectar.Name = "lbCantRecolectar";
            this.lbCantRecolectar.Size = new System.Drawing.Size(124, 20);
            this.lbCantRecolectar.Text = "Nivel Buffer:";
            this.lbCantRecolectar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbClave
            // 
            this.lbClave.BackColor = System.Drawing.Color.Black;
            this.lbClave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbClave.ForeColor = System.Drawing.Color.Yellow;
            this.lbClave.Location = new System.Drawing.Point(14, 32);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(220, 20);
            this.lbClave.Text = "CLAVE";
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.BackColor = System.Drawing.Color.Yellow;
            this.lbDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbDescripcion.ForeColor = System.Drawing.Color.Black;
            this.lbDescripcion.Location = new System.Drawing.Point(14, 85);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(220, 40);
            this.lbDescripcion.Text = "DESCRIPCION";
            // 
            // lbSemaforo
            // 
            this.lbSemaforo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lbSemaforo.Location = new System.Drawing.Point(14, 131);
            this.lbSemaforo.Name = "lbSemaforo";
            this.lbSemaforo.Size = new System.Drawing.Size(220, 20);
            this.lbSemaforo.Text = "SEMAFORO";
            this.lbSemaforo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbLockPkg
            // 
            this.lbLockPkg.BackColor = System.Drawing.Color.Yellow;
            this.lbLockPkg.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbLockPkg.ForeColor = System.Drawing.Color.Red;
            this.lbLockPkg.Location = new System.Drawing.Point(14, 58);
            this.lbLockPkg.Name = "lbLockPkg";
            this.lbLockPkg.Size = new System.Drawing.Size(220, 20);
            this.lbLockPkg.Text = "LocPkg";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.Yellow;
            this.btnSiguiente.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSiguiente.Location = new System.Drawing.Point(14, 244);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(220, 30);
            this.btnSiguiente.TabIndex = 14;
            this.btnSiguiente.Text = "Omitir esta clave";
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lbBuffer
            // 
            this.lbBuffer.BackColor = System.Drawing.Color.Black;
            this.lbBuffer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbBuffer.ForeColor = System.Drawing.Color.Blue;
            this.lbBuffer.Location = new System.Drawing.Point(144, 157);
            this.lbBuffer.Name = "lbBuffer";
            this.lbBuffer.Size = new System.Drawing.Size(90, 20);
            this.lbBuffer.Text = "0";
            this.lbBuffer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(38, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Buffer:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbNivelBuffer
            // 
            this.lbNivelBuffer.BackColor = System.Drawing.Color.Black;
            this.lbNivelBuffer.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lbNivelBuffer.ForeColor = System.Drawing.Color.Red;
            this.lbNivelBuffer.Location = new System.Drawing.Point(144, 183);
            this.lbNivelBuffer.Name = "lbNivelBuffer";
            this.lbNivelBuffer.Size = new System.Drawing.Size(90, 20);
            this.lbNivelBuffer.Text = "0";
            this.lbNivelBuffer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.lbNoTransferencia);
            this.panel1.Controls.Add(this.lbNivelBuffer);
            this.panel1.Controls.Add(this.btnLocalizaciones);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbCantRecolectar);
            this.panel1.Controls.Add(this.lbBuffer);
            this.panel1.Controls.Add(this.lbClave);
            this.panel1.Controls.Add(this.lbDescripcion);
            this.panel1.Controls.Add(this.btnSiguiente);
            this.panel1.Controls.Add(this.lbSemaforo);
            this.panel1.Controls.Add(this.lbLockPkg);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 295);
            // 
            // Recolectar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Recolectar";
            this.Text = "Recolectar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRecolectar_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNoTransferencia;
        private System.Windows.Forms.Button btnLocalizaciones;
        private System.Windows.Forms.Label lbCantRecolectar;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Label lbSemaforo;
        private System.Windows.Forms.Label lbLockPkg;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lbBuffer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbNivelBuffer;
        private System.Windows.Forms.Panel panel1;
    }
}