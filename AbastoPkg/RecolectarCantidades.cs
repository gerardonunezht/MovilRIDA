using System;
using System.Windows.Forms;

namespace Movil_RIDA
{

    public partial class RecolectarCantidades : Form
    {                       
        private static float recolectadoLoc = 0;
        private float porRecolectarLoc = 0;        
        private string ultimoCodigoBarras;
        private Product producto;

        Recoleccion repositorio = new Recoleccion();
        
        private bool VerificaCodigoClaveRecolectada(string pClaveRecolectada)
        {
            if (Recoleccion.Clave.Trim() == pClaveRecolectada.Trim())
            {
                return true;
            }
            else
            {
                MessageBox.Show("El código escaneado NO pertenece a la clave a Recolectar.", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                txtCB.Text = "";
                txtCantidad.Text = "";
                txtMultiplo.Text = "";
                txtCB.Focus();
                return false;
            } 
        }

        // constructor
        public RecolectarCantidades()
        {
            InitializeComponent();
        }
        
        //
        private void SolicitarLocalizacion()
        {
            try
            {
                this.Close();
                RecolectarLoc fRecolectarLoc = new RecolectarLoc();
                fRecolectarLoc.Show();
            }
            catch (Exception)
            {
            }
        }

        //
        private void AgregarRecoleccion(string pClaveRecolectada, float pCantidadRecolectada)
        {            
            //Permite agregar las recolecciones que se deben de hacer en cada localización, cada que se registra una recolección 
            //se valida si con esa recoleccion se completa la recolección total de la lozalización, en caso de que si, la recolección 
            //se convierte como un detalle de transferencia, en caso de que se pretendan recolectar más unidades de los solicitadas
            //esto no se permitira.           

            //Asignamos la suma total de lo recolectado
            recolectadoLoc += pCantidadRecolectada;                                

            if (recolectadoLoc > porRecolectarLoc)
            {
                MessageBox.Show("NO está permitido recolectar más unidades de las solicitadas.", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                recolectadoLoc = recolectadoLoc - pCantidadRecolectada;
                lbRecolectado.Text = recolectadoLoc.ToString();
            }
            else
            {
                //Agregamos la recolección y regresamos la suma total de lo recolectado                
                repositorio.PostAgregarRecoleccion(Recoleccion.ID, Recoleccion.Clave, Recoleccion.LocalizacionOrigenRecolectar, pCantidadRecolectada, Recoleccion.LocalizacionPkg, Global.Usuario);
                txtCB.Text = string.Empty;
                lbRecolectado.Text = recolectadoLoc.ToString();
                btnCero.Enabled = false;
                btnTruncar.Enabled = true;
                if (recolectadoLoc == porRecolectarLoc)
                {
                    //Indicamos que la recolección de la localización ha sido completada
                    recolectadoLoc = 0;
                    SolicitarLocalizacion();
                }
            }                               
        }

        //
        private void frmRecolectarCantidades_Load(object sender, EventArgs e)
        {
            btnCero.Enabled = true;
            btnTruncar.Enabled = false;
            txtCantidad.Visible = false;
            lbCantidad.Visible = false;
      
            lbClave.Text =  Recoleccion.Clave; 
            lbDescripcion.Text = Recoleccion.Descripcion; 
            lbMultAbasto.Text = Recoleccion.MultiploAbastoPkg; 
            lbTrnf.Text = "ID: " +Recoleccion.ID.ToString();
            lbLocalizacion.Text = Recoleccion.LocalizacionOrigenRecolectar;
            lbPorRecolectar.Text = Recoleccion.PorRecolectarLoc.ToString();
            porRecolectarLoc = Recoleccion.PorRecolectarLoc;

            recolectadoLoc = 0;
            ultimoCodigoBarras = "0";

            // instanciamos la clase Product
            producto = new Product();
        }

        //
        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            
            //Al dar enter sobre el campo cantidad se valida que se haya registrado una cantidad y que esta a su vez
            //sea mayor a cero, posterior a esto de valida que la cantidad concuerde con el formato de cantidad
                        
            if (e.KeyCode == Keys.Enter)
            {
                //Validar que se registre un valor en la cantidad
                if ((txtCantidad.Text == "") || (txtCantidad.Text == "0") || (txtCantidad.Text == null))
                {
                    MessageBox.Show("Debe de registrar una cantidad mayor a cero");
                    txtCantidad.Text = "";
                    txtCantidad.Focus();
                }
                else
                {                    
                    //Validar si lo registrado en el campo cantidad, tiene formato de numérico de 999999.99
                    if (Global.ValidaCantidad(txtCantidad.Text))
                    {                        
                        //La cantidad recolectada se determina de multiplicar el múltiplo de nivel del SKU por la cantidad capturada
                        float cantidad = (Convert.ToSingle(txtCantidad.Text) * producto.Multiplo);

                        AgregarRecoleccion(producto.Clave, cantidad);
                    }
                    else
                    {
                        MessageBox.Show("Cantidad registrada incorrecta, favor de verificarla");
                        txtCantidad.Text = "";
                        txtCantidad.Focus();
                    }
                }                                
            }          
        }
        
        //
        private void txtCB_KeyUp(object sender, KeyEventArgs e)
        {

            // Al dar enter sobre sobre el campo código se valida que se haya registrado un código, para buscar   
            // el código según corresponda, ya sea de barras o código interno.

            if (e.KeyCode == Keys.Enter)
            {
                //Validamos que se digite un código a buscar
                if (string.IsNullOrEmpty(txtCB.Text))
                {
                    MessageBox.Show("Debe de registrar un código de producto ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtCB.Focus();
                }
                else
                {
                    //Obtenemos los datos generales del codigo de barras capturado, se asignan a la varibale Clave y Multiplo
                    //de la clase heredada producto                                  
                    
                    if (ultimoCodigoBarras!=txtCB.Text.Trim())
                    {
                        producto = producto.GetDatosProducto(txtCB.Text.Trim());                     
                    }
                    
                    if (!string.IsNullOrEmpty(producto.Clave))
                    {
                        ultimoCodigoBarras = producto.CodBarras;
                        //label5.Text = ultimoCodigoBarras;
    
                        //Asignamos el múltiplo del artículo
                        txtMultiplo.Text = producto.Multiplo.ToString();

                        if (VerificaCodigoClaveRecolectada(producto.Clave))
                        {
                            if (Recoleccion.LocPermiteCapturarMultiplo == "NO")
                            {                            
                                //Agregamos la recolección del artículo, no importando si el multiplo es diferente del sugerido.
                                AgregarRecoleccion(producto.Clave, producto.Multiplo);                            
                            }
                            else
                            {
                                txtCantidad.Visible = true;
                                lbCantidad.Visible = true;
                                txtCantidad.SelectAll();
                                txtCantidad.Focus();
                            } 
                        }                                                   
                    }
                    else
                    {
                        MessageBox.Show("Código de Producto NO encontrado, favor de verificarlo", "Aviso");
                        ultimoCodigoBarras = string.Empty;
                        txtCB.Text = "";
                        txtMultiplo.Text = "";
                        txtCantidad.Text = "";
                        txtCantidad.Visible = false;
                        lbCantidad.Visible = false;
                        txtCB.Focus();
                    }
                }
            }
        }

        //
        private void btnCero_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Esta seguro?", "Aviso",MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

            if ( resp==DialogResult.Yes)
            {
                // omitimos la localización marcandola con cero            
                repositorio.PostAgregarRecoleccion(Recoleccion.ID, Recoleccion.Clave, Recoleccion.LocalizacionOrigenRecolectar, 0, Recoleccion.LocalizacionPkg, Global.Usuario);
                //Regresamos a la pantalla de SolicitarLoc para solicitar otra
                SolicitarLocalizacion();                
            }            
        }

        //
        private void btnTruncar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Esta seguro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resp == DialogResult.Yes)
            {
                // omitimos la localización marcandola con una excepción            
                repositorio.RegistrarExcepcion(Recoleccion.ID, Recoleccion.Clave, Recoleccion.LocalizacionOrigenRecolectar, "Recoleccion Truncada");
                //Regresamos a la pantalla de SolicitarLoc para solicitar otra
                SolicitarLocalizacion();
            }
        }


    }//Clase o forma

}//namespace