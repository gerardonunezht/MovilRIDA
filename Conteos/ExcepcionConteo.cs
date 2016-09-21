using System;
using System.Windows.Forms;
using System.Data;

namespace Movil_RIDA
{
    public partial class ExcepcionConteo : Form
    {
        Conteo cto = new Conteo();
        public string PantallaInvoca = "";

        private void Agregarexcepcion()
        {
            if (txtLocalizacionExp.Text == "")
            {
                MessageBox.Show("Debe registrar una localización.");
                return;
            }

            if (txtCodigoExp.Text == "")
            {
                MessageBox.Show("Debe registrar un código de barras de producto.");
                return;
            }
            if (!Producto.ValidaCantidad(txtCantidadExp.Text))
            {
                MessageBox.Show("Cantidad invalida, favor de verifica");
                return;
            }

            float CantidadExcepcion = Convert.ToSingle(txtCantidadExp.Text);

            if (CantidadExcepcion<=0)
            {
                MessageBox.Show("La cantidad debe de ser mayor a cero.");
                return;
            }

            DataRow dr = cto.agregarLocalizacionExcepcion(Conteo.NoConteo, Conteo.ClaveContar, txtLocalizacionExp.Text.Trim().ToUpper(), CantidadExcepcion, Global.Usuario);

            if (dr[0].ToString() != "0")
            {
                MessageBox.Show(dr[1].ToString());
                return;
            }

            MessageBox.Show("Excepción registrada correctamente.");
            this.Close();
            ConfirmarLocalizacion fLocalizacion = new ConfirmarLocalizacion();
            fLocalizacion.Show();
        }


        public ExcepcionConteo()
        {
            InitializeComponent();
        }

        private void btnExcepcion_Click(object sender, EventArgs e)
        {
            Agregarexcepcion();
            
        }

        private void txtLocalizacionExp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCodigoExp.Focus();
            }
        }

        private void ExcepcionConteo_Load(object sender, EventArgs e)
        {
            txtLocalizacionExp.Focus();
        }

        private void txtCodigoExp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Validamos que se digite un código a buscar
                if ((txtCodigoExp.Text == "") || (txtCodigoExp.Text == null))
                {
                    MessageBox.Show("Debe de registrar un código de producto. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtCodigoExp.Focus();
                }
                else
                {
                    //Obtenemos los datos generales del codigo de barras capturado                                                       
                    cto.ObtenerDatosProducto(txtCodigoExp.Text.Trim(), Global.IdProcesoADN);

                    if (cto.Clave == Conteo.ClaveContar)
                    {
                        //lbProductoExcepcion.Text = cto.Descripcion;
                        txtCantidadExp.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El código de barras registrado no pertenece al producto que se debe de contar, favor de verificar.", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        txtCodigoExp.Text = "";
                        txtCodigoExp.Focus();
                    }
                }
            }
        }

        private void txtCantidadExp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Agregarexcepcion();
            }
        }
    }
}