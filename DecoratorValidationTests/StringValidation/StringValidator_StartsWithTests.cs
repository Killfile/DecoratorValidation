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
    public class StringValidator_StartsWithTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase("ABC", "BC", false)]
        [TestCase("ABC", "AB", true)]
        [TestCase("ABC", "ABCD", false)]
        [TestCase("ABCABC", "ABCABC", true)]
        public void WhenStartsWithValidates(string candidate, string StartsWith, bool expectedResult)
        {
            string error = "StartsWith not met";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_StartsWith(validator, StartsWith, error);
            bool result = validator.Validate(candidate);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test()]
        public void WhenStartsWithDoesNotValidate_GenerateError()
        {
            string errorMessage = "StartsWith not found";
            string candidate = "abcabc";
            string StartsWith = "D";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_StartsWith(validator, StartsWith, errorMessage);
            bool result = validator.Validate(candidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
