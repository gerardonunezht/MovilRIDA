using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class Recolectar : Form
    {
        AbastoPkg abasto = new AbastoPkg();

        //
        public Recolectar()
        {
            InitializeComponent();
        }

        //
        private void SolicitarClaveRecolectar()
        {

            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                lbSemaforo.Text = "";
                lbBuffer.Text = "";
                lbNivelBuffer.Text = "";

                ds = abasto.ObtenerClavePorRecolectar(Global.Usuario);
                dr = ds.Tables[0].Rows[0];
                //Asignamos los datos obtenidos de la clave a las variables globales del programa
                AbastoPkg.ClaveRecolectar = dr["Clave"].ToString().Trim();
                AbastoPkg.DescrClaveRecolectar = dr["Descripcion"].ToString().Trim();
                AbastoPkg.LocalizacionPkgDestino = dr["LocalizacionPkg"].ToString();
                AbastoPkg.BufferPkg = dr["BufferPkg"].ToString();
                AbastoPkg.NivelBufferPkg = dr["NivelBuffer"].ToString();
                AbastoPkg.Semaforo = dr["Semaforo"].ToString();
                AbastoPkg.LocPermiteCapturarMultiplo = dr["AceptaMultiploEmpaque"].ToString();

                //Asignamos los datos obtenidos de la clave a las etiquetas visuales de la aplicación            
                lbClave.Text = AbastoPkg.ClaveRecolectar;
                lbLockPkg.Text = AbastoPkg.LocalizacionPkgDestino;
                lbDescripcion.Text = AbastoPkg.DescrClaveRecolectar;
                lbSemaforo.Text = AbastoPkg.Semaforo;
                lbBuffer.Text = AbastoPkg.BufferPkg;
                lbNivelBuffer.Text = Math.Round(Convert.ToDecimal(AbastoPkg.NivelBufferPkg)) + "%";

                //Verificamos el texto del semforo para indicar el color correspondiente a la etiqueta
                if (lbSemaforo.Text == "ROJO")
                { lbSemaforo.ForeColor = Color.Red;
                  lbNivelBuffer.ForeColor = Color.Red;
                }
                if (lbSemaforo.Text == "AMARILLO")
                { lbSemaforo.ForeColor = Color.Yellow;
                  lbNivelBuffer.ForeColor = Color.Yellow;
                }
                if (lbSemaforo.Text == "VERDE")
                { lbSemaforo.ForeColor = Color.Green;
                  lbNivelBuffer.ForeColor = Color.Green;
                }
                btnLocalizaciones.Focus();

            }
            catch
            {
                //Si se regresa un nulo en el bloque del "Try" entonces quiere decir que ya no hay más claves por recolectar
                lbClave.Text = "";
                lbLockPkg.Text = "";
                lbDescripcion.Text = "";
                lbSemaforo.Text = "";
            }          

        }

        //
        private void btnLocalizaciones_Click(object sender, EventArgs e)
        {
            //se calculan los datos de abasto requeridos para la localización selecciona y pasamos a la siguiente ventana
            if (abasto.CalcularDatosParaRecoleccionClave(AbastoPkg.LocalizacionPkgDestino))
            {
                this.Close();
                RecolectarLoc fRecolectarLoc = new RecolectarLoc();
                fRecolectarLoc.Show();
            }                   
        }

        //
        private void frmRecolectar_Load(object sender, EventArgs e)
        {
            //asignamos el número de transferencia generado por el sistema sobre el cual se realizará la recolección
            AbastoPkg.Transferencia = abasto.ObtenerNoTransferencia(Global.Usuario);

            lbNoTransferencia.Text = "No. Transferencia: " + AbastoPkg.Transferencia.ToString();

            SolicitarClaveRecolectar();                
        }

        //
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            //marcamos la localización para poder leer la siguiente localización a abastecer
            if (abasto.OmitirClavePorRecolectar(lbLockPkg.Text))
            {
                SolicitarClaveRecolectar();
            }
        }

    }
}