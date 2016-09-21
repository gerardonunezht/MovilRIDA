namespace Movil_RIDA
{
    partial class Utilerias
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
            this.txtValor = new System.Windows.Forms.TextBox();
            this.dgDatos = new System.Windows.Forms.DataGrid();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.lbClave = new System.Windows.Forms.Label();
            this.lbNivel = new System.Windows.Forms.Label();
            this.lbMultiplo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.Yellow;
            this.txtValor.Location = new System.Drawing.Point(7, 5);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(210, 23);
            this.txtValor.TabIndex = 0;
            this.txtValor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValor_KeyUp);
            // 
            // dgDatos
            // 
            this.dgDatos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgDatos.Location = new System.Drawing.Point(7, 34);
            this.dgDatos.Name = "dgDatos";
            this.dgDatos.Size = new System.Drawing.Size(210, 80);
            this.dgDatos.TabIndex = 1;
            this.dgDatos.CurrentCellChanged += new System.EventHandler(this.dgDatos_CurrentCellChanged);
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.BackColor = System.Drawing.Color.Yellow;
            this.lbDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbDescripcion.ForeColor = System.Drawing.Color.Black;
            this.lbDescripcion.Location = new System.Drawing.Point(7, 165);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(210, 32);
            this.lbDescripcion.Text = "DESCRIPCION";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Black;
            this.btnCerrar.ForeColor = System.Drawing.Color.Red;
            this.btnCerrar.Location = new System.Drawing.Point(7, 223);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(210, 30);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lbCodigo
            // 
            this.lbCodigo.BackColor = System.Drawing.Color.Yellow;
            this.lbCodigo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbCodigo.Location = new System.Drawing.Point(7, 141);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(210, 20);
            this.lbCodigo.Text = "CODIGO BARRAS";
            // 
            // lbClave
            // 
            this.lbClave.BackColor = System.Drawing.Color.Yellow;
            this.lbClave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbClave.ForeColor = System.Drawing.Color.Blue;
            this.lbClave.Location = new System.Drawing.Point(7, 118);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(210, 20);
            this.lbClave.Text = "CLAVE";
            // 
            // lbNivel
            // 
            this.lbNivel.BackColor = System.Drawing.Color.Yellow;
            this.lbNivel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbNivel.Location = new System.Drawing.Point(7, 201);
            this.lbNivel.Name = "lbNivel";
            this.lbNivel.Size = new System.Drawing.Size(94, 20);
            this.lbNivel.Text = "Nivel:";
            // 
            // lbMultiplo
            // 
            this.lbMultiplo.BackColor = System.Drawing.Color.Yellow;
            this.lbMultiplo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbMultiplo.Location = new System.Drawing.Point(124, 201);
            this.lbMultiplo.Name = "lbMultiplo";
            this.lbMultiplo.Size = new System.Drawing.Size(93, 20);
            this.lbMultiplo.Text = "Mult:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.txtValor);
            this.panel1.Controls.Add(this.lbMultiplo);
            this.panel1.Controls.Add(this.dgDatos);
            this.panel1.Controls.Add(this.lbNivel);
            this.panel1.Controls.Add(this.lbDescripcion);
            this.panel1.Controls.Add(this.lbClave);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.lbCodigo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 255);
            // 
            // Utilerias
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Utilerias";
            this.Text = "Utilerias";
            this.Load += new System.EventHandler(this.Utilerias_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.DataGrid dgDatos;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.Label lbNivel;
        private System.Windows.Forms.Label lbMultiplo;
        private System.Windows.Forms.Panel panel1;

    }
}