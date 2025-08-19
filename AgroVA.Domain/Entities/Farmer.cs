using AgroVA.Domain.Messages;
using AgroVA.Domain.Validation;
using System.Text.RegularExpressions;

namespace AgroVA.Domain.Entities;

public sealed class Farmer : EntityBase
{
    public string Name { get; private set; }
    public string? Phone { get; private set; }

    public Farmer(int id, string name, string phone)
    {
        DomainExceptionValidation.When(id < 0, FarmerMessage.InvalidId);
        Id = id;
        ValidateDomain(name, phone);
    }

    public Farmer(string name, string phone)
    {
        ValidateDomain(name, phone);
    }

    public void Update(string name, string phone)
    {
        ValidateDomain(name, phone);
    }

    public ICollection<Annotation> Annotations { get; set; }
    public ICollection<Load> Loads { get; set; }
    public ICollection<Receipt> Receipts { get; set; }
    public ICollection<Promissory> Promissories { get; set; }
    public ICollection<Rent> Rents { get; set; }

    public void ValidateDomain(string name, string? phone)
    {
        phone = ExtractNumbers(phone);
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), FarmerMessage.InvalidName);
        DomainExceptionValidation.When(string.IsNullOrEmpty(phone), FarmerMessage.InvalidPhone);
        DomainExceptionValidation.When(phone?.Length < 10, FarmerMessage.ShortPhone);
        Name = name;
        Phone = phone;
    }

    private string? ExtractNumbers(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        return Regex.Replace(input, @"\D", "");
    }
}
