using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Movil_RIDA
{
    class Recepcion:Producto
    {
        public static string OrdenCompra;
        public static string NoProveedor;
        public static string NombreProveedor;
        public static string MonedaOrdenCompra;
        public static string FechaOrdenCompra;
        public static string Factura { get; set; }
        //public static string StatusRcp { get; set; }
        //public static string NoRecepcion { get; set; }
        public string StatusPartida { get; set; }
        public float CantidadRecibida { get; set; }
        public float CantidadOrdenada { get; set; }

        /// <summary>
        /// Permite obtener los datos generales de la orden de compra a recibir
        /// </summary>
        /// <param name="pOrdenCompra">Numero de orden de compra que se recibirá</param>
        /// <returns></returns>
        public DataRow ObtenerDatosOrdenCompra(string pOrdenCompra)
        {
            DataSet ds = new DataSet();

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_RcpProv_ObtenerDatosOrdenCompra", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@OrdenCompra", pOrdenCompra);
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
        /// Permite actualizar el registro de la recepcion con los datos de finalización.
        /// </summary>
        /// <param name="pOrdenCompra">Número de Orden de compra a la que se finalizará la recepción</param>
        /// <returns></returns>
        public bool FinalizarRecepcion(string pOrdenCompra, string pReferenciaFactura)
        {
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_RcpProv_FinRececpion", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrdenCompra", pOrdenCompra);
                cmd.Parameters.AddWithValue("@ReferenciaFactura", pReferenciaFactura);
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
                //Global.cnSQL.Close();
                return true;
            }//try
            catch (InvalidCastException ce)
            {
                MessageBox.Show(ce.Message);
                return false;
            }
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
                if (Global.cnSQL != null && Global.cnSQL.State != ConnectionState.Closed)
                {
                    //Cerramos conexión a BD
                    Global.cnSQL.Close();
                }
            }//finally
        }

        /// <summary>
        /// Verifica si la referencia (No. de Factura del proveedor) no está ya asignada a alguna otra recepción.
        /// </summary>
        /// <param name="pReferencia">Número de factura del proveedor que se asigna como referencia a la recepción.</param>
        /// <param name="pNumProveedor">Número interno del proveedor al cual se le realiza la recepción.</param>
        /// <returns></returns>
        public DataSet ValidaNoDuplicidadReferencia(string pReferencia, string pNumProveedor)
        {
            DataSet ds = new DataSet();

            //Declaramos el comando para ejecutar el query
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("ADN_RcpProv_ValidaNoDuplicidadReferencia", Global.cnSQL);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@Referencia", pReferencia);
            cmd.Parameters.AddWithValue("@NumProveedor", pNumProveedor);
            try
            {
                //Abrimos conexin a BD
                Global.cnSQL.Open();
                //Llenanos un DataSet con el resultado de la(s) consulta(s)
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

        /*******************************/

        /// <summary>
        /// Permite verificar si existe una partida pendiente de RECIBIR de un usuario, es decir, que tenga status RECIBIENDO
        /// </summary>
        /// <param name="pUsuario">Número de usuario que esta realizando la recepción</param>
        public void ContinuarRecpecionPartida(string pUsuario)
        {
            DataSet ds = new DataSet();
            DataRow dr;
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_RcpProv_ContinuarRecpecion", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@Usuario", pUsuario);

                //Abrimos conexin a BD
                Global.cnSQL.Open();
                //Llenanos un DataSet con el resultado de la consulta
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];

                    //
                    Recepcion.OrdenCompra = dr["PoNbr"].ToString().Trim();
                    Recepcion.NoProveedor = dr["VendId"].ToString().Trim();
                    Recepcion.MonedaOrdenCompra = dr["CuryId"].ToString().Trim();
                    this.StatusPartida = dr["StatusPartidaRecepcion"].ToString().Trim();
                    this.Clave = dr["Invtid"].ToString().Trim();
                }
                else
                {
                    Recepcion.OrdenCompra = "";
                    this.StatusPartida = "";
                }
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

        /// <summary>
        /// Permite eliminar los registros asociados a una recepción de orden de compra
        /// </summary>
        /// <param name="pOrdenCompra">Orden de compra de la cual se eliminaron los registros asociados para la recepcion</param>
        public bool CancelarRecpecionPartida(string pOrdenCompra, string pProducto)
        {
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_RcpProv_CancelarRecpecion", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@OrdenCompra", pOrdenCompra);
                cmd.Parameters.AddWithValue("@Producto", pProducto);
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
                Global.cnSQL.Close();
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
                if (Global.cnSQL != null && Global.cnSQL.State != ConnectionState.Closed)
                {
                    //Cerramos conexin a BD
                    Global.cnSQL.Close();
                }
            }//finally
        }

        /// <summary>
        /// Verifica si ya se ha recibido completamente la partida
        /// </summary>
        /// <param name="pOrdenCompra">Número de Orden de Compra</param>
        /// <param name="pClave">Clave interna del producto de la partida a verificar</param>
        public void ObtenerCantidadRecibida(string pOrdenCompra, string pClave)
        {
            DataSet ds = new DataSet();
            DataRow dr;
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_RcpProv_ObtenerCantidadRecibida", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@OrdenCompra", pOrdenCompra);
                cmd.Parameters.AddWithValue("@Articulo", pClave);
                //Abrimos conexin a BD
                Global.cnSQL.Open();
                //Llenanos un DataSet con el resultado de la consulta
                da.Fill(ds);
                dr = ds.Tables[0].Rows[0];
                //
                this.CantidadRecibida = Convert.ToSingle(dr["CantidadRecibida"]);
                this.CantidadOrdenada = Convert.ToSingle(dr["CantidadOrdenada"]);

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


        public int EliminarPartida(string pOrdenCompra, string pClave, string pUsuario)
        {
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_RcpProv_EliminarPartida", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrdenCompra", pOrdenCompra);
                cmd.Parameters.AddWithValue("@Producto", pClave);
                cmd.Parameters.AddWithValue("@Usuario", pUsuario);
                Global.cnSQL.Open();
                return cmd.ExecuteNonQuery();
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
            return -1;
        }

        /// <summary>
        /// Permite capturar un registror de partida de recepcon de orden de compra
        /// </summary>
        /// <param name="pOrdenCompra">Número de Orden de Compra</param>
        /// <param name="pClave">Clave Interna de product</param>
        /// <param name="pCodigoBarras">Codigo de barras escaneado asociado al producto</param>
        /// <param name="pMultiplo">Múltiplo de empaque asociado al código de barras escaneado</param>
        /// <param name="pNivel">Nivel de empaque asociado al código de barras escaneado</param>
        /// <param name="pCantidad">Cantidad recibida</param>
        public DataRow AgregarPartida(string pOrdenCompra, string pMoneda, string pProveedor, string pCodigoBarras, float pCantidad, string pReferenciaFactura, string pUsuario)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_RcpProv_AgregarPartida_New", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrdenCompra", pOrdenCompra);
                cmd.Parameters.AddWithValue("@Moneda", pMoneda);
                cmd.Parameters.AddWithValue("@Proveedor", pProveedor);
                cmd.Parameters.AddWithValue("@CodigoBarras", pCodigoBarras);
                cmd.Parameters.AddWithValue("@Cantidad", pCantidad);
                cmd.Parameters.AddWithValue("@ReferenciaFactura", pReferenciaFactura);
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

        //Obsoleto eliminar despues de publicar cambio en produccion
        public DataRow AgregarPartida(string pOrdenCompra, string pMoneda, string pProveedor, string pClave, string pCodigoBarras, float pMultiplo, float pNivel, float pCantidad, string pUsuario)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_RcpProv_AgregarPartida", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrdenCompra", pOrdenCompra);
                cmd.Parameters.AddWithValue("@Moneda", pMoneda);
                cmd.Parameters.AddWithValue("@Proveedor", pProveedor);
                cmd.Parameters.AddWithValue("@Producto", pClave);
                cmd.Parameters.AddWithValue("@CodigoBarras", pCodigoBarras);
                cmd.Parameters.AddWithValue("@Multiplo", pMultiplo);
                cmd.Parameters.AddWithValue("@Nivel", pNivel);
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

    }
}
