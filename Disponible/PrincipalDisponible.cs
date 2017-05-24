using System;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class PrincipalDisponible : Form
    {
        Disponible disponible = new Disponible();
        Product producto = new Product();

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

            DataRow registro = disponible.VerificarTransferenciaError(Global.Usuario);
            if (registro != null)
            {
                //Asignamos el número de Transferencia que corresponde a la recolección pendiente de Re-Abastecer
                Disponible.ID = registro["ID"].ToString().TrimEnd();
                Disponible.ClaveColocar = registro["InvtId"].ToString().TrimEnd();

                string msj = string.Format("NO se pudo generar lote de TRANSFERENCIA para Disponible del producto: {0} con ID: {1} ", Disponible.ClaveColocar, Disponible.ID);

                btnIniciar.Enabled = false;
                txtSeleccionar.Enabled = false;
                MessageBox.Show(msj);
            }
            else
            {
                var datos = disponible.ObtenerProductosAceptados();
                if (datos!=null)
                {
                    dgDisponible.DataSource = datos;
                    btnIniciar.Enabled = true;
                    txtSeleccionar.Enabled = true;
                    txtSeleccionar.Focus();                    
                }
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
                MessageBox.Show(Disponible.ID.ToString()+ " - " + Global.Usuario);
                DataRow registro = disponible.IniciarProcesoDisponible(Disponible.ID, Global.Usuario);

                int error = Convert.ToInt16(registro[0]);
                string msjError = registro[1].ToString();

                if (error == 0) 
                {                   
                    LocalizacionesDisponible fLocalizaciones = new LocalizacionesDisponible();
                    this.Close();
                    fLocalizaciones.Show();
                }
                else if (error == 1) 
                {
                    MessageBox.Show(msjError);
                    LocalizacionesDisponible fLocalizaciones = new LocalizacionesDisponible();
                    this.Close();
                    fLocalizaciones.Show();
                }
                else
                {
                    MessageBox.Show(msjError);
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
                            dr = disponible.SeleccionarProductoDisponible(producto.Clave);

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