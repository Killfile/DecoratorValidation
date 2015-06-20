using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorValidation.StringValidation.Validators;
using NUnit.Framework;
using DecoratorValidation.Core;
namespace DecoratorValidation.StringValidation.Validators.Tests
{
    [TestFixture()]
    public class StringValidator_ExpectedStringTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        public void WhenExpectedStringValidates_Pass()
        {
            string error = "ExpectedString not found";
            string candidate = "expected";
            string expectedString = "expected";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_ExpectedString(validator, expectedString, error);
            bool result = validator.Validate(candidate);
            Assert.That(result, Is.True);
        }

        [Test()]
        public void WhenExpectedStringDoesNotValidate_Fail()
        {
            string error = "ExpectedString not found";
            string candidate = "notexpected";
            string expectedString = "expected";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_ExpectedString(validator, expectedString, error);
            bool result = validator.Validate(candidate);
            Assert.That(result, Is.False);
        }

        [Test()]
        public void WhenExpectedStringDoesNotValidate_GenerateError()
        {
            string errorMessage = "ExpectedString not found";
            string candidate = "notexpected";
            string expectedString = "expected";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_ExpectedString(validator, expectedString, errorMessage);
            bool result = validator.Validate(candidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
