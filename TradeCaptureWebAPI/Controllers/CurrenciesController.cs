using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TradeCaptureWebAPI.Models;

namespace TradeCaptureWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : Controller
    {
        private readonly TradeCaptureContext _context;

        public CurrenciesController(TradeCaptureContext context)
        {
            _context = context;
        }

        [HttpGet("Get-All-Currencies")]
        public IEnumerable<Currency> GetAll()
        {
            try
            {

                var currencies = _context.Currency.ToList();
                return currencies;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Currency>();
            }
        }
    }
}
