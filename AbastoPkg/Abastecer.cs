using System;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class Abastecer : Form
    {
        AbastoPkg abasto = new AbastoPkg();

        public Abastecer()
        {
            InitializeComponent();
        }

        private void SolicitarPartidaParaReAbastecer()
        {
            DataRow drPartida;
            DataSet dsPartidas = new DataSet();

            try
            {
                //Obtenemos la primer partida recolectada a Re-Abastecer
                dsPartidas = abasto.ObtenerRecoleccionParaReAbastecer(AbastoPkg.Transferencia);

                //Si la consulta regresa datos (Partidas), entonces
                if (dsPartidas.Tables[0].Rows.Count > 0)
                {
                    //Mostramos en pantalla la clave del producto a Re-Abastecer y la Localización donde se deberá de colocar 
                    drPartida = dsPartidas.Tables[0].Rows[0];

                    if (drPartida["InvtId"].ToString() == "NA")
                    {
                        btnFinalizar.Visible = true;
                        panel.Visible = false;
                    }
                    else
                    {
                        btnFinalizar.Visible = false;
                        panel.Visible = true;
                        lbConfirmarProducto.Text = drPartida["InvtId"].ToString(); 
                        lbConfirmarLocalizacion.Text = drPartida["LocDestino"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void Abastecer_Load(object sender, EventArgs e)
        {
            btnFinalizar.Visible = false;
            panel.Visible = false;

            txtConfirmarProducto.Focus();
            
            lbNoTransferencia.Text = "No. Transferencia: " + AbastoPkg.Transferencia;
            txtConfirmarLocalizacion.Visible = false;
            lbConfirmarLocalizacion.Visible = false;


            //Establecemos el inicio del proceso de ReAbasto
            abasto.IniciarReAbasto(Convert.ToInt32(AbastoPkg.Transferencia));
            
            //Solicitamos las partidas correspondientes al Re-Abasto
            SolicitarPartidaParaReAbastecer();
        }

        private void txtConfirmarLocalizacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tmLocalizacion.Enabled = false;

                if ((txtConfirmarLocalizacion.Text.ToUpper() == lbConfirmarLocalizacion.Text.Trim()) || (txtConfirmarLocalizacion.Text == "."))
                {
                    abasto.FinalizarReAbasto(Convert.ToInt32(AbastoPkg.Transferencia));
                    AbastoPkg.Transferencia = "";//Limpiamos la variable de No. de Transferencia                
                    MessageBox.Show("ABASTO COMPLETADO!!!", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

                    //Regresamos a la página principal
                    this.Close();
                    PrincipalAbastoPkg fPrincipal = new PrincipalAbastoPkg();
                    fPrincipal.Show();
                }
                else
                {
                    MessageBox.Show("NO coinciden las Localizaciones.", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtConfirmarLocalizacion.Text = "";
                    txtConfirmarLocalizacion.Focus();
                }
            }
            else
            {
                tmLocalizacion.Enabled = true;
            }
        }

        private void txtConfirmarProducto_KeyUp(object sender, KeyEventArgs e)
        {
            DataSet ds = new DataSet();

            if (e.KeyCode == Keys.Enter)
            {
                //Obtenemos los datos generales del codigo de barras capturado, se asignan a la varibale Clave y Multiplo
                //de la clase heredada producto                                  
                abasto.ObtenerDatosProducto(txtConfirmarProducto.Text.Trim(), "");

                if (abasto.Clave == lbConfirmarProducto.Text.Trim())
                {
                    txtConfirmarLocalizacion.Text = "";
                    txtConfirmarLocalizacion.Visible = true;
                    lbConfirmarLocalizacion.Visible = true;
                    txtConfirmarLocalizacion.Focus();
                }
                else
                {
                    MessageBox.Show("NO coincide el código ingresado con la clave del producto, favor de verificarlo.", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtConfirmarProducto.Text = "";
                    txtConfirmarProducto.Focus();
                }
            }
        }

        private void tmLocalizacion_Tick(object sender, EventArgs e)
        {
            txtConfirmarLocalizacion.Text = "";
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
            PrincipalAbastoPkg fPrincipal = new PrincipalAbastoPkg();
            fPrincipal.Show();   
        }


    }
}