using System;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class PrincipalConteos : Form
    {

        Conteo conteo = new Conteo();

        
        public PrincipalConteos()
        {
            InitializeComponent();
        }

        private void PrincipalConteos_Load(object sender, EventArgs e)
        {
            btnIniciar.Enabled = false;
            try
            {
                DataSet ds = conteo.obtenerConteosProgramados();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgProgramados.DataSource = ds.Tables[0];
                    btnIniciar.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al tratar de obtener los conteos programados.");
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (Conteo.ClaveContar!=null)
            {
                conteo.congelarExistenciasConteo(Conteo.NoConteo, Conteo.ClaveContar);
                ConfirmarLocalizacion fLocalizacion = new ConfirmarLocalizacion();
                this.Close();
                fLocalizacion.Show();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el producto a contar.");
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Global.LogOut(Global.Usuario);
            this.Close();
        }

        private void dgProgramados_CurrentCellChanged(object sender, EventArgs e)
        {
            int columnIndex = dgProgramados.CurrentCell.ColumnNumber;
            int rowIndex = dgProgramados.CurrentCell.RowNumber;

            Conteo.NoConteo = dgProgramados[rowIndex, 0].ToString().Trim();
            Conteo.ClaveContar = dgProgramados[rowIndex, 1].ToString().Trim();
            Conteo.DescripcionContar = dgProgramados[rowIndex, 2].ToString().Trim();
            lbDescripcion.Text = Conteo.DescripcionContar;                               
        }

    }


}