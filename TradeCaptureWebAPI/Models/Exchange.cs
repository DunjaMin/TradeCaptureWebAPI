using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TradeCaptureWebAPI.Models
{
    public class Exchange
    {
        [Key]
        [Column("exchangeId")]
        public int ExchangeId { get; set; }

        [Column("name")]
        public string? Name { get; set; }
    }
}
