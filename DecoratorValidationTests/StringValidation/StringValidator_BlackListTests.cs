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
    public class StringValidator_BlackListTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void SetUp()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        public void WhenStringValidatorBlacklistFails_ValidatorReturnFalse()
        {
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_BlackList(validator, new List<string> { "banned" }, "Blacklist failed");

            bool result = validator.Validate("banned");
            Assert.That(result, Is.False);
        }

        [Test()]
        public void WhenStringValidatorBlacklistFails_ErrorMessageIsSet()
        {
            
            string errorMessage = "Blacklist failed";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_BlackList(validator, new List<string> { "banned" }, errorMessage);

            bool result = validator.Validate("banned");
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }

        [Test()]
        public void ValidateTest_Passes()
        {
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_BlackList(validator, new List<string> { "banned" }, "Blacklist failed");

            bool result = validator.Validate("not banned");
            Assert.That(result, Is.True);
        }
    }
}
