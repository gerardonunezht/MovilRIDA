using System;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class PrincipalRecepcionPlanta : Form
    {
        RecepcionPlanta recepcion = new RecepcionPlanta();

        public PrincipalRecepcionPlanta()
        {
            InitializeComponent();
        }

        #region Métodos

        private void LimpiarObjetos()
        {
            btnIniciar.Enabled = false;
            txtTrnsfrDocNbr.Text = "";
            txtTrnsfrDocNbr.Focus();

            lblEnvia.Visible = false;
            lblRecibe.Visible = false;
            lblReferencia.Visible = false;
            lblComentario.Visible = false;

            lblSiteId.Visible = false;
            lblToSiteId.Visible = false;
            lblRefNbr.Visible = false;
            lblComment.Visible = false;
            txtTrnsfrDocNbr.Enabled = true;

        }

        private void txtTrnsfrDocNbr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RecepcionPlanta.TrnsfrDocNbr = txtTrnsfrDocNbr.Text.Trim();
                BuscarTransferencia();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Global.LogOut(Global.Usuario);
            //Application.Exit();
            this.Close();
        }

        private void BuscarTransferencia()
        {
            DataRow dr;

            dr = recepcion.ObtenerDatosTransferencia(RecepcionPlanta.TrnsfrDocNbr);

            if (dr != null)
            {
                RecepcionPlanta.BatNbr = dr["BatNbr"].ToString().Trim();
                RecepcionPlanta.SiteID = dr["SiteID"].ToString().Trim();
                RecepcionPlanta.ToSiteID = dr["ToSiteID"].ToString().Trim();
                RecepcionPlanta.RefNbr = dr["RefNbr"].ToString().Trim();
                RecepcionPlanta.Comment = dr["Comment"].ToString().Trim();

                lblEnvia.Text = RecepcionPlanta.SiteID;
                lblRecibe.Text = RecepcionPlanta.ToSiteID;
                lblReferencia.Text = RecepcionPlanta.RefNbr;
                lblComentario.Text = RecepcionPlanta.Comment;

                lblEnvia.Visible = true;
                lblRecibe.Visible = true;
                lblReferencia.Visible = true;
                lblComentario.Visible = true;

                lblSiteId.Visible = true;
                lblToSiteId.Visible = true;
                lblRefNbr.Visible = true;
                lblComment.Visible = true;

                btnIniciar.Enabled = true;
                btnIniciar.Focus();
            }
            else
            {
                MessageBox.Show("La transferencia ingresada NO EXISTE o ya esta marcada como RECIBIDA, favor de verificar con el supervisor administrativo.", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                LimpiarObjetos();
            }
        }

        private void PrincipalRecepcionPlanta_Load(object sender, EventArgs e)
        {
            LimpiarObjetos();
            if (recepcion.ContinuarRecepcionPartidaPlanta(Global.Usuario))
            {
                MessageBox.Show("Su usuario tiene pendiente de recibir la transferencia: "+RecepcionPlanta.TrnsfrDocNbr);
                this.Close();
                PartidasPlanta fPartidas = new PartidasPlanta();
                fPartidas.Show();
            }

                
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            this.Close();
            PartidasPlanta fPartidas = new PartidasPlanta();
            fPartidas.Show();
        }

        #endregion
    }
}