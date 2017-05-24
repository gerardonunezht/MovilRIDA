using System;
using System.Windows.Forms;
using System.Drawing;

namespace Movil_RIDA
{
    public partial class Excepcion : Form
    {


        //AbastoPkg abasto = new AbastoPkg();
        Recoleccion repositorio = new Recoleccion();

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

            //repositorio.RegistrarExcepcion(Convert.ToInt32(AbastoPkg.Transferencia), AbastoPkg.ClaveRecolectar, AbastoPkg.LocalizacionOrigenRecolectar, "Recoleccion Truncada");
            repositorio.RegistrarExcepcion(Recoleccion.ID, Recoleccion.Clave, Recoleccion.LocalizacionOrigenRecolectar, "Recoleccion Truncada");
            
            //Regresamos a la pantalla de SolicitarLoc para solicitar otra
            SolicitarLocalizacion();           
        }

        private void SolicitarLocalizacion()
        {
            try
            {
                this.Close();
                RecolectarLoc fRecolectarLoc = new RecolectarLoc();
                fRecolectarLoc.Show();
            }
            catch (Exception)
            {
            }
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            /*
              Permite terminar previamente con la recolección en una localización indicando que en dicha
              localización no se encontró cantidad física alguna para recolectar  
            */

            //Omitimos la localización marcandola con cero            
            //abasto.AgregarRecoleccion(Convert.ToInt32(AbastoPkg.Transferencia), AbastoPkg.ClaveRecolectar, AbastoPkg.LocalizacionOrigenRecolectar, 0, AbastoPkg.LocalizacionPkgDestino, Global.Usuario, out SumaCantidadRecolectada);
            
            //abasto.RegistrarExcepcion(Convert.ToInt32(AbastoPkg.Transferencia), AbastoPkg.ClaveRecolectar, AbastoPkg.LocalizacionOrigenRecolectar, "Existencia Cero");
            SolicitarLocalizacion();
        }

        private void frmExcepcion_Load(object sender, EventArgs e)
        {
            //if (RecolectarCantidades.recolectadoLoc > 0)
            //{
            //    btnCero.Enabled = false;
            //    btnTruncar.Enabled = true;
            //}
            //else
            //{
            //    btnCero.Enabled = true;
            //    btnTruncar.Enabled = false;
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            RecolectarCantidades Regresar = new RecolectarCantidades();
            Regresar.Show();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //Solo el abastecedor de Picking 2 (6001) puede Finalizar los abastos
            if (Global.Usuario == "6001")
            {
                //Finalizamos el proceso de recolección de claves.
                //abasto.FinalizarRecoleccion(AbastoPkg.Transferencia, AbastoPkg.LocalizacionPkgDestino);
                repositorio.FinalizarRecoleccion(Recoleccion.ID, Recoleccion.LocalizacionPkg);

                this.Close();
                Abastecer fAbastecer = new Abastecer();
                fAbastecer.Show();
            }
        }

    }
}