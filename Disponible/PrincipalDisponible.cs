using System;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class PrincipalDisponible : Form
    {
        Disponible disp = new Disponible();

        public PrincipalDisponible()
        {
            InitializeComponent();
        }

        private void PrincipalDisponible_Load(object sender, EventArgs e)
        {
            //Limpiamos objetos al iniciar
            Disponible.ID = null;
            Disponible.ClaveColocar = null;
            Disponible.DescripcionProd = null;
            Disponible.CantColocar = "0";
            lbColocar.Text = "A COLOCAR: " + Disponible.CantColocar;
            lbSeleccionado.Text = "SEL.: " + Disponible.ClaveColocar;

            btnIniciar.Enabled = false;


            DataSet dsError = new DataSet();
            DataRow drError;

            //Mandamos llamar el método que verifica si existen transferencias fallidas (es decir, con error)
            dsError = disp.VerificarTransferenciaError(Global.Usuario);
            int TransferenciasDisponibleConError = dsError.Tables[0].Rows.Count;


            //Si existen abastos con status de Error, entonces:
            if (TransferenciasDisponibleConError > 0)
            {
                //Asignamos el número de Transferencia que corresponde a la recolección pendiente de Re-Abastecer
                drError = dsError.Tables[0].Rows[0];
                Disponible.ID = drError["ID"].ToString().TrimEnd();
                Disponible.ClaveColocar = drError["InvtId"].ToString().TrimEnd();

                string msj = string.Format("NO se pudo generar lote de TRANSFERENCIA para Disponible del producto: {0} con ID: {1} ", Disponible.ClaveColocar, Disponible.ID);
                
                /*
                lbClavesDelSemaforo.Text = "ERROR"; //msj;
                lbClavesEnRojo.Text = "";
                lbClavesEnAmarillo.Text = "";
                lbClavesEnVerde.Text = "";
                */
                btnIniciar.Enabled = false;
                txtSeleccionar.Enabled = false;
                MessageBox.Show(msj);
            }
            else
            {
                DataSet ds = disp.obtenerProductosAceptados();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgDisponible.DataSource = ds.Tables[0];
                    btnIniciar.Enabled = true;
                    txtSeleccionar.Enabled = true;
                    txtSeleccionar.Focus();
                }
            }


            /*
            try
            {

            }
            catch (Exception)
            {
                MessageBox.Show("Error al tratar de obtener los conteos programados.");
            }
            */

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Global.LogOut(Global.Usuario);
            this.Close();
        }

        private void dgDisponible_CurrentCellChanged(object sender, EventArgs e)
        {
            int columnIndex = dgDisponible.CurrentCell.ColumnNumber;
            int rowIndex = dgDisponible.CurrentCell.RowNumber;

            Disponible.ID = dgDisponible[rowIndex, 0].ToString().Trim();
            Disponible.ClaveColocar = dgDisponible[rowIndex, 1].ToString().Trim();
            Disponible.DescripcionProd = dgDisponible[rowIndex, 2].ToString().Trim();
            Disponible.CantColocar = dgDisponible[rowIndex, 3].ToString().Trim();
            lbColocar.Text = "A COLOCAR: " + Disponible.CantColocar;
            lbDescripcion.Text = Disponible.DescripcionProd;
            lbSeleccionado.Text = "SEL.: "+Disponible.ClaveColocar;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (Disponible.ClaveColocar != null)
            {
                DataRow resp = disp.iniciarProcesoDisponible(Disponible.ID, Global.Usuario);

                if (resp[0].ToString()=="0") 
                {                   
                    LocalizacionesDisponible fLocalizaciones = new LocalizacionesDisponible();
                    this.Close();
                    fLocalizaciones.Show();
                }
                else if (resp[0].ToString() == "1") 
                {
                    MessageBox.Show(resp[1].ToString());
                    LocalizacionesDisponible fLocalizaciones = new LocalizacionesDisponible();
                    this.Close();
                    fLocalizaciones.Show();
                }
                else
                {
                    MessageBox.Show(resp[1].ToString());
                }

            }
            else
            {
                MessageBox.Show("Favor de seleccionar algún producto.");
            }
        }

        private void txtSeleccionar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Validamos que se digite un código a buscar
                if ((txtSeleccionar.Text == "") || (txtSeleccionar.Text == null))
                {
                    MessageBox.Show("Debe de registrar un código de producto. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtSeleccionar.Focus();
                }
                else
                {
                    //Obtenemos los datos generales del codigo de barras capturado                                                       
                    disp.ObtenerDatosProducto(txtSeleccionar.Text.Trim(), Global.IdProcesoADN);

                    if (disp.Clave != "")
                    {
                        DataRow dr;
                        try
                        {
                            dr = disp.SeleccionarProductoDisponible(disp.Clave);

                            Disponible.ID = dr["ID"].ToString().Trim();
                            Disponible.ClaveColocar = dr["Invtid"].ToString().Trim();
                            Disponible.DescripcionProd = dr["Descr"].ToString().Trim();
                            Disponible.CantColocar = dr["Cantidad"].ToString().Trim();
                            lbColocar.Text = "A COLOCAR: " + Disponible.CantColocar;
                            lbDescripcion.Text = Disponible.DescripcionProd;
                            lbSeleccionado.Text = "SEL.: " + Disponible.ClaveColocar;   
                        }
                        catch (Exception)
                        {
                            lbColocar.Text = "A COLOCAR: ";
                            lbDescripcion.Text = "";
                            lbSeleccionado.Text = "SEL.: ";
                        }                                               
                    }
                    else
                    {
                        MessageBox.Show("El código de barras registrado no está asociado a una clave de artículo, favor de verificarlo", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        txtSeleccionar.Text = "";
                        txtSeleccionar.Focus();
                    }
                }
                txtSeleccionar.Text = "";
            }

        }

    }
}