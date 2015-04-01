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
    public class StringValidator_MinNumericCharsTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        public void WhenMinNumericCharsValidates_Pass()
        {
            string error = "MinNumericChars not met";
            string candidate = "12345678";
            int MinNumericChars = 8;
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinNumericChars(validator, MinNumericChars, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(result, Is.True);
        }

        [Test()]
        public void WhenMinNumericCharsDoesNotValidate_Fail()
        {
            string error = "MinNumericChars not met";
            string candidate = "1234567a";
            int MinNumericChars = 8;
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinNumericChars(validator, MinNumericChars, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(result, Is.False);
        }

        [Test()]
        public void WhenMinNumericCharsDoesNotValidate_GenerateError()
        {
            string error = "MinNumericChars not found";
            string candidate = "1234567a";
            int MinNumericChars = 9;
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinNumericChars(validator, MinNumericChars, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(errorAccumulator.ToString(), Is.EqualTo(error));
        }
    }
}
