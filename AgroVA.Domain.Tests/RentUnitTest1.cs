using AgroVA.Domain.Entities;
using FluentAssertions;
using System.ComponentModel;

namespace AgroVA.Domain.Tests
{
    public class RentUnitTest1
    {
        [Fact(DisplayName = "Create Rent With Valid State")]
        public void AddRent_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Rent(1, "Person", 0, 0, "Annotation");

            action.Should()
                .NotThrow<AgroVA.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Rent With Null Annotation")]
        public void AddRent_WithNullAnnotation_NoDomainException()
        {
            Action action = () => new Rent(1, "Person", 0, 0, null);

            action.Should()
                .NotThrow<AgroVA.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Rent With Null Person")]
        public void AddRent_WithNullPerson_DomainExceptionInvalidPerson()
        {
            Action action = () => new Rent(1, null, 0, 0, "Annotation");

            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.RentMessage.InvalidPerson);
        }

        [Fact(DisplayName = "Create Rent With Empty Person")]
        public void AddRent_WithEmptyPerson_DomainExceptionInvalidPerson()
        {
            Action action = () => new Rent(1, "", 0, 0, null);

            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.RentMessage.InvalidPerson);
        }

        [Theory]
        [DisplayName("Create Rent With Negative Percentual")]
        [InlineData(-1)]
        public void AddRent_WithNegativePercentual_DomainExceptionInvalidPercent(int percent)
        {
            Action action = () => new Rent(1, "Person", percent, 0, "Annotation");
            
            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.RentMessage.InvalidPercent);
        }

        [Theory]
        [DisplayName("Create Rent With Negative Value")]
        [InlineData(-1)]
        public void AddRent_WithNegativeValue_DomainExceptionInvalidValue(int value)
        {
            Action action = () => new Rent(1, "Person", 0, value, null);

            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.RentMessage.InvalidValue);
        }

        [Fact(DisplayName = "Create Rent With Negative Id")]
        public void AddRent_WithNegativeId_DomainExceptionInvalidId()
        {
            Action action = () => new Rent(-1, "Person", 0, 0, "Annotation");

            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.RentMessage.InvalidId);
        }
    }
}
