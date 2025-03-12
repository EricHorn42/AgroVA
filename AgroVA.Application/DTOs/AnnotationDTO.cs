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
        [DisplayName("Observation")]
        public string Observation { get; set; }

        [Required(ErrorMessage = AnnotationMessage.RequiredTimestamp)]
        [Column(TypeName = "datetime")]
        [Timestamp]
        [DisplayName("Timestamp")]
        public DateTime Timestamp { get; set; }

        [DisplayName("Farmer")]
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        [DisplayName("Harvest")]
        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }
    }
}
