using AgroVA.Domain.Messages;
using AgroVA.Domain.Validation;

namespace AgroVA.Domain.Entities;

public sealed class Rent : EntityBase
{
    public string Person { get; private set; }
    public decimal Percent { get; private set; }
    public decimal Value { get; private set; }
    public string? Annotation { get; private set; }

    public int FarmerId { get; set; }
    public Farmer Farmer { get; set; }

    public int HarvestId { get; set; }
    public Harvest Harvest { get; set; }

    public Rent(int id, string? person, decimal percent, decimal value, string? annotation)
    {
        DomainExceptionValidation.When(id < 0, RentMessage.InvalidId);
        Id = id;
        ValidateDomain(person, percent, value, annotation);
    }

    public Rent(string? person, decimal percent, decimal value, string? annotation)
    {
        ValidateDomain(person, percent, value, annotation);
    }

    public void Update(string? person, decimal percent, decimal value, string? annotation, int farmerId, int harvestId)
    {
        ValidateDomain(person, percent, value, annotation);
        FarmerId = farmerId;
        HarvestId = harvestId;
    }

    public void ValidateDomain(string? person, decimal percent, decimal value, string? annotation)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(person), RentMessage.InvalidPerson);
        DomainExceptionValidation.When(percent < 0 || percent > 100, RentMessage.InvalidPercent);
        DomainExceptionValidation.When(value < 0, RentMessage.InvalidValue);
        DomainExceptionValidation.When(string.Empty.Equals(annotation), RentMessage.InvalidAnnotation);

        Person = person;
        Percent = percent;
        Value = value;
        Annotation = annotation;
    }
}
