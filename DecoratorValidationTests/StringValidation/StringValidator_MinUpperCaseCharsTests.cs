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
    public class StringValidator_MinUpperCaseCharsTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase("ABcabc", 3, false)]
        [TestCase("ABCabc", 3, true)]
        [TestCase("ABCABC", 3, true)]
        public void WhenMinUpperCaseCharsValidates(string candidate, int MinUpperCaseChars, bool expectedResult)
        {
            string error = "MinUpperCaseChars not met";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinUpperCaseChars(validator, MinUpperCaseChars, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test()]
        public void WhenMinUpperCaseCharsDoesNotValidate_GenerateError()
        {
            string error = "MinUpperCaseChars not found";
            string candidate = "abcabc";
            int MinUpperCaseChars = 9;
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinUpperCaseChars(validator, MinUpperCaseChars, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(errorAccumulator.ToString(), Is.EqualTo(error));
        }
    }
}
