using System;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class PrincipalRecepcion : Form
    {
        Recepcion recepcion = new Recepcion();
        public string Clave { get; set; }

        // constructor
        public PrincipalRecepcion()
        {
            InitializeComponent();
        }

        #region Métodos

        //
        private void LimpiarObjetos()
        {
            txtReferenciaFactura.Visible = false;
            btnIniciar.Enabled = false;
            txtProveedor.Text = "";
            txtOrdenCompra.Text = "";
            txtOrdenCompra.Focus();
        }

        //
        private void BuscarOrdenCompra()
        {
            DataRow dr;

            dr = recepcion.ObtenerDatosOrdenCompra(Recepcion.OrdenCompra);

            if (dr != null)
            {
                Recepcion.FechaOrdenCompra = dr["FechaOrdenCompra"].ToString().Trim();
                Recepcion.NoProveedor = dr["NoProveedor"].ToString().Trim();
                Recepcion.NombreProveedor = dr["Proveedor"].ToString().Trim();
                Recepcion.MonedaOrdenCompra = dr["Moneda"].ToString().Trim();

                txtProveedor.Text = Recepcion.NoProveedor + '-' + Recepcion.NombreProveedor;

                txtReferenciaFactura.Visible = true;
                btnIniciar.Enabled = true;
                txtReferenciaFactura.Focus();
            }
            else
            {
                MessageBox.Show("La orden de compra ingresada NO EXISTE o ya esta marcada como RECIBIDA TOTALMENTE, favor de verificarla con el área de Suministros.", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                LimpiarObjetos();
            }
        }

        #endregion
        
        private void Principal_Load(object sender, EventArgs e)
        {
            //Primero verificamos si exite alguna partida pendiente de recibir
            DataRow dr = recepcion.ContinuarRecpecionPartida(Global.Usuario);

            if (dr!=null)
            {
                    Recepcion.OrdenCompra = dr["PoNbr"].ToString().Trim();
                    Recepcion.NoProveedor = dr["VendId"].ToString().Trim();
                    Recepcion.MonedaOrdenCompra = dr["CuryId"].ToString().Trim();
                    Recepcion.StatusPartida = dr["StatusPartidaRecepcion"].ToString().Trim();
                    this.Clave = dr["Invtid"].ToString().Trim();
            }

            if (Recepcion.StatusPartida == "RECIBIENDO")
            {

                string mensaje = String.Format("Se quedo pendiente de RECIBIR la partida {0} perteneciente a la O.C. {1}, ¿Desea continuarla? en caso de que NO, sera cancelada.", this.Clave, Recepcion.OrdenCompra);
                DialogResult resp = MessageBox.Show(mensaje, "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (resp == DialogResult.Yes)
                {                                        
                    this.Close();
                }else
                {
                    recepcion.CancelarRecepcionPartida(Recepcion.OrdenCompra, this.Clave);
                    MessageBox.Show("Se ha eliminado por completo la información de la recepción");
                    LimpiarObjetos();
                    btnIniciar.Enabled = false;
                    txtOrdenCompra.Focus();                  
                }
            }
            else
            {
                LimpiarObjetos();
                btnIniciar.Enabled = false;
                txtOrdenCompra.Focus();
            }
        }
        
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReferenciaFactura.Text))
            { 
                DataRow dr = recepcion.ValidaNoDuplicidadReferencia(txtReferenciaFactura.Text, Recepcion.NoProveedor);

                if (dr != null)            
                {
                    string mensaje = String.Format("La Referencia: {0} ya fué asignada previamente en la recepción: {1} de la orden de compra: {2} del proveedor: {3},  ¿Desea continuar de cualquier manera?.", txtReferenciaFactura.Text, dr["RcptNbr"].ToString().Trim(), dr["PoNbr"].ToString().Trim(), dr["Proveedor"].ToString().Trim());
                    
                    DialogResult resp=MessageBox.Show(mensaje, "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

                    //Preguntamos si se desea continuar con la referencia a pesar de que ya existe previamente
                    if (resp == DialogResult.Yes)
                    {
                        Recepcion.Factura = txtReferenciaFactura.Text;
                        this.Close();
                        Partidas fPartidas = new Partidas();
                        fPartidas.Show();
                        txtReferenciaFactura.Text = "";
                    }
                    else
                    {
                        txtReferenciaFactura.SelectAll();
                        txtReferenciaFactura.Focus();     
                    }           
                }
                else
                {
                    //No existe duplicidad
                    Recepcion.Factura = txtReferenciaFactura.Text;                
                    this.Close();
                    Partidas fPartidas = new Partidas();
                    fPartidas.Show();
                }            
            }
            else
            {
                MessageBox.Show("Debe de ingresa el NUMERO DE FACTURA asociado a la orden de compra que se recibirá.", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                txtReferenciaFactura.SelectAll();
                txtReferenciaFactura.Focus();  
            }                                  
        }
        
        private void txtOrdenCompra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Recepcion.OrdenCompra = txtOrdenCompra.Text.Trim();
                BuscarOrdenCompra();
            }
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Global.LogOut(Global.Usuario);
            this.Close();
        }

    }
}