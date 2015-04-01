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
    public class StringValidator_MinLowerCaseCharsTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        public void WhenMinLowerCaseCharsValidates_Pass()
        {
            string error = "MinLowerCaseChars not met";
            string candidate = "abcABC";
            int MinLowerCaseChars = 3;
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinLowerCaseChars(validator, MinLowerCaseChars, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(result, Is.True);
        }

        [Test()]
        public void WhenMinLowerCaseCharsDoesNotValidate_Fail()
        {
            string error = "MinLowerCaseChars not met";
            string candidate = "abCABC";
            int MinLowerCaseChars = 3;
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinLowerCaseChars(validator, MinLowerCaseChars, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(result, Is.False);
        }

        [Test()]
        public void WhenMinLowerCaseCharsDoesNotValidate_GenerateError()
        {
            string error = "MinLowerCaseChars not found";
            string candidate = "abCABC";
            int MinLowerCaseChars = 3;
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinLowerCaseChars(validator, MinLowerCaseChars, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(errorAccumulator.ToString(), Is.EqualTo(error));
        }
    }
}
