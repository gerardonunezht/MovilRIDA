using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Text.RegularExpressions;

namespace Movil_RIDA
{
    public class Producto
    {
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public string Familia { get; set; }
        public string Linea { get; set; }
        public string CodBarras { get; set; }
        public int Multiplo { get; set; }
        public int Nivel { get; set; }
        public string PermiteCapturarMultiplo { get; set; }

        public Producto()
        {

        }

        public void ObtenerDatosProducto(string pCodigoBarras,string pIdProcesoADN)
        {
            DataRow dr;
            dr = ObtenerDatosGeneralesProductoPorCodigo(pCodigoBarras);
            if (dr != null)
            {
                this.CodBarras = pCodigoBarras;
                this.Clave = dr["Clave"].ToString().Trim();
                this.Descripcion = dr["Descripcion"].ToString().Trim();
                this.Familia = dr["Familia"].ToString().Trim();
                this.Linea = dr["Linea"].ToString().Trim();
                this.Multiplo = Convert.ToInt16(dr["Multiplo"]);
                this.Nivel = Convert.ToInt16(dr["Nivel"]);
                this.PermiteCapturarMultiplo = PermiteCapturarMultiploEmbarque(this.Clave, pIdProcesoADN);
            }
            else
            {
                this.Clave = "";
            }
        }

        /// <summary>
        /// Determina si el producto acepta o no la captura de multiplo de empaque para el proceso
        /// </summary>
        /// <param name="pClaveHT">Clave interna de producto</param>
        private string PermiteCapturarMultiploEmbarque(string pClave, string pIdProcesoADN)
        {
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

        }

        /// <summary>
        /// Permite obtener los datos generales de la clave de un producto asociados al codifo de barras, tales como:
        ///	Clave, CodigoBarras, Descripción, Multiplo, Nivel, ClaveCategoria, NombreCatagoria, ClaveFamilia, NombreFamilia, ClaveLinea, NombreLinea, ClaveCategoria, NombreCategoria, UnidadVenta, PrecioLista, ConfiguradoPedimento
        ///	Peso, Largo, Alto, Ancho, Diam
        /// </summary>
        /// <param name="pCodigoBarras"></param>
        /// <returns>Un solo registro con los siguientes campos:
        ///	Clave, CodigoBarras, Descripción, Multiplo, Nivel, ClaveCategoria, NombreCatagoria, ClaveFamilia, NombreFamilia, ClaveLinea, NombreLinea, ClaveCategoria, NombreCategoria, UnidadVenta, PrecioLista, ConfiguradoPedimento
        ///	Peso, Largo, Alto, Ancho, Diam
        /// </returns>
        private DataRow ObtenerDatosGeneralesProductoPorCodigo(string pCodigoBarras)
        {
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                //Declaramos el comando para ejecutar el query
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("ObtenerDatosGeneralesProductoPorCodigoBarras", Global.cnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@CodigoBarras", pCodigoBarras);
                //Abrimos conexin a BD
                Global.cnSQL.Open();
                //Llenanos un DataSet con el resultado de la(s) consulta(s)
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0) //Si se encontró un registro,  se regresa el registro con los datos del producto
                {
                    dr = ds.Tables[0].Rows[0];
                    return dr;
                }
                else //no se encontro información en la base de daots del codigo 
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

        /// <summary>
        /// Este método valida que la cantidad capturada sea un valor númerico entero o decimal con formato 999999.99
        /// </summary>
        /// <param name="Cantidad">Valor que se desea evaluar que coincida con el patrón de dígitos</param>
        /// <returns></returns>
        public static bool ValidaCantidad(string Cantidad)
        {
            Regex ER = new Regex(@"^[0-9]{1,6}(\.[0-9]{1,2})?$"); //999999.99
            return (ER.IsMatch(Cantidad));
        }

        public DataSet ObtenerNivelesPorCodigoClave(string pValor)
        {
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
        }

    }//fin clase
}
