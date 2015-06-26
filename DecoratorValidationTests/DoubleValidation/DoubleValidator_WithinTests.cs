using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorValidation.DoubleValidation.Validators;
using NUnit.Framework;
using DecoratorValidation.Core;
namespace DecoratorValidation.DoubleValidation.Validators.Tests
{
    [TestFixture()]
    public class DoubleValidator_WithinTests
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
        public void WhenDoubleValidator_WithinValidates(double toValidate, double target, double delta, bool expectedResult)
        {
            string errorMessage = "DoubleValidator_Within Failed";
            Validator<double> validator = new ValidatorBaseCase<double>();
            validator = new DoubleValidator_Within(validator, target, delta, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test()]
        [TestCase(1D, 2D, .5D)]
        public void WhenDoubleValidator_WithinFails_ErrorMessageIsGenerated(double toValidate, double target, double delta)
        {
            string errorMessage = "DoubleValidator_Within Failed";
            Validator<double> validator = new ValidatorBaseCase<double>();
            validator = new DoubleValidator_Within(validator, target, delta, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
