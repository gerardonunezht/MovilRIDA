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
        public int rojas { get; set; }
        public int amarillas { get; set; }

        //
        public Recolectar()
        {
            InitializeComponent();
        }

        //
        private void SolicitarClaveRecolectar(int idx)
        {
            semaforo = new ADN_SemaforoAbastoPkg();

            semaforo = listadoClaves[idx];

            lbSemaforo.Text = "";
            lbBuffer.Text = "";
            lbNivelBuffer.Text = "";

            //Verificamos el texto del semforo para indicar el color correspondiente a la etiqueta
            if (semaforo.Semaforo == "ROJO")
            {
                lbSemaforo.BackColor = Color.Red;
                lbSemaforo.ForeColor = Color.White;
                lbNivelBuffer.ForeColor = Color.Red;

                //Asignamos los datos obtenidos de la clave a las etiquetas visuales de la aplicación            
                lbClave.Text = semaforo.Clave;
                lbLockPkg.Text = semaforo.LocalizacionPkg;
                lbDescripcion.Text = semaforo.Descripcion;
                lbSemaforo.Text = semaforo.Semaforo;
                lbBuffer.Text = semaforo.BufferPkg.ToString();
                lbNivelBuffer.Text = Math.Round(Convert.ToDecimal(semaforo.NivelBuffer)) + "%";
                btnLocalizaciones.Focus();
            }
            else if (semaforo.Semaforo == "AMARILLO")
            {
                /*     
                lbSemaforo.BackColor = Color.Yellow;
                lbSemaforo.ForeColor = Color.Black;
                lbNivelBuffer.ForeColor = Color.Yellow;

                //Asignamos los datos obtenidos de la clave a las etiquetas visuales de la aplicación            
                lbClave.Text = semaforo.Clave;
                lbLockPkg.Text = semaforo.LocalizacionPkg;
                lbDescripcion.Text = semaforo.Descripcion;
                lbSemaforo.Text = semaforo.Semaforo;
                lbBuffer.Text = semaforo.BufferPkg.ToString();
                lbNivelBuffer.Text = Math.Round(Convert.ToDecimal(semaforo.NivelBuffer)) + "%";
                btnLocalizaciones.Focus();
                */

                if (this.rojas == 0)
                {
                    lbSemaforo.BackColor = Color.Yellow;
                    lbSemaforo.ForeColor = Color.Black;
                    lbNivelBuffer.ForeColor = Color.Yellow;

                    //Asignamos los datos obtenidos de la clave a las etiquetas visuales de la aplicación            
                    lbClave.Text = semaforo.Clave;
                    lbLockPkg.Text = semaforo.LocalizacionPkg;
                    lbDescripcion.Text = semaforo.Descripcion;
                    lbSemaforo.Text = semaforo.Semaforo;
                    lbBuffer.Text = semaforo.BufferPkg.ToString();
                    lbNivelBuffer.Text = Math.Round(Convert.ToDecimal(semaforo.NivelBuffer)) + "%";
                    btnLocalizaciones.Focus();
                }
                else
                {
                    //Las verdes no seran mostradas
                    this.index = 0; //inicializamos el indice a 0
                    SolicitarClaveRecolectar(0); //volvemos a empezar 
                }
            }
            else if (semaforo.Semaforo == "VERDE")
            {                
                if ((this.rojas==0) && (this.amarillas==0))
                {
                    lbSemaforo.BackColor = Color.Green;
                    lbSemaforo.ForeColor = Color.Black;
                    lbNivelBuffer.ForeColor = Color.Yellow;

                    //Asignamos los datos obtenidos de la clave a las etiquetas visuales de la aplicación            
                    lbClave.Text = semaforo.Clave;
                    lbLockPkg.Text = semaforo.LocalizacionPkg;
                    lbDescripcion.Text = semaforo.Descripcion;
                    lbSemaforo.Text = semaforo.Semaforo;
                    lbBuffer.Text = semaforo.BufferPkg.ToString();
                    lbNivelBuffer.Text = Math.Round(Convert.ToDecimal(semaforo.NivelBuffer)) + "%";
                    btnLocalizaciones.Focus();
                }
                else
                {
                    //Las verdes no seran mostradas
                    this.index = 0; //inicializamos el indice a 0
                    SolicitarClaveRecolectar(0); //volvemos a empezar 
                }
                
            }  
        }

        //
        private void frmRecolectar_Load(object sender, EventArgs e)
        {
            this.index = 0;
            SolicitarClaveRecolectar(index);              
        }

        //
        private void btnLocalizaciones_Click(object sender, EventArgs e)
        {
            var respuesta = repositorio.IniciarRecoleccion(Global.Usuario, semaforo.LocalizacionPkg);

            if (respuesta!=null)
            {
             try
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

                    SolicitarLocalizacion();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se puede calcular la cantidad por abastecer, verifique que el NIVEL para abasto asignado sea el correcto.");
                    //throw;
                }
            }
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

        //
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.index = this.index + 1;
            //MessageBox.Show(index.ToString());
            SolicitarClaveRecolectar(this.index);
        }

    }
}