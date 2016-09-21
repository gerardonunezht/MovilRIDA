namespace Movil_RIDA
{
    partial class PrincipalRecepcion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalRecepcion));
            this.lbOrdenCompra = new System.Windows.Forms.Label();
            this.lbProveedor = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtOrdenCompra = new System.Windows.Forms.TextBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtReferenciaFactura = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbOrdenCompra
            // 
            resources.ApplyResources(this.lbOrdenCompra, "lbOrdenCompra");
            this.lbOrdenCompra.Name = "lbOrdenCompra";
            // 
            // lbProveedor
            // 
            resources.ApplyResources(this.lbProveedor, "lbProveedor");
            this.lbProveedor.Name = "lbProveedor";
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.Black;
            this.btnIniciar.ForeColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(this.btnIniciar, "btnIniciar");
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtOrdenCompra
            // 
            this.txtOrdenCompra.BackColor = System.Drawing.Color.Yellow;
            this.txtOrdenCompra.ForeColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.txtOrdenCompra, "txtOrdenCompra");
            this.txtOrdenCompra.Name = "txtOrdenCompra";
            this.txtOrdenCompra.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOrdenCompra_KeyUp);
            // 
            // txtProveedor
            // 
            this.txtProveedor.BackColor = System.Drawing.Color.White;
            this.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtProveedor, "txtProveedor");
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Black;
            this.btnSalir.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btnSalir, "btnSalir");
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtReferenciaFactura
            // 
            this.txtReferenciaFactura.BackColor = System.Drawing.Color.Yellow;
            this.txtReferenciaFactura.ForeColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.txtReferenciaFactura, "txtReferenciaFactura");
            this.txtReferenciaFactura.Name = "txtReferenciaFactura";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.lbOrdenCompra);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbProveedor);
            this.panel1.Controls.Add(this.txtReferenciaFactura);
            this.panel1.Controls.Add(this.btnIniciar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.txtOrdenCompra);
            this.panel1.Controls.Add(this.txtProveedor);
            this.panel1.Name = "panel1";
            // 
            // PrincipalRecepcion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrincipalRecepcion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbOrdenCompra;
        private System.Windows.Forms.Label lbProveedor;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox txtOrdenCompra;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtReferenciaFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}

