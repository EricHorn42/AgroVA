using AgroVA.Domain.Messages;
using AgroVA.Domain.Validation;

namespace AgroVA.Domain.Entities;

public sealed class Promissory : EntityBase
{
    public DateOnly Timestamp { get; private set; }
    public decimal Value { get; private set; }

    public int FarmerId { get; set; }
    public Farmer Farmer { get; set; }

    public int HarvestId { get; set; }
    public Harvest Harvest { get; set; }

    public Promissory(int id, DateOnly timestamp, decimal value)
    {
        DomainExceptionValidation.When(id < 0, PromissoryMessage.InvalidId);
        Id = id;
        ValidateDomain(timestamp, value);
    }

    public Promissory(DateOnly timestamp, decimal value)
    {
        ValidateDomain(timestamp, value);
    }

    public void Update(DateOnly timestamp, decimal value, int farmerId, int harvestId)
    {
        ValidateDomain(timestamp, value);
        FarmerId = farmerId;
        HarvestId = harvestId;
    }

    public void ValidateDomain(DateOnly timestamp, decimal value)
    {
        DomainExceptionValidation.When(timestamp == DateOnly.MinValue, PromissoryMessage.InvalidTimestamp);
        DomainExceptionValidation.When(value < 0, PromissoryMessage.InvalidValue);
        Timestamp = timestamp;
        Value = value;
    }
}
