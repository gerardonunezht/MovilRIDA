namespace Movil_RIDA
{
    partial class PrincipalConteos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.dgProgramados = new System.Windows.Forms.DataGrid();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 19);
            this.label1.Text = "Seleccione el producto a contar:";
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbDescripcion.ForeColor = System.Drawing.Color.Blue;
            this.lbDescripcion.Location = new System.Drawing.Point(14, 170);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(215, 27);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.Black;
            this.btnIniciar.ForeColor = System.Drawing.Color.Yellow;
            this.btnIniciar.Location = new System.Drawing.Point(14, 204);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(215, 30);
            this.btnIniciar.TabIndex = 22;
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // dgProgramados
            // 
            this.dgProgramados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgProgramados.Location = new System.Drawing.Point(14, 31);
            this.dgProgramados.Name = "dgProgramados";
            this.dgProgramados.Size = new System.Drawing.Size(215, 125);
            this.dgProgramados.TabIndex = 24;
            this.dgProgramados.CurrentCellChanged += new System.EventHandler(this.dgProgramados_CurrentCellChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Black;
            this.btnSalir.ForeColor = System.Drawing.Color.Red;
            this.btnSalir.Location = new System.Drawing.Point(14, 240);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(215, 30);
            this.btnSalir.TabIndex = 23;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // PrincipalConteos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDescripcion);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.dgProgramados);
            this.Controls.Add(this.btnSalir);
            this.Name = "PrincipalConteos";
            this.Text = "PrincipalConteos";
            this.Load += new System.EventHandler(this.PrincipalConteos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.DataGrid dgProgramados;
        private System.Windows.Forms.Button btnSalir;
    }
}