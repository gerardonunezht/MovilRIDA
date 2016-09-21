using System;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{

    public partial class RecolectarCantidades : Form
    {

        AbastoPkg abasto = new AbastoPkg();

        //
        public static bool CapturaExcepcion = false;
        private string RecoleccionLocCompleta = "No";//Almacena un Si, si ya se recolectaron todas las unidades de la lozalización, y un No en caso contrario
        private string SumaCantidadRecolectada;//Almacena el total de la suma de la cantidad recolectada, una vez registrada una recoleccion
        public static double TotalRecolectadoLoc = 0; //Almacena el total de unidades recolectadas al momento de la localizacion, se inicializa con 0
        public static double RestanteLoc = 0; //Almacena el total de unidades restantes para terminar la recolección en la localización, se inicializa en 0 
        private double PorRecolectarLoc = 0;       
        private double PorRecolectarLocMultiplo = 0;//Almacena el total de unidades a recolectar de la localización, en función del múltiplo de abasto de la clave a recolectar        
        
        public RecolectarCantidades()
        {
            InitializeComponent();
        }

        //
        private void AgregarRecoleccion(string pClaveRecolectada, float pCantidadRecolectada)
        {
            /*
            Permite agregar las recolecciones que se deben de hacer en cada localización, cada que se registra una recolección 
            se valida si con esa recoleccion se completa la recolección total de la lozalización, en caso de que si, la recolección 
            se convierte como un detalle de transferencia, en caso de que se pretendan recolectar más unidades de los solicitadas
            esto no se permitira.
            */

            //Validamos si la clave recolectada coincide con la clave a recolectar

            if (AbastoPkg.ClaveRecolectar == pClaveRecolectada.ToString())
            {
                //Agregamos la recolección y regresamos la suma total de lo recolectado                
                abasto.AgregarRecoleccion(Convert.ToInt32(AbastoPkg.Transferencia), AbastoPkg.ClaveRecolectar, AbastoPkg.LocalizacionOrigenRecolectar, pCantidadRecolectada, AbastoPkg.LocalizacionPkgDestino, Global.Usuario, out SumaCantidadRecolectada);
                
                //Asignamos la suma total de lo recolectado    
                TotalRecolectadoLoc = Convert.ToSingle(SumaCantidadRecolectada);
                
                //Calculamos la cantidad restante por recolectar en la localización
                RestanteLoc = PorRecolectarLoc - TotalRecolectadoLoc;

                //Mostramos en pantalla la cantidad total recolectada en la localización y el restante por recolectar
                lbRecolectado.Text = TotalRecolectadoLoc.ToString();
                lbPorRecolectar.Text = RestanteLoc.ToString();

                //Limpiamos objetos
                txtCB.Text = "";
                txtCantidad.Text = "";
                txtCB.Focus();

                //Se valida si el total recolectado de la localizacion, es igual (Completa) a la recolección total de la lozalización                               
                if (TotalRecolectadoLoc == PorRecolectarLoc)
                {
                    //Indicamos que la recolección de la localización ha sido completada
                    RecoleccionLocCompleta = "Si";

                    TotalRecolectadoLoc = 0;
                    RestanteLoc = 0;

                    lbRecolectado.Text = TotalRecolectadoLoc.ToString();
                    lbPorRecolectar.Text = RestanteLoc.ToString();
                }
                else
                {
                    //Establecemos el valor a falso, para que ya no se puedan registrar excepciones del tipo cero, una vez realizada una recolección
                    AbastoPkg.PermiteRegistrarExepcionCero = false;
                }

                //Se valida si el total recolectado de la localizacion es mayor a lo solicitado a recolectar de la localización, si es asi, 
                //se manda un aviso para informar que esto no es posible y se aborta la recoelcción previa
                if (TotalRecolectadoLoc > PorRecolectarLoc)
                {
                    MessageBox.Show("NO está permitido recolectar más unidades de las solicitadas.", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    //Eliminamos la última recolección registrada                   
                    abasto.EliminarRecoleccion(Convert.ToInt32(AbastoPkg.Transferencia), AbastoPkg.ClaveRecolectar, AbastoPkg.LocalizacionOrigenRecolectar, pCantidadRecolectada, out SumaCantidadRecolectada);
                    
                    //Actualizamos las cantidades recolectadas
                    TotalRecolectadoLoc = Convert.ToSingle(SumaCantidadRecolectada);
                    lbRecolectado.Text = TotalRecolectadoLoc.ToString();
                    RestanteLoc = PorRecolectarLoc - TotalRecolectadoLoc;
                    lbPorRecolectar.Text = RestanteLoc.ToString();
                }
            }
            else
            {
                MessageBox.Show("Clave recolectada no coincide con la Indicada a Recolectar.", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);                
                txtCB.Text = "";
                txtCantidad.Text = "";
                txtMultiplo.Text = "";
                txtCB.Focus();
            }                            
        }

        //
        private void frmRecolectarCantidades_Load(object sender, EventArgs e)
        {
            AbastoPkg.PermiteRegistrarExepcionCero = true;

            //convertimos el valor string al tipo double para facilita los cálculos
            PorRecolectarLoc = Convert.ToSingle(AbastoPkg.PorRecolectarLoc);
            PorRecolectarLocMultiplo = Convert.ToSingle(AbastoPkg.PorRecolectarLoc);

            //convertimos el valor string al tipo float para facilita los cálculos
            float MultiploAbastoPkg = Convert.ToSingle(AbastoPkg.MultiploAbastoPkg);

            TotalRecolectadoLoc = 0;
            RestanteLoc = 0;

            lbClave.Text = AbastoPkg.ClaveRecolectar;
            lbDescripcion.Text = AbastoPkg.DescrClaveRecolectar;
            lbMultAbasto.Text = AbastoPkg.MultiploAbastoPkg;
            lbTrnf.Text = AbastoPkg.Transferencia;
            lbLocalizacion.Text = AbastoPkg.LocalizacionOrigenRecolectar;

            if (AbastoPkg.LocPermiteCapturarMultiplo == "SI")
            {
                txtCantidad.Visible = true;
                lbCantidad.Visible = true;
            }
            else
            {
                txtCantidad.Visible = false;
                lbCantidad.Visible = false;
            }

            //determinamos si la localizaión continene poquedades
            double poquedades = PorRecolectarLoc / MultiploAbastoPkg;

            if (poquedades < 1)
            {

                lbTotEmp.Text = "0";

                //es poquedad, se debe de recolectar el total de la localización
                lbRecolectado.Text = TotalRecolectadoLoc.ToString();
                lbPorRecolectar.Text = PorRecolectarLoc.ToString();
            }
            else
            {
                //NO es poquedad, se debe de recolectar el total de paquetes en función del multiplo de abasto
 
                //Obtenemos el total de paquetes (parte entera) que se pueden tomar de la localización
                double TotalEmpaques = Math.Floor(PorRecolectarLoc / MultiploAbastoPkg);
                lbTotEmp.Text = TotalEmpaques.ToString();

                //Calculamos las unidades totales a recolectar de la localización en función del los paquetes calculados
                PorRecolectarLoc = TotalEmpaques * MultiploAbastoPkg;

                lbRecolectado.Text = TotalRecolectadoLoc.ToString();
                lbPorRecolectar.Text = PorRecolectarLocMultiplo.ToString();
            }

            //Este IF sirve para no perder los datos TotalRecolectado y Restante, en caso de llamar a la pantalla de Excepción
            if (CapturaExcepcion == false)
            {
                //Al cargar la forma el restante es igual al total por recolectar
                lbPorRecolectar.Text = PorRecolectarLoc.ToString();
            }
            else
            {
                //Mostramos en pantalla la cantidad total recolectada en la localización y el restante por recolectar
                lbRecolectado.Text = TotalRecolectadoLoc.ToString();
                lbPorRecolectar.Text = RestanteLoc.ToString();
            }
            txtCB.Focus();
        }

        //
        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            /*
              Al dar enter sobre el campo cantidad se valida que se haya registrado una cantidad y que esta a su vez
              sea mayor a cero, posterior a esto de valida que la cantidad concuerde con el formato de cantidad
            */

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
                    if (Producto.ValidaCantidad(txtCantidad.Text))
                    {
                        //La cantidad recolectada se determina de multiplicar el múltiplo de nivel del SKU por la cantidad capturada
                        float CantidadRecolectada = (Convert.ToSingle(txtCantidad.Text) * abasto.Multiplo);
                        AgregarRecoleccion(abasto.Clave, CantidadRecolectada);                         
                    }
                    else
                    {
                        MessageBox.Show("Cantidad registrada incorrecta, favor de verificarla");
                        txtCantidad.Text = "";
                        txtCantidad.Focus();
                    }
                }

                //Verificamos si la recolección esta completa
                if (RecoleccionLocCompleta == "Si")
                {
                    this.Close();
                    RecolectarLoc fRecolectarLoc = new RecolectarLoc();
                    fRecolectarLoc.Show();
                }
            }          
        }
        
        //
        private void txtCB_KeyUp(object sender, KeyEventArgs e)
        {
            /*
              Al dar enter sobre sobre el campo código se valida que se haya registrado un código, para buscar   
              el código según corresponda, ya sea de barras o código interno.
            */

            if (e.KeyCode == Keys.Enter)
            {
                //Validamos que se digite un código a buscar
                if ((txtCB.Text == "") || (txtCB.Text == null))
                {
                    MessageBox.Show("Debe de registrar un código de producto ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtCB.Focus();
                }
                else
                {

                    //Obtenemos los datos generales del codigo de barras capturado, se asignan a la varibale Clave y Multiplo
                    //de la clase heredada producto                                  
                    abasto.ObtenerDatosProducto(txtCB.Text.Trim(), "");

                    if (abasto.Clave != "")
                    {
                        //Asignamos el múltiplo del artículo
                        txtMultiplo.Text = abasto.Multiplo.ToString();

                        if (AbastoPkg.LocPermiteCapturarMultiplo == "NO")
                        {
                            //Agregamos la recolección del artículo, no importando si el multiplo es diferente del sugerido.
                            AgregarRecoleccion(abasto.Clave, abasto.Multiplo);
                        }
                        else
                        {
                            txtCantidad.SelectAll();
                            txtCantidad.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Código de Producto NO encontrado, favor de verificarlo", "Aviso");
                        txtCB.Text = "";
                        txtMultiplo.Text = "";
                        txtCantidad.Text = "";
                        txtCB.Focus();
                    }

                    //Verificamos si la recolección esta completa
                    if (RecoleccionLocCompleta == "Si")
                    {
                        this.Close();
                        RecolectarLoc fRecolectarLoc = new RecolectarLoc();                        
                        fRecolectarLoc.Show();
                    }
                }
            }
        }

        //
        private void btnExcepcion_Click(object sender, EventArgs e)
        {
            //Regresamos a la pantalla de SolicitarLoc para solicitar otra
            this.Close();
            Excepcion fExcepcion = new Excepcion();
            fExcepcion.Show();
        }

    }//Clase o forma

}//namespace