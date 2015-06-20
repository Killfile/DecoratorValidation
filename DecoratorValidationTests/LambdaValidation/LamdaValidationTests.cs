using DecoratorValidation.Core;
using DecoratorValidation.LambdaValidation.Validators;
using NUnit.Framework;
using System;
using System.Text;

namespace DecoratorValidationTests.LambdaValidation
{
    [TestFixture]
    public class LambdaValidationTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test]
        public void LambdaValidator_Validates_Fail()
        {
            string errorMessage = "Lambda not met";
            Validator<Guid> validator = new ValidatorBaseCase<Guid>();
            Guid expectedValue = Guid.NewGuid();
            validator = new LambdaValidator<Guid>(validator, g => g == expectedValue, errorMessage);
            bool actual = validator.Validate(Guid.NewGuid());
            Assert.That(actual, Is.False);
        }

        [Test]
        public void LambdaValidator_Validates_Pass()
        {
            string errorMessage = "Lambda not met";
            Validator<Guid> validator = new ValidatorBaseCase<Guid>();
            Guid expectedValue = Guid.NewGuid();
            validator = new LambdaValidator<Guid>(validator, g => g == expectedValue, errorMessage);
            bool actual = validator.Validate(expectedValue);
            Assert.That(actual, Is.True);
        }

        [Test]
        public void LambdaValidator_Validates_FailProducesError()
        {
            string errorMessage = "Lambda not met";
            Validator<Guid> validator = new ValidatorBaseCase<Guid>();
            Guid expectedValue = Guid.NewGuid();
            validator = new LambdaValidator<Guid>(validator, g => g == expectedValue, errorMessage);
            bool actual = validator.Validate(Guid.NewGuid());
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
