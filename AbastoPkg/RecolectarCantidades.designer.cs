namespace Movil_RIDA
{
    partial class RecolectarCantidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecolectarCantidades));
            this.lbCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lbMultiplo = new System.Windows.Forms.Label();
            this.txtMultiplo = new System.Windows.Forms.TextBox();
            this.txtCB = new System.Windows.Forms.TextBox();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.lbClave = new System.Windows.Forms.Label();
            this.lbPorRecolectar = new System.Windows.Forms.Label();
            this.lbRecolectado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMultAbasto = new System.Windows.Forms.Label();
            this.lbLocalizacion = new System.Windows.Forms.Label();
            this.lbTotEmp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTrnf = new System.Windows.Forms.Label();
            this.tmRegistrarCanidades = new System.Windows.Forms.Timer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTruncar = new System.Windows.Forms.Button();
            this.btnCero = new System.Windows.Forms.Button();
            this.pbInspeccion = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCantidad
            // 
            this.lbCantidad.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbCantidad.Location = new System.Drawing.Point(51, 138);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(87, 20);
            this.lbCantidad.Text = "Cantidad";
            this.lbCantidad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(151, 134);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(76, 23);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyUp);
            // 
            // lbMultiplo
            // 
            this.lbMultiplo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbMultiplo.Location = new System.Drawing.Point(51, 167);
            this.lbMultiplo.Name = "lbMultiplo";
            this.lbMultiplo.Size = new System.Drawing.Size(86, 20);
            this.lbMultiplo.Text = "de";
            this.lbMultiplo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMultiplo
            // 
            this.txtMultiplo.BackColor = System.Drawing.Color.Yellow;
            this.txtMultiplo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMultiplo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtMultiplo.ForeColor = System.Drawing.Color.Red;
            this.txtMultiplo.Location = new System.Drawing.Point(151, 161);
            this.txtMultiplo.Name = "txtMultiplo";
            this.txtMultiplo.ReadOnly = true;
            this.txtMultiplo.Size = new System.Drawing.Size(76, 26);
            this.txtMultiplo.TabIndex = 1;
            // 
            // txtCB
            // 
            this.txtCB.Location = new System.Drawing.Point(52, 108);
            this.txtCB.Name = "txtCB";
            this.txtCB.Size = new System.Drawing.Size(176, 23);
            this.txtCB.TabIndex = 0;
            this.txtCB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCB_KeyUp);
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.BackColor = System.Drawing.Color.Yellow;
            this.lbDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbDescripcion.Location = new System.Drawing.Point(9, 44);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(220, 37);
            this.lbDescripcion.Text = "DESCR";
            // 
            // lbClave
            // 
            this.lbClave.BackColor = System.Drawing.Color.Black;
            this.lbClave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbClave.ForeColor = System.Drawing.Color.Yellow;
            this.lbClave.Location = new System.Drawing.Point(9, 22);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(220, 20);
            this.lbClave.Text = "CLAVE";
            // 
            // lbPorRecolectar
            // 
            this.lbPorRecolectar.BackColor = System.Drawing.Color.Yellow;
            this.lbPorRecolectar.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lbPorRecolectar.Location = new System.Drawing.Point(151, 216);
            this.lbPorRecolectar.Name = "lbPorRecolectar";
            this.lbPorRecolectar.Size = new System.Drawing.Size(77, 20);
            // 
            // lbRecolectado
            // 
            this.lbRecolectado.BackColor = System.Drawing.Color.Lime;
            this.lbRecolectado.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lbRecolectado.Location = new System.Drawing.Point(151, 241);
            this.lbRecolectado.Name = "lbRecolectado";
            this.lbRecolectado.Size = new System.Drawing.Size(78, 20);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(38, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Por Recolectar:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(38, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Recolectado:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbMultAbasto
            // 
            this.lbMultAbasto.BackColor = System.Drawing.Color.Yellow;
            this.lbMultAbasto.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbMultAbasto.Location = new System.Drawing.Point(151, 194);
            this.lbMultAbasto.Name = "lbMultAbasto";
            this.lbMultAbasto.Size = new System.Drawing.Size(76, 20);
            this.lbMultAbasto.Text = "Multiplo Abasto";
            this.lbMultAbasto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbMultAbasto.Visible = false;
            // 
            // lbLocalizacion
            // 
            this.lbLocalizacion.BackColor = System.Drawing.Color.Yellow;
            this.lbLocalizacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbLocalizacion.ForeColor = System.Drawing.Color.Blue;
            this.lbLocalizacion.Location = new System.Drawing.Point(9, 85);
            this.lbLocalizacion.Name = "lbLocalizacion";
            this.lbLocalizacion.Size = new System.Drawing.Size(218, 20);
            this.lbLocalizacion.Text = "Localizacion";
            // 
            // lbTotEmp
            // 
            this.lbTotEmp.BackColor = System.Drawing.Color.Yellow;
            this.lbTotEmp.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lbTotEmp.ForeColor = System.Drawing.Color.Red;
            this.lbTotEmp.Location = new System.Drawing.Point(12, 176);
            this.lbTotEmp.Name = "lbTotEmp";
            this.lbTotEmp.Size = new System.Drawing.Size(45, 20);
            this.lbTotEmp.Text = "Empaques";
            this.lbTotEmp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbTotEmp.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(14, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 15);
            this.label5.Text = "codigo";
            this.label5.Visible = false;
            // 
            // lbTrnf
            // 
            this.lbTrnf.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbTrnf.Location = new System.Drawing.Point(12, 5);
            this.lbTrnf.Name = "lbTrnf";
            this.lbTrnf.Size = new System.Drawing.Size(217, 15);
            this.lbTrnf.Text = "ID:";
            // 
            // tmRegistrarCanidades
            // 
            this.tmRegistrarCanidades.Interval = 1000;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnTruncar);
            this.panel1.Controls.Add(this.btnCero);
            this.panel1.Controls.Add(this.pbInspeccion);
            this.panel1.Controls.Add(this.lbClave);
            this.panel1.Controls.Add(this.txtMultiplo);
            this.panel1.Controls.Add(this.txtCB);
            this.panel1.Controls.Add(this.lbDescripcion);
            this.panel1.Controls.Add(this.lbTrnf);
            this.panel1.Controls.Add(this.lbMultiplo);
            this.panel1.Controls.Add(this.lbPorRecolectar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbCantidad);
            this.panel1.Controls.Add(this.lbTotEmp);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.lbRecolectado);
            this.panel1.Controls.Add(this.lbLocalizacion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbMultAbasto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 295);
            // 
            // btnTruncar
            // 
            this.btnTruncar.BackColor = System.Drawing.Color.Red;
            this.btnTruncar.ForeColor = System.Drawing.Color.White;
            this.btnTruncar.Location = new System.Drawing.Point(9, 264);
            this.btnTruncar.Name = "btnTruncar";
            this.btnTruncar.Size = new System.Drawing.Size(100, 25);
            this.btnTruncar.TabIndex = 76;
            this.btnTruncar.Text = "Truncar";
            this.btnTruncar.Click += new System.EventHandler(this.btnTruncar_Click);
            // 
            // btnCero
            // 
            this.btnCero.BackColor = System.Drawing.Color.Red;
            this.btnCero.ForeColor = System.Drawing.Color.White;
            this.btnCero.Location = new System.Drawing.Point(129, 264);
            this.btnCero.Name = "btnCero";
            this.btnCero.Size = new System.Drawing.Size(100, 25);
            this.btnCero.TabIndex = 75;
            this.btnCero.Text = "Cero";
            this.btnCero.Click += new System.EventHandler(this.btnCero_Click);
            // 
            // pbInspeccion
            // 
            this.pbInspeccion.Image = ((System.Drawing.Image)(resources.GetObject("pbInspeccion.Image")));
            this.pbInspeccion.Location = new System.Drawing.Point(14, 108);
            this.pbInspeccion.Name = "pbInspeccion";
            this.pbInspeccion.Size = new System.Drawing.Size(32, 23);
            this.pbInspeccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // RecolectarCantidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecolectarCantidades";
            this.Text = "Registrar Cantidades";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRecolectarCantidades_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCB;
        private System.Windows.Forms.TextBox txtMultiplo;
        private System.Windows.Forms.Label lbCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lbMultiplo;
        private System.Windows.Forms.Label lbRecolectado;
        private System.Windows.Forms.Label lbPorRecolectar;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMultAbasto;
        private System.Windows.Forms.Label lbLocalizacion;
        private System.Windows.Forms.Label lbTotEmp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTrnf;
        private System.Windows.Forms.Timer tmRegistrarCanidades;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbInspeccion;
        private System.Windows.Forms.Button btnCero;
        private System.Windows.Forms.Button btnTruncar;

    }
}