using AgroVA.Domain.Entities;
using AgroVA.Domain.Messages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroVA.Application.DTOs
{
    public class AnnotationDTO : DTOBase
    {
        [Required(ErrorMessage = AnnotationMessage.RequiredObservation)]
        [MaxLength(150, ErrorMessage = AnnotationMessage.LongObservation)]
        [DisplayName("Texto")]
        public string Observation { get; set; }

        [Required(ErrorMessage = AnnotationMessage.RequiredTimestamp)]
        [Timestamp]
        [DisplayName("Data")]
        public DateOnly Timestamp { get; set; }

        public int FarmerId { get; set; }
        
        [DisplayName("Produtor")]
        public Farmer? Farmer { get; set; }

        public int HarvestId { get; set; }

        [DisplayName("Safra")]
        public Harvest? Harvest { get; set; }
    }
}
