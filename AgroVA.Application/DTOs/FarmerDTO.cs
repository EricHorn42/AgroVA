using AgroVA.Domain.Messages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgroVA.Application.DTOs;

public class FarmerDTO : DTOBase
{
    //[Required(ErrorMessage = FarmerMessage.RequiredName)]
    [MaxLength(150, ErrorMessage = FarmerMessage.MaxLengthName)]
    [DisplayName("Nome")]
    public string Name { get; set; }

    //[Required(ErrorMessage = FarmerMessage.RequiredPhone)]
    [MinLength(10, ErrorMessage = FarmerMessage.ShortPhone)]
    [MaxLength(13, ErrorMessage = FarmerMessage.LongPhone)]
    [DisplayName("Telefone")]
    public string? Phone { get; set; }
}
