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
    public class DecimalValidator_LessThanTests
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
        [TestCase(2, 1, true, false)]
        [TestCase(2, 1, false, false)]
        [TestCase(1, 2, true, true)]
        [TestCase(1, 2, false, true)]
        public void WhenDecimalValidator_LessThanValidates(decimal toValidate, decimal bound, bool orEqualTo, bool expectedResult)
        {
            string errorMessage = "DecimalValidator_LessThan Failed";
            Validator<decimal> validator = new ValidatorBaseCase<decimal>();
            validator = new DecimalValidator_LessThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test()]
        [TestCase(1, 1, false)]
        public void WhenDecimalValidator_LessThanFails_ErrorMessageIsGenerated(decimal toValidate, decimal bound, bool orEqualTo)
        {
            string errorMessage = "DecimalValidator_LessThan Failed";
            Validator<decimal> validator = new ValidatorBaseCase<decimal>();
            validator = new DecimalValidator_LessThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
