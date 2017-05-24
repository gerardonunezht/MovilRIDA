using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Movil_RIDA
{
    public partial class Recolectar : Form
    {
        Recoleccion repositorio = new Recoleccion();
        private ADN_SemaforoAbastoPkg semaforo;
        public List<ADN_SemaforoAbastoPkg> listadoClaves;
        private int index = 0;

        //
        public Recolectar()
        {
            InitializeComponent();
        }

        //
        private void SolicitarClaveRecolectar()
        {
            semaforo = new ADN_SemaforoAbastoPkg();                        

            semaforo = listadoClaves[index];

            lbSemaforo.Text = "";
            lbBuffer.Text = "";
            lbNivelBuffer.Text = "";

            //Asignamos los datos obtenidos de la clave a las etiquetas visuales de la aplicación            
            lbClave.Text = semaforo.Clave;
            lbLockPkg.Text = semaforo.LocalizacionPkg;
            lbDescripcion.Text = semaforo.Descripcion;
            lbSemaforo.Text = semaforo.Semaforo;
            lbBuffer.Text = semaforo.BufferPkg.ToString();
            lbNivelBuffer.Text = Math.Round(Convert.ToDecimal(semaforo.NivelBuffer)) + "%";

            //Verificamos el texto del semforo para indicar el color correspondiente a la etiqueta
            if (semaforo.Semaforo == "ROJO")
            {
                lbSemaforo.BackColor = Color.Red;
                lbSemaforo.ForeColor = Color.White;
                lbNivelBuffer.ForeColor = Color.Red;
            }
            if (semaforo.Semaforo == "AMARILLO")
            {
                lbSemaforo.BackColor = Color.Yellow;
                lbSemaforo.ForeColor = Color.Black;
                lbNivelBuffer.ForeColor = Color.Yellow;
            }
            if (semaforo.Semaforo == "VERDE")
            {
                lbSemaforo.BackColor = Color.Green;
                lbSemaforo.ForeColor = Color.White;
                lbNivelBuffer.ForeColor = Color.Green;
            }
            btnLocalizaciones.Focus();

            index++;
        }

        //
        private void frmRecolectar_Load(object sender, EventArgs e)
        {
            SolicitarClaveRecolectar();                
        }

        //
        private void btnLocalizaciones_Click(object sender, EventArgs e)
        {
            var respuesta = repositorio.GetIniciarRecoleccion(Global.Usuario, semaforo.LocalizacionPkg);

            if (respuesta!=null)
            {
                // asignamos los datos correspondientes a las variables statitcas de la clase Recoleccion
                Recoleccion.ID = Convert.ToInt32(respuesta[0]);
                Recoleccion.PorAbastecer = Convert.ToSingle(respuesta[1]);
                Recoleccion.Clave = semaforo.Clave;
                Recoleccion.Descripcion = semaforo.Descripcion;
                Recoleccion.LocalizacionPkg = semaforo.LocalizacionPkg;
                Recoleccion.BufferPkg = semaforo.BufferPkg;
                Recoleccion.MultiploAbastoPkg = semaforo.MultiploAbastoPkg;
                Recoleccion.LocPermiteCapturarMultiplo = semaforo.AceptaMultiploEmpaque;

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
        }

        //
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            SolicitarClaveRecolectar();
        }

    }
}