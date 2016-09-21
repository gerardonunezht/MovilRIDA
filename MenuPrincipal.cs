using System;
//using System.Linq;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Movil_RIDA
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public string GetCurrentPublishVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void btnInspeccion_Click(object sender, EventArgs e)
        {
            Global.Aplicacion = "INSPECCION";
            Global.Version = "1.0";
            Global.IdProcesoADN = "10"; 
            Acceso fAcceso = new Acceso();
            fAcceso.Show();
        }

        private void btnRecepcion_Click(object sender, EventArgs e)
        {
            Global.Aplicacion = "RECEPCION";
            Global.Version = "1.2";
            Global.IdProcesoADN = "5";
            Acceso fAcceso = new Acceso();
            fAcceso.Show();
        }

        private void btnAbasto_Click(object sender, EventArgs e)
        {            
            Global.Aplicacion = "ABASTO PKG";
            Global.Version = "3.0";
            Global.IdProcesoADN = "7";
            Acceso fAcceso = new Acceso();
            fAcceso.Show();
        }

        private void btnConteos_Click(object sender, EventArgs e)
        {
            Global.Aplicacion = "CONTEOS";
            Global.Version = "2.0";
            Global.IdProcesoADN = "11"; 
            Acceso fAcceso = new Acceso();
            fAcceso.Show();
        }

        private void btnDisponible_Click(object sender, EventArgs e)
        {
            Global.Aplicacion = "DISPONIBLE";
            Global.Version = "1.0";
            Global.IdProcesoADN = "12";
            Acceso fAcceso = new Acceso();
            fAcceso.Show();            
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            lbCompilacion.Text = "Versión compilación:  "+GetCurrentPublishVersion();
        }
    }
}