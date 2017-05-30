namespace Movil_RIDA
{
    partial class PrincipalRecepcionPlanta
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
            this.lblComentario = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.lblRefNbr = new System.Windows.Forms.Label();
            this.lblRecibe = new System.Windows.Forms.Label();
            this.lblEnvia = new System.Windows.Forms.Label();
            this.lblToSiteId = new System.Windows.Forms.Label();
            this.lblSiteId = new System.Windows.Forms.Label();
            this.lblTrnsfrDocNbr = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtTrnsfrDocNbr = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblComentario
            // 
            this.lblComentario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblComentario.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblComentario.Location = new System.Drawing.Point(3, 181);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(215, 20);
            this.lblComentario.Text = "Comentario";
            this.lblComentario.Visible = false;
            // 
            // lblComment
            // 
            this.lblComment.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblComment.Location = new System.Drawing.Point(2, 162);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(215, 20);
            this.lblComment.Text = "Comentario:";
            this.lblComment.Visible = false;
            // 
            // lblReferencia
            // 
            this.lblReferencia.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblReferencia.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblReferencia.Location = new System.Drawing.Point(3, 142);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(215, 20);
            this.lblReferencia.Text = "Referencia";
            this.lblReferencia.Visible = false;
            // 
            // lblRefNbr
            // 
            this.lblRefNbr.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblRefNbr.Location = new System.Drawing.Point(2, 123);
            this.lblRefNbr.Name = "lblRefNbr";
            this.lblRefNbr.Size = new System.Drawing.Size(215, 20);
            this.lblRefNbr.Text = "Referencia:";
            this.lblRefNbr.Visible = false;
            // 
            // lblRecibe
            // 
            this.lblRecibe.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecibe.ForeColor = System.Drawing.Color.Red;
            this.lblRecibe.Location = new System.Drawing.Point(3, 105);
            this.lblRecibe.Name = "lblRecibe";
            this.lblRecibe.Size = new System.Drawing.Size(215, 20);
            this.lblRecibe.Text = "Recibe";
            this.lblRecibe.Visible = false;
            // 
            // lblEnvia
            // 
            this.lblEnvia.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblEnvia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblEnvia.Location = new System.Drawing.Point(3, 69);
            this.lblEnvia.Name = "lblEnvia";
            this.lblEnvia.Size = new System.Drawing.Size(215, 22);
            this.lblEnvia.Text = "Envía";
            this.lblEnvia.Visible = false;
            // 
            // lblToSiteId
            // 
            this.lblToSiteId.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblToSiteId.Location = new System.Drawing.Point(3, 89);
            this.lblToSiteId.Name = "lblToSiteId";
            this.lblToSiteId.Size = new System.Drawing.Size(215, 20);
            this.lblToSiteId.Text = "Almacén que recibe:";
            this.lblToSiteId.Visible = false;
            // 
            // lblSiteId
            // 
            this.lblSiteId.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblSiteId.Location = new System.Drawing.Point(3, 51);
            this.lblSiteId.Name = "lblSiteId";
            this.lblSiteId.Size = new System.Drawing.Size(215, 18);
            this.lblSiteId.Text = "Almacén que envía:";
            this.lblSiteId.Visible = false;
            // 
            // lblTrnsfrDocNbr
            // 
            this.lblTrnsfrDocNbr.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTrnsfrDocNbr.Location = new System.Drawing.Point(3, 3);
            this.lblTrnsfrDocNbr.Name = "lblTrnsfrDocNbr";
            this.lblTrnsfrDocNbr.Size = new System.Drawing.Size(214, 19);
            this.lblTrnsfrDocNbr.Text = "Número de Ref: ";
            this.lblTrnsfrDocNbr.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.Black;
            this.btnIniciar.Enabled = false;
            this.btnIniciar.ForeColor = System.Drawing.Color.Yellow;
            this.btnIniciar.Location = new System.Drawing.Point(3, 204);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(215, 29);
            this.btnIniciar.TabIndex = 12;
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Black;
            this.btnSalir.ForeColor = System.Drawing.Color.Red;
            this.btnSalir.Location = new System.Drawing.Point(2, 239);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(215, 29);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtTrnsfrDocNbr
            // 
            this.txtTrnsfrDocNbr.BackColor = System.Drawing.Color.Yellow;
            this.txtTrnsfrDocNbr.Enabled = false;
            this.txtTrnsfrDocNbr.ForeColor = System.Drawing.Color.Blue;
            this.txtTrnsfrDocNbr.Location = new System.Drawing.Point(3, 26);
            this.txtTrnsfrDocNbr.MaxLength = 15;
            this.txtTrnsfrDocNbr.Name = "txtTrnsfrDocNbr";
            this.txtTrnsfrDocNbr.Size = new System.Drawing.Size(214, 23);
            this.txtTrnsfrDocNbr.TabIndex = 9;
            this.txtTrnsfrDocNbr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTrnsfrDocNbr_KeyUp);
            // 
            // PrincipalRecepcionPlanta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblReferencia);
            this.Controls.Add(this.lblRefNbr);
            this.Controls.Add(this.lblRecibe);
            this.Controls.Add(this.lblEnvia);
            this.Controls.Add(this.lblToSiteId);
            this.Controls.Add(this.lblSiteId);
            this.Controls.Add(this.lblTrnsfrDocNbr);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtTrnsfrDocNbr);
            this.Name = "PrincipalRecepcionPlanta";
            this.Text = "PrincipalRecepcionPlanta";
            this.Load += new System.EventHandler(this.PrincipalRecepcionPlanta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.Label lblRefNbr;
        private System.Windows.Forms.Label lblRecibe;
        private System.Windows.Forms.Label lblEnvia;
        private System.Windows.Forms.Label lblToSiteId;
        private System.Windows.Forms.Label lblSiteId;
        private System.Windows.Forms.Label lblTrnsfrDocNbr;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtTrnsfrDocNbr;
    }
}