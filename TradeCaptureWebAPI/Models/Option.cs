using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeCaptureWebAPI.Models
{
    [Table("Option")]
    public class Option : Security
    {
        public Option() { }

        [Display(Name = "Side id")]
        [Column("sideId")]
        public int SideId { get; set; }

        [Display(Name = "Expiration time")]
        [Column("expirationTime")]
        public DateTime ExpirationTime { get; set; }

        [Display(Name = "Contract size")]
        [Column("contractSize")]
        public int ContractSize { get; set; }

        [Column("strike")]
        public int Strike { get; set; }

        [Column("optionStyleId")]
        public int OptionStyleId { get; set; }

        [Column("settlementId")]
        public int SettlementId { get; set; } 


    }
}
