using webapi.Modelo;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace webapi.Servicio
{
    public class Conecta
    {
        string cadenaConexion = "Data Source=34.218.6.36,1435\\evaluaciones;Initial Catalog=evaluacion_hhernandez;Trust Server Certificate=true;User ID=sa;Password=abcd1234";


        public string IngresaTicket(string IdT, string IdRegistradora, DateTime FechaH, int Ticket
            , float impuestos, float Total )
        {
            List<TicketResponse> ultimos = new List<TicketResponse>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                
                try
                {
                    conn.Open();
                    System.Data.Common.DbDataReader r = null;
                    SqlCommand cmd = new SqlCommand("SP_IngresaTicket", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Tienda", IdT);
                    cmd.Parameters.AddWithValue("@Id_Registradora", IdRegistradora);
                    cmd.Parameters.AddWithValue("@FechaHora", FechaH);
                    cmd.Parameters.AddWithValue("@Ticket", Ticket);
                    cmd.Parameters.AddWithValue("@Impuesto", impuestos);
                    cmd.Parameters.AddWithValue("@Total", Total);  
                    r = cmd.ExecuteReader();

                }
                catch (Exception ex)
                {
                    return "Error";
                }
                                

            }
            return "";
        }
    }


 
}
