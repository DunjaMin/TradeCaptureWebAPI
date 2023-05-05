using Microsoft.AspNetCore.Mvc;
using TradeCaptureWebAPI.Models;

namespace TradeCaptureWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangesController : Controller
    {
        private readonly TradeCaptureContext _context;

        public ExchangesController(TradeCaptureContext context)
        {
            _context = context;
        }

        [HttpGet("Get-All-Exchanges")]
        public IEnumerable<Exchange> GetAll()
        {
            try
            {
                var exchanges = _context.Exchange.ToList();
                return exchanges;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Exchange>();
            }
        }
    }
}
