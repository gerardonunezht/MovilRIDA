using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class PrincipalAbastoPkg : Form
    {

        AbastoPkg abasto = new AbastoPkg();

        public PrincipalAbastoPkg()
        {
            InitializeComponent();
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
            /*Se da inicio al proceso de recolección, obteniendo el número de Transferenica correspondiente*/
            btnRecolectar.Enabled = false;

            //Cerramos la ventana principal y pasamos a la de recolección
            this.Close();
            Recolectar fRecolectar = new Recolectar();
            fRecolectar.Show();
        }

        //
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            /*
            Al cargar la página principal, lo primero que se debe de verificar es si existen recolecciones pendientes de Re-Abastecer, antes de hacer otra recolección
            en caso de que si, primero se procede a terminar la recoleccón pendiente de Re-Abastecer, en caso de que no existan pendiente, entonces se procede
            a generar el cálculo correspondiente al semáforo de picking.
            */

            DataSet ds0 = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet dsError = new DataSet();
            DataRow dr,dr0, drError;

            int ExistenPendientesPorReAbastecer = 0;

            //Mandamos llamar el método que verifica si existen recolecciones pendientes de Re-Abastecer
            ds0 = abasto.VerificarReAbastoPendiente(Global.Usuario);
            ExistenPendientesPorReAbastecer = ds0.Tables[0].Rows.Count;

            //Mandamos llamar el método que verifica si existen transferencias fallidas (es decir, con error)
            dsError = abasto.VerificarAbastoError(Global.Usuario);
            int AbastosConErrorPorAbastecedor = dsError.Tables[0].Rows.Count;

            try
            {

                //Si existen abastos con status de Error, entonces:
                if (AbastosConErrorPorAbastecedor > 0)
                {
                    //Asignamos el número de Transferencia que corresponde a la recolección pendiente de Re-Abastecer
                    drError = dsError.Tables[0].Rows[0];
                    AbastoPkg.Transferencia = drError["transferencia"].ToString();
                    AbastoPkg.ClaveRecolectar = drError["Clave"].ToString();

                    //Primero se debe de concluir con el Re-Abasto de la recolección pendiente, por tal motivo sólo se habilita el botón de Re-Abastecer.
                    btnRecolectar.Enabled = false;
                    btnAbastecer.Enabled = false;
                    btnAbastecer.BackColor = Color.Red;
                    btnAbastecer.ForeColor = Color.Black;

                    string msj = string.Format("NO se pudo generar lote de abasto en SL para el ID:{0} ", AbastoPkg.Transferencia, AbastoPkg.ClaveRecolectar);
                    lbClavesDelSemaforo.Text = "ERROR"; //msj;
                    lbClavesEnRojo.Text = "";
                    lbClavesEnAmarillo.Text = "";
                    lbClavesEnVerde.Text = "";

                    MessageBox.Show(msj);
                }
                //Si existen recolecciones pendientes de Re-Abastecer, entonces:
                else if (ExistenPendientesPorReAbastecer > 0)
                {
                    //Asignamos el número de Transferencia que corresponde a la recolección pendiente de Re-Abastecer
                    dr0 = ds0.Tables[0].Rows[0];
                    AbastoPkg.Transferencia = dr0[0].ToString();

                    //Primero se debe de concluir con el Re-Abasto de la recolección pendiente, por tal motivo sólo se habilita el botón de Re-Abastecer.
                    btnRecolectar.Enabled = false;
                    btnAbastecer.Enabled = true;
                    btnAbastecer.BackColor = Color.Red;
                    btnAbastecer.ForeColor = Color.Black;

                    lbClavesDelSemaforo.Text = "Existen recolecciones pendientes por Re-Abastecer";
                    lbClavesEnRojo.Text = "";
                    lbClavesEnAmarillo.Text = "";
                    lbClavesEnVerde.Text = "";
                }
                else
                {
                    //Si no hay recolecciones pendientes de Re-Abastecer, sólo se habilita el Botón Recolectar
                    btnRecolectar.Enabled = true;          
                    btnAbastecer.Enabled = false;
                    
                    if (abasto.GenerarAbastoPicking(Global.Usuario))
                    {
                        ds1 = abasto.ObtenerClavesSemaforoPorColor(Global.Usuario);
                        dr = ds1.Tables[0].Rows[0];
                        //Asignamos los datos obtenidos de la clave a las variables globales del programa
                        lbClavesDelSemaforo.Text = "Claves por Abastecer: ";
                        lbClavesEnRojo.Text = dr["Rojo"].ToString().Trim();
                        lbClavesEnAmarillo.Text = dr["Amarillo"].ToString().Trim();
                        lbClavesEnVerde.Text = dr["Verde"].ToString().Trim();
                    }
                    else
                    {
                        MessageBox.Show("Error, no se generó correctamente el cálculo del semáforo.");
                    }                 
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error, no controlado.");
            }

        }

        //
        private void btnAbastecer_Click(object sender, EventArgs e)
        {
            /*
             Se da inicio al proceso de Re-Abasto, esto solo es en el caso de que exista rolección pendiente de re-abastecer
            */

            //Habilitamos el botón de abastecer y inabilitamos el botón de Recolectar            
            btnAbastecer.Enabled = true;
            btnRecolectar.Enabled = false;

            this.Close();
            Abastecer fAbastecer = new Abastecer();
            fAbastecer.Show();
        }


    }
}