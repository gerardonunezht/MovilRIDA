using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace Movil_RIDA
{
    class RecepcionPlanta:Producto
    {

        public static string TrnsfrDocNbr;
        public static string BatNbr;
        public static string SiteID;
        public static string ToSiteID;
        public static string RefNbr;
        public static string Comment;

        public string StatusPartida { get; set; }
        public float CantidadRecibida { get; set; }
        public float CantidadOrdenada { get; set; }
        public bool PartidasCompletas { get; set; }


        /// <summary>
        /// Permite actualizar el registro de la recepcion con los datos de finalización.
        /// </summary>
        /// <param name="pTrnsfrDocNbr">Número de transferencia a la que se finalizará la recepción</param>
        /// <returns></returns>
        public bool FinalizarRecepcion(string pTrnsfrDocNbr)
        {
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_RcpPlanta_FinRecepcion", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TrnsfrDocNbr", pTrnsfrDocNbr);
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

        /*******************************/

        /// <summary>
        /// Permite eliminar el registro de la ultima partida escaneada
        /// </summary>
        /// <param name="pTrnsfrDocNbr">Número de transferencia</param>
        /// <param name="pClave">Número de articulo a borrar registro</param>
        /// <param name="pUsuario">Número de usuario que esta realizando la recepción</param> 
        public int EliminarPartida(string pTrnsfrDocNbr, string pClave, string pUsuario)
        {
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_RcpPlanta_EliminarPartida", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TrnsfrDocNbr", pTrnsfrDocNbr);
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

        /*******************************/

        /// <summary>
        /// Permite verificar si existe una partida pendiente de RECIBIR de un usuario, es decir, que tenga status RECIBIENDO
        /// </summary>
        /// <param name="pUsuario">Número de usuario que esta realizando la recepción</param>
        public void ContinuarRecepcionPartidaPlanta(string pUsuario)
        {
            DataSet ds = new DataSet();
            DataRow dr;
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_RcpPlanta_ContinuarRecepcionPlanta", Global.cnSQL);
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

                    RecepcionPlanta.BatNbr = dr["BatNbr"].ToString().Trim();
                    RecepcionPlanta.SiteID = dr["SiteID"].ToString().Trim();
                    RecepcionPlanta.ToSiteID = dr["ToSiteID"].ToString().Trim();
                    RecepcionPlanta.RefNbr = dr["RefNbr"].ToString().Trim();
                    this.Clave = dr["InvtId"].ToString().Trim();

                 
                }
                else
                {
                    RecepcionPlanta.TrnsfrDocNbr = "";
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
                    //Cerramos conexión a BD
                    Global.cnSQL.Close();
                }
            }//finally
        }

        /// <summary>
        /// Permite obtener los datos generales de la transferencia
        /// </summary>
        /// <param name="@pTranfrDocNbr">Numero de transferencia que se recibirá</param>
        /// <returns></returns>
        public DataRow ObtenerDatosTransferencia(string pTrnsfrDocNbr)
        {
            DataSet ds = new DataSet();

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_RcpPlanta_ObtenerDatosTransferencia", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@TrnsfrDocNbr", pTrnsfrDocNbr);
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
        /// Verifica si ya se ha recibido completamente la partida
        /// </summary>
        /// <param name="pTrnsfrDocNbr">Número de transferencia</param>
        /// <param name="pClave">Clave interna del producto de la partida a verificar</param>
        public void ObtenerCantidadRecibida(string pTrnsfrDocNbr, string pClave)
        {
            DataSet ds = new DataSet();
            DataRow dr;
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_RcpPlanta_ObtenerCantidadRecibida", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@TrnsfrDocNbr", pTrnsfrDocNbr);
                cmd.Parameters.AddWithValue("@Articulo", pClave);
                //Abrimos conexin a BD
                Global.cnSQL.Open();
                //Llenanos un DataSet con el resultado de la consulta
                da.Fill(ds);
                dr = ds.Tables[0].Rows[0];
                //
                CantidadRecibida = Convert.ToSingle(dr["CantidadRecibida"]);
                CantidadOrdenada = Convert.ToSingle(dr["CantidadOrdenada"]);
                PartidasCompletas=Convert.ToBoolean(dr["PartidasCompletas"]);

            }//try
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    MessageBox.Show(err.Message+" cantidad recibida", "Error SQL");
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
        /// Permite capturar un registror de partida de recepcon de orden de compra
        /// </summary>
        /// <param name="pTrnsfrDocNbr">Número de Transferencia</param>
        /// <param name="pClave">Clave Interna de producto</param>
        /// <param name="pCodigoBarras">Codigo de barras escaneado asociado al producto</param>
        /// <param name="pMultiplo">Múltiplo de empaque asociado al código de barras escaneado</param>
        /// <param name="pNivel">Nivel de empaque asociado al código de barras escaneado</param>
        /// <param name="pCantidad">Cantidad recibida</param>
        /// <param name="pUsuario">Usuario que agrega la partida</param>
        /// <param name="pBatNbr">Numero de lote de referencia en transito</param>
        public DataRow AgregarPartida(string pTrnsfrDocNbr, string pCodigoBarras, float pCantidad, string pUsuario, string pBatNbr)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow dr;

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_RcpPlanta_AgregarPartida", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TrnsfrDocNbr", pTrnsfrDocNbr);
                cmd.Parameters.AddWithValue("@CodigoBarras", pCodigoBarras);
                cmd.Parameters.AddWithValue("@Cantidad", pCantidad);
                cmd.Parameters.AddWithValue("@Usuario", pUsuario);
                cmd.Parameters.AddWithValue("@BatNbr",pBatNbr);
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
