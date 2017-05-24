using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Movil_RIDA
{
    public class AccesoDatos
    {
        private SqlDataAdapter Adapter;
        private SqlConnection conn;
        private string connectionString;

        public string SqlErrorMesage { get; set; }
        public int SqlErrorNumber { get; set; }

        /// <summary>
        /// Método: Abre una conexión a la base de datos si está cerrada o interrumpida
        /// </summary>
        /// <returns></returns>
        private SqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        /// <summary>
        /// Constructor: Inicializa la conexión tomada de un string  
        /// </summary>
        /// <param name="conexionBD"></param>
        public AccesoDatos(string cadenaConexion)
        {
            Adapter = new SqlDataAdapter();
            conn = new SqlConnection(cadenaConexion);
            connectionString = cadenaConexion;
        }

        public DataTable ExecuteSelect(string NombreStoredProcedure, Dictionary<string, object> Parametros)
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            dataTable = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(NombreStoredProcedure, conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Cargamos los paramatros con sus respectivos valores
                        foreach (var parametro in Parametros)
                        {
                            cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
                        }

                        conn.Open();
                        Adapter.SelectCommand = cmd;
                        Adapter.Fill(ds);

                        dataTable = ds.Tables[0];
                    }
                    catch (SqlException e)
                    {
                        SqlErrorNumber = e.Number;
                        SqlErrorMesage = e.Message;
                        return null;
                    }
                }
            }
            return dataTable;
        }

        public DataTable ExecuteSelect(string NombreStoredProcedure)
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            dataTable = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(NombreStoredProcedure, conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        Adapter.SelectCommand = cmd;
                        Adapter.Fill(ds);

                        dataTable = ds.Tables[0];
                    }
                    catch (SqlException e)
                    {
                        SqlErrorMesage = e.Message;
                        return null;
                    }
                }
            }
            return dataTable;
        }

        public bool ExecuteInsert(string NombreStoredProcedure, Dictionary<string, object> Parametros)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(NombreStoredProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        //Cargamos los paramatros con sus respectivos valores
                        foreach (var parametro in Parametros)
                        {
                            cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
                        }

                        cmd.Connection = openConnection();
                        Adapter.InsertCommand = cmd;
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        SqlErrorNumber = e.Number;
                        SqlErrorMesage = e.Message;
                        return false;
                    }
                }
            }
            return true;
        }

        public bool ExecuteInsert(string NombreStoredProcedure)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(NombreStoredProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cmd.Connection = openConnection();
                        Adapter.InsertCommand = cmd;
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        SqlErrorNumber = e.Number;
                        SqlErrorMesage = e.Message;
                        return false;
                    }
                }
            }
            return true;
        }

        public bool ExecuteUpdate(string NombreStoredProcedure, Dictionary<string, object> Parametros)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(NombreStoredProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        //Cargamos los paramatros con sus respectivos valores
                        foreach (var parametro in Parametros)
                        {
                            cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
                        }

                        cmd.Connection = openConnection();
                        Adapter.UpdateCommand = cmd;
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        SqlErrorNumber = e.Number;
                        SqlErrorMesage = e.Message;
                        return false;
                    }
                }
            }
            return true;
        }

        public bool ExecuteUpdate(string NombreStoredProcedure)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(NombreStoredProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cmd.Connection = openConnection();
                        Adapter.UpdateCommand = cmd;
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        SqlErrorNumber = e.Number;
                        SqlErrorMesage = e.Message;
                        return false;
                    }
                }
            }
            return true;
        }

        public bool ExecuteDelete(string NombreStoredProcedure, Dictionary<string, object> Parametros)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(NombreStoredProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        //Cargamos los paramatros con sus respectivos valores
                        foreach (var parametro in Parametros)
                        {
                            cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
                        }

                        cmd.Connection = openConnection();
                        Adapter.DeleteCommand = cmd;
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        SqlErrorNumber = e.Number;
                        SqlErrorMesage = e.Message;
                        return false;
                    }
                }
            }
            return true;
        }

        public bool ExecuteDelete(string NombreStoredProcedure)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(NombreStoredProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cmd.Connection = openConnection();
                        Adapter.DeleteCommand = cmd;
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        SqlErrorNumber = e.Number;
                        SqlErrorMesage = e.Message;
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Ejecuta la sentencia SQL y regresa el total de registros afectados
        /// </summary>
        /// <param name="NombreStoredProcedure">Nombre del stored procedure a ejecutar</param>
        /// <param name="Parametros">Listado de parámetros a enviar al stored procedure</param>
        public int ExecuteNonQuery(string NombreStoredProcedure, Dictionary<string, object> Parametros)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(NombreStoredProcedure, conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Cargamos los paramatros con sus respectivos valores
                        foreach (var parametro in Parametros)
                        {
                            cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
                        }

                        conn.Open();
                        Adapter.SelectCommand = cmd;

                        return cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        SqlErrorNumber = e.Number;
                        SqlErrorMesage = e.Message;
                        return 0;
                    }
                }
            }
            //return dataTable;
        }

        /// <summary>
        /// Ejecuta la sentencia SQL y regresa el total de registros afectados
        /// </summary>
        /// <param name="NombreStoredProcedure">Nombre del stored procedure a ejecutar</param>
        public int ExecuteNonQuery(string NombreStoredProcedure)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(NombreStoredProcedure, conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        Adapter.SelectCommand = cmd;
                        return cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        SqlErrorNumber = e.Number;
                        SqlErrorMesage = e.Message;
                        return 0;
                    }
                }
            }

        }

    } //clae
}//namespace
