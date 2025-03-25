using AgroVA.Domain.Messages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgroVA.Application.DTOs;

public class HarvestDTO : DTOBase
{
    [Required(ErrorMessage = HarvestMessage.RequiredYear)]
    [DisplayName("Ano")]
    public int Year { get; set; }
}
