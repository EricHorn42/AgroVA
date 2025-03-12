using AgroVA.Domain.Entities;
using AgroVA.Domain.Messages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroVA.Application.DTOs
{
    public class ReceiptDTO : DTOBase
    {
        [Required(ErrorMessage = ReceiptMessage.RequiredTimestamp)]
        [Timestamp]
        [DisplayName("Timestamp")]
        public DateTime Timestamp { get; set; }

        [Required(ErrorMessage = ReceiptMessage.RequiredValue)]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Value")]
        public decimal Value { get; set; }

        [DisplayName("Farmer")]
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        [DisplayName("Harvest")]
        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }
    }
}
