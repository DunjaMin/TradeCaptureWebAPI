using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeCaptureWebAPI.Models
{
    [JsonConverter(typeof(CustomConverter))]
    public class Security
    {
        public Security() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("sid")]
        public int? Sid { get; set; }

        [Column("typeId")]
        public int? TypeId { get; set; }

        [Display(Name = "Security type")]
        [Column("name", TypeName = "varchar(250)")]
        public string? Name { get; set; }

        [Display(Name = "Start date")]
        [Column("startDate", TypeName = "DateTime2")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [Column("endDate", TypeName = "DateTime2")]
        public DateTime EndDate { get; set; }

        [Column("ticker", TypeName = "varchar(50)")]
        public string Ticker { get; set; }

        [Column("exchangeId")]
        public int ExchangeId { get; set; }

        [Column("currencyId")]
        public int CurrencyId { get; set; }

        [Column("underlierSid")]
        public int? UnderlierSid { get; set; }

        [ConcurrencyCheck]
        [Column("version"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? Version { get; set; }

        [Column("created"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Created { get; set; }

        [Column("lastUpdate"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastUpdate { get; set; }

        [Column("updateUser", TypeName = "varchar(250)"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string? UpdateUser { get; set; }

        [JsonIgnore]
        [ForeignKey("UnderlierSid")]
        public Security? UnderlierSecurity { get; set; }

    }
}
