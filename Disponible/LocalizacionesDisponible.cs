using System;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class LocalizacionesDisponible : Form
    {
        Disponible disp = new Disponible();
        static bool MostrarVacias = false;
        
        // constructor
        public LocalizacionesDisponible()
        {
            InitializeComponent();
        }

        private void LocalizacionesDisponible_Load(object sender, EventArgs e)
        {            
            dgLocalizaciones.DataSource = disp.ObtenerLocalizacionesProductoExistencia(Disponible.ClaveColocar);
            btnLocalizaciones.Text = "Sugerir: Vacias";
            MostrarVacias = true;

            lbColocar.Text = "A COLOCAR: " + Disponible.CantColocar;
            lbSeleccionado.Text = "SEL.: " + Disponible.ClaveColocar;

            txtLocalizacion.Focus();
        }

        private void btnLocalizaciones_Click(object sender, EventArgs e)
        {
            if (MostrarVacias)
            {
                dgLocalizaciones.DataSource = disp.ObtenerLocalizacionesVacias();
                btnLocalizaciones.Text = "Sugerir: Con Existencia";
                MostrarVacias = false;
            }
            else
            {
                dgLocalizaciones.DataSource = disp.ObtenerLocalizacionesProductoExistencia(Disponible.ClaveColocar);
                btnLocalizaciones.Text = "Sugerir: Vacias";
                MostrarVacias = true;
            }
        }

        private void txtLocalizacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Disponible.Localizacion = txtLocalizacion.Text.Trim().ToUpper();
                this.Close();
                RegistrarDisponible fRegistrar = new RegistrarDisponible();
                fRegistrar.Show();
            }
        }

    }
}