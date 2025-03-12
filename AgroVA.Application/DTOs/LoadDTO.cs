using AgroVA.Domain.Entities;
using AgroVA.Domain.Messages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroVA.Application.DTOs
{
    public class LoadDTO : DTOBase
    {
        [Required(ErrorMessage = LoadMessage.RequiredTimestamp)]
        [Timestamp]
        [DisplayName("Timestamp")]
        public DateTime Timestamp { get; set; }

        [MaxLength(8, ErrorMessage = LoadMessage.MaxLengthGreenWeight)]
        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("GreenWeight")]
        public decimal? GreenWeight { get; set; }

        [MaxLength(8, ErrorMessage = LoadMessage.MaxLengthDryWeight)]
        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("DryWeight")]
        public decimal? DryWeight { get; set; }

        [Required(ErrorMessage = LoadMessage.RequiredRegister)]
        [DisplayName("Register")]
        public int Register { get; set; }

        [MaxLength(10, ErrorMessage = LoadMessage.MaxLengthPrice)]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Price")]
        public decimal? Price { get; set; }

        [MaxLength(3, ErrorMessage = LoadMessage.MaxLengthWholePercent)]
        [Column(TypeName = "decimal(3,2)")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        [DisplayName("WholePercent")]
        public decimal? WholePercent { get; set; }

        [Required(ErrorMessage = LoadMessage.RequiredInvoice)]
        [DisplayName("Invoice")]
        public long Invoice { get; set; }

        [DisplayName("Farmer")]
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        [DisplayName("Harvest")]
        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }
    }
}
