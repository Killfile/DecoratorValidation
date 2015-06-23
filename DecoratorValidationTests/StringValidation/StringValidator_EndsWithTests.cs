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
    public class StringValidator_EndsWithTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase("ABC", "BC", true, Result = true)]
        [TestCase("ABC", "bc", true, Result = false)]
        [TestCase("ABC", "AB", true, Result = false)]
        [TestCase("ABC", "ABCD", true, Result = false)]
        [TestCase("ABCABC", "ABCABC", true, Result = true)]
        [TestCase("ABC", "bc", true, Result = false)]
        [TestCase("ABCABC", "abcabc", true, Result = false)]
        [TestCase("ABC", "bc", false, Result = true)]
        [TestCase("ABCABC", "abcabc", false, Result = true)]
        public bool WhenEndsWithValidates(string candidate, string EndsWith, bool caseSensitive)
        {
            string error = "EndsWith not met";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_EndsWith(validator, EndsWith, error, caseSensitive);
            return validator.Validate(candidate);
        }

        [Test()]
        public void WhenEndsWithDoesNotValidate_GenerateError()
        {
            string errorMessage = "EndsWith not found";
            string candidate = "abcabc";
            string EndsWith = "D";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_EndsWith(validator, EndsWith, errorMessage);
            bool result = validator.Validate(candidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
