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
        /// Retorna el Número de ID de transferencia que quedó pendiente de finalizar para abasto
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
        
        /// <summary>
        /// Da inicio al procesos del cálculo del semaforo para las calves asignadas al usuario en cuestión
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <returns></returns>
        public bool GenerarAbastoPicking(string pUsuario)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Abastecedor", pUsuario);

            db.ExecuteNonQuery("ADN_AbastoPkg_GenerarAbastoPkgPaso1", Parametros);

            return true;
        }

        /// <summary>
        /// Obtiene lel listado de claves a recolectar por semáforo del usuario
        /// </summary>
        public List<ADN_SemaforoAbastoPkg> ObtenerClavesPorRecolectar(string pUsuario)
        {
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

        /// <summary>
        /// Obtiene el ID de transferencia que se generará a SL y el total de unidades por abastecer
        /// </summary>
        public DataRow IniciarRecoleccion(string pUsuario, string pLocalizacion)
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

        /// <summary>
        /// Obtiene la primer localización con menor cantidad disponible para recolectar, y también obtiene el total global recolectado de todas las localizaciones al momento
        /// </summary>
        public DataRow ObtenerExistenciaLocalizacion(string pID, string pClave)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pID);
            Parametros.Add("@clave", pClave);

            var datos = db.ExecuteSelect("ADN_AbastoPkg_ObtenerExistenciaLocalizacionV2", Parametros);

            DataRow registro = datos.Rows[0];
            return registro;
        }

        /// <summary>
        /// Agregar registro de partida recolectada
        /// </summary>
        public bool AgregarRecoleccion(int pTransferencia, string pClave, string pLocalizacion, float pCantidad, string pLocalizacionDest, string pAbastecedor)
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
        
        /// <summary>
        /// Permite agregar un registro de excepción en recolección
        /// </summary>
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

        /// <summary>
        /// Finaliza el proceso de Recolección registrando la hora en que se terminó la recolección 
        /// y cambia el status de la Transferencia a RECOLECTADA lo cual indica que esta disponible para re-abastecerse
        /// </summary>
        public bool FinalizarRecoleccion(int pTransferencia, string pLocPkg)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pTransferencia);
            Parametros.Add("@LocPkg", pLocPkg);

            int resp = db.ExecuteNonQuery("ADN_AbastoPkg_FinalizarRecoleccion", Parametros);

            return resp > 0 ? true : false;
        }
      
        /// <summary>
        /// Obtiene las partidas recolectadas de la transferencia para su ReAbasto
        /// </summary>
        public DataTable ObtenerRecoleccionParaReAbastecer(int @pTransferencia)
        {
            //Ejecuta el SP que obtiene las partidas recolectadas de la transferencia para su ReAbasto
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pTransferencia);

            return db.ExecuteSelect("ADN_AbastoPkg_ObtenerRecoleccionAbastecer", Parametros);
        }

        /// <summary>
        /// Finaliza el proceso de ReAbasto registrando la hora en que se terminó de Reabastecer y cambia el status de la Transferencia a ABASTECIDA 
        /// lo cual indica que ya se vació la mercancía previamente recolectada en la localización destino correspondiente
        /// </summary>
        public bool FinalizarReAbasto(int pTransferencia)
        {
            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Transferencia", pTransferencia);

            int resp = db.ExecuteNonQuery("ADN_AbastoPkg_FinalizarReAbasto", Parametros);

            return resp > 0 ? true : false;
        }

    }
}
