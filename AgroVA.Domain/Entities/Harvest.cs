using AgroVA.Domain.Messages;
using AgroVA.Domain.Validation;

namespace AgroVA.Domain.Entities;

public sealed class Harvest : EntityBase
{
    public int Year { get; private set; }

    public Harvest(int id, int year)
    {
        DomainExceptionValidation.When(id < 0, HarvestMessage.InvalidId);
        Id = id;
        ValidateDomain(year);
    }

    public Harvest(int year)
    {
        ValidateDomain(year);
    }

    public void Update(int year)
    {
        ValidateDomain(year);
    }

    public ICollection<Annotation> Annotations { get; set; }
    public ICollection<HuskPrice> HuskPrices { get; set; }
    public ICollection<Load> Loads { get; set; }
    public ICollection<Promissory> Promissories { get; set; }
    public ICollection<Receipt> Receipts { get; set; }
    public ICollection<Rent> Rents { get; set; }

    private void ValidateDomain(int year)
    {
        DomainExceptionValidation.When(year <= 0, HarvestMessage.InvalidYear);
        Year = year;
    }
}
