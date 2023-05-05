using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TradeCaptureWebAPI.Models
{
    public class Currency
    {
        [Key]
        [Column("currencyId")]
        public int CurrencyId { get; set; } 

        [Column("name")]
        public string? Name { get; set; }

        [Column("rate")]
        public double? Rate { get; set; }
    }
}
