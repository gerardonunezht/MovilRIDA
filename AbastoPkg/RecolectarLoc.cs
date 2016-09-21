using System;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class RecolectarLoc : Form
    {
        AbastoPkg abasto = new AbastoPkg();

        //
        public RecolectarLoc()
        {
            InitializeComponent();
        }

        //
        private void txtLocalizacion_KeyUp(object sender, KeyEventArgs e)
        {
            /*
              Valida que la localización capturada sea igual a la localización mostrada en la pantalla para poder continuar           
            */

            if (e.KeyCode == Keys.Enter)
            {
                tmLocalizacion.Enabled = false;

                if ((txtLocalizacion.Text.ToUpper().Trim() == lbLocalizacion.Text.ToUpper().Trim()) || (txtLocalizacion.Text == Global.CaracterEscape))
                {
                    this.Close();
                    //Pasamos a la pantalla de Recolectar (Cantidades)
                    RecolectarCantidades fRecolectarCant = new RecolectarCantidades();
                    fRecolectarCant.Show();
                }
                else
                {
                    MessageBox.Show("No coincide la localización, favor de verificarla ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtLocalizacion.Text = "";
                    txtLocalizacion.Focus();
                }
            }
            else
            {
                tmLocalizacion.Enabled = true;
            }

        }

        //
        private void frmRecolectarLoc_Load(object sender, EventArgs e)
        {
            /*
             Al cargar la forma se busca la localización con menor cantidad disponible para recolectar, asi sucesivamente hasta
             que se recolecte la cantidad total global de la clave             
            */

            lbNoTransferencia.Text = AbastoPkg.Transferencia;
            lbAviso.Visible = false;
            btnFinalizar.Visible = false;
            txtLocalizacion.Visible = true;

            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                ds = abasto.ObtenerExistenciaLocalizacion(AbastoPkg.LocalizacionPkgDestino, AbastoPkg.Transferencia);
                dr = ds.Tables[0].Rows[0];

                //Asignamos los valores a las variables públicas
                AbastoPkg.TotalRecolectado = dr["TotalRecolectado"].ToString().Trim();
                AbastoPkg.TotalRestante = dr["TotalRestante"].ToString().Trim();
                AbastoPkg.PorRecolectarLoc = dr["PorRecolectarLoc"].ToString().Trim();
                AbastoPkg.ExistenciaLoc = dr["ExistenciaLoc"].ToString().Trim();
                AbastoPkg.LocalizacionOrigenRecolectar = dr["LocalizacionOrigenRecolectar"].ToString().Trim();
                AbastoPkg.LocConExistencia = Convert.ToInt16(dr["LocConExistencia"].ToString());
                AbastoPkg.MultiploAbastoPkg = dr["MultiploAbastoPkg"].ToString().Trim();

                if (Convert.ToSingle(AbastoPkg.TotalRestante) == 0)
                {
                    //Finalizamos el proceso de recolección de claves.
                    abasto.FinalizarRecoleccion(AbastoPkg.Transferencia, AbastoPkg.LocalizacionPkgDestino);

                    this.Close();
                    Abastecer fAbastecer = new Abastecer();
                    fAbastecer.Show();
                }
                else if (AbastoPkg.LocConExistencia == 0)
                {
                    //Finalizamos el proceso de recolección de claves.
                    abasto.FinalizarRecoleccion(AbastoPkg.Transferencia, AbastoPkg.LocalizacionPkgDestino);

                    this.Close();
                    Abastecer fAbastecer = new Abastecer();
                    fAbastecer.Show();

                }
                else
                {
                    float ExistenciaLoc = Convert.ToSingle(AbastoPkg.ExistenciaLoc);
                    float MultiploAbastoPkg = Convert.ToSingle(AbastoPkg.MultiploAbastoPkg);

                    //determinamos si la localizaión continene poquedades
                    float hayPoquedades = ExistenciaLoc / MultiploAbastoPkg;

                    if (hayPoquedades < 1)
                    {
                        lbAviso.Visible = true;
                        lbAviso.Text = "La existencia de esta localización es menor al múltiplo de abasto (POQUEDAD)";
                    }

                    //Mostramos la clave, la cantidad y la localizaciónque se debe de Recolectar
                    lbClave.Text = AbastoPkg.ClaveRecolectar;
                    lbDescripcion.Text = AbastoPkg.DescrClaveRecolectar;
                    lbCantidad.Text = AbastoPkg.PorRecolectarLoc;
                    lbLocalizacion.Text = AbastoPkg.LocalizacionOrigenRecolectar;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Es probable que esta clave no tenga asignado correctamente un múltiplo de abasto o quizá no cuente con codigo de barras, favor de verificar con Supervisor Administrativo.", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                txtLocalizacion.Visible = false;
                btnFinalizar.Visible = true;
            }

            //Si el usuario es el abastecedor de Picking 2, entonces se muestra el botón finalizar
            if (Global.Usuario == "6001")
            {
                btnFinalizar.Visible = true;
            }

        }

        //limpiamos la captura de la localización despues de que expire el tiempo límite máximo de captura
        private void tmLocalizacion_Tick(object sender, EventArgs e)
        {
            txtLocalizacion.Text = "";
        }


        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //this.Close();
            //PrincipalAbastoPkg fPrincipal = new PrincipalAbastoPkg();
            //fPrincipal.Show();

            //Regresamos a la pantalla de SolicitarLoc para solicitar otra
            this.Close();
            Excepcion fExcepcion = new Excepcion();
            fExcepcion.Show();
        }


    }//Clase o Forma

}//namespace