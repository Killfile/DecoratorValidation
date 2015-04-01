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
    public class StringValidator_RegExTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase("ABC", @"^[AB]{3}", false)]
        [TestCase("ABC", @"^[ABC]{3}", true)]
        [TestCase("aABC", @"^[ABC]{3}", false)]
        [TestCase("ABCABC", @"^[ABC]{3}", true)]
        public void WhenRegExValidates(string candidate, string RegEx, bool expectedResult)
        {
            string error = "RegEx not met";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_RegEx(validator, RegEx, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test()]
        public void WhenRegExDoesNotValidate_GenerateError()
        {
            string error = "RegEx not found";
            string candidate = "abcabc";
            string RegEx = @"$[AB]{3}";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_RegEx(validator, RegEx, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(errorAccumulator.ToString(), Is.EqualTo(error));
        }
    }
}
