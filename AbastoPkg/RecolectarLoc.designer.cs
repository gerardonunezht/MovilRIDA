﻿namespace Movil_RIDA
{
    partial class RecolectarLoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecolectarLoc));
            this.txtLocalizacion = new System.Windows.Forms.TextBox();
            this.lbLocalizacion = new System.Windows.Forms.Label();
            this.lbClave = new System.Windows.Forms.Label();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.tmLocalizacion = new System.Windows.Forms.Timer();
            this.pbInspeccion = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbAviso = new System.Windows.Forms.Label();
            this.lbNoTransferencia = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLocalizacion
            // 
            this.txtLocalizacion.Location = new System.Drawing.Point(17, 196);
            this.txtLocalizacion.Name = "txtLocalizacion";
            this.txtLocalizacion.Size = new System.Drawing.Size(182, 23);
            this.txtLocalizacion.TabIndex = 4;
            this.txtLocalizacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLocalizacion_KeyUp);
            // 
            // lbLocalizacion
            // 
            this.lbLocalizacion.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Regular);
            this.lbLocalizacion.Location = new System.Drawing.Point(17, 151);
            this.lbLocalizacion.Name = "lbLocalizacion";
            this.lbLocalizacion.Size = new System.Drawing.Size(215, 50);
            this.lbLocalizacion.Text = "LOC.";
            this.lbLocalizacion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbClave
            // 
            this.lbClave.BackColor = System.Drawing.Color.Black;
            this.lbClave.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lbClave.ForeColor = System.Drawing.Color.Yellow;
            this.lbClave.Location = new System.Drawing.Point(17, 28);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(215, 20);
            this.lbClave.Text = "CLAVE";
            this.lbClave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbCantidad
            // 
            this.lbCantidad.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.lbCantidad.ForeColor = System.Drawing.Color.Red;
            this.lbCantidad.Location = new System.Drawing.Point(79, 113);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(76, 25);
            this.lbCantidad.Text = "0";
            this.lbCantidad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(22, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 16);
            this.label4.Text = "Cantidad a recolectar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(22, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 20);
            this.label1.Text = "de la localización:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.BackColor = System.Drawing.Color.Yellow;
            this.lbDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbDescripcion.Location = new System.Drawing.Point(17, 52);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(215, 42);
            this.lbDescripcion.Text = "label2";
            // 
            // tmLocalizacion
            // 
            this.tmLocalizacion.Interval = 1000;
            this.tmLocalizacion.Tick += new System.EventHandler(this.tmLocalizacion_Tick);
            // 
            // pbInspeccion
            // 
            this.pbInspeccion.Image = ((System.Drawing.Image)(resources.GetObject("pbInspeccion.Image")));
            this.pbInspeccion.Location = new System.Drawing.Point(200, 196);
            this.pbInspeccion.Name = "pbInspeccion";
            this.pbInspeccion.Size = new System.Drawing.Size(32, 23);
            this.pbInspeccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnFinalizar);
            this.panel1.Controls.Add(this.lbAviso);
            this.panel1.Controls.Add(this.lbNoTransferencia);
            this.panel1.Controls.Add(this.lbClave);
            this.panel1.Controls.Add(this.pbInspeccion);
            this.panel1.Controls.Add(this.txtLocalizacion);
            this.panel1.Controls.Add(this.lbLocalizacion);
            this.panel1.Controls.Add(this.lbDescripcion);
            this.panel1.Controls.Add(this.lbCantidad);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 295);
            // 
            // lbAviso
            // 
            this.lbAviso.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbAviso.ForeColor = System.Drawing.Color.Red;
            this.lbAviso.Location = new System.Drawing.Point(17, 222);
            this.lbAviso.Name = "lbAviso";
            this.lbAviso.Size = new System.Drawing.Size(215, 50);
            this.lbAviso.Text = "Aviso";
            this.lbAviso.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbNoTransferencia
            // 
            this.lbNoTransferencia.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbNoTransferencia.Location = new System.Drawing.Point(17, 4);
            this.lbNoTransferencia.Name = "lbNoTransferencia";
            this.lbNoTransferencia.Size = new System.Drawing.Size(215, 20);
            this.lbNoTransferencia.Text = "Trns:";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.Red;
            this.btnFinalizar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnFinalizar.ForeColor = System.Drawing.Color.White;
            this.btnFinalizar.Location = new System.Drawing.Point(17, 268);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(215, 24);
            this.btnFinalizar.TabIndex = 10;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // RecolectarLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecolectarLoc";
            this.Text = "Confirmar Localización";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRecolectarLoc_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLocalizacion;
        private System.Windows.Forms.Label lbLocalizacion;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.Label lbCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Timer tmLocalizacion;
        private System.Windows.Forms.PictureBox pbInspeccion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbNoTransferencia;
        private System.Windows.Forms.Label lbAviso;
        private System.Windows.Forms.Button btnFinalizar;
    }
}