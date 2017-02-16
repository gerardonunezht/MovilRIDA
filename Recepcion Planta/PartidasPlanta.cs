using System;
using System.Windows.Forms;
using System.Data;

namespace Movil_RIDA
{
    public partial class PartidasPlanta : Form
    {

        //Partida partida = new Partida();
        RecepcionPlanta recepcion = new RecepcionPlanta();

        public PartidasPlanta()
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
            lbCantidad.Visible = false;
            txtCantidad.Visible = false;
            
        }
        
        private void ValidaRecepcionPartidaCompleta()
        {
            
            recepcion.ObtenerCantidadRecibida(RecepcionPlanta.TrnsfrDocNbr, recepcion.Clave);
            

            lbCantRecibida.Text = recepcion.CantidadRecibida.ToString().Trim();
            lbCantOrdenada.Text = recepcion.CantidadOrdenada.ToString().Trim();

            /*if (recepcion.CantidadRecibida < recepcion.CantidadOrdenada)
            {
                MessageBox.Show("La partida: " + recepcion.Clave + " se ha recibido con un faltante respecto la cantidad de la transferencia. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                Limpiar();          
            }
            else 
             */
            if (recepcion.CantidadRecibida > recepcion.CantidadOrdenada)
            {
                MessageBox.Show("No se puede recibir la el articulo:"+recepcion.Clave+" con excedente. Favor de verificar.", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }else if (recepcion.CantidadRecibida == recepcion.CantidadOrdenada)
            {
                MessageBox.Show("La partida: " + recepcion.Clave + " se ha recibido totalmente conforme a la transferencia: "+RecepcionPlanta.TrnsfrDocNbr.Trim() , "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                Limpiar();
                if (recepcion.PartidasCompletas)
                {
                    MessageBox.Show("La transferencia " + RecepcionPlanta.TrnsfrDocNbr.ToString().Trim() + " se ha recibido totalmente.","AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    Limpiar();
                    PrincipalRecepcionPlanta fRecepcion = new PrincipalRecepcionPlanta();
                    fRecepcion.Show();
                    this.Hide();
                    
                }

            } 
        } 
        
        
        private void RegistrarPartida(float CantidadRecibida)
        {
            DataRow dr;
            if (RecepcionPlanta.TrnsfrDocNbr=="")
            {
                MessageBox.Show("No se ha registrado un número de transferencia, favor de verificar. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            //Registramos la partida en la Base de datos
            dr = recepcion.AgregarPartida(RecepcionPlanta.TrnsfrDocNbr, recepcion.CodBarras, CantidadRecibida, Global.Usuario,RecepcionPlanta.BatNbr);

            string NoError = dr[0].ToString();
            string MensajeError=dr[1].ToString();

            if (NoError == "0")
            {
                btnEliminarUltimaPartida.Enabled = true;
                txtCB.Text = "";
                txtCB.Focus();
                ValidaRecepcionPartidaCompleta();
                txtCantidad.Text = "";
                txtCantidad.Visible=false;
                lbCantidad.Visible=false;
            }
            else
            {
                MessageBox.Show(MensajeError, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                //Limpiar();
                txtCB.Text = "";
                txtCB.Focus();
                
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
                        MessageBox.Show("El código de barras registrado no está asociado a una clave de artículo, favor de verificar con Supervisor Administrativo", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
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
                if (Producto.ValidaCantidad(txtCantidad.Text) && !txtCantidad.Text.Equals("0"))
                {
                        //Cantidad a registrar es igual a la multiplicación del múltiplo del empaque del artículo por la cantidad de empaques
                        float CantidadRegistrar = Convert.ToSingle(txtCantidad.Text) * recepcion.Multiplo;

                        RegistrarPartida(CantidadRegistrar);
                
                }
                else
                {
                    MessageBox.Show("La cantidad a registrar es incorrecta, favor de verificarla.","Aviso!!!",MessageBoxButtons.OK ,MessageBoxIcon.Hand,MessageBoxDefaultButton.Button1);
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
            lblTrnsfrDocNbr.Text = "# Transferencia: " + RecepcionPlanta.TrnsfrDocNbr;
            txtCB.Focus();
        }

        private void Partidas_Closed(object sender, EventArgs e)
        {           
            Global.LogOut(Global.Usuario);
            Application.Exit();
        }



        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Seguro que desea FINALIZAR la recepcion de la transferencia? ", "AVISO!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
 
                if (recepcion.FinalizarRecepcion(RecepcionPlanta.TrnsfrDocNbr))
                {
                    if ((recepcion.CantidadRecibida) < (recepcion.CantidadOrdenada))
                    {
                        MessageBox.Show("La transferencia: " + RecepcionPlanta.TrnsfrDocNbr + " se ha recibido con un faltante. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        Limpiar();
                    }
                    PrincipalRecepcionPlanta fRecepcion = new PrincipalRecepcionPlanta();
                    fRecepcion.Show();
                    this.Hide();
                }
            }
        }
        
        private void btnEliminarUltimaPartida_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Está seguro de eliminar el último registro de partida escaneado?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (resp == DialogResult.Yes)
            {
                //Registramos la partida en la Base de datos
                int res = recepcion.EliminarPartida(RecepcionPlanta.TrnsfrDocNbr, recepcion.Clave, Global.Usuario);

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

  
        
    }//Forma
}//namespace