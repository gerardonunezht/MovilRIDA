using System;
using System.Data;
using System.Windows.Forms;
using Movil_RIDA.Clases;

namespace Movil_RIDA
{
    public partial class PrincipalDisponiblePlanta : Form
    {
        DisponiblePlanta disp = new DisponiblePlanta();
        Product producto = new Product();

        public PrincipalDisponiblePlanta()
        {
            InitializeComponent();
        }

        private void PrincipalDisponible_Load(object sender, EventArgs e)
        {
            try
            {
                //Limpiamos objetos al iniciar
                DisponiblePlanta.ID = null;
                DisponiblePlanta.ClaveColocar = null;
                DisponiblePlanta.DescripcionProd = null;
                DisponiblePlanta.CantColocar = "0";
                lbColocar.Text = "A COLOCAR: " + DisponiblePlanta.CantColocar;
                lbSeleccionado.Text = "SEL.: " + DisponiblePlanta.ClaveColocar;

                btnIniciar.Enabled = false;

                DataSet dsError = new DataSet();
                DataRow drError;
                
                //Mandamos llamar el método que verifica si existen transferencias fallidas (es decir, con error)
                dsError = disp.VerificarTransferenciaError(Global.Usuario);
                int TransferenciasDisponibleConError = dsError.Tables[0].Rows.Count;

                //Si existen tranferencias con status de Error, entonces:
                if (TransferenciasDisponibleConError > 0)
                {
                    //Asignamos el número de Transferencia que corresponde a la recolección pendiente de Re-Abastecer
                    drError = dsError.Tables[0].Rows[0];
                    DisponiblePlanta.ID = drError["ID"].ToString().TrimEnd();
                    DisponiblePlanta.ClaveColocar = drError["InvtId"].ToString().TrimEnd();

                    string msj = string.Format("NO se pudo generar lote de TRANSFERENCIA EN SOLOMON para Disponible del producto: {0} con ID: {1} , verificar con SUPERVISOR ADMINISTRATIVO", DisponiblePlanta.ClaveColocar, DisponiblePlanta.ID);
                    btnIniciar.Enabled = false;
                    txtSeleccionar.Enabled = false;
                    MessageBox.Show(msj);
                    this.Hide();
                }
                else
                {
                    DataSet ds = disp.obtenerProductosRegistrados();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgDisponible.DataSource = ds.Tables[0];
                        btnIniciar.Enabled = true;
                        txtSeleccionar.Enabled = true;
                        txtSeleccionar.Focus();
                    }
                }
            
            }
            catch (Exception)
            {
                MessageBox.Show("Error al tratar de obtener los articulos para disponible programados.");
            }
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

            DisponiblePlanta.ID = dgDisponible[rowIndex, 0].ToString().Trim();
            DisponiblePlanta.ClaveColocar = dgDisponible[rowIndex, 1].ToString().Trim();
            DisponiblePlanta.DescripcionProd = dgDisponible[rowIndex, 2].ToString().Trim();
            DisponiblePlanta.CantColocar = dgDisponible[rowIndex, 3].ToString().Trim();
            lbColocar.Text = "A COLOCAR: " + DisponiblePlanta.CantColocar;
            lbDescripcion.Text = DisponiblePlanta.DescripcionProd;
            lbSeleccionado.Text = "SEL.: " + DisponiblePlanta.ClaveColocar;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (DisponiblePlanta.ClaveColocar != null)
            {
                DataRow resp = disp.iniciarProcesoDisponiblePlanta(DisponiblePlanta.ClaveColocar, Global.Usuario,DisponiblePlanta.CantColocar);

                if (resp[0].ToString()=="0") 
                {
                    LocalizacionesDisponiblePlanta fLocalizaciones = new LocalizacionesDisponiblePlanta();
                    this.Close();
                    fLocalizaciones.Show();
                }
                else if (resp[0].ToString() == "1") 
                {
                    MessageBox.Show(resp[1].ToString());
                    LocalizacionesDisponiblePlanta fLocalizaciones = new LocalizacionesDisponiblePlanta();
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
                if (string.IsNullOrEmpty(txtSeleccionar.Text))
                {
                    MessageBox.Show("Debe de registrar un código de producto. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtSeleccionar.Focus();
                }
                else
                {
                    //Obtenemos los datos generales del codigo de barras capturado                                                       
                    producto = producto.GetDatosProducto(txtSeleccionar.Text.Trim());

                    if (!string.IsNullOrEmpty(producto.Clave))
                    {
                        DataRow dr;
                        try
                        {
                            dr = disp.SeleccionarProductoDisponible(producto.Clave);

                            DisponiblePlanta.ID = dr["ID"].ToString().Trim();
                            DisponiblePlanta.ClaveColocar = dr["Invtid"].ToString().Trim();
                            DisponiblePlanta.DescripcionProd = dr["Descr"].ToString().Trim();
                            DisponiblePlanta.CantColocar = dr["Cantidad"].ToString().Trim();
                            lbColocar.Text = "A COLOCAR: " + DisponiblePlanta.CantColocar;
                            lbDescripcion.Text = DisponiblePlanta.DescripcionProd;
                            lbSeleccionado.Text = "SEL.: " + DisponiblePlanta.ClaveColocar;
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DataSet ds = disp.obtenerProductosRegistrados();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgDisponible.DataSource = ds.Tables[0];
                btnIniciar.Enabled = true;
                txtSeleccionar.Enabled = true;
                txtSeleccionar.Focus();
            }
        }

    }
}