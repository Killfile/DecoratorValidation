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
    public class StringValidator_MinLengthTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        public void WhenMinLengthValidates_Pass()
        {
            string error = "MinLength not met";
            string candidate = "12345678";
            int MinLength = 8;
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinLength(validator, MinLength, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(result, Is.True);
        }

        [Test()]
        public void WhenMinLengthDoesNotValidate_Fail()
        {
            string error = "MinLength not met";
            string candidate = "1234567";
            int MinLength = 8;
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinLength(validator, MinLength, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(result, Is.False);
        }

        [Test()]
        public void WhenMinLengthDoesNotValidate_GenerateError()
        {
            string error = "MinLength not found";
            string candidate = "1234567";
            int MinLength = 9;
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinLength(validator, MinLength, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(errorAccumulator.ToString(), Is.EqualTo(error));
        }
    }
}
