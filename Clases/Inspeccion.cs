using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Movil_RIDA
{
    class Inspeccion
    {
        private AccesoDatos db; // objeto para el acceso a datos

        public Inspeccion()
        {
            //Establecemos la cadena de conexión a la BD
            db = new AccesoDatos(Properties.Resources.cnStr);
        }

        /// <summary>
        /// Permite liberar la rececpción para que se de ingreso al almacen de recepciones en Solomon registrando
        /// en cada partida (segun corresponda) los datos del pedimento
        /// </summary>
        public DataRow AgregarRegistroMuestreo(string pCodigoBarras, string pUsuario)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@CodigoBarras", pCodigoBarras);
            Parametros.Add("@Usuario", pUsuario);

            var datos = db.ExecuteSelect("ADN_Inspec_AgregarRegistroMuestreo", Parametros);

            if (datos.Rows.Count > 0)
            {
                DataRow registro = datos.Rows[0];
                return registro;
            }
            else
            {
                return null;
            }
        }

        /*
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
        */

    }
}
