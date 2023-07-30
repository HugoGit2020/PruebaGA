using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Modelo;
using webapi.Servicio;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly Conecta conecta;

        public TicketController(Conecta conecta )
        {
            this.conecta = conecta;
        }

        [HttpPost]
        [HttpPost("/Ticket")]
        public async Task<ActionResult<string>> PostTicket(TicketRequest t)
        {
            conecta.IngresaTicket(t.Id_Tienda, t.Id_Registradora, t.FechaHora, t.Ticket,t.Impuesto, t.Total);

            return "ok";

        }

    }
}
