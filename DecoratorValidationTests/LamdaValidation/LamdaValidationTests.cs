using DecoratorValidation.Core;
using DecoratorValidation.LamdaValidation.Validators;
using NUnit.Framework;
using System;
using System.Text;

namespace DecoratorValidationTests.LamdaValidation
{
    [TestFixture]
    public class LamdaValidationTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test]
        public void LamdaValidator_Validates_Fail()
        {
            string errorMessage = "Lamda not met";
            Validator<Guid> validator = new ValidatorBaseCase<Guid>();
            Guid expectedValue = Guid.NewGuid();
            validator = new LamdaValidator<Guid>(validator, g => g == expectedValue, errorMessage);
            bool actual = validator.Validate(Guid.NewGuid());
            Assert.That(actual, Is.False);
        }

        [Test]
        public void LamdaValidator_Validates_Pass()
        {
            string errorMessage = "Lamda not met";
            Validator<Guid> validator = new ValidatorBaseCase<Guid>();
            Guid expectedValue = Guid.NewGuid();
            validator = new LamdaValidator<Guid>(validator, g => g == expectedValue, errorMessage);
            bool actual = validator.Validate(expectedValue);
            Assert.That(actual, Is.True);
        }

        [Test]
        public void LamdaValidator_Validates_FailProducesError()
        {
            string errorMessage = "Lamda not met";
            Validator<Guid> validator = new ValidatorBaseCase<Guid>();
            Guid expectedValue = Guid.NewGuid();
            validator = new LamdaValidator<Guid>(validator, g => g == expectedValue, errorMessage);
            bool actual = validator.Validate(Guid.NewGuid());
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
