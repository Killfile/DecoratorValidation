using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorValidation.FloatValidation.Validators;
using NUnit.Framework;
using DecoratorValidation.Core;
namespace DecoratorValidation.FloatValidation.Validators.Tests
{
    [TestFixture()]
    public class FloatValidator_WithinTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase(0F, 1F, 1.5F, true, Description = "Within bound")]
        [TestCase(0F, 1.5F, 1.5F, true, Description="At bound")]
        [TestCase(0F, -2F, 1.5F, false, Description="Too high")]
        [TestCase(0F, 2F, 1.5F, false, Description="Too low")]

        [TestCase(0F, 1F, -1.5F, true, Description = "Negative Delta: Within bound")]
        [TestCase(0F, 1.5F, -1.5F, true, Description = "Negative Delta: At bound")]
        [TestCase(0F, -2F, -1.5F, false, Description = "Negative Delta: too high")]
        [TestCase(0F, 2F, -1.5F, false, Description = "Negative Delta: too low")]
        public void WhenFloatValidator_WithinValidates(float toValidate, float target, float delta, bool expectedResult)
        {
            string errorMessage = "FloatValidator_Within Failed";
            Validator<float> validator = new ValidatorBaseCase<float>();
            validator = new FloatValidator_Within(validator, target, delta, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test()]
        [TestCase(1F, 2F, .5F)]
        public void WhenFloatValidator_WithinFails_ErrorMessageIsGenerated(float toValidate, float target, float delta)
        {
            string errorMessage = "FloatValidator_Within Failed";
            Validator<float> validator = new ValidatorBaseCase<float>();
            validator = new FloatValidator_Within(validator, target, delta, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
