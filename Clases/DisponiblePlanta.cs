using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Movil_RIDA.Clases
{
    class DisponiblePlanta
    {
        /// <summary>
        /// Variables estáticas utilizadas para
        /// </summary>
        public static string ID { get; set; }
        public static string Localizacion { get; set; }
        public static string DescripcionProd { get; set; }
        public static string ClaveColocar { get; set; } //Guarda la clave del producto seleccionado colocar como disponible
        public static string CantColocar { get; set; }
        private AccesoDatos db;// objeto para el acceso a datos
       
        // contructor
        public DisponiblePlanta()
        {
            //Establecemos la cadena de conexión a la BD
            db = new AccesoDatos(Properties.Resources.cnStr);
        }

        public DataSet obtenerProductosRegistrados()
        {
            var datos = db.ExecuteSelect("ADN_DisponibleRcpPlanta_ObtenerProductosRegistrados");
            return datos.DataSet;
        }
        /*{
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_DisponibleRcpPlanta_ObtenerProductosRegistrados", Global.cnSQL);
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



        public DataRow iniciarProcesoDisponiblePlanta(string pClave, string pUsuario, string pCantidadColocar)
        {
            DataRow registro = null;
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@InvtID", pClave);            
            Parametros.Add("@Usuario", pUsuario);
            Parametros.Add("@CantidadColocar",Convert.ToDouble(pCantidadColocar));


            var datos = db.ExecuteSelect("ADN_DisponibleRcpPlanta_IniciarDisponible", Parametros);
            if (datos.Rows.Count > 0)
            {
                registro = datos.Rows[0];
            }
            return registro;
        }
            /*
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_DisponibleRcpPlanta_IniciarDisponible", Global.cnSQL);
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


        public DataRow SeleccionarProductoDisponible(string pClave)
        {
            DataRow registro = null;
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@claveProducto", pClave);
            var datos = db.ExecuteSelect("ADN_DisponibleRcpPlanta_ObtenerProductoRegistrado", Parametros);
            if (datos.Rows.Count > 0)
            {
                registro = datos.Rows[0];
            }
            return registro;
        }
            /*
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_DisponibleRcpPlanta_ObtenerProductoRegistrado", Global.cnSQL);
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
        public DataSet VerificarTransferenciaError(string pNumAbastecedor)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@NumAbastecedor", pNumAbastecedor);
            var datos = db.ExecuteSelect("ADN_DisponibleRcpPlanta_TransferenciasDisponiblePlantaConError", Parametros);
            return datos.DataSet;
        }

            /*
        {
            //Ejecuta el SP que verificar si existen recolecciones pendientes de Re-Abastecer, antes de hacer otra recolección
            

            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_DisponibleRcpPlanta_TransferenciasDisponiblePlantaConError", Global.cnSQL);
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
        public DataSet ObtenerLocalizacionesProductoExistencia(string pArticulo)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Articulo", pArticulo);
            var datos = db.ExecuteSelect("ADN_DisponibleRcpPlanta_ObtenerLocalizacionesProductoExistencia", Parametros);
            return datos.DataSet;
        }
        /*
        {
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_DisponibleRcpPlanta_ObtenerLocalizacionesProductoExistencia", Global.cnSQL);
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
        public DataSet ObtenerLocalizacionesVacias()
        {
            var datos = db.ExecuteSelect("ADN_DisponibleRcpPlanta_ObtenerLocalizacionesVacias");
            return datos.DataSet;
        }
        /*
        {
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_DisponibleRcpPlanta_ObtenerLocalizacionesVacias", Global.cnSQL);
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
        public string eliminarRegistroDisponible(string pUsuario,string pClaveColocar,string pLocalizacion)
        {
            string valor = "";
            DataRow registro = null;
            
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            //Parametros.Add("@ID", pID);
            //Parametros.Add("@Usuario", pUsuario);
            Parametros.Add("@Usuario", pUsuario);
            Parametros.Add("@Clave", pClaveColocar);
            Parametros.Add("@Localizacion", pLocalizacion);

            var datos = db.ExecuteSelect("ADN_DisponibleRcpPlanta_EliminarRegistroDisponible", Parametros);
            if (datos.Rows.Count > 0)
            {
                registro = datos.Rows[0];
                valor=registro[0].ToString();
            }
            return valor;
        }
        /*
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
        public DataRow registrarDisponiblePlanta(string pLocalizacion, string pCodigoBarras, float pCantidad, string pUsuario)
        {
            DataRow registro = null;
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
           
            Parametros.Add("@LocalizacionColocar", pLocalizacion);
            Parametros.Add("@CodigoBarras", pCodigoBarras);
            Parametros.Add("@Cantidad", pCantidad);
            Parametros.Add("@Usuario", pUsuario);
            var datos = db.ExecuteSelect("ADN_DisponibleRcpPlanta_RegistrarDisponible", Parametros);
            if (datos.Rows.Count > 0)
            {
                registro = datos.Rows[0];
            }
            return registro;
        }
        /*
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_DisponibleRcpPlanta_RegistrarDisponible", Global.cnSQL);
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

        //
        public void finalizarDisponible(string pClaveColocar,string pUsuario, string pLocalizacion)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            //Parametros.Add("@ID", pID);
            Parametros.Add("@Clave", pClaveColocar);
            Parametros.Add("@Usuario", pUsuario);
            Parametros.Add("@Localizacion", pLocalizacion);
            db.ExecuteNonQuery("ADN_DisponibleRcpPlanta_FinalizarDisponible", Parametros);
        }
        /*
        {
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_DisponibleRcpPlanta_FinalizarDisponible", Global.cnSQL);
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
    }//End Class
}//End Namespace
