
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Movil_RIDA
{

    class Global
    {
        //Establecemos la cadena de conexión con la BD establecida en las propiedades del proyecto
        public static SqlConnection cnSQL= new SqlConnection(Properties.Resources.cnStr);

        public static string Aplicacion { get; set; }
        public static string Version { get; set; }
        public static string Usuario { get; set; }
        public static string CaracterEscape = "*";
        public static string IdProcesoADN { get; set; } //Guarda el identificador del proceso que se esta ejecutando, segun tabla ADN_Procesos
        
        /// <summary>
        /// Permite registrar la entrada del usuario a la aplicación
        /// </summary>
        /// <param name="pNumAlmacenista">Número de usuario quien ingresara a la aplicación</param>
        /// <returns></returns>
        public static DataRow LogIn(string pUsuario)
        {
            DataSet ds = new DataSet();

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_LogIn", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@Usuario", pUsuario);
                //Abrimos conexin a BD
                Global.cnSQL.Open();
                //Llenanos un DataSet con el resultado de la consulta
                da.Fill(ds);

                //
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0];
                }
                else
                {
                    return null;
                }
            }//try
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    MessageBox.Show(err.Message, "Error SQL");
                }
                return null;
            } // catch
            finally
            {
                if (Global.cnSQL != null && Global.cnSQL.State != ConnectionState.Closed)
                {
                    //Cerramos conexin a BD
                    Global.cnSQL.Close();
                }
            }//finally
        }

        /// <summary>
        /// Permite registrar la salida del usuario de la aplicación
        /// </summary>
        /// <param name="pNumAlmacenista">Número de Usuario que termina de usar la aplicación</param>
        /// <returns></returns>
        public static bool LogOut(string pNumAlmacenista)
        {
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_LogOut", cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@Usuario", pNumAlmacenista);
                //Ejecutamos comando
                cnSQL.Open();
                cmd.ExecuteNonQuery();
                return true;
            }//try
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    MessageBox.Show(err.Message, "Error SQL");
                }
                return false;
            } // catch
            finally
            {
                if (cnSQL != null && cnSQL.State != ConnectionState.Closed)
                {
                    //Cerramos conexin a BD
                    cnSQL.Close();
                }
            }//finally
        }

        /// <summary>
        /// Este método valida que la cantidad capturada sea un valor númerico entero o decimal con formato 999999.99
        /// </summary>
        /// <param name="Cantidad">Valor que se desea evaluar que coincida con el patrón de dígitos</param>
        /// <returns></returns>
        public static bool ValidaCantidad(string Cantidad)
        {
            Regex ER = new Regex(@"^[0-9]{1,6}(\.[0-9]{1,2})?$"); //999999.99
            return (ER.IsMatch(Cantidad));
        }

    }
}
