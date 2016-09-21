using System;
using System.Windows.Forms;
using System.Data;

namespace Movil_RIDA
{
    public partial class Partidas : Form
    {

        //Partida partida = new Partida();
        Recepcion recepcion = new Recepcion();

        public Partidas()
        {
            InitializeComponent();
            txtCB.Focus();
        }

        #region Métodos

        private void Limpiar()
        {
            lbClave.Text = "";
            lbDescripcion.Text = "";
            lbMultiploEmpaque.Text = "";
            lbCantOrdenada.Text = "";
            lbCantRecibida.Text = "";
            btnEliminarUltimaPartida.Enabled = false;
        }
        
        private void ValidaRecepcionPartidaCompleta()
        {
            //
            recepcion.ObtenerCantidadRecibida(Recepcion.OrdenCompra, recepcion.Clave);

            lbCantRecibida.Text = recepcion.CantidadRecibida.ToString();
            lbCantOrdenada.Text = recepcion.CantidadOrdenada.ToString();

            if (recepcion.CantidadRecibida > recepcion.CantidadOrdenada)
            {
                MessageBox.Show("La partida: " + recepcion.Clave + " se ha recibido con un excedente respecto la cantidad solicitada en la orden de compra. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                Limpiar();          
            }
            else if (recepcion.CantidadRecibida == recepcion.CantidadOrdenada)
            {
                MessageBox.Show("La partida: " + recepcion.Clave + " se ha recibido totalmente conforme a la orden de compra. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                Limpiar();  
            }
        } 

        private void RegistrarPartida(float CantidadRecibida)
        {
            DataRow dr;
            if (Recepcion.Factura=="")
            {
                MessageBox.Show("No se tienen registrado un número de factura a asociar, favor de verificar. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            //Registramos la partida en la Base de datos
            dr = recepcion.AgregarPartida(Recepcion.OrdenCompra, Recepcion.MonedaOrdenCompra, Recepcion.NoProveedor, recepcion.CodBarras, CantidadRecibida, Recepcion.Factura, Global.Usuario);

            string NoError = dr[0].ToString();
            string MensajeError=dr[1].ToString();

            if (NoError == "0")
            {
                btnEliminarUltimaPartida.Enabled = true;
                txtCB.Text = "";
                txtCB.Focus();
                ValidaRecepcionPartidaCompleta();             
            }
            else
            {
                MessageBox.Show(MensajeError, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }

        }
        
        #endregion

        private void txtCB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Validamos que se digite un código a buscar
                if ((txtCB.Text == "") || (txtCB.Text == null))
                {
                    MessageBox.Show("Debe de registrar un código de producto. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtCB.Focus();
                }
                else
                {
                    //Obtenemos los datos generales del codigo de barras capturado                                                       
                    recepcion.ObtenerDatosProducto(txtCB.Text.Trim(), Global.IdProcesoADN);

                    if (recepcion.Clave != "")                                        
                    {
                        //Mostramos información en pantalla
                        lbClave.Text = recepcion.Clave;
                        lbDescripcion.Text = recepcion.Descripcion;
                        lbMultiploEmpaque.Text = recepcion.Multiplo.ToString();

                        if (recepcion.PermiteCapturarMultiplo == "SI")
                        {
                            lbCantidad.Visible = true;
                            txtCantidad.Visible = true;
                            txtCantidad.Focus();
                        }
                        else
                        {                                                    
                            //Regresamos un -1 en cantidad para indicarle al sistema que tome el multiplo del producto como la cantidad
                            RegistrarPartida(-1);  
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
                if (Producto.ValidaCantidad(txtCantidad.Text))
                {
                    //Cantidad a registrar es igual a la multiplicación del múltiplo del empaque del artículo por la cantidad de empaques
                    float CantidadRegistrar = Convert.ToSingle(txtCantidad.Text) * recepcion.Multiplo;

                    RegistrarPartida(CantidadRegistrar);
                }
                else
                {
                    MessageBox.Show("Cantidad a registrar es incorrecta, favor de verificarla.","Aviso!!!",MessageBoxButtons.OK ,MessageBoxIcon.Hand,MessageBoxDefaultButton.Button1);
                    txtCantidad.Text = "";
                    txtCantidad.Focus();
                }

            }
        }

        private void Partidas_Load(object sender, EventArgs e)
        {
            btnEliminarUltimaPartida.Enabled = false;
            lbCantidad.Visible = false;
            txtCantidad.Visible = false;
            lbOC.Text = "OC: " + Recepcion.OrdenCompra;
            lbFactura.Text = "Fact: " + Recepcion.Factura;
            txtCB.Focus();
        }

        private void Partidas_Closed(object sender, EventArgs e)
        {           
            Global.LogOut(Global.Usuario);
            Application.Exit();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Seguro que desea FINALIZAR la recepcion de la orden de compra? ", "AVISO!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (recepcion.FinalizarRecepcion(Recepcion.OrdenCompra, Recepcion.Factura))
                {
                    PrincipalRecepcion fRecepcion = new PrincipalRecepcion();
                    fRecepcion.Show();
                    this.Hide();
                }
            }
        }

        private void btnEliminarUltimaPartida_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Está seguro de eliminar el último registro de partida ingresado?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (resp == DialogResult.Yes)
            {
                //Registramos la partida en la Base de datos
                int res = recepcion.EliminarPartida(Recepcion.OrdenCompra, recepcion.Clave, Global.Usuario);

                if (res > 0)
                {
                    //Se eliminó la partida
                    btnEliminarUltimaPartida.Enabled = false;
                    txtCB.Text = "";
                    //txtCB.Text = "7506055126472";
                    txtCB.Focus();
                    ValidaRecepcionPartidaCompleta();
                }
            }
        }

        private void lbMultiploEmpaque_ParentChanged(object sender, EventArgs e)
        {

        }

    }//Forma
}//namespace