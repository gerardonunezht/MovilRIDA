using System;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class PrincipalInspeccion : Form
    {
        Inspeccion inspeccion = new Inspeccion();
        Product producto = new Product();

        // constructor
        public PrincipalInspeccion()
        {
            InitializeComponent();
        }

        #region Métodos

        private void RegistrarPartida()
        {
            
            //Registramos la partida en la Base de datos
            DataRow dr = inspeccion.AgregarRegistroMuestreo(producto.CodBarras, Global.Usuario);

            string NoError = dr[0].ToString();
            string MensajeError = dr[1].ToString();

            if (NoError== "0")
            {
                
                float TamañoMuestra = Convert.ToSingle(dr[2].ToString());
                float MuestraRecolectada = Convert.ToSingle(dr[3].ToString());

                lbTamañoMuestra.Text = TamañoMuestra.ToString();
                lbRecolectado.Text = MuestraRecolectada.ToString();

                if (MuestraRecolectada > TamañoMuestra)
                {
                    MessageBox.Show("Producto: " + producto.Clave + " se ha recolectado con un excedente respecto al tamaño de la muestra. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                else if (MuestraRecolectada ==TamañoMuestra)
                {
                    MessageBox.Show("Producto: " + producto.Clave + " se ha recolectado totalmente conforme al tamaño de muestra. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show(MensajeError, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void Limpiar()
        {
            txtCodigoBarras.Text = "";
            txtCodigoBarras.Focus();
        }

        #endregion

        private void txtCodigoBarras_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Validamos que se digite un código a buscar
                if (string.IsNullOrEmpty(txtCodigoBarras.Text))
                {
                    MessageBox.Show("Debe de registrar un código de producto. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtCodigoBarras.Focus();
                }
                else
                {
                    //Obtenemos los datos generales del codigo de barras capturado                                                       
                    producto = producto.GetDatosProducto(txtCodigoBarras.Text.Trim());

                    if (!string.IsNullOrEmpty(producto.Clave))
                    {
                        //Mostramos información en pantalla
                        lbClave.Text = producto.Clave;
                        lbDescripcion.Text = producto.Descripcion;
                        lbMultiploEmpaque.Text = producto.Multiplo.ToString();

                        RegistrarPartida();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El código de barras registrado no está asociado a una clave de artículo, favor de verificarlo", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        txtCodigoBarras.Text = "";
                        txtCodigoBarras.Focus();
                    }
                }

            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Global.LogOut(Global.Usuario);
            this.Close();
        }

        private void btnUtilerias_Click(object sender, EventArgs e)
        {
            try
            {
                Utilerias fUtilerias = new Utilerias();
                this.Close();
                fUtilerias.Show();
            }
            catch (Exception)
            {
            }
        }

        private void PrincipalInspeccion_Load(object sender, EventArgs e)
        {

        }

    }
}