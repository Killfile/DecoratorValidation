using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorValidation.DecimalValidation.Validators;
using NUnit.Framework;
using DecoratorValidation.Core;
namespace DecoratorValidation.DecimalValidation.Validators.Tests
{
    [TestFixture()]
    public class DecimalValidator_WithinTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase(0D, 1D, 1.5D, true, Description = "Within bound")]
        [TestCase(0D, 1.5D, 1.5D, true, Description="At bound")]
        [TestCase(0D, -2D, 1.5D, false, Description="Too high")]
        [TestCase(0D, 2D, 1.5D, false, Description="Too low")]

        [TestCase(0D, 1D, -1.5D, true, Description = "Negative Delta: Within bound")]
        [TestCase(0D, 1.5D, -1.5D, true, Description = "Negative Delta: At bound")]
        [TestCase(0D, -2D, -1.5D, false, Description = "Negative Delta: too high")]
        [TestCase(0D, 2D, -1.5D, false, Description = "Negative Delta: too low")]
        public void WhenDecimalValidator_WithinValidates(decimal toValidate, decimal target, decimal delta, bool expectedResult)
        {
            string errorMessage = "DecimalValidator_Within Failed";
            Validator<decimal> validator = new ValidatorBaseCase<decimal>();
            validator = new DecimalValidator_Within(validator, target, delta, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test()]
        [TestCase(1D, 2D, .5D)]
        public void WhenDecimalValidator_WithinFails_ErrorMessageIsGenerated(decimal toValidate, decimal target, decimal delta)
        {
            string errorMessage = "DecimalValidator_Within Failed";
            Validator<decimal> validator = new ValidatorBaseCase<decimal>();
            validator = new DecimalValidator_Within(validator, target, delta, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
