﻿using System;
using System.Data;
using System.Windows.Forms;
using Movil_RIDA.Clases;

namespace Movil_RIDA
{
    public partial class RegistrarDisponiblePlanta : Form
    {

        DisponiblePlanta disp = new DisponiblePlanta();
        public string NoError = "";
        public string MensajeError = "";
        public string CantidadTotal = "0";
        Product producto = new Product();

        public RegistrarDisponiblePlanta()
        {
            InitializeComponent();
        }

        private void RegistrarPartidaDisponible(float Cantidad)
        {
            DataRow dr;

            //Registramos la partida en la Base de datos          
            //dr = disp.registrarDisponiblePlanta(DisponiblePlanta.ID, DisponiblePlanta.Localizacion, txtCB.Text, Cantidad, Global.Usuario);
            dr = disp.registrarDisponiblePlanta(DisponiblePlanta.Localizacion, txtCB.Text, Cantidad, Global.Usuario);
            NoError = dr[0].ToString();
            MensajeError = dr[1].ToString();
            CantidadTotal = dr[2].ToString();

            if (NoError == "0")
            {

                if (Convert.ToSingle(CantidadTotal) <= Convert.ToSingle(DisponiblePlanta.CantColocar))
                {
                    btnEliminarUltimaPartida.Enabled = true;
                    lbUnidades.Text = "UDS. COLOCADAS: " + CantidadTotal;
                    txtCB.Text = "";
                    txtCantidad.Text = "";
                    txtCB.Focus();
                }
                else
                {
                    MessageBox.Show("Cantidad colocada como Disponible es mayor a lo indicado, puede continuar pero existen posibilidades de error posteriores.", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show(MensajeError, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                txtCB.Text="";
                txtCB.Focus();
                txtMultiplo.Text = "";
                lbDescripcion.Text = "";
                lbClave.Text=DisponiblePlanta.ClaveColocar;
            }
        }

        private void RegistrarDisponible_Load(object sender, EventArgs e)
        {
            txtCantidad.Enabled = false;
            lbID.Text = "ID RCP: " + DisponiblePlanta.ID;
            lbLoc.Text = "LOC: " + DisponiblePlanta.Localizacion;
            lbClave.Text = DisponiblePlanta.ClaveColocar;
            lbColocar.Text = "A COLOCAR: " + DisponiblePlanta.CantColocar;
            txtCB.Focus();
        }

        private void txtCB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Validamos que se digite un código a buscar
                if (string.IsNullOrEmpty(txtCB.Text))
                {
                    MessageBox.Show("Debe de registrar un código de producto. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtCB.Focus();
                }
                else
                {
                    //Obtenemos los datos generales del codigo de barras capturado                                                       
                    producto=producto.GetDatosProducto(txtCB.Text.Trim());

                    if (!string.IsNullOrEmpty(producto.Clave))
                    {
                        //Mostramos información en pantalla
                        lbClave.Text = producto.Clave;
                        lbDescripcion.Text = producto.Descripcion;
                        txtMultiplo.Text = producto.Multiplo.ToString();

                        if ((producto.PermiteCapturarMultiplo == "SI") || (producto.Nivel >= 1))
                        {
                            txtCantidad.Enabled = true;
                            txtCantidad.Focus();
                        }
                        else
                        {
                            //Regresamos un -1 en cantidad para indicarle al sistema que tome el multiplo del producto como la cantidad
                            RegistrarPartidaDisponible(-1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El código de barras registrado no está asociado a una clave de artículo, favor de verificarlo", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        txtCB.Text = "";
                        txtCB.Focus();
                    }
                }
            }


        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Validar si lo registrado en el campo cantidad, tiene formato de numérico de 999999.99
                if (Global.ValidaCantidad(txtCantidad.Text))
                {
                    //Cantidad a registrar es igual a la multiplicación del múltiplo del empaque del artículo por la cantidad de empaques
                    float CantidadRegistrar = Convert.ToSingle(txtCantidad.Text) * producto.Multiplo;

                    RegistrarPartidaDisponible(CantidadRegistrar);
                }
                else
                {
                    MessageBox.Show("Cantidad a registrar es incorrecta, favor de verificarla.", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    txtCantidad.Text = "";
                    txtCantidad.Focus();
                }
            }
        }

        private void btnEliminarUltimaPartida_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Está seguro de eliminar el último registro de conteo ingresado?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (resp == DialogResult.Yes)
            {
                //Eliminamos el último registro insertado                
                CantidadTotal = disp.eliminarRegistroDisponible(Global.Usuario,DisponiblePlanta.ClaveColocar,DisponiblePlanta.Localizacion);
                if (!string.IsNullOrEmpty(CantidadTotal))
                {
                    //Se eliminó la partida
                    btnEliminarUltimaPartida.Enabled = false;
                    lbUnidades.Text = "UDS. COLOCADAS: " + CantidadTotal;
                    txtCB.Text = "";
                    txtCantidad.Text = "";
                    txtCB.Focus();
                }
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

            if (CantidadTotal != "0")
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea FINALIZAR con el disponible? ", "AVISO!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    disp.finalizarDisponible(DisponiblePlanta.ClaveColocar,Global.Usuario,DisponiblePlanta.Localizacion);
                    this.Close();
                    PrincipalDisponiblePlanta fPrincipal = new PrincipalDisponiblePlanta();
                    fPrincipal.Show();
                }
            }
            else
            {
                MessageBox.Show("No se registraron movimientos, la aplicación se cerrará y la partida continuará como COLOCAR. ", "AVISO!!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                this.Close();
                PrincipalDisponiblePlanta fPrincipal = new PrincipalDisponiblePlanta();
                fPrincipal.Show();
            }



        }

        private void pbInspeccion_Click(object sender, EventArgs e)
        {
            LocalizacionesDisponiblePlanta fLocalizaciones = new LocalizacionesDisponiblePlanta();
            this.Close();
            fLocalizaciones.Show();
        }

    }//Fin clase
}