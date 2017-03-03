using System;
using System.Windows.Forms;
using Movil_RIDA.Clases;

namespace Movil_RIDA
{
    public partial class LocalizacionesDisponiblePlanta : Form
    {
        DisponiblePlanta disp = new DisponiblePlanta();
        static bool MostrarVacias = false;
        public LocalizacionesDisponiblePlanta()
        {
            InitializeComponent();
        }


        private void LocalizacionesDisponible_Load(object sender, EventArgs e)
        {            
            //dgLocalizaciones.DataSource = disp.ObtenerLocalizacionesVacias().Tables[0];
            //btnLocalizaciones.Text = "Mostrar: Con Existencia";

            dgLocalizaciones.DataSource = disp.ObtenerLocalizacionesProductoExistencia(DisponiblePlanta.ClaveColocar).Tables[0];
            btnLocalizaciones.Text = "Sugerir: Vacias";
            MostrarVacias = true;

            lbColocar.Text = "A COLOCAR: " + DisponiblePlanta.CantColocar;
            lbSeleccionado.Text = "SEL.: " + DisponiblePlanta.ClaveColocar;

            txtLocalizacion.Focus();

        }

        private void btnLocalizaciones_Click(object sender, EventArgs e)
        {
            if (MostrarVacias)
            {
                dgLocalizaciones.DataSource = disp.ObtenerLocalizacionesVacias().Tables[0];
                btnLocalizaciones.Text = "Sugerir: Con Existencia";
                MostrarVacias = false;
            }
            else
            {
                dgLocalizaciones.DataSource = disp.ObtenerLocalizacionesProductoExistencia(DisponiblePlanta.ClaveColocar).Tables[0];
                btnLocalizaciones.Text = "Sugerir: Vacias";
                MostrarVacias = true;
            }
        }

        private void txtLocalizacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DisponiblePlanta.Localizacion = txtLocalizacion.Text.Trim().ToUpper();
                this.Close();
                RegistrarDisponiblePlanta fRegistrar = new RegistrarDisponiblePlanta();
                fRegistrar.Show();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
            PrincipalDisponiblePlanta DispPlanta = new PrincipalDisponiblePlanta();
            DispPlanta.Show();
            this.Close();
        }

    }
}