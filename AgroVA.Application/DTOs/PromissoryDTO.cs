using AgroVA.Domain.Entities;
using AgroVA.Domain.Messages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AgroVA.Application.DTOs;

public class PromissoryDTO : DTOBase
{
    [Required(ErrorMessage = PromissoryMessage.RequiredTimestamp)]
    [Timestamp]
    [DisplayName("Data")]
    public DateOnly Timestamp { get; set; }

    [Required(ErrorMessage = PromissoryMessage.RequiredValue)]
    [Column(TypeName = "decimal(10,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Valor")]
    public decimal Value { get; set; }

    public int FarmerId { get; set; }

    [JsonIgnore]
    [DisplayName("Produtor")]
    public Farmer? Farmer { get; set; }

    public int HarvestId { get; set; }

    [JsonIgnore]
    [DisplayName("Safra")]
    public Harvest? Harvest { get; set; }
}
