using System;
using System.Data;
using System.Windows.Forms;
using Movil_RIDA.Clases;

namespace Movil_RIDA
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Ingresar()
        {
            
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Debe de registrar su código de usuario ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                txtUsuario.Focus();
            }
            else
            {
                Global.Usuario = txtUsuario.Text.Trim();

                try
                {
                    DataRow drLogIn = Global.LogIn(Global.Usuario);

                    string error = drLogIn[0].ToString();
                    string mensaje = drLogIn[1].ToString();
                    
                    if ((error == "0") || (error == "2"))
                    {
                        
                        switch (Global.Aplicacion)
                        {
                            case "RECEPCION":
                                PrincipalRecepcion fRecepcion = new PrincipalRecepcion();
                                fRecepcion.Show();
                                this.Hide();
                                break;
                            case "INSPECCION":
                                PrincipalInspeccion fInspeccion = new PrincipalInspeccion();
                                fInspeccion.Show();
                                this.Hide();
                                break;
                            case "DISPONIBLE":
                                PrincipalDisponible fDisponible = new PrincipalDisponible();
                                fDisponible.Show();
                                this.Hide();
                                break;
                            case "ABASTO PKG":
                                PrincipalAbastoPkg fAbastoPkg = new PrincipalAbastoPkg();
                                fAbastoPkg.Show();
                                this.Hide();
                                break;
                            case "CONTEOS":
                                PrincipalConteos fConteo = new PrincipalConteos();
                                fConteo.Show();
                                this.Hide();
                                break;
                            case "RECEPCION_PLANTA":
                                PrincipalRecepcionPlanta fRcpPlanta = new PrincipalRecepcionPlanta();
                                fRcpPlanta.Show();
                                this.Hide();
                                break;
                            case "DISPONIBLE_PLANTA":
                                PrincipalDisponiblePlanta fDisponiblePlanta = new PrincipalDisponiblePlanta();
                                fDisponiblePlanta.Show();
                                this.Hide();
                                break;
                            default:
                                break;
                        }
                         
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        txtUsuario.Text = "";
                        txtUsuario.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void Acceso_Load(object sender, EventArgs e)
        {
            lbAplicacion.Text = Global.Aplicacion;
            lbVersion.Text = Global.Version;

            //Verificamos a que servidor nos estamos conectando; pruebas o producción, si es pruebas
            //lo mostramos en pantalla
            if (Properties.Resources.cnStr.Contains("Server=172.16.1.42"))
            {
                lbServidor.Visible = true;
                lbServidor.ForeColor = System.Drawing.Color.Green;
                lbServidor.Text = "Servidor: PRUEBAS";
            }
            else
            {
                lbServidor.Visible = false;
            }

            btnIngresar.Enabled = true;
            txtUsuario.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void txtID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Ingresar();
            }
        }

    }//clase
}//namespace