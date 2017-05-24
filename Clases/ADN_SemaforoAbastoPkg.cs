using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class ADN_SemaforoAbastoPkg 
{
	
	public string Clave { get; set; } 
	public string LocalizacionPkg { get; set; } 
	public string ClasifABC { get; set; } 
	public double BufferPkg { get; set; } 
	public double DisponiblePkg { get; set; } 
	public double DisponibleFueraPkg { get; set; } 
	public double NivelBuffer { get; set; } 
	public string PrioridadSemaforo { get; set; } 
	public string Semaforo { get; set; } 
	public double PorAbastecer { get; set; } 
	public string Status { get; set; } 
	public string Abastecedor { get; set; } 
	public string NivelAbastoPkg { get; set; } 
	public string MultiploAbastoPkg { get; set; } 
	public double PorSurtir { get; set; } 
	public double BackOrder { get; set; } 


    //propiedades que no forman parte de algun campo de la tabla
    public string Descripcion { get; set; }
    public string AceptaMultiploEmpaque { get; set; }
    public double DispActualPkg { get; set; }

	//Constructor 
    //public ADN_SemaforoAbastoPkg() { }

}
