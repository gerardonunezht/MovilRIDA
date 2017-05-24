using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Movil_RIDA
{
    public class SemaforoPkg
    {
        public string Transferencia { get; set; } //Almacena el número consecutivo que genera el sistema de abasto de Picking, el cual será usado como referencia en la Tranferencia final hacia el ERP (Dynamics SL)        
        public string ClaveRecolectar { get; set; } //Almacena la clave del producto a abastecer        
        public string DescrClaveRecolectar { get; set; } //Almacena la descripción del producto a abastecer      
        public string LocalizacionPkgDestino { get; set; } //Almacena la localización de Picking en la cual se tendrá que dejar el producto que se esta abasteciendo
        public Double BufferPkg { get; set; } //Almacena el buffer que tiene asignado la localización de picking del producto a abastecer
        public string NivelBufferPkg { get; set; } //Almacena el nivel actual del buffer en la localización de picking
        public string Semaforo { get; set; } //Almacena el color del semáforo que tiene asignado el producto-localizacion a abastecer al momento del cálculo
        public string LocPermiteCapturarMultiplo { get; set; } //Sirve para indicar si la localización permite capturar multiplos de codigo de barras del producto asignado                
        public string TotalRecolectado { get; set; } //Almacena la cantidad total de unidades recolectadas del producto a abastecer 
        public string TotalRestante { get; set; } //Almacena la cantidad total de unidades que faltan por recolectar
        public string PorRecolectarLoc { get; set; } //Almacena la cantidad de unidades que se deberán de recolectar de la localización
        public string ExistenciaLoc { get; set; } //Almacena la cantidad disponible con la que cuenta la localización        
        public string LocalizacionOrigenRecolectar { get; set; } //Almacena la localización de donde se deberán tomar las unidades a recolectar                               
        public int LocConExistencia { get; set; } //Almacena el total de localizaciones que cuentan con cantidad en existencia para poder recolectar, ademas también sirve para identificar si ya no existen más localizaciones de donde poder recolectar                                
        public string MultiploAbastoPkg { get; set; } //Almacena el múltiplo correspondiente al nivel del codigo de barras del artículo                                        
        public string NombreFormaQueInvocaExcepcion { get; set; } //almacena el nombre de la pantalla que manda invocar a la pantalla de Excepcion        
        public bool PermiteRegistrarExepcionCero { get; set; } //Establece el valor a true (verdadero), para permitir el el registro de una excepción Cero
        public bool RecoleccionGlobalFinalizada { get; set; } //Indicamos si el proceso de recoleccion de claves esta en proceso (false) o finalizado (true)

        //
        public string ClasifABC { get; set; }
        public Double NivelBuffer { get; set; }
        public Double PorAbastecer { get; set; }
        public string NivelAbastoPkg { get; set; }
        public Double DispActualPkg { get; set; }
        public string AceptaMultiploEmpaque { get; set; }


        
    }
}
