using FluentValidation.TestHelper;
using Clothes.Application.CreateClothe;
using Xunit;

namespace Clothes.UnitTest.CreateClotheTest
{
    public class CreateClotheCommandValidatorUnitTest
    {
        private readonly CreateClotheCommandValidator _validator;

        public CreateClotheCommandValidatorUnitTest()
        {
            _validator = new CreateClotheCommandValidator();
        }

        [Fact]
        public void Validate_Name_ShouldHaveValidationErrorWhenNameIsNull()
        {
            // Act
            var result = _validator.TestValidate(new CreateClotheCommand(null, "ValidModel",2024, "ValidChassis", "ValidColor"));

            // Assert
            result.ShouldHaveValidationErrorFor(command => command.Name);
        }

        [Fact]
        public void Validate_Name_ShouldHaveValidationErrorWhenNameIsEmpty()
        {
            // Act
            var result = _validator.TestValidate(new CreateClotheCommand("", "ValidModel", 2024, "ValidChassis", "ValidColor"));

            // Assert
            result.ShouldHaveValidationErrorFor(command => command.Name);
        }

        [Fact]
        public void Validate_Name_ShouldHaveValidationErrorWhenNameIsTooLong()
        {
            // Act
            var result = _validator.TestValidate(new CreateClotheCommand("This is a very long string that is definitely more than one hundred characters long. It is so long that it will definitely exceed the maximum length.", "ValidModel", 2024, "ValidChassis", "ValidColor"));

            // Assert
            result.ShouldHaveValidationErrorFor(command => command.Name);
        }

    }
}
