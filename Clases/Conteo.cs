using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movil_RIDA
{
	class Conteo:Producto
	{
  
        public static string NoConteo { get; set; }
        public static string Localizacion { get; set; }
        public static string Almacen { get; set; }
        public static string ClaveContar { get; set; } //Guarda la clave del producto seleccionado para conteo
        public static string DescripcionContar { get; set; }
        
        //
		public DataSet obtenerConteosProgramados()
		{
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_Conteos_ObtenerConteosProgramados", Global.cnSQL);
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

        //
		public void congelarExistenciasConteo(string pConteo, string pArticulo)
		{
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_Conteos_ExistenciasPorArticuloDetalle", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@Conteo", pConteo);
                cmd.Parameters.AddWithValue("@Articulo", pArticulo);
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
                    //Cerramos conexin a BD
                    Global.cnSQL.Close();
                }
            }//finally
		}

        //Obsoleto eliminar despues de publicar
        //public DataRow obtenerLocalizacionContar(string pConteo)
        //{
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataSet ds = new DataSet();
        //    DataRow dr;
        //    try
        //    {
        //        //Declaramos el comando para ejecutar el query
        //        SqlCommand cmd = new SqlCommand("ADN_Conteos_ObtenerLocalizacionContar", Global.cnSQL);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Conteo", pConteo);
        //        da.SelectCommand = cmd;
        //        //Ejecutamos comando
        //        Global.cnSQL.Open();
        //        da.Fill(ds);

        //        int tot=ds.Tables[0].Rows.Count;
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            dr = ds.Tables[0].Rows[0];
        //            return dr;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }//try
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error SQL");

        //        return null;
        //    }// catch
        //    finally
        //    {
        //        if (Global.cnSQL != null && Global.cnSQL.State != ConnectionState.Closed)
        //        {
        //            //Cerramos conexión a BD
        //            Global.cnSQL.Close();
        //        }
        //    }//finally
        //    return null;
        //}

        //
        public DataSet obtenerLocalizacionesContar(string pConteo)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_Conteos_ObtenerLocalizacionesContar", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Conteo", pConteo);
                da.SelectCommand = cmd;
                //Llenanos un DataSet con el resultado de la consulta
                da.Fill(ds);
                //Regresamos los datos encontrados
                return ds; ;
            }//try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error SQL");

                return null;
            }// catch
            finally
            {
                if (Global.cnSQL != null && Global.cnSQL.State != ConnectionState.Closed)
                {
                    //Cerramos conexión a BD
                    Global.cnSQL.Close();
                }
            }//finally
        }


        //
		public DataRow registrarConteo(string pConteo, string pAlmacen, string pLocalizacion, string pCodigoBarras, float pCantidad, string pUsuario)
		{
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_Conteos_RegistrarConteo", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Conteo", pConteo);
                cmd.Parameters.AddWithValue("@Almacen", pAlmacen);
                cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
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

        //
        public string eliminarRegistroConteo(string pConteo, string pUsuario)
        {
            string valor = "";

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_Conteos_EliminarRegistroConteo", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Conteo", pConteo);
                cmd.Parameters.AddWithValue("@Usuario", pUsuario);
                da.SelectCommand = cmd;
                //Ejecutamos comando
                Global.cnSQL.Open();
                valor=cmd.ExecuteScalar().ToString();
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

        //
        public string finalizarConteo(string pConteo, string pAlmacen, string pLocalizacion,string pUsuario)
		{
            string valor = "";
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_Conteos_FinalizarConteo", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Conteo", pConteo);
                cmd.Parameters.AddWithValue("@Almacen", pAlmacen);
                cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
                cmd.Parameters.AddWithValue("@Usuario", pUsuario);
                //Ejecutamos comando
                Global.cnSQL.Open();
                valor=cmd.ExecuteScalar().ToString();
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


        public string finalizarConteo(string pConteo)
        {
            string valor = "";
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_Conteos_FinalizarConteoCeroExistencias", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Conteo", pConteo);
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


        public DataRow agregarLocalizacionExcepcion(string pConteo, string pArticulo, string pLocalizacion, float pCantidad, string pUsuario)
        {

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow dr;
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_Conteos_AgregarLocalizacionExcepcion", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Conteo", pConteo);
                cmd.Parameters.AddWithValue("@Clave", pArticulo);
                cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
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


    }//fin clase
}
