using AgroVA.Domain.Entities;
using FluentAssertions;

namespace AgroVA.Domain.Tests
{
    public class FarmerUnitTest1
    {
        [Fact(DisplayName = "Create Farmer With Valid State")]
        public void AddFarmer_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Farmer(1, "Name", "0123456789");

            action.Should()
                .NotThrow<AgroVA.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Farmer With Empty Name")]
        public void AddFarmer_WithEmptyName_DomainExceptionInvalidName()
        {
            Action action = () => new Farmer(1, "", "0123456789");

            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.FarmerMessage.InvalidName);
        }

        [Fact(DisplayName = "Create Farmer With Empty Phone")]
        public void AddFarmer_WithEmptyPhone_DomainExceptionInvalidPhone()
        {
            Action action = () => new Farmer(1, "Name", "");

            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.FarmerMessage.InvalidPhone);
        }

        [Fact(DisplayName = "Create Farmer With Character Phone")]
        public void AddFarmer_WithCharacterPhone_DomainExceptionInvalidName()
        {
            Action action = () => new Farmer(1, "Name", "Phone");

            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.FarmerMessage.InvalidPhone);
        }

        [Fact(DisplayName = "Create Farmer With Short Phone")]
        public void AddFarmer_WithShortPhone_DomainExceptionInvalidName()
        {
            Action action = () => new Farmer(1, "Name", "0123456");

            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.FarmerMessage.ShortPhone);
        }

        [Fact(DisplayName = "Create Farmer With Negative Id")]
        public void AddFarmer_WithNegativeId_DomainExceptionInvalidId()
        {
            Action action = () => new Farmer(-1, "Name", "0123456789");

            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.FarmerMessage.InvalidId);
        }
    }
}