
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeCaptureWebAPI.Models
{
    public class SecurityType
    {
        [Key]
        [Column("typeId")]
        public int TypeId { get; set; }

        [Column("name")]
        public string? Name { get; set; }
    }
}
