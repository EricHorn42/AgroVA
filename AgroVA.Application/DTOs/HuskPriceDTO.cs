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
        [DisplayName("Data")]
        public DateOnly Timestamp { get; set; }

        [Required(ErrorMessage = HuskPriceMessage.RequiredPercent)]
        //[MaxLength(3, ErrorMessage = HuskPriceMessage.MaxLengthPercent)]
        [Column(TypeName = "decimal(3,2)")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        [DisplayName("Percentual")]
        public decimal Percent { get; set; }

        [Required(ErrorMessage = HuskPriceMessage.RequiredPrice)]
        //[MaxLength(7, ErrorMessage = HuskPriceMessage.MaxlengthPrice)]
        [Column(TypeName = "decimal(7,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Price { get; set; }

        public int HarvestId { get; set; }

        [DisplayName("Safra")]
        public Harvest? Harvest { get; set; }

    }
}
