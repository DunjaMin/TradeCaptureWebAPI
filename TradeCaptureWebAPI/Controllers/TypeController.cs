using Microsoft.AspNetCore.Mvc;
using TradeCaptureWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradeCaptureWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly TradeCaptureContext _context;
        public TypeController(TradeCaptureContext context) 
        {
            _context = context;
        }

        [HttpGet("Get-By-id")]
        public async Task<ActionResult<SecurityType>> GetType(int tid)
        {
            var type = await _context.SecurityType.FindAsync(tid);

            if (type == null)
                return NotFound();

            return type;
        }

        [HttpGet("Get-All")]
        public IEnumerable<SecurityType> GetAll()
        {
            try { 

            var securityTypes= _context.SecurityType.ToList();
            return securityTypes;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<SecurityType>();
            }
        }


    }
}
