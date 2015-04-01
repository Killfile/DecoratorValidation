using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorValidation.BoolValidation.Validators;
using NUnit.Framework;
using DecoratorValidation.Core;
namespace DecoratorValidation.BoolValidation.Validators.Tests
{
    [TestFixture()]
    public class BoolValidator_ExpectedValueTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase(true, true, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, true)]
        public void WhenBoolValidator_ExpectedValueValidates(bool toValidate, bool expectedValue, bool expectedResult)
        {
            string errorMessage = "BoolValidator_ExpectedValue Failed";
            Validator<bool> validator = new ValidatorBaseCase<bool>();
            validator = new BoolValidator_ExpectedValue(validator, expectedValue, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test()]
        [TestCase(true, false)]
        public void WhenBoolValidator_ExpectedValueFails_ErrorMessageIsGenerated(bool toValidate, bool expectedValue)
        {
            string errorMessage = "BoolValidator_ExpectedValue Failed";
            Validator<bool> validator = new ValidatorBaseCase<bool>();
            validator = new BoolValidator_ExpectedValue(validator, expectedValue, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
