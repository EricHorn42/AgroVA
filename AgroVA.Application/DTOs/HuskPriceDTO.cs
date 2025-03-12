using AgroVA.Domain.Entities;
using AgroVA.Domain.Messages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroVA.Application.DTOs
{
    public class HuskPriceDTO : DTOBase
    {
        [Required(ErrorMessage = HuskPriceMessage.RequiredTimestamp)]
        [Timestamp]
        [DisplayName("Timestamp")]
        public DateTime Timestamp { get; set; }

        [Required(ErrorMessage = HuskPriceMessage.RequiredPercent)]
        [MaxLength(3, ErrorMessage = HuskPriceMessage.MaxLengthPercent)]
        [Column(TypeName = "decimal(3,2)")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        [DisplayName("Percent")]
        public decimal Percent { get; set; }

        [Required(ErrorMessage = HuskPriceMessage.RequiredPrice)]
        [MaxLength(7, ErrorMessage = HuskPriceMessage.MaxlengthPrice)]
        [Column(TypeName = "decimal(7,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [DisplayName("Harvest")]
        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }

    }
}
