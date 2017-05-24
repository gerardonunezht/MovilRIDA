using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Movil_RIDA
{
    class Disponible
    {
        public static string ID { get; set; }
        public static string Localizacion { get; set; }
        public static string DescripcionProd { get; set; }
        public static string ClaveColocar { get; set; } //Guarda la clave del producto seleccionado colocar como disponible
        public static string CantColocar { get; set; }

        private AccesoDatos db; // objeto para el acceso a datos

        public Disponible()
        {
            //Establecemos la cadena de conexión a la BD
            db = new AccesoDatos(Properties.Resources.cnStr);
        }

        public DataRow VerificarTransferenciaError(string pUsuario)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@NumAbastecedor", pUsuario);

            var datos = db.ExecuteSelect("ADN_Disponible_TransferenciasDisponibleConError", Parametros);

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

        public DataTable ObtenerProductosAceptados()
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            var datos = db.ExecuteSelect("ADN_Disponible_ObtenerProductosAceptados");

            return datos.Rows.Count > 0 ? datos : null;
        }

        public DataRow IniciarProcesoDisponible(string pID, string pUsuario)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@ID", pID);
            Parametros.Add("@Usuario", pUsuario);
            var datos = db.ExecuteSelect("ADN_Disponible_IniciarDisponible", Parametros);

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

        public DataRow SeleccionarProductoDisponible(string pClave)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@claveProducto", pClave);
            var datos = db.ExecuteSelect("ADN_Disponible_ObtenerProductoAceptado", Parametros);

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

        public DataTable ObtenerLocalizacionesProductoExistencia(string pArticulo)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Articulo", pArticulo);
            var datos = db.ExecuteSelect("ADN_Disponible_ObtenerLocalizacionesProductoExistencia", Parametros);

            if (datos.Rows.Count > 0)
            {
                return datos;
            }
            else
            {
                return null;
            }
        }

        public DataTable ObtenerLocalizacionesVacias()
        {            
            var datos = db.ExecuteSelect("ADN_Disponible_ObtenerLocalizacionesVacias");

            if (datos.Rows.Count > 0)
            {
                return datos;
            }
            else
            {
                return null;
            }
        }

        public DataRow RegistrarDisponible(string pID, string pLocalizacion, string pCodigoBarras, float pCantidad, string pUsuario)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@ID", pID);
            Parametros.Add("@LocalizacionColocar", pLocalizacion);
            Parametros.Add("@CodigoBarras", pCodigoBarras);
            Parametros.Add("@Cantidad", pCantidad);
            Parametros.Add("@Usuario", pUsuario);
            var datos = db.ExecuteSelect("ADN_Disponible_RegistrarDisponible", Parametros);

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

        public string EliminarRegistroDisponible(string pID, string pUsuario)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@ID", pID);
            Parametros.Add("@Usuario", pUsuario);
            var datos = db.ExecuteSelect("ADN_Disponible_EliminarRegistroDisponible", Parametros);

            if (datos.Rows.Count > 0)
            {
                return datos.Rows[0].ItemArray[0].ToString(); //retornamos el valor de la primer columna del primer registro
            }
            else
            {
                return null;
            }
        }

        public void FinalizarDisponible(string pID)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@ID", pID);
            db.ExecuteNonQuery("ADN_Disponible_FinalizarDisponible", Parametros);
        }

        /*************************************/

        /*
        public DataSet obtenerProductosAceptados()
        {
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_Disponible_ObtenerProductosAceptados", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                //Abrimos conexin a BD
                Global.cnSQL.Open();
                //Llenanos un DataSet con el resultado de la consulta
                da.Fill(ds);
                //Regresamos los datos encontrados
                return ds;
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
                    //Cerramos conexin a BD
                    Global.cnSQL.Close();
                }
            }//finally
            return null;
        }
        */

        /*
        public DataSet ObtenerLocalizacionesVacias()
        {
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_Disponible_ObtenerLocalizacionesVacias", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                //Abrimos conexin a BD
                Global.cnSQL.Open();
                //Llenanos un DataSet con el resultado de la consulta
                da.Fill(ds);
                //Regresamos los datos encontrados
                return ds;
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
                    //Cerramos conexin a BD
                    Global.cnSQL.Close();
                }
            }//finally
            return null;
        }
        */

        /*
        public DataSet ObtenerLocalizacionesProductoExistencia(string pArticulo)
        {
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_Disponible_ObtenerLocalizacionesProductoExistencia", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Articulo", pArticulo);
                da.SelectCommand = cmd;
                //Abrimos conexin a BD
                Global.cnSQL.Open();
                //Llenanos un DataSet con el resultado de la consulta
                da.Fill(ds);
                //Regresamos los datos encontrados
                return ds;
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
                    //Cerramos conexin a BD
                    Global.cnSQL.Close();
                }
            }//finally
            return null;
        }
        */

        /*
        public DataRow registrarDisponible(string pID, string pLocalizacion, string pCodigoBarras, float pCantidad, string pUsuario)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_Disponible_RegistrarDisponible", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", pID);
                cmd.Parameters.AddWithValue("@LocalizacionColocar", pLocalizacion);
                cmd.Parameters.AddWithValue("@CodigoBarras", pCodigoBarras);
                cmd.Parameters.AddWithValue("@Cantidad", pCantidad);
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

        /*
        public string eliminarRegistroDisponible(string pID, string pUsuario)
        {
            string valor = "";

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_Disponible_EliminarRegistroDisponible", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", pID);
                cmd.Parameters.AddWithValue("@Usuario", pUsuario);
                da.SelectCommand = cmd;
                //Ejecutamos comando
                Global.cnSQL.Open();
                valor = cmd.ExecuteScalar().ToString();
                Global.cnSQL.Close();
                return valor;
            }//try
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    MessageBox.Show(err.Message, "Error SQL");
                }
                return "";
            } // catch
            finally
            {
                if (Global.cnSQL != null && Global.cnSQL.State != ConnectionState.Closed)
                {
                    //Cerramos conexión a BD
                    Global.cnSQL.Close();
                }
            }//finally

        }
        */

        /*
        public void finalizarDisponible(string pID)
        {
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_Disponible_FinalizarDisponible", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", pID);
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
                Global.cnSQL.Close();
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
        }
        */

        /*
        public DataRow iniciarProcesoDisponible(string pID, string pUsuario)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_Disponible_IniciarDisponible", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", pID);
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
        
        /*
        public DataRow SeleccionarProductoDisponible(string pClave)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_Disponible_ObtenerProductoAceptado", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@claveProducto", pClave);
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

        /*
        public DataSet VerificarTransferenciaError(string pNumAbastecedor)
        {
            
            //Ejecuta el SP que verificar si existen recolecciones pendientes de Re-Abastecer, antes de hacer otra recolección
            
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_Disponible_TransferenciasDisponibleConError", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@NumAbastecedor", @pNumAbastecedor);
                //Abrimos conexin a BD
                Global.cnSQL.Open();
                //Llenanos un DataSet con el resultado de la consulta
                da.Fill(ds);
                //Regresamos los datos encontrados
                return ds;
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
                    //Cerramos conexin a BD
                    Global.cnSQL.Close();
                }
            }//finally
            return null;
        }
        */

    }//fin clase
}
