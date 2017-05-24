using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Movil_RIDA
{
    public partial class PrincipalAbastoPkg : Form
    {
        Recoleccion repositorio = new Recoleccion();
        List<ADN_SemaforoAbastoPkg> lstClavesRecolectar;

        public PrincipalAbastoPkg()
        {
            InitializeComponent();            
        }

        //
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            
            //Al cargar la página principal, lo primero que se debe de verificar es si existen recolecciones pendientes de Re-Abastecer, antes de hacer otra recolección
            //en caso de que si, primero se procede a terminar la recoleccón pendiente de Re-Abastecer, en caso de que no existan pendiente, entonces se procede
            //a generar el cálculo correspondiente al semáforo de picking.            

            DataRow registro = repositorio.VerificarAbastoConError(Global.Usuario);

            // Si el objeto es distinto de nulo, significa que exite un Abasto con status de Error
            if (registro != null)
            {
                    string clave = registro[0].ToString();
                    string ID = registro[1].ToString();

                    //Primero se debe de concluir con el Re-Abasto de la recolección pendiente, por tal motivo sólo se habilita el botón de Re-Abastecer.
                    btnRecolectar.Enabled = false;
                    btnAbastecer.Enabled = false;
                    btnAbastecer.BackColor = Color.Red;
                    btnAbastecer.ForeColor = Color.Black;

                    string msj = string.Format("ERROR!!! NO se pudo generar lote de abasto en SL del Producto {0}, TR:{1} ", clave, ID);
                    lbClavesDelSemaforo.Text = msj;
                    lbClavesEnRojo.Text = "";
                    lbClavesEnAmarillo.Text = "";
                    lbClavesEnVerde.Text = "";
                    return;
            }

            int idPendiente = repositorio.VerificarAbastoPendiente(Global.Usuario);

            if (idPendiente > 0)
            {
                Recoleccion.ID = idPendiente;

                //Primero se debe de concluir con el Re-Abasto de la recolección pendiente, por tal motivo sólo se habilita el botón de Re-Abastecer.
                btnRecolectar.Enabled = false;
                btnAbastecer.Enabled = true;
                btnAbastecer.BackColor = Color.Red;
                btnAbastecer.ForeColor = Color.Black;

                string msj = string.Format(" Existen recolecciones pendientes por Re-Abastecer, TR: {0}", Recoleccion.ID);
                lbClavesDelSemaforo.Text = msj;
                lbClavesEnRojo.Text = "";
                lbClavesEnAmarillo.Text = "";
                lbClavesEnVerde.Text = "";                
            }
            else
            {
                int rojas = 0;
                int amarillas = 0;
                int verdes = 0;

                lbClavesDelSemaforo.Text = "Generando cálculo... ";
                
                //Generamos el cálculo del semaforo de las claves asignadas al usuario
                repositorio.GenerarAbastoPicking(Global.Usuario);

                lstClavesRecolectar = new List<ADN_SemaforoAbastoPkg>();
                lstClavesRecolectar = repositorio.GetClavesPorRecolectar(Global.Usuario);

                foreach (var item in lstClavesRecolectar)
                {
                    switch (item.Semaforo)
                    {                        
                        case "ROJO":
                            rojas++;
                            break;
                        case "AMARILLO":
                            amarillas++;
                            break;
                        case "VERDE":
                            verdes++;
                            break;
                        default:
                            break;
                    }
                }

                //Si no hay recolecciones pendientes de Re-Abastecer, sólo se habilita el Botón Recolectar
                btnRecolectar.Enabled = true;
                btnAbastecer.Enabled = false;

                //Asignamos los datos obtenidos de la clave a las variables globales del programa
                lbClavesDelSemaforo.Text = "Claves por Abastecer: ";
                lbClavesEnRojo.Text = rojas.ToString();
                lbClavesEnAmarillo.Text = amarillas.ToString();
                lbClavesEnVerde.Text = verdes.ToString();    
            }           
        }

        //
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Global.LogOut(Global.Usuario);
            this.Close();
        }

        //
        private void btnRecolectar_Click(object sender, EventArgs e)
        {            
            btnRecolectar.Enabled = false;

            try
            {
                //Cerramos la ventana principal y pasamos a la de recolección
                this.Close();
                Recolectar fRecolectar = new Recolectar();
                fRecolectar.listadoClaves = lstClavesRecolectar; //le pasamos al formulario el objeto que contiene el listado de las claves por abastecer
                fRecolectar.Show();
            }
            catch (Exception)
            {                
            }
        }

        //
        private void btnAbastecer_Click(object sender, EventArgs e)
        {            
            //Si existe alguna recolección pendiente, se manda a finalizarla
            
            //Habilitamos el botón de abastecer y inabilitamos el botón de Recolectar            
            btnAbastecer.Enabled = true;
            btnRecolectar.Enabled = false;

            try
            {
                this.Close();
                Abastecer fAbastecer = new Abastecer();
                fAbastecer.Show();
            }
            catch (Exception)
            {
            }
        }

    }
}