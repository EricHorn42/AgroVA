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
        [DisplayName("Data")]
        public DateOnly Timestamp { get; set; }

        [MaxLength(8, ErrorMessage = LoadMessage.MaxLengthGreenWeight)]
        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Peso verde")]
        public decimal? GreenWeight { get; set; }

        [MaxLength(8, ErrorMessage = LoadMessage.MaxLengthDryWeight)]
        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Peso seco")]
        public decimal? DryWeight { get; set; }

        [Required(ErrorMessage = LoadMessage.RequiredRegister)]
        [DisplayName("Registro")]
        public int Register { get; set; }

        [MaxLength(10, ErrorMessage = LoadMessage.MaxLengthPrice)]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Valor")]
        public decimal? Price { get; set; }

        [MaxLength(3, ErrorMessage = LoadMessage.MaxLengthWholePercent)]
        [Column(TypeName = "decimal(3,2)")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        [DisplayName("Inteiro")]
        public decimal? WholePercent { get; set; }

        [Required(ErrorMessage = LoadMessage.RequiredInvoice)]
        [DisplayName("Nota")]
        public long Invoice { get; set; }

        public int FarmerId { get; set; }

        [DisplayName("Produtor")]
        public Farmer? Farmer { get; set; }

        public int HarvestId { get; set; }

        [DisplayName("Safra")]
        public Harvest? Harvest { get; set; }
    }
}
