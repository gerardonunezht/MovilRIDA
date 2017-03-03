namespace Movil_RIDA
{
    partial class Acceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acceso));
            this.lbAplicacion = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lbServidor = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbAplicacion
            // 
            resources.ApplyResources(this.lbAplicacion, "lbAplicacion");
            this.lbAplicacion.ForeColor = System.Drawing.Color.Blue;
            this.lbAplicacion.Name = "lbAplicacion";
            // 
            // lbVersion
            // 
            resources.ApplyResources(this.lbVersion, "lbVersion");
            this.lbVersion.ForeColor = System.Drawing.Color.Blue;
            this.lbVersion.Name = "lbVersion";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(this.txtUsuario, "txtUsuario");
            this.txtUsuario.Name = "txtUsuario";
            // 
            // lbServidor
            // 
            resources.ApplyResources(this.lbServidor, "lbServidor");
            this.lbServidor.ForeColor = System.Drawing.Color.Red;
            this.lbServidor.Name = "lbServidor";
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.Black;
            this.btnIngresar.ForeColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(this.btnIngresar, "btnIngresar");
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Black;
            this.btnSalir.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btnSalir, "btnSalir");
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbAplicacion);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.lbVersion);
            this.panel1.Controls.Add(this.btnIngresar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbServidor);
            this.panel1.Controls.Add(this.txtUsuario);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // Acceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "Acceso";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Acceso_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbAplicacion;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lbServidor;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;


    }
}