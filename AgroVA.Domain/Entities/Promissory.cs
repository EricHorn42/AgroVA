using AgroVA.Domain.Messages;
using AgroVA.Domain.Validation;

namespace AgroVA.Domain.Entities
{
    public sealed class Promissory : EntityBase
    {
        public DateTime Timestamp { get; private set; }
        public float Value { get; private set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }

        public Promissory(int id, DateTime timestamp, float value)
        {
            DomainExceptionValidation.When(id < 1, PromissoryMessage.InvalidId);
            Id = id;
            ValidateDomain(timestamp, value);
        }

        public Promissory(DateTime timestamp, float value)
        {
            ValidateDomain(timestamp, value);
        }

        public void Update(DateTime timestamp, float value, int farmerId, int harvestId)
        {
            ValidateDomain(timestamp, value);
            FarmerId = farmerId;
            HarvestId = harvestId;
        }

        public void ValidateDomain(DateTime timestamp, float value)
        {
            DomainExceptionValidation.When(timestamp == DateTime.MinValue, PromissoryMessage.InvalidTimestamp);
            DomainExceptionValidation.When(value < 0, PromissoryMessage.InvalidValue);
            Timestamp = timestamp;
            Value = value;
        }
    }
}
