using AgroVA.Domain.Messages;
using AgroVA.Domain.Validation;

namespace AgroVA.Domain.Entities
{
    public sealed class Receipt : EntityBase
    {
        public DateTime Timestamp { get; private set; }
        public decimal Value { get; private set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }

        public Receipt(int id, DateTime timestamp, decimal value)
        {
            DomainExceptionValidation.When(id < 1, ReceiptMessage.InvalidId);
            Id = id;
            ValidateDomain(timestamp, value);
        }

        public Receipt(DateTime timestamp, decimal value)
        {
            ValidateDomain(timestamp, value);
        }

        public void Update(DateTime timestamp, decimal value, int farmerId, int harvestId)
        {
            ValidateDomain(timestamp, value);
            FarmerId = farmerId;
            HarvestId = harvestId;
        }

        public void ValidateDomain(DateTime timestamp, decimal value)
        {
            DomainExceptionValidation.When(timestamp == DateTime.MinValue, ReceiptMessage.InvalidTimestamp);
            DomainExceptionValidation.When(value < 0, ReceiptMessage.InvalidValue);
            Timestamp = timestamp;
            Value = value;
        }
    }
}
