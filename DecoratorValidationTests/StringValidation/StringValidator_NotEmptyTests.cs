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
    public class StringValidator_NotEmptyTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("Yo", true)]
        public void WhenNotEmptyValidates(string candidate, bool expectedResult)
        {
            string error = "Empty!";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_NotEmpty(validator, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test()]
        public void WhenNotEmptyDoesNotValidate_GenerateError()
        {
            string error = "Empty!";
            string candidate = string.Empty;
            int NotEmpty = 9;
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_NotEmpty(validator, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(errorAccumulator.ToString(), Is.EqualTo(error));
        }
    }
}
