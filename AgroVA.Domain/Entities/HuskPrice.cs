using AgroVA.Domain.Messages;
using AgroVA.Domain.Validation;

namespace AgroVA.Domain.Entities
{
    public sealed class HuskPrice : EntityBase
    {
        public DateTime Timestamp { get; private set; }
        public float Percent { get; private set; }
        public float Price { get; private set; }

        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }

        public HuskPrice(int id, DateTime timestamp, float percent, float price)
        {
            DomainExceptionValidation.When(id < 1, HuskPriceMessage.InvalidId);
            Id = id;
            ValidateDomain(timestamp, percent, price);
        }

        public HuskPrice(DateTime timestamp, float percent, float price)
        {
            ValidateDomain(timestamp, percent, price);
        }

        public void Update(DateTime timestamp, float percent, float price, int harvestId)
        {
            ValidateDomain(timestamp, percent, price);
            HarvestId = harvestId;
        }

        public void ValidateDomain(DateTime timestamp, float percent, float price)
        {
            DomainExceptionValidation.When(timestamp == DateTime.MinValue, HuskPriceMessage.InvalidTimestamp);
            DomainExceptionValidation.When(percent < 0 || percent > 100, HuskPriceMessage.InvalidPercent);
            DomainExceptionValidation.When(price < 0, HuskPriceMessage.InvalidPrice);

            Timestamp = timestamp;
            Percent = percent;
            Price = price;
        }
    }
}
