using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Movil_RIDA
{
    public class Recoleccion
    {
        public static int ID { get; set; }        
        public static string Clave { get; set; } //Almacena la clave del producto a abastecer        
        public static string Descripcion { get; set; } //Almacena la descripción del producto a abastecer      
        public static string LocalizacionPkg { get; set; } //Almacena la localización de Picking en la cual se tendrá que dejar el producto que se esta abasteciendo
        public static string MultiploAbastoPkg { get; set; } //Almacena el múltiplo correspondiente al nivel del codigo de barras del artículo                                        
        public static float PorRecolectarLoc { get; set; } //Almacena la cantidad de unidades que se deberán de recolectar de la localización
        public static string LocalizacionOrigenRecolectar { get; set; } //Almacena la localización de donde se deberán tomar las unidades a recolectar                               
        public static string LocPermiteCapturarMultiplo { get; set; } //Sirve para indicar si la localización permite capturar multiplos de codigo de barras del producto asignado                                    
        public static Double BufferPkg { get; set; } //Almacena el buffer que tiene asignado la localización de picking del producto a abastecer
        public static Double PorAbastecer { get; set; }
        public static float Recolectado { get; set; }
        //public static string NoTransferencia { get; set; } //Almacena el número consecutivo que genera el sistema de abasto de Picking, el cual será usado como referencia en la Tranferencia final hacia el ERP (Dynamics SL)        

        private AccesoDatos db; // objeto para el acceso a datos
        private List<ADN_SemaforoAbastoPkg> listadoClaves;

        // contructor
        public Recoleccion()
        {
            //Establecemos la cadena de conexión a la BD
            db = new AccesoDatos(Properties.Resources.cnStr);
        }

        /// <summary>
        /// Si existe un abasto en status de Error, se retorna un objeto con el número de Transferencia y clave en cuestión 
        /// </summary>
        public DataRow VerificarAbastoConError(string pUsuario)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@NumAbastecedor", pUsuario);

            var datos = db.ExecuteSelect("ADN_AbastoPkg_AbastosConErrorPorAbastecedor", Parametros);

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

        /// <summary>
        /// Retorna el Número de ID de transferencia que quedó pendiente de finalizar el abasto
        /// </summary>
        public int VerificarAbastoPendiente(string pUsuario)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@NumAbastecedor", pUsuario);

            var datos = db.ExecuteSelect("ADN_AbastoPkg_VerificarReAbastoPendiente", Parametros);

            if (datos.Rows.Count > 0)
            {
                return Convert.ToInt32(datos.Rows[0].ItemArray[0]);                
            }
            else
            {
                return 0;
            }
        }
        
        public bool GenerarAbastoPicking(string pUsuario)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Abastecedor", pUsuario);

            db.ExecuteNonQuery("ADN_AbastoPkg_GenerarAbastoPkgPaso1", Parametros);

            return true;
        }

        public List<ADN_SemaforoAbastoPkg> GetClavesPorRecolectar(string pUsuario)
        {
            //Ejecuta el SP que obtiene la primer clave a recolectar en función del semáforo de picking 

            listadoClaves = new List<ADN_SemaforoAbastoPkg>();

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@usuario", pUsuario);

            DataTable datos = db.ExecuteSelect("ADN_AbastoPkg_ObtenerClavesPorRecolectarV2", Parametros);

            foreach (DataRow registro in datos.Rows)
            {
                ADN_SemaforoAbastoPkg obj = new ADN_SemaforoAbastoPkg();
                obj.Clave = registro[0].ToString(); //Clave
                obj.Descripcion = registro[1].ToString(); //Descripcion
                obj.LocalizacionPkg = registro[2].ToString(); //LocalizacionPkg
                obj.Semaforo = registro[3].ToString(); //Semaforo
                obj.ClasifABC = registro[4].ToString(); //ClasifABC
                obj.NivelBuffer = (Double)registro[5]; //NivelBuffer
                obj.PorAbastecer = (Double)registro[6]; //PorAbastecer
                obj.NivelAbastoPkg = registro[7].ToString(); //NivelAbastoPkg
                obj.MultiploAbastoPkg = registro[8].ToString(); //MultiploAbastoPkg
                obj.AceptaMultiploEmpaque = registro[9].ToString(); //AceptaMultiploEmpaque
                obj.DispActualPkg = (Double)registro[10]; //DispActualPkg
                obj.BufferPkg = (Double)registro[11]; //BufferPkg

                listadoClaves.Add(obj);
            }

            return listadoClaves;
        }

        public DataRow GetIniciarRecoleccion(string pUsuario, string pLocalizacion)
        {
            DataRow registro = null;

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Usuario", pUsuario);
            Parametros.Add("@LocPkg", pLocalizacion);

            var datos = db.ExecuteSelect("dbo.ADN_AbastoPkg_IniciarRecoleccion", Parametros);

            if (datos.Rows.Count > 0)
            {
                registro = datos.Rows[0];

            }

            return registro;
        }

        public DataRow GetExistenciaLocalizacion(string pID, string pClave)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pID);
            Parametros.Add("@clave", pClave);

            var datos = db.ExecuteSelect("ADN_AbastoPkg_ObtenerExistenciaLocalizacionV2", Parametros);

            DataRow registro = datos.Rows[0];
            return registro;
        }

        public bool PostAgregarRecoleccion(int pTransferencia, string pClave, string pLocalizacion, float pCantidad, string pLocalizacionDest, string pAbastecedor)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pTransferencia);
            Parametros.Add("@Clave", pClave);
            Parametros.Add("@Localizacion", pLocalizacion);
            Parametros.Add("@Cantidad", pCantidad);
            Parametros.Add("@LocalizacionDest", pLocalizacionDest);
            Parametros.Add("@Abastecedor", pAbastecedor);
            db.ExecuteNonQuery("ADN_AbastoPkg_AgregarRecoleccionV2", Parametros);

            return true;
        }
        
        public bool RegistrarExcepcion(int pTransferencia, string pClave, string pLocalizacion, string pExcepcion)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pTransferencia);
            Parametros.Add("@Clave", pClave);
            Parametros.Add("@LocalizacionRecoleccion", pLocalizacion);
            Parametros.Add("@Excepcion", pExcepcion);

            int resp = db.ExecuteNonQuery("ADN_AbastoPkg_RegistrarExcepcion", Parametros);

            return resp > 0 ? true : false;
        }

        public bool FinalizarRecoleccion(int pTransferencia, string pLocPkg)
        {
            //Ejecuta el SP que finaliza el proceso de Recolección registrando la hora en que se terminó la recolección 
            //y cambia el status de la Transferencia a RECOLECTADA lo cual indica que esta disponible para re-abastecerse            

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pTransferencia);
            Parametros.Add("@LocPkg", pLocPkg);

            int resp = db.ExecuteNonQuery("ADN_AbastoPkg_FinalizarRecoleccion", Parametros);

            return resp > 0 ? true : false;
        }
      
        public DataTable ObtenerRecoleccionParaReAbastecer(int @pTransferencia)
        {
            //Ejecuta el SP que obtiene las partidas recolectadas de la transferencia para su ReAbasto
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pTransferencia);

            return db.ExecuteSelect("ADN_AbastoPkg_ObtenerRecoleccionAbastecer", Parametros);
        }

        public bool FinalizarReAbasto(int pTransferencia)
        {
            //Ejecuta el SP que finaliza el proceso de ReAbasto registrando la hora en que se terminó de Reabastecer 
            //y cambia el status de la Transferencia a ABASTECIDA lo cual indica que ya se vació la mercancía previamente recolectada en la localización destino correspondiente 

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pTransferencia);

            int resp = db.ExecuteNonQuery("ADN_AbastoPkg_FinalizarReAbasto", Parametros);

            return resp > 0 ? true : false;
        }

        /*

        // confirmar obsolescencia *
        public bool EliminarReAbasto(int pTransferencia, string pClave, string pLocalizacion, float pCantidad)
        {

            //  Ejecuta el SP que Permite eliminar la última recolección registrada mediante la aplicación


            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pTransferencia);
            Parametros.Add("@Clave", pClave);
            Parametros.Add("@Localizacion", pLocalizacion);
            Parametros.Add("@Cantidad", pCantidad);

            int resp = db.ExecuteNonQuery("ADN_AbastoPkg_EliminarReAbasto", Parametros);

            return resp > 0 ? true : false;
        }

        // confirmar obsolescencia *
        public bool ReAbastoCompletado(int pTransferencia, string pClave, string pLocDestino)
        {
            //Ejecuta el SP que agrega Permite registrar el detalle de una recolección como una partida de transferencia y cierra la recolección del
            //producto en caso de que todas las recolecciones sean mayores o iguales al total por abastecer del producto.

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pTransferencia);
            Parametros.Add("@Clave", pClave);
            Parametros.Add("@LocDestino", pLocDestino);

            int resp = db.ExecuteNonQuery("ADN_AbastoPkg_ReAbastoCompletado", Parametros);

            return resp > 0 ? true : false;
        }

        // confirmar obsolescencia *
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
            catch (InvalidCastException)
            {
                //MessageBox.Show(ce.Message);
                SumaCantidadReAbastecida = "0";
                return false;
            }
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    //MessageBox.Show(err.Message, "Error SQL");
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

        // confirmar obsolescencia *       
        public bool IniciarReAbasto(int pTransferencia)
        {
            //Ejecuta el SP que inicia el proceso de ReAbasto registrando la hora en que se comienza a Reabastecer            

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pTransferencia);

            int resp = db.ExecuteNonQuery("ADN_AbastoPkg_IniciarReAbasto", Parametros);

            return resp > 0 ? true : false;
        }
        
        // confirmar obsolescencia *
        public ADN_SemaforoAbastoPkg ObtenerClavePorRecolectar(string pUsuario)
        {
            //Ejecuta el SP que obtiene la primer clave a recolectar en función del semáforo de picking 

            ADN_SemaforoAbastoPkg obj = new ADN_SemaforoAbastoPkg();

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@NumAbastecedor", pUsuario);
            
            var datos = db.ExecuteSelect("ADN_AbastoPkg_ObtenerClavePorRecolectar", Parametros);

            DataRow registro = datos.Rows[0];

            obj.Clave = registro[0].ToString(); //Clave
            obj.Descripcion = registro[1].ToString(); //Descripcion
            obj.LocalizacionPkg = registro[2].ToString(); //LocalizacionPkg
            obj.Semaforo = registro[3].ToString(); //Semaforo
            obj.ClasifABC = registro[4].ToString(); //ClasifABC
            obj.NivelBuffer = (Double)registro[5]; //NivelBuffer
            obj.PorAbastecer = (Double)registro[6]; //PorAbastecer
            obj.NivelAbastoPkg = registro[7].ToString(); //NivelAbastoPkg
            obj.MultiploAbastoPkg = registro[8].ToString(); //MultiploAbastoPkg
            obj.AceptaMultiploEmpaque = registro[9].ToString(); //AceptaMultiploEmpaque
            obj.DispActualPkg = (Double)registro[10]; //DispActualPkg
            obj.BufferPkg = (Double)registro[11]; //BufferPkg
            return obj;

        }

        // confirmar obsolescencia *
        public string ObtenerNoTransferencia(string pUsuario)
        {
            // Ejecuta el SP que permite obtener el número de transferencia que se generará a SL como parte del proceso de abasto de Picking

            string noTransferencia = "0";

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Usuario", pUsuario);

            var datos = db.ExecuteSelect("ADN_AbastoPkg_ObtenerNoTransferencia", Parametros);

            if (datos.Rows.Count > 0)
            {
                DataRow registro = datos.Rows[0];
                noTransferencia = registro[0].ToString();
            }
            else
            {
                noTransferencia = "0";
            }

            return noTransferencia;
        }

        // confirmar obsolescencia *
        public DataTable ObtenerClavesSemaforoPorColor(string pUsuario)
        {

            //Ejecuta el SP que permite saber cuantas claves estan en cada color del semaforo

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Abastecedor", pUsuario);

            return db.ExecuteSelect("ADN_AbastoPkg_ObtenerClavesSemaforoPorColor", Parametros);
        }

        // confirmar obsolescencia *        
        public DataTable ObtenerClavePorRecolectar(string pUsuario)
        {
            //Ejecuta el SP que obtiene la primer clave a recolectar en función del semáforo de picking 

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@NumAbastecedor", pUsuario);

            return db.ExecuteSelect("ADN_AbastoPkg_ObtenerClavePorRecolectar", Parametros);
        }        

        // confirmar obsolescencia ESTE SP NO SE MARCA COMO OBSOLETO
        public bool CalcularDatosParaRecoleccionClave(string pLocalizacion)
        {
            // Ejecuta el SP que calcula la cantidad a recolectar en función del múltiplo de abasto  

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@LocPkg", pLocalizacion);

            var resp = db.ExecuteNonQuery("ADN_AbastoPkg_GenerarAbastoPkgPaso3", Parametros);

            if (resp > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // confirmar obsolescencia *
        public bool OmitirClavePorRecolectar(string pLocPkg)
        {
            // Ejecuta el SP que obtiene la primer clave a recolectar en función del semáforo de picking 
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@LocPkg", pLocPkg);

            int resp = db.ExecuteNonQuery("ADN_AbastoPkg_OmitirClavePorRecolectar", Parametros);

            return resp > 0 ? true : false;
        }

        // confirmar obsolescencia *
        public DataTable ObtenerExistenciaLocalizacion(string pLocPkg, string pTransferencia)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@LocPkg", pLocPkg);
            Parametros.Add("@Transferencia", pTransferencia);

            return db.ExecuteSelect("ADN_AbastoPkg_ObtenerExistenciaLocalizacion", Parametros);
        }

        // confirmar obsolescencia *        
        public SemaforoPkg ObtenerExistenciaLocalizacion(string pLocPkg, string pTransferencia)
        {
            SemaforoPkg obj = new SemaforoPkg();

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@LocPkg", pLocPkg);
            Parametros.Add("@Transferencia", pTransferencia);

            var datos = db.ExecuteSelect("ADN_AbastoPkg_ObtenerExistenciaLocalizacion", Parametros);

            DataRow registro = datos.Rows[0];

            obj.TotalRecolectado = registro[0].ToString(); //TotalRecolectado
            obj.TotalRestante = registro[1].ToString(); //TotalRestante
            obj.ExistenciaLoc = registro[2].ToString(); //ExistenciaLoc
            obj.PorRecolectarLoc = registro[3].ToString(); //PorRecolectarLoc
            obj.LocalizacionOrigenRecolectar = registro[4].ToString(); //LocalizacionOrigenRecolectar
            obj.LocConExistencia = (int)registro[5]; //LocConExistencia
            obj.MultiploAbastoPkg = registro[6].ToString(); //MultiploAbastoPkg
            return obj;
        }                
        
        // confirmar obsolescencia *
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
            catch (InvalidCastException)
            {
                //MessageBox.Show(ce.Message);
                return false;
            }
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    //MessageBox.Show(err.Message, "Error SQL");
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

        // confirmar obsolescencia *
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
            catch (InvalidCastException)
            {
                //MessageBox.Show(ce.Message);
                SumaCantidadRecolectada = "0";
                return false;
            }
            catch (SqlException myexception)
            {
                foreach (SqlError err in myexception.Errors)
                {
                    //MessageBox.Show(err.Message, "Error SQL");
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

        */

    }
}
