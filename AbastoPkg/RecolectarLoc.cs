using System;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class RecolectarLoc : Form
    {
        private string localizacion { get; set; }
        private Single exitenciaLoc { get; set; }
        private Single recolectado { get; set; }
        private Single porRecolectar { get; set; }
        private Single porRecolectarLoc { get; set; }
        private Single porAbastecer { get; set; }

        Recoleccion repositorio = new Recoleccion();

        //
        public RecolectarLoc()
        {
            InitializeComponent();
        }

        //
        private void frmRecolectarLoc_Load(object sender, EventArgs e)
        {            
            // Al cargar la forma se busca la localización con menor cantidad disponible para recolectar, asi sucesivamente hasta
            // que se recolecte la cantidad total global de la clave o ya no existan más localizaciones para recolectar                        

            lbNoTransferencia.Text = "ID: " +Recoleccion.ID.ToString();

            lbAviso.Visible = true;
            btnFinalizar.Visible = false;
            txtLocalizacion.Visible = true;

            try
            {                                
                lbClave.Text = Recoleccion.Clave;
                lbDescripcion.Text = Recoleccion.Descripcion;
                lbPorAbastecer.Text = "Recolección: " +Recoleccion.PorAbastecer.ToString();
                
                var drExistenciaLocalizacion = repositorio.GetExistenciaLocalizacion(Recoleccion.ID.ToString(), Recoleccion.Clave);

                //
                this.localizacion = drExistenciaLocalizacion[0].ToString();
                this.exitenciaLoc = (Single)drExistenciaLocalizacion[1];
                this.recolectado = (Single)drExistenciaLocalizacion[2];

                lbRecolectado.Text = "Recolectado: " + this.recolectado.ToString();
                Recoleccion.Recolectado = this.recolectado;

                lbLocalizacion.Text = this.localizacion;
                
                this.porRecolectar = (Single)Recoleccion.PorAbastecer - this.recolectado;

                string msj = "";      
                if (this.porRecolectar<0)
                {
                    msj = "ERROR: Por recolectar negativo, Omitir esta clave!!!!!!!";
                    lbAviso.Text = msj;
                    return;
                }

                if (this.localizacion=="NA")
                {
                    msj = "Ya no hay mas localizaciones con Existencia!!!!!!!";
                    lbAviso.Text = msj;
                    FinalizarRecoleccion();
                }

                //
                if (this.recolectado >= Recoleccion.PorAbastecer)
                {
                    msj = "Recolección completada o con excedente";
                    lbAviso.Text = msj;
                    FinalizarRecoleccion();
                }
                else{                                    
                    if (this.exitenciaLoc<=this.porRecolectar)
                    {
                        this.porRecolectarLoc=this.exitenciaLoc;                     
                    }
                    else{
                        this.porRecolectarLoc=this.porRecolectar;
                    }
                    //Asignamos el valor de la cantidad a Recolectar de la localización
                    Recoleccion.PorRecolectarLoc = this.porRecolectarLoc;
                    Recoleccion.LocalizacionOrigenRecolectar = this.localizacion;
                    lbCantidad.Text = "Tomar: " +this.porRecolectarLoc.ToString() + " de Loc. ";             
                }
            }
            catch (Exception)
            {
                string msj = "Es probable que esta clave no tenga asignado correctamente un múltiplo de abasto o quizá no cuente con codigo de barras, favor de verificar con Supervisor Administrativo.";
                lbAviso.Text = msj;
                txtLocalizacion.Visible = false;
                btnFinalizar.Visible = true;
            }

            //Si el usuario es el abastecedor de Picking 2, entonces puede finalizar la recolección en cualquier momento
            if (Global.Usuario == "6001")
            {
                btnFinalizar.Visible = true;
            }            
        }

        //
        private void FinalizarRecoleccion()
        {   
            //Finalizamos el proceso de recolección de claves.
            repositorio.FinalizarRecoleccion(Recoleccion.ID, Recoleccion.LocalizacionPkg);
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

        //
        private void txtLocalizacion_KeyUp(object sender, KeyEventArgs e)
        {
            
            // Valida que la localización capturada sea igual a la localización mostrada en la pantalla para poder continuar           
            
            if (e.KeyCode == Keys.Enter)
            {
                tmLocalizacion.Enabled = false;

                if ((txtLocalizacion.Text.ToUpper().Trim() == lbLocalizacion.Text.ToUpper().Trim()) || (txtLocalizacion.Text == Global.CaracterEscape))
                {
                    try
                    {
                        //Pasamos a la pantalla de Recolectar (Cantidades)
                        this.Close();
                        RecolectarCantidades fRecolectarCant = new RecolectarCantidades();
                        fRecolectarCant.Show();
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    string msj = "AVISO!!!  No coincide la localización ";
                    lbAviso.Text = msj;
                    lbAviso.BackColor = System.Drawing.Color.Red;
                    lbAviso.ForeColor = System.Drawing.Color.White;
                    txtLocalizacion.Text = "";
                    txtLocalizacion.Focus();
                }
            }
            else
            {
                tmLocalizacion.Enabled = true;
            }
        }

        //
        private void tmLocalizacion_Tick(object sender, EventArgs e)
        {
            //limpiamos la captura de la localización despues de que expire el tiempo límite máximo de captura
            txtLocalizacion.Text = "";
        }

        //
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //Solo el abastecedor de Picking 2 (6001) puede Finalizar los abastos en esta pantalla
            if (Global.Usuario == "6001")
            {
                FinalizarRecoleccion();
            }
        }

    }//Clase o Forma

}//namespace