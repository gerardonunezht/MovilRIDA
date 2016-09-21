namespace Movil_RIDA
{
    partial class ConfirmarLocalizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmarLocalizacion));
            this.pbInspeccion = new System.Windows.Forms.PictureBox();
            this.btnExcepcion = new System.Windows.Forms.Button();
            this.lstLocalizaciones = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocalizacion = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbInspeccion
            // 
            this.pbInspeccion.Image = ((System.Drawing.Image)(resources.GetObject("pbInspeccion.Image")));
            this.pbInspeccion.Location = new System.Drawing.Point(17, 205);
            this.pbInspeccion.Name = "pbInspeccion";
            this.pbInspeccion.Size = new System.Drawing.Size(32, 23);
            this.pbInspeccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // btnExcepcion
            // 
            this.btnExcepcion.BackColor = System.Drawing.Color.Black;
            this.btnExcepcion.ForeColor = System.Drawing.Color.Red;
            this.btnExcepcion.Location = new System.Drawing.Point(17, 235);
            this.btnExcepcion.Name = "btnExcepcion";
            this.btnExcepcion.Size = new System.Drawing.Size(215, 30);
            this.btnExcepcion.TabIndex = 2;
            this.btnExcepcion.Text = "EXCEPCION";
            this.btnExcepcion.Click += new System.EventHandler(this.btnExcepcion_Click);
            // 
            // lstLocalizaciones
            // 
            this.lstLocalizaciones.Location = new System.Drawing.Point(17, 66);
            this.lstLocalizaciones.Name = "lstLocalizaciones";
            this.lstLocalizaciones.Size = new System.Drawing.Size(215, 130);
            this.lstLocalizaciones.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 20);
            this.label1.Text = "CLAVE";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 20);
            this.label2.Text = "DESCRIPCION";
            // 
            // txtLocalizacion
            // 
            this.txtLocalizacion.Location = new System.Drawing.Point(56, 205);
            this.txtLocalizacion.Name = "txtLocalizacion";
            this.txtLocalizacion.Size = new System.Drawing.Size(176, 23);
            this.txtLocalizacion.TabIndex = 1;
            this.txtLocalizacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLocalizacion_KeyUp);
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.txtLocalizacion);
            this.panel.Controls.Add(this.pbInspeccion);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.btnExcepcion);
            this.panel.Controls.Add(this.lstLocalizaciones);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(245, 295);
            // 
            // ConfirmarLocalizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.panel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmarLocalizacion";
            this.Text = "Confirmar Localizacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ConfirmarLocalizacion_Load);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbInspeccion;
        private System.Windows.Forms.Button btnExcepcion;
        private System.Windows.Forms.ListBox lstLocalizaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocalizacion;
        private System.Windows.Forms.Panel panel;
    }
}