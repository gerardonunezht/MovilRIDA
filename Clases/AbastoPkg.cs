using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movil_RIDA
{
    class AbastoPkg:Producto
    {
        public static string Transferencia { get; set; } //Almacena el número consecutivo que genera el sistema de abasto de Picking, el cual será usado como referencia en la Tranferencia final hacia el ERP (Dynamics SL)        
        public static string ClaveRecolectar { get; set; } //Almacena la clave del producto a abastecer        
        public static string DescrClaveRecolectar { get; set; } //Almacena la descripción del producto a abastecer      
        public static string LocalizacionPkgDestino { get; set; } //Almacena la localización de Picking en la cual se tendrá que dejar el producto que se esta abasteciendo
        public static string BufferPkg { get; set; } //Almacena el buffer que tiene asignado la localización de picking del producto a abastecer
        public static string NivelBufferPkg { get; set; } //Almacena el nivel actual del buffer en la localización de picking
        public static string Semaforo { get; set; } //Almacena el color del semáforo que tiene asignado el producto-localizacion a abastecer al momento del cálculo
        public static string LocPermiteCapturarMultiplo { get; set; } //Sirve para indicar si la localización permite capturar multiplos de codigo de barras del producto asignado                
        public static string TotalRecolectado { get; set; } //Almacena la cantidad total de unidades recolectadas del producto a abastecer 
        public static string TotalRestante { get; set; } //Almacena la cantidad total de unidades que faltan por recolectar
        public static string PorRecolectarLoc { get; set; } //Almacena la cantidad de unidades que se deberán de recolectar de la localización
        public static string ExistenciaLoc { get; set; } //Almacena la cantidad disponible con la que cuenta la localización        
        public static string LocalizacionOrigenRecolectar { get; set; } //Almacena la localización de donde se deberán tomar las unidades a recolectar                               
        public static int LocConExistencia { get; set; } //Almacena el total de localizaciones que cuentan con cantidad en existencia para poder recolectar, ademas también sirve para identificar si ya no existen más localizaciones de donde poder recolectar                                
        public static string MultiploAbastoPkg { get; set; } //Almacena el múltiplo correspondiente al nivel del codigo de barras del artículo                                        
        public static string NombreFormaQueInvocaExcepcion { get; set; } //almacena el nombre de la pantalla que manda invocar a la pantalla de Excepcion        
        public static bool PermiteRegistrarExepcionCero { get; set; } //Establece el valor a true (verdadero), para permitir el el registro de una excepción Cero

        public static bool RecoleccionGlobalFinalizada { get; set; } //Indicamos si el proceso de recoleccion de claves esta en proceso (false) o finalizado (true)

        //
        public bool AgregarRecoleccion(int pTransferencia, string pClave, string pLocalizacion, float pCantidad, string pLocalizacionDest, string pAbastecedor, out string SumaCantidadRecolectada)
        {
            ///////////////
            //Ejecuta el SP que agrega un registro de recolección y regresa la suma total de lo recolectado
            ///////////////

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_AgregarRecoleccion", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transferencia", pTransferencia);
                cmd.Parameters.AddWithValue("@Clave", pClave);
                cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
                cmd.Parameters.AddWithValue("@Cantidad", pCantidad);
                cmd.Parameters.AddWithValue("@LocalizacionDest", pLocalizacionDest);
                cmd.Parameters.AddWithValue("@Abastecedor", pAbastecedor);
                //Parámetro de salida
                cmd.Parameters.Add("@SumaCantidadRecolectada", SqlDbType.VarChar, 30);
                cmd.Parameters["@SumaCantidadRecolectada"].Direction = ParameterDirection.Output;
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
                SumaCantidadRecolectada = cmd.Parameters["@SumaCantidadRecolectada"].Value.ToString();
                Global.cnSQL.Close();
                return true;
            }//try
            catch (InvalidCastException ce)
            {
                MessageBox.Show(ce.Message);
                SumaCantidadRecolectada = "0";
                return false;
            }
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    MessageBox.Show(err.Message, "Error SQL");
                }
                SumaCantidadRecolectada = "0";
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

        // 
        public bool AgregarRecoleccionComoDetalleTransferencia(int pTransferencia, string pAbastecedor, string pClave, string pLocOrigen, string pLocDestino)
        {
            ///////////////
            //Ejecuta el SP que agrega Permite registrar el detalle de una recolección como una partida de transferencia y cierra la recolección del
            //producto en caso de que todas las recolecciones sean mayores o iguales al total por abastecer del producto.
            ///////////////

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_AgregarRecoleccionComoDetalleTransferencia", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transferencia", pTransferencia);
                cmd.Parameters.AddWithValue("@Abastecedor", pAbastecedor);
                cmd.Parameters.AddWithValue("@Clave", pClave);
                cmd.Parameters.AddWithValue("@LocOrigen", pLocOrigen);
                cmd.Parameters.AddWithValue("@LocDestino", pLocDestino);
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
                Global.cnSQL.Close();
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
        
        //
        public bool AgregarReAbasto(int pTransferencia, string pClave, string pLocalizacion, float pCantidad, string pAbastecedor, out string SumaCantidadReAbastecida)
        {
            ///////////////
            //Ejecuta el SP que agrega un registro de recolección y regresa la suma total de lo recolectado
            ///////////////
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_AgregarReAbasto", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transferencia", pTransferencia);
                cmd.Parameters.AddWithValue("@Clave", pClave);
                cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
                cmd.Parameters.AddWithValue("@Cantidad", pCantidad);
                cmd.Parameters.AddWithValue("@Abastecedor", pAbastecedor);
                //Parámetro de salida
                cmd.Parameters.Add("@SumaCantidadReAbastecida", SqlDbType.VarChar, 30);
                cmd.Parameters["@SumaCantidadReabastecida"].Direction = ParameterDirection.Output;
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
                SumaCantidadReAbastecida = cmd.Parameters["@SumaCantidadReabastecida"].Value.ToString();
                Global.cnSQL.Close();
                return true;
            }//try
            catch (InvalidCastException ce)
            {
                MessageBox.Show(ce.Message);
                SumaCantidadReAbastecida = "0";
                return false;
            }
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    MessageBox.Show(err.Message, "Error SQL");
                }
                SumaCantidadReAbastecida = "0";
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

        //
        public bool CalcularDatosParaRecoleccionClave(string pLocalizacion)
        {
            /*
             Ejecuta el SP que calcula la cantidad a recolectar en función del múltiplo de abasto  
            */

            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_GenerarAbastoPkgPaso3", Global.cnSQL);
                //SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_GenerarAbastoPkgPaso3Prueba", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@LocPkg", pLocalizacion);
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

        //
        public bool EliminarRecoleccion(int pTransferencia, string pClave, string pLocalizacion, float pCantidad, out string SumaCantidadRecolectada)
        {
            ///////////////
            //Ejecuta el SP que Permite eliminar la última recolección registrada mediante la aplicación
            ///////////////

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_EliminarRecoleccion", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transferencia", pTransferencia);
                cmd.Parameters.AddWithValue("@Clave", pClave);
                cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
                cmd.Parameters.AddWithValue("@Cantidad", pCantidad);
                //Parámetro de salida
                cmd.Parameters.Add("@SumaCantidadRecolectada", SqlDbType.VarChar, 30);
                cmd.Parameters["@SumaCantidadRecolectada"].Direction = ParameterDirection.Output;
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
                SumaCantidadRecolectada = cmd.Parameters["@SumaCantidadRecolectada"].Value.ToString();
                Global.cnSQL.Close();
                return true;
            }//try
            catch (InvalidCastException ce)
            {
                MessageBox.Show(ce.Message);
                SumaCantidadRecolectada = "0";
                return false;
            }
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    MessageBox.Show(err.Message, "Error SQL");
                }
                SumaCantidadRecolectada = "0";
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

        //
        public bool EliminarReAbasto(int pTransferencia, string pClave, string pLocalizacion, float pCantidad)
        {
            /*
              Ejecuta el SP que Permite eliminar la última recolección registrada mediante la aplicación
            */

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_EliminarReAbasto", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transferencia", pTransferencia);
                cmd.Parameters.AddWithValue("@Clave", pClave);
                cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
                cmd.Parameters.AddWithValue("@Cantidad", pCantidad);
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
                //SumaCantidadRecolectada = cmd.Parameters["@SumaCantidadRecolectada"].Value.ToString();
                Global.cnSQL.Close();
                return true;
            }//try
            catch (InvalidCastException ce)
            {
                MessageBox.Show(ce.Message);
                //SumaCantidadRecolectada = "0";
                return false;
            }
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    MessageBox.Show(err.Message, "Error SQL");
                }
                //SumaCantidadRecolectada = "0";
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
                        
        //
        public bool FinalizarRecoleccion(string pTransferencia, string pLocPkg)
        {
            /*
              Ejecuta el SP que finaliza el proceso de Recolección registrando la hora en que se terminó la recolección 
              y cambia el status de la Transferencia a RECOLECTADA lo cual indica que esta disponible para re-abastecerse 
            */
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_FinalizarRecoleccion", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transferencia", pTransferencia);
                cmd.Parameters.AddWithValue("@LocPkg", pLocPkg);
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
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
                    //Cerramos conexin a BD
                    Global.cnSQL.Close();
                }
            }//finally
        }

        //
        public bool FinalizarReAbasto(int pTransferencia)
        {
            ///////////////
            //Ejecuta el SP que finaliza el proceso de ReAbasto registrando la hora en que se terminó de Reabastecer 
            //y cambia el status de la Transferencia a ABASTECIDA lo cual indica que ya se vació la mercancía previamente recolectada en la localización destino correspondiente 
            ///////////////

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_FinalizarReAbasto", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transferencia", pTransferencia);
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
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
                    //Cerramos conexin a BD
                    Global.cnSQL.Close();
                }
            }//finally
        }

        //
        public bool GenerarAbastoPicking(string pAbastecedor)
        {
            //Declaramos el comando para ejecutar el query
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_GenerarAbastoPkgPaso1", Global.cnSQL);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandTimeout = 0;//Valor de tiempo de espera ilimitado
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@Abastecedor", pAbastecedor);
            try
            {
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

        //
        public bool IniciarReAbasto(int pTransferencia)
        {
            ///////////////
            //Ejecuta el SP que inicia el proceso de ReAbasto registrando la hora en que se comienza a Reabastecer            
            ///////////////

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_IniciarReAbasto", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transferencia", pTransferencia);
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
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
                    //Cerramos conexin a BD
                    Global.cnSQL.Close();
                }
            }//finally
        }

        //
        public DataSet ObtenerClavePorRecolectar(string pNumAbastecedor)
        {
            ///////////////
            //Ejecuta el SP que obtiene la primer clave a recolectar en función del semáforo de picking 
            ///////////////

            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_ObtenerClavePorRecolectar", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@NumAbastecedor", pNumAbastecedor);
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
        public bool OmitirClavePorRecolectar(string pLocPkg)
        {
            ///////////////
            //Ejecuta el SP que obtiene la primer clave a recolectar en función del semáforo de picking 
            ///////////////

            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_OmitirClavePorRecolectar", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                //cmd.Parameters.AddWithValue("@Articulo", pClave);
                cmd.Parameters.AddWithValue("@LocPkg", pLocPkg);
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

       
        public DataSet ObtenerExistenciaLocalizacion(string pLocPkg, string pTransferencia)
        {
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_ObtenerExistenciaLocalizacion", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@LocPkg", pLocPkg);
                cmd.Parameters.AddWithValue("@Transferencia", pTransferencia);
                //ejecutamos comando
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
        public DataSet ObtenerRecoleccionParaReAbastecer(string @pTransferencia)
        {
            ///////////////
            //Ejecuta el SP que obtiene las partidas recolectadas de la transferencia para su ReAbasto
            ///////////////

            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                //SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_ObtenerRecoleccionParaReAbastecer", Global.cnSQL);
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_ObtenerRecoleccionAbastecer", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@Transferencia", @pTransferencia);
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
        public DataSet ObtenerClavesSemaforoPorColor(string pAbastecedor)
        {
            /*
            Ejecuta el SP que permite saber cuantas claves estan en cada color del semaforo
            */

            DataSet ds = new DataSet();
            try
            {

                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_ObtenerClavesSemaforoPorColor", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;//Valor de tiempo de espera ilimitado
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@Abastecedor", pAbastecedor);
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
        public string ObtenerNoTransferencia(string pUsuario)
        {
            /*
             Ejecuta el SP que permite obtener el número de transferencia que se generará a SL como parte del proceso de abasto de Picking
            */

            string Transferencia = "";
            try
            {
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_ObtenerNoTransferencia", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", pUsuario);
                Global.cnSQL.Open();
                Transferencia = cmd.ExecuteScalar().ToString();
                return Transferencia;
            }//try
            catch (InvalidCastException ce)
            {
                MessageBox.Show(ce.Message);
                Transferencia = "0";
                return Transferencia;
            }
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    MessageBox.Show(err.Message);
                }
                Transferencia = "0";
                return Transferencia;
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

        //
        public bool RegistrarExcepcion(int pTransferencia, string pClave, string pLocalizacion, string pExcepcion)
        {
            ///////////////
            //Ejecuta el SP que Permite eliminar la última recolección registrada mediante la aplicación
            ///////////////

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_RegistrarExcepcion", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transferencia", pTransferencia);
                cmd.Parameters.AddWithValue("@Clave", pClave);
                cmd.Parameters.AddWithValue("@LocalizacionRecoleccion", pLocalizacion);
                cmd.Parameters.AddWithValue("@Excepcion", pExcepcion);
                //Parámetro de salida
                //cmd.Parameters.Add("@SumaCantidadRecolectada", SqlDbType.VarChar, 30);
                //cmd.Parameters["@SumaCantidadRecolectada"].Direction = ParameterDirection.Output;
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
                //SumaCantidadRecolectada = cmd.Parameters["@SumaCantidadRecolectada"].Value.ToString();
                Global.cnSQL.Close();
                return true;
            }//try
            catch (InvalidCastException ce)
            {
                MessageBox.Show(ce.Message);
                //SumaCantidadRecolectada = "0";
                return false;
            }
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    MessageBox.Show(err.Message, "Error SQL");
                }
                //SumaCantidadRecolectada = "0";
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

        public bool ReAbastoCompletado(int pTransferencia, string pClave, string pLocDestino)
        {
            ///////////////
            //Ejecuta el SP que agrega Permite registrar el detalle de una recolección como una partida de transferencia y cierra la recolección del
            //producto en caso de que todas las recolecciones sean mayores o iguales al total por abastecer del producto.
            ///////////////

            try
            {
                //Declaramos el comando para ejecutar el query
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_ReAbastoCompletado", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transferencia", pTransferencia);
                cmd.Parameters.AddWithValue("@Clave", pClave);
                cmd.Parameters.AddWithValue("@LocDestino", pLocDestino);
                //Ejecutamos comando
                Global.cnSQL.Open();
                cmd.ExecuteNonQuery();
                Global.cnSQL.Close();
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

        //
        public DataSet VerificarReAbastoPendiente(string pNumAbastecedor)
        {
            /*
            Ejecuta el SP que verificar si existen recolecciones pendientes de Re-Abastecer, antes de hacer otra recolección
            */

            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_VerificarReAbastoPendiente", Global.cnSQL);
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

        public DataSet VerificarAbastoError(string pNumAbastecedor)
        {
            /*
            Ejecuta el SP que verificar si existen recolecciones pendientes de Re-Abastecer, antes de hacer otra recolección
            */

            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ADN_AbastoPkg_AbastosConErrorPorAbastecedor", Global.cnSQL);
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

    }
}
