using System;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class RegistrarConteo : Form
    {
        Conteo conteo = new Conteo();
        Product producto = new Product();

        // constructor
        public RegistrarConteo()
        {
            InitializeComponent();
        }

        private void RegistrarPartidaConteo(float CantidadRecibida)
        {
            DataRow dr;

            //Registramos la partida en la Base de datos          
            dr = conteo.RegistrarConteo(Conteo.NoConteo, Conteo.Almacen, Conteo.Localizacion, txtCB.Text, CantidadRecibida, Global.Usuario);

            string NoError = dr[0].ToString();
            string MensajeError = dr[1].ToString();
            string CantidadContada = dr[2].ToString();
            if (NoError == "0")
            {
                btnEliminarUltimaPartida.Enabled = true;
                lbCantContada.Text = "CANT. CONTADA: "+CantidadContada;
                txtCB.Text = "";
                txtCantidad.Text = "";
                txtCB.Focus();
            }
            else
            {
                MessageBox.Show(MensajeError, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void RegistrarConteo_Load(object sender, EventArgs e)
        {
            txtCantidad.Enabled = false;
            lbIdConteo.Text = "NO. CONTEO: " +Conteo.NoConteo;
            lbLoc.Text = Conteo.Localizacion;
            lbClave.Text = Conteo.ClaveContar;
            txtCB.Focus();
        }

        private void txtCB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Validamos que se digite un código a buscar
                if (string.IsNullOrEmpty(txtCB.Text.Trim()))
                {
                    MessageBox.Show("Debe de registrar un código de producto. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtCB.Focus();
                }
                else
                {
                    //Obtenemos los datos generales del codigo de barras capturado                                                       
                    producto = producto.GetDatosProducto(txtCB.Text.Trim());

                    if (!string.IsNullOrEmpty(producto.Clave))
                    {
                        //Mostramos información en pantalla
                        lbClave.Text = producto.Clave;
                        lbDescripcion.Text = producto.Descripcion;
                        txtMultiplo.Text = producto.Multiplo.ToString();

                        var aceptaMultiplo = producto.PermiteCapturarMultiploEmpaque(producto.Clave, Global.IdProcesoADN);

                        if ((aceptaMultiplo == "SI") || (producto.Nivel > 1))
                        {
                            txtCantidad.Enabled = true;
                            txtCantidad.Focus();
                        }
                        else
                        {
                            //Regresamos un -1 en cantidad para indicarle al sistema que tome el multiplo del producto como la cantidad
                            RegistrarPartidaConteo(-1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El código de barras registrado no está asociado a una clave de artículo, favor de verificarlo", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        txtCB.Text = "";
                        txtCB.Focus();
                    }
                }
            }
        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Validar si lo registrado en el campo cantidad, tiene formato de numérico de 999999.99
                if (Global.ValidaCantidad(txtCantidad.Text))
                {
                    //Cantidad a registrar es igual a la multiplicación del múltiplo del empaque del artículo por la cantidad de empaques
                    float CantidadRegistrar = Convert.ToSingle(txtCantidad.Text) * producto.Multiplo;

                    RegistrarPartidaConteo(CantidadRegistrar);
                }
                else
                {
                    MessageBox.Show("Cantidad a registrar es incorrecta, favor de verificarla.", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    txtCantidad.Text = "";
                    txtCantidad.Focus();
                }
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("¿Seguro que desea FINALIZAR el conteo de la localización? ", "AVISO!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {

                string ConteoFinalizado = conteo.FinalizarConteo(Conteo.NoConteo, Conteo.Almacen, Conteo.Localizacion, Global.Usuario);
                if (ConteoFinalizado=="True")
                {
                    MessageBox.Show("CONTEO FINALIZADO.", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    this.Close();
                    PrincipalConteos fConteos = new PrincipalConteos();
                    fConteos.Show();
                }
                else
                {
                    this.Close();
                    ConfirmarLocalizacion fLocalizacion = new ConfirmarLocalizacion();
                    fLocalizacion.Show();
                }
            }
        }

        private void btnEliminarUltimaPartida_Click(object sender, EventArgs e)
        {            
            DialogResult resp = MessageBox.Show("¿Está seguro de eliminar el último registro de conteo ingresado?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (resp == DialogResult.Yes)
            {
                //Eliminamos el último registro insertado
                string cantidadContada = conteo.EliminarRegistroConteo(Conteo.NoConteo, Global.Usuario);

                if (cantidadContada!="")
                {
                    //Se eliminó la partida
                    btnEliminarUltimaPartida.Enabled = false;
                    lbCantContada.Text =  "CANT. CONTADA: " + cantidadContada;
                    txtCB.Text = "";
                    txtCantidad.Text = "";
                    txtCB.Focus();
                }
            }
        }


    }
}