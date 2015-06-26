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
    public class DoubleValidator_GreaterThanTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase(1, 1, false, false)]
        [TestCase(1, 1, true, true)]
        [TestCase(2, 1, true, true)]
        [TestCase(2, 1, false, true)]
        [TestCase(1, 2, true, false)]
        [TestCase(1, 2, false, false)]
        public void WhenDoubleValidator_GreaterThanValidates(double toValidate, double bound, bool orEqualTo, bool expectedResult)
        {
            string errorMessage = "DoubleValidator_GreaterThan Failed";
            Validator<double> validator = new ValidatorBaseCase<double>();
            validator = new DoubleValidator_GreaterThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test()]
        [TestCase(1, 1, false)]
        public void WhenDoubleValidator_GreaterThanFails_ErrorMessageIsGenerated(double toValidate, double bound, bool orEqualTo)
        {
            string errorMessage = "DoubleValidator_GreaterThan Failed";
            Validator<double> validator = new ValidatorBaseCase<double>();
            validator = new DoubleValidator_GreaterThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
