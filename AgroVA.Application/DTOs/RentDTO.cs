using AgroVA.Domain.Entities;
using AgroVA.Domain.Messages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroVA.Application.DTOs
{
    public class RentDTO : DTOBase
    {
        [Required(ErrorMessage = RentMessage.RequiredPerson)]
        [MaxLength(200, ErrorMessage = RentMessage.MaxLengthPerson)]
        [DisplayName("Person")]
        public string Person { get; set; }

        [Required(ErrorMessage = RentMessage.RequiredPercent)]
        [MaxLength(3, ErrorMessage = RentMessage.MaxLengthPercent)]
        [Column(TypeName = "decimal(3,2)")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        [DisplayName("Percent")]
        public decimal Percent { get; set; }

        [Required(ErrorMessage = RentMessage.RequiredValue)]
        [MaxLength(10, ErrorMessage = RentMessage.MaxLengthValue)]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Value")]
        public decimal Value { get; set; }

        [MaxLength(500, ErrorMessage = RentMessage.MaxLengthAnnotation)]
        [DisplayName("Annotation")]
        public string? Annotation { get; set; }

        [DisplayName("Farmer")]
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        [DisplayName("Harvest")]
        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }
    }
}
