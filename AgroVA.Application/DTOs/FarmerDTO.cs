using AgroVA.Domain.Messages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgroVA.Application.DTOs
{
    public class FarmerDTO : DTOBase
    {
        [Required(ErrorMessage = FarmerMessage.RequiredName)]
        [MaxLength(150, ErrorMessage = FarmerMessage.MaxLengthName)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = FarmerMessage.RequiredPhone)]
        [MinLength(10, ErrorMessage = FarmerMessage.ShortPhone)]
        [MaxLength(13, ErrorMessage = FarmerMessage.LongPhone)]
        [DisplayName("Phone")]
        public string? Phone { get; set; }
    }
}
