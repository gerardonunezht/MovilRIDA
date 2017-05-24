using System;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class ReAbastecer : Form
    {

        AbastoPkg abasto = new AbastoPkg();
        Recoleccion repositorio = new Recoleccion();
        
        //Variables Locales     
        private string ClaveReAbastecida = "";//Almacena la clave interna (HT) obtenida de buscar el codigo de barras correspondiente
        //private float MultiploClave;//Almacena el múltiplo asignado a dicha clave interna (HT) obtenida de buscar el codigo de barras correspondiente
        private string SumaCantidadReAbastecida;//Almacena el total de la suma de la cantidad recolectada, una vez registrada una recoleccion
        private float TotalReabastecido = 0;//Almacena el total de unidades recolectadas al momento
        private string CantidadPorReabastecer = "";

        public ReAbastecer()
        {
            InitializeComponent();
        }

        //
        private void SolicitarPartidaParaReAbastecer()
        {
            /*
              Se solicitando las partidas a Re-Abastecer correspondientes a la transferencia actual            
            */

            
            DataSet dsPartidas = new DataSet();
            DataTable dtPartidas;
            DataRow drPartida;


            try
            {

            //Obtenemos la primer partida recolectada a Re-Abastecer
            //dsPartidas = abasto.ObtenerRecoleccionParaReAbastecer(AbastoPkg.Transferencia);
            dtPartidas = repositorio.ObtenerRecoleccionParaReAbastecer(Recoleccion.ID);


                //Si la consulta regresa datos (Partidas), entonces
                if (dtPartidas.Rows.Count > 0)
                {
                    //Mostramos en pantalla la clave del producto a Re-Abastecer y la Localización donde se deberá de colocar 
                    //drPartida = dsPartidas.Tables[0].Rows[0];
                    drPartida = dtPartidas.Rows[0];

                    //lbNoTransferencia.Text = lbNoTransferencia.Text = "No. Transf: " + drPartida["Transferencia"].ToString();
                    lbConfirmarProducto.Text = drPartida["InvtId"].ToString(); //
                    lbConfirmarLocalizacion.Text = drPartida["LocDestino"].ToString(); //
                    //CantidadPorReabastecer = drPartida["Cantidad"].ToString();
                    //txtConfirmarLocalizacion.Focus();
                }
                else
                {
                    //Si Ya no existen más datos (Partidas), entonces finalizamos el Re-Abasto
                    //Metodos.FinalizarReAbasto(Convert.ToInt32(Metodos.Transferencia));
                    //abasto.FinalizarReAbasto(Convert.ToInt32(AbastoPkg.Transferencia));
                    //AbastoPkg.Transferencia = "";//Limpiamos la variable de No. de Transferencia                
                    //MessageBox.Show("RE-ABASTO COMPLETADO!!!", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    //Regresamos a la página principal
                    this.Close();                    
                    PrincipalAbastoPkg fPrincipal = new PrincipalAbastoPkg();
                    fPrincipal.Show();
                    
                    //btnSinAbasto.Visible = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        
        //private bool ObtenerDatosProducto(string Codigo, string pTipoCodigo)
        //{
        //    /*
        //      Busca información general del artículo como: clave, múltiplo y nivel en función del código de barras o el código interno (HT) 
        //      si no se encuentra el artículo regresamos un false y mostramos el aviso correspondinete.
        //    */

        //    DataSet ds = new DataSet();
        //    DataRow dr;
        //    try
        //    {
        //        //Verificamos el tipo de código que es
        //        if (pTipoCodigo == "CodigoBarras")
        //        {
        //            //Buscamos la información del producto en función del código de barras
        //            ds = abasto.ObtenerDatosCodigoBarras(Codigo);
        //        }
        //        else
        //        {
        //            //Buscamos la información del producto en función del código interno (HT)
        //            ds = abasto.ObtenerDatosCodigoHT(Codigo);
        //        }
        //        dr = ds.Tables[0].Rows[0];
        //        ClaveReAbastecida = dr["Clave"].ToString().Trim();
        //        MultiploClave = Convert.ToSingle(dr["Multiplo"]);
        //        //txtMultiplo.Text = dr["Multiplo"].ToString();
        //        //NivelClave = dr["Nivel"].ToString().Trim();

        //        return true;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Código de Producto NO encontrado, favor de verificarlo", "Aviso");
        //        txtConfirmarProducto.Text = "";
        //        txtConfirmarProducto.Focus();
        //        return false;
        //    }

        //}
        
        private void AgregarReabasto(string pClaveReAbastecer, float pCantidadReAbastecida)
        {
            /*
             Permite agregar las recolecciones que se deben de hacer en cada localización, cada que se registra una recolección 
             se valida si con esa recoleccion se completa la recolección total de la lozalización, en caso de que si, la recolección 
             se convierte como un detalle de transferencia, en caso de que se pretendan recolectar más unidades de los solicitadas
             esto no se permitira.
            */

             //Agregamos la recolección y regresamos la suma total de lo recolectado            
            repositorio.AgregarReAbasto(Recoleccion.ID, pClaveReAbastecer, lbConfirmarLocalizacion.Text, pCantidadReAbastecida, Global.Usuario, out SumaCantidadReAbastecida);
            
            //Asignamos la suma total de lo recolectado    
            TotalReabastecido = Convert.ToSingle(SumaCantidadReAbastecida);

            lbTotReAbastecido.Text = TotalReabastecido.ToString();

                //Se valida si el total recolectado de la localizacion, es igual (Completa) a la recolección total de la lozalización, en caso de que si, 
                //la recolección la pasamos como un detalle de transferencia
            if (TotalReabastecido == Convert.ToSingle(CantidadPorReabastecer))//Convert.ToSingle(Metodos.PorRecolectarLoc))
            {
                //Se registra el total de recolectado de la localizacón como detalle de transferencia                
                repositorio.ReAbastoCompletado(Recoleccion.ID, pClaveReAbastecer, lbConfirmarLocalizacion.Text);
                //Indicamos que la recolección de la localización ha sido completada
                //RecoleccionLocCompleta = "Si";
            }
            else if (TotalReabastecido > Convert.ToSingle(CantidadPorReabastecer))
            {
                MessageBox.Show("NO está permitido rabastecer más unidades de las solicitadas. Se elimina la partida.", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                //abasto.EliminarReAbasto(Convert.ToInt32(AbastoPkg.Transferencia), pClaveReAbastecer, AbastoPkg.LocalizacionPkgDestino, pCantidadReAbastecida);
                repositorio.EliminarReAbasto(Recoleccion.ID, pClaveReAbastecer, Recoleccion.LocalizacionPkg, pCantidadReAbastecida);

                txtConfirmarProducto.Text = "";
                txtConfirmarProducto.Focus();
            }
            else
            {
                txtConfirmarProducto.Text = "";
                txtConfirmarProducto.Focus();

            }
        }

        //
        private void frmReAbastecer_Load(object sender, EventArgs e)
        {
            /*
              Al cargar la forma, damos inicio al proceso de Re-Abasto, solicitando las partidas a Re-Abastecer
              en la localización destino
            */

            //panel.Visible = false;

            btnSinAbasto.Visible = false;
            //lbNoTransferencia.Text = "No. Transferencia: " + AbastoPkg.Transferencia;
            lbNoTransferencia.Text = "ID: " + Recoleccion.ID;
            txtConfirmarProducto.Enabled = false;
            //Establecemos el inicio del proceso de ReAbasto
            //repositorio.IniciarReAbasto(Convert.ToInt32(AbastoPkg.Transferencia));
            repositorio.IniciarReAbasto(Recoleccion.ID);
            //Solicitamos las partidas correspondientes al Re-Abasto
            SolicitarPartidaParaReAbastecer();
        }

        //
        private void txtConfirmarProducto_KeyUp(object sender, KeyEventArgs e)
        {
            /////////////////////
            //Al pulsar la tecla ENTER sobre el campo confirmar producto, verificamos si la el código de barras corresponde
            //a la clave interna (HT) del producto          
            /////////////////////

            //String ClaveInterna = "";
            DataSet ds = new DataSet();

            if (e.KeyCode == Keys.Enter)
            {             
                        //if (ObtenerDatosProducto(txtConfirmarProducto.Text.Trim(), "CodigoBarras"))
                        //{
                            if (ClaveReAbastecida == lbConfirmarProducto.Text.Trim())
                            {
                                    /*Esto es por si aceptan omitir el registrar los reabastos*/

                                    //abasto.FinalizarReAbasto(Convert.ToInt32(AbastoPkg.Transferencia));
                                    repositorio.FinalizarReAbasto(Recoleccion.ID);
                                    //AbastoPkg.Transferencia = "";//Limpiamos la variable de No. de Transferencia 
                                    Recoleccion.ID = 0;
                                    MessageBox.Show("RE-ABASTO COMPLETADO!!!", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

                                    //Regresamos a la página principal
                                    this.Close();
                                    PrincipalAbastoPkg fPrincipal = new PrincipalAbastoPkg();
                                    fPrincipal.Show();                              
                            }
                            else
                            {
                                MessageBox.Show("NO coincide el código ingresado con la clave del producto, favor de verificarlo.", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);                                
                                txtConfirmarProducto.Text = "";
                                txtConfirmarProducto.Focus();
                            }

                        //}
                }
        }

        //
        private void txtConfirmarLocalizacion_KeyUp(object sender, KeyEventArgs e)
        {
            /////////////////////
            //Al pulsar la tecla ENTER sobre el campo confirmar localización, verificamos si lo registrado corresponde
            //a la localización indicada, en caso de que si, marcamos la partida como ABASTECIDA.            
            /////////////////////

            if (e.KeyCode == Keys.Enter)
            {

                tmLocalizacion.Enabled = false;

                if ((txtConfirmarLocalizacion.Text.ToUpper() == lbConfirmarLocalizacion.Text.Trim()) || (txtConfirmarLocalizacion.Text == "."))
                {                    
                    txtConfirmarProducto.Text = "";
                    txtConfirmarProducto.Enabled = true;
                    txtConfirmarProducto.Focus();
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

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{

            //    //Validar que se registre un valor en la cantidad
            //    if ((txtCantidad.Text == "") || (txtCantidad.Text == "0") || (txtCantidad.Text == null))
            //    {
            //        MessageBox.Show("Debe de registrar una cantidad mayor a cero");
            //        txtCantidad.Text = "";
            //        txtCantidad.Focus();
            //    }
            //    else
            //    {
            //        //Validar si lo registrado en el campo cantidad, tiene formato de numérico de 999999.99
            //        if (Producto.ValidaCantidad(txtCantidad.Text))
            //        {
            //            //La cantidad recolectada se determina de multiplicar el múltiplo de nivel del SKU por la cantidad capturada
            //            float CantidadReAbastecida = (Convert.ToSingle(txtCantidad.Text) * MultiploClave);
            //            AgregarReabasto(ClaveReAbastecida, CantidadReAbastecida);
            //            txtMultiplo.Text = "";
            //            txtCantidad.Text = "";
            //        }
            //        else
            //        {
            //            MessageBox.Show("Cantidad registrada incorrecta, favor de verificarla");
            //            txtCantidad.Text = "";
            //            txtCantidad.Focus();
            //        }
            //    }

            //}

        }

        private void tmLocalizacion_Tick(object sender, EventArgs e)
        {
            txtConfirmarProducto.Text = "";
        }

        private void btnSinAbasto_Click(object sender, EventArgs e)
        {
            //Regresamos a la página principal
            this.Close();
            PrincipalAbastoPkg fPrincipal = new PrincipalAbastoPkg();
            fPrincipal.Show();   
        }

    }
}