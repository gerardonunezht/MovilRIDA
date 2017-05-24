using System;
using System.Windows.Forms;
using System.Data;

namespace Movil_RIDA
{
    public partial class Partidas : Form
    {
        Recepcion recepcion = new Recepcion();
        private Product producto;
        
        private float CantidadRecibida { get; set; }
        private float CantidadOrdenada { get; set; }
        private string Clave { get; set; }

        // constructor
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
            DataRow dr = recepcion.ObtenerCantidadRecibida(Recepcion.OrdenCompra, producto.Clave);
            if (dr!=null)
            {
                this.CantidadRecibida = Convert.ToSingle(dr["CantidadRecibida"]);
                this.CantidadOrdenada = Convert.ToSingle(dr["CantidadOrdenada"]);

                lbCantRecibida.Text = this.CantidadRecibida.ToString();
                lbCantOrdenada.Text = this.CantidadOrdenada.ToString();
            }

            if (this.CantidadRecibida > this.CantidadOrdenada)
            {
                MessageBox.Show("La partida: " + this.Clave + " se ha recibido con un excedente respecto la cantidad solicitada en la orden de compra. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                Limpiar();          
            }
            else if (this.CantidadRecibida == this.CantidadOrdenada)
            {
                MessageBox.Show("La partida: " + this.Clave + " se ha recibido totalmente conforme a la orden de compra. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                Limpiar();  
            }
        } 

        private void RegistrarPartida(float CantidadRecibida)
        {
            if (string.IsNullOrEmpty(Recepcion.Factura))
            {
                MessageBox.Show("No se tienen registrado un número de factura a asociar, favor de verificar. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            //Registramos la partida en la Base de datos
            DataRow dr = recepcion.AgregarPartida(Recepcion.OrdenCompra, Recepcion.MonedaOrdenCompra, Recepcion.NoProveedor, producto.CodBarras, CantidadRecibida, Recepcion.Factura, Global.Usuario);

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
                if (string.IsNullOrEmpty(txtCB.Text))
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
                        lbMultiploEmpaque.Text = producto.Multiplo.ToString();

                        var aceptaMultiplo = producto.PermiteCapturarMultiploEmpaque(producto.Clave, Global.IdProcesoADN);

                        //if (recepcion.PermiteCapturarMultiplo == "SI")
                        if (aceptaMultiplo == "SI")
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
                if (Global.ValidaCantidad(txtCantidad.Text))
                {
                    //Cantidad a registrar es igual a la multiplicación del múltiplo del empaque del artículo por la cantidad de empaques
                    float CantidadRegistrar = Convert.ToSingle(txtCantidad.Text) * producto.Multiplo;

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

            // instanciamos la clase Product
            producto = new Product();
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
                int res = recepcion.EliminarPartida(Recepcion.OrdenCompra, producto.Clave, Global.Usuario);

                if (res > 0)
                {
                    //Se eliminó la partida
                    btnEliminarUltimaPartida.Enabled = false;
                    txtCB.Text = "";
                    txtCB.Focus();
                    ValidaRecepcionPartidaCompleta();
                }
            }
        }


    }//Forma

}//namespace