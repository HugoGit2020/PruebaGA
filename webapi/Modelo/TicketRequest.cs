using System.ComponentModel.DataAnnotations;

namespace webapi.Modelo
{
    public class TicketRequest
    {
        public string Id_Tienda { get; set; }
        public string Id_Registradora { get; set; }
        public DateTime FechaHora { get; set; }
        [Required]
        public int Ticket { get; set; }
        public float Impuesto { get; set; }
        public float Total { get; set; }

    }
}
