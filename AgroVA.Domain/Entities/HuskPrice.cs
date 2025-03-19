using AgroVA.Domain.Messages;
using AgroVA.Domain.Validation;

namespace AgroVA.Domain.Entities
{
    public sealed class HuskPrice : EntityBase
    {
        public DateOnly Timestamp { get; private set; }
        public decimal Percent { get; private set; }
        public decimal Price { get; private set; }

        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }

        public HuskPrice(int id, DateOnly timestamp, decimal percent, decimal price)
        {
            DomainExceptionValidation.When(id < 0, HuskPriceMessage.InvalidId);
            Id = id;
            ValidateDomain(timestamp, percent, price);
        }

        public HuskPrice(DateOnly timestamp, decimal percent, decimal price)
        {
            ValidateDomain(timestamp, percent, price);
        }

        public void Update(DateOnly timestamp, decimal percent, decimal price, int harvestId)
        {
            ValidateDomain(timestamp, percent, price);
            HarvestId = harvestId;
        }

        public void ValidateDomain(DateOnly timestamp, decimal percent, decimal price)
        {
            DomainExceptionValidation.When(timestamp == DateOnly.MinValue, HuskPriceMessage.InvalidTimestamp);
            DomainExceptionValidation.When(percent < 0 || percent > 1, HuskPriceMessage.InvalidPercent);
            DomainExceptionValidation.When(price < 0, HuskPriceMessage.InvalidPrice);

            Timestamp = timestamp;
            Percent = percent;
            Price = price;
        }
    }
}
