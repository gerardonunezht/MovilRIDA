using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Movil_RIDA
{
    public class Product
    {
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public string Familia { get; set; }
        public string Linea { get; set; }
        public string CodBarras { get; set; }
        public int Multiplo { get; set; }
        public int Nivel { get; set; }
        public string PermiteCapturarMultiplo { get; set; }

        public Product()
        {

        }

        public Product GetDatosProducto(string pCodigoBarras)
        {
            //Establecemos la cadena de conexión a la BD
            AccesoDatos db = new AccesoDatos(Properties.Resources.cnStr);

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@CodigoBarras", pCodigoBarras);

            var datos=db.ExecuteSelect("ObtenerDatosGeneralesProductoPorCodigoBarras", Parametros);

            Product obj = new Product();

            if (datos.Rows.Count>0)
            {
                DataRow dr = datos.Rows[0];

                obj.CodBarras=pCodigoBarras;
                obj.CodBarras = pCodigoBarras;
                obj.Clave = dr["Clave"].ToString().Trim();
                obj.Descripcion = dr["Descripcion"].ToString().Trim();
                obj.Familia = dr["Familia"].ToString().Trim();
                obj.Linea = dr["Linea"].ToString().Trim();
                obj.Multiplo = Convert.ToInt16(dr["Multiplo"]);
                obj.Nivel = Convert.ToInt16(dr["Nivel"]); 
            }
            return obj;
        }

        /// <summary>
        /// Determina si el producto acepta o no la captura de multiplo de empaque para el proceso
        /// </summary>
        /// <param name="pClaveHT">Clave interna de producto</param>
        public string PermiteCapturarMultiploEmpaque(string pClave, string pIdProcesoADN)
        {
            //Establecemos la cadena de conexión a la BD
            AccesoDatos db = new AccesoDatos(Properties.Resources.cnStr);

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Articulo", pClave);
            Parametros.Add("@idProceso", pIdProcesoADN);

            var datos = db.ExecuteSelect("ADN_RcpProv_PermiteCapturarMultiploEmbarque", Parametros);

            if (datos.Rows.Count>0)
            {

                return datos.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                return "NO";
            }


            /*
            DataSet ds = new DataSet();
            DataRow dr;

            //Declaramos el comando para ejecutar el query
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("ADN_RcpProv_PermiteCapturarMultiploEmbarque", Global.cnSQL);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@Articulo", pClave);
            cmd.Parameters.AddWithValue("@idProceso", pIdProcesoADN); //para saber el id de los procesos, consultar tabla: ADN_Procesos
            try
            {
                //Abrimos conexin a BD
                Global.cnSQL.Open();
                //Llenanos un DataSet con el resultado de la consulta
                da.Fill(ds);
                dr = ds.Tables[0].Rows[0];
                return dr["PermiteCapturarMultiplo"].ToString().Trim(); //deberia regresar un "SI" o un "NO"

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
            */
        }

        public DataTable ObtenerNivelesPorCodigoClave(string pValor)
        {
            //Establecemos la cadena de conexión a la BD
            AccesoDatos db = new AccesoDatos(Properties.Resources.cnStr);

            Dictionary<string, object> Parametros = new Dictionary<string, object>();
            Parametros.Add("@Valor", pValor);

            var datos = db.ExecuteSelect("ObtenerNivelesPorCodigo_Clave", Parametros);

            if (datos.Rows.Count > 0)
            {   
                return datos;
            }
            else
            {
                return null;
            }


            /*
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ObtenerNivelesPorCodigo_Clave", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@Valor", pValor);
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
                    //Cerramos conexión a BD
                    Global.cnSQL.Close();
                }
            }//finally   
            return null;
             */
        }       
    }
}
