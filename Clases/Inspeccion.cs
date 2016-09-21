using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movil_RIDA
{
    class Inspeccion:Producto
    {

        /// <summary>
        /// Permite liberar la rececpción para que se de ingreso al almacen de recepciones en Solomon registrando
        /// en cada partida (segun corresponda) los datos del pedimento
        /// </summary>
        /// <param name="pOrdenCompra">Número de Orden de Compra que se está recibiendo</param>
        /// <param name="pFactura">Numero de factura de proveedorer que se registrará como referencia en la recepción</param>
        /// <param name="pMonto">Monto de la factura ecibida correspondiente a la orden de compra</param>
        /// <param name="pPedimento">Numero de pedimento que se asociará a la partida recibida</param>
        /// <param name="pAduanaPedimento">Nombre de la aduana correspondiente al pedimento</param>
        /// <param name="pFechaPedimento">Fecha de ingreso correspondiente al pedimento</param>
        /// <returns></returns>
        public DataRow AgregarRegistroMuestreo(string pCodigoBarras, string pUsuario)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_Inspec_AgregarRegistroMuestreo", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@OrdenCompra", pOrdenCompra);
                cmd.Parameters.AddWithValue("@CodigoBarras", pCodigoBarras);
                cmd.Parameters.AddWithValue("@Usuario", pUsuario);
                da.SelectCommand = cmd;
                //Ejecutamos comando
                Global.cnSQL.Open();
                da.Fill(ds);
                dr = ds.Tables[0].Rows[0];
                return dr;
            }//try
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    MessageBox.Show(err.Message, "Error SQL");
                }
            } // catch
            finally
            {
                if (Global.cnSQL != null && Global.cnSQL.State != ConnectionState.Closed)
                {
                    //Cerramos conexión a BD
                    Global.cnSQL.Close();
                }
            }//finally
            return null;
        }
    }
}
