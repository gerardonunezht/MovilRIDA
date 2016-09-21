using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Movil_RIDA
{
    public partial class Utilerias : Form
    {
        Producto prod = new Producto();
        public Utilerias()
        {
            InitializeComponent();
        }

        private void txtValor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 //Validamos que se digite un código a buscar
                if ((txtValor.Text == "") || (txtValor.Text == null))
                {
                    MessageBox.Show("Debe de registrar un código de producto. ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txtValor.Focus();
                }
                else
                {
                    DataSet ds = prod.ObtenerNivelesPorCodigoClave(txtValor.Text.Trim());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgDatos.DataSource = ds.Tables[0];

                        lbClave.Text = "Clave: ";
                        lbDescripcion.Text = "";
                        lbCodigo.Text = "CB: ";
                        lbMultiplo.Text = "Mult: ";
                        lbNivel.Text = "Nivel: ";

                        txtValor.Text = "";
                        txtValor.Focus();
                    }
                    
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            PrincipalInspeccion fInspeccion = new PrincipalInspeccion();
            this.Close();
            fInspeccion.Show();
        }

        private void dgDatos_CurrentCellChanged(object sender, EventArgs e)
        {
            int columnIndex = dgDatos.CurrentCell.ColumnNumber;
            int rowIndex = dgDatos.CurrentCell.RowNumber;

            lbClave.Text = "Clave: " +dgDatos[rowIndex, 0].ToString().Trim();
            lbDescripcion.Text = dgDatos[rowIndex, 1].ToString().Trim();
            lbCodigo.Text = "CB: "+dgDatos[rowIndex, 2].ToString().Trim();
            lbMultiplo.Text = "Mult: "+dgDatos[rowIndex, 3].ToString().Trim();
            lbNivel.Text = "Nivel: "+dgDatos[rowIndex, 4].ToString().Trim();

            txtValor.Focus();
        }

        private void Utilerias_Load(object sender, EventArgs e)
        {
            txtValor.Focus();
        }


    }
}