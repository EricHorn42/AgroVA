using AgroVA.Domain.Messages;
using AgroVA.Domain.Validation;

namespace AgroVA.Domain.Entities
{
    public sealed class Receipt : EntityBase
    {
        public DateOnly Timestamp { get; private set; }
        public float Value { get; private set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }

        public Receipt(int id, DateOnly timestamp, float value)
        {
            DomainExceptionValidation.When(id < 1, ReceiptMessage.InvalidId);
            Id = id;
            ValidateDomain(timestamp, value);
        }

        public Receipt(DateOnly timestamp, float value)
        {
            ValidateDomain(timestamp, value);
        }

        public void Update(DateOnly timestamp, float value, int farmerId, int harvestId)
        {
            ValidateDomain(timestamp, value);
            FarmerId = farmerId;
            HarvestId = harvestId;
        }

        public void ValidateDomain(DateOnly timestamp, float value)
        {
            DomainExceptionValidation.When(timestamp == DateOnly.MinValue, ReceiptMessage.InvalidTimestamp);
            DomainExceptionValidation.When(value < 0, ReceiptMessage.InvalidValue);
            Timestamp = timestamp;
            Value = value;
        }
    }
}
