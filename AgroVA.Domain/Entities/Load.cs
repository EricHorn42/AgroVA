using AgroVA.Domain.Messages;
using AgroVA.Domain.Validation;

namespace AgroVA.Domain.Entities
{
    public sealed class Load : EntityBase
    {
        public DateTime Timestamp { get; private set; }
        public float? GreenWeight { get; private set; }
        public float? DryWeight { get; private set; }
        public int Register { get; private set; }
        public float? Price { get; private set; }
        public float? WholePercent { get; private set; }
        public long Invoice { get; private set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }

        public Load(int id, DateTime timestamp, float? greenWeight, float? dryWeight, int register, float? price, float? wholePercent, long invoice)
        {
            DomainExceptionValidation.When(id < 1, LoadMessage.InvalidId);
            Id = id;
            ValidateDomain(timestamp, greenWeight, dryWeight, register, price, wholePercent, invoice);
        }

        public Load(DateTime timestamp, float? greenWeight, float? dryWeight, int register, float? price, float? wholePercent, long invoice)
        {
            ValidateDomain(timestamp, greenWeight, dryWeight, register, price, wholePercent, invoice);
        }

        public void Update(DateTime timestamp, float? greenWeight, float? dryWeight, int register, float? price, float wholePercent, long invoice, int farmerId, int harvestId)
        {
            ValidateDomain(timestamp, greenWeight, dryWeight, register, price, wholePercent, invoice);
            FarmerId = farmerId;
            HarvestId = harvestId;
        }

        public void ValidateDomain(DateTime timestamp, float? greenWeight, float? dryWeight, int register, float? price, float? wholePercent, long invoice)
        {
            DomainExceptionValidation.When(timestamp == DateTime.MinValue, LoadMessage.InvalidTimestamp);

            if (greenWeight != null)
                DomainExceptionValidation.When(greenWeight < 0, LoadMessage.InvalidGreenWeight);

            if (dryWeight != null)
                DomainExceptionValidation.When(dryWeight < 0, LoadMessage.InvalidDryWeight);

            DomainExceptionValidation.When(register < 0, LoadMessage.InvalidRegister);

            if (price != null)
                DomainExceptionValidation.When(price < 0, LoadMessage.InvalidPrice);

            if (wholePercent != null)
                DomainExceptionValidation.When(wholePercent < 0 || wholePercent > 100, LoadMessage.InvalidWholePercent);

            DomainExceptionValidation.When(invoice < 0, LoadMessage.InvalidInvoice);

            Timestamp = timestamp;
            GreenWeight = greenWeight;
            DryWeight = dryWeight;
            Register = register;
            Price = price;
            WholePercent = wholePercent;
            Invoice = invoice;
        }
    }
}
