using AgroVA.Domain.Entities;
using FluentAssertions;

namespace AgroVA.Domain.Tests
{
    public class HarvestUnitTest1
    {
        [Fact(DisplayName = "Create Harvest With Valid State")]
        public void AddHarvest_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Harvest(1, 2000);

            action.Should()
                .NotThrow<AgroVA.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Harvest With Zero Year")]
        public void AddHarvest_WithZeroYear_DomainExceptionInvalidYear()
        {
            Action action = () => new Harvest(1, 0);

            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.HarvestMessage.InvalidYear);
        }

        [Fact(DisplayName = "Create Harvest With Negative Year")]
        public void AddHarvest_WithNegativeYear_DomainExceptionInvalidYear()
        {
            Action action = () => new Harvest(1, -1);

            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.HarvestMessage.InvalidYear);
        }

        [Fact(DisplayName = "Create Harvest With Negative Id")]
        public void AddHarvest_WithNegativeId_DomainExceptionInvalidId()
        {
            Action action = () => new Harvest(-1, 2000);

            action.Should()
                .Throw<AgroVA.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(AgroVA.Domain.Messages.HarvestMessage.InvalidId);
        }
    }
}
