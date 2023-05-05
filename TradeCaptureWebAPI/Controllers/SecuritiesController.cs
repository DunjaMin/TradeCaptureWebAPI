using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeCaptureWebAPI.Models;

namespace TradeCaptureWebAPI.Controllers
{
   [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class SecuritiesController : ControllerBase
    {
        private readonly TradeCaptureContext _context;
        public SecuritiesController(TradeCaptureContext context)
        {
            _context = context;
        }

        [HttpGet("Get-By-Sid/{Sid}")]
        public async Task<ActionResult<Security>> GetSecurity(int Sid)
        {
            var security = await _context.Security.FindAsync(Sid);

            if (security == null)
                return NotFound();

            return security;
        }

        [HttpPut("Update-By-Sid")]
        public async Task<IActionResult> PutSecurity([FromBody] Security security)
        {
            /*if (Sid != security.Sid)           
                return BadRequest();*/
            
            _context.Entry(security).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Version mismatch");
            }
            return Ok(security);
        }

        [HttpPost("Create-New-Security")]
        public async Task<ActionResult<Security>> PostNewSecurity([FromBody] Security newSecurity)
        {
            _context.Security.Add(newSecurity);
            await _context.SaveChangesAsync();

            return Ok(newSecurity);
        }
    }
}
