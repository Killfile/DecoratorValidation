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
    public class StringValidator_ContainsStringTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        public void WhenContainsStringValidates_Pass()
        {
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_ContainsString(validator, "Contains", "Contains Not Found");
            bool result = validator.Validate("[Contains]");
            Assert.That(result, Is.True);
        }

        [Test()]
        public void WhenContainsStringDoesNotValidate_Fail()
        {
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_ContainsString(validator, "Contains", "Contains Not Found");
            bool result = validator.Validate("[NoDice]");
            Assert.That(result, Is.False);
        }

        [Test()]
        public void WhenContainsStringDoesNotValidate_GenerateError()
        {
            string errorMessage = "Contains Not Found";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_ContainsString(validator, "Contains", errorMessage);
            bool result = validator.Validate("[NoDice]");
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
