using System;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class ConfirmarLocalizacion : Form
    {
        Conteo conteo = new Conteo();
        DataTable LocalizacionesContar = new DataTable();

        // constructor
        public ConfirmarLocalizacion()
        {
            InitializeComponent();
        }

        private void ConfirmarLocalizacion_Load(object sender, EventArgs e)
        {
            label1.Text = Conteo.ClaveContar;
            label2.Text = Conteo.DescripcionContar;

            LocalizacionesContar = conteo.ObtenerLocalizacionesContar(Conteo.NoConteo);
            lstLocalizaciones.DataSource = LocalizacionesContar; 
            lstLocalizaciones.ValueMember = "Almacen";
            lstLocalizaciones.DisplayMember = "Localizacion";

            txtLocalizacion.Focus();          
        }

        private bool BuscarLocalizacion(string Localizacion)
        {
            bool Existe=false;
            foreach (DataRow localizacion in LocalizacionesContar.Rows)
            {
                if (Localizacion.Trim().ToUpper() == localizacion[1].ToString().Trim().ToUpper())
                {
                    Conteo.Almacen = localizacion[0].ToString().Trim().ToUpper();
                    Existe = true;
                    break;
                }
            }            
            return Existe;
        }

        private void btnExcepcion_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                ExcepcionConteo fExcepcion = new ExcepcionConteo();
                fExcepcion.Show();
                this.Show();
            }
            catch (Exception)
            {                
            }

        }

        private void txtLocalizacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((BuscarLocalizacion(txtLocalizacion.Text.Trim().ToUpper())) || (txtLocalizacion.Text.Trim().ToUpper() == "0"))
                {
                    Conteo.Localizacion = txtLocalizacion.Text.Trim().ToUpper();
                    this.Close();
                    RegistrarConteo fContar = new RegistrarConteo();
                    fContar.Show();
                }
                else
                {
                    MessageBox.Show("Localización capturada NO coindice con el listado.");
                }
            }
        }

    }
}