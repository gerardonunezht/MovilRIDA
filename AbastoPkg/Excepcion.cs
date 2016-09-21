using System;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class Excepcion : Form
    {

        AbastoPkg abasto = new AbastoPkg();

        private string SumaCantidadRecolectada;//Almacena el total de la suma de la cantidad recolectada, una vez registrada una recoleccion

        public Excepcion()
        {
            InitializeComponent();
        }

        private void btnTruncar_Click(object sender, EventArgs e)
        {
            /*
              Permite terminar previamente con la recolección en una localización, esto debido a dos posibilidades:  
              la primera, que al estar recolectándo físicamente no se cuente con la mercancia 
              la segunda, que se puedan registrar recolecciones menores a las indicadas, con la finalidas de no abrir cajas para recolectar unidades pequeñas            
            */

            abasto.RegistrarExcepcion(Convert.ToInt32(AbastoPkg.Transferencia), AbastoPkg.ClaveRecolectar, AbastoPkg.LocalizacionOrigenRecolectar, "Recoleccion Truncada");
            //Regresamos a la pantalla de SolicitarLoc para solicitar otra
            this.Close();
            RecolectarLoc fRecolectarLoc = new RecolectarLoc();
            fRecolectarLoc.Show();           
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            /*
              Permite terminar previamente con la recolección en una localización indicando que en dicha
              localización no se encontró cantidad física alguna para recolectar  
            */

            //Omitimos la localización marcandola con cero            
            abasto.AgregarRecoleccion(Convert.ToInt32(AbastoPkg.Transferencia), AbastoPkg.ClaveRecolectar, AbastoPkg.LocalizacionOrigenRecolectar, 0, AbastoPkg.LocalizacionPkgDestino, Global.Usuario, out SumaCantidadRecolectada);

            abasto.RegistrarExcepcion(Convert.ToInt32(AbastoPkg.Transferencia), AbastoPkg.ClaveRecolectar, AbastoPkg.LocalizacionOrigenRecolectar, "Existencia Cero");

            //Regresamos a la pantalla de SolicitarLoc para solicitar otra
            this.Close();
            RecolectarLoc fRecolectarLoc = new RecolectarLoc();
            fRecolectarLoc.Show();
        }

        private void frmExcepcion_Load(object sender, EventArgs e)
        {

            if (RecolectarCantidades.TotalRecolectadoLoc>0)
            {
                btnCero.Enabled = false;
                btnTruncar.Enabled = true;
            }
            else
            {
                btnCero.Enabled = true;
                btnTruncar.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            RecolectarCantidades Regresar = new RecolectarCantidades();
            Regresar.Show();

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (Global.Usuario == "6001")
            {
                //Finalizamos el proceso de recolección de claves.
                abasto.FinalizarRecoleccion(AbastoPkg.Transferencia, AbastoPkg.LocalizacionPkgDestino);

                this.Close();
                Abastecer fAbastecer = new Abastecer();
                fAbastecer.Show();
            }
        }

    }
}