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
    public class StringValidator_EmailTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        public void WhenEmailValidates_Pass()
        {
            string error = "Email not found";
            string candidate = "foo@bar.com";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_Email(validator, error);
            bool result = validator.Validate(candidate);
            Assert.That(result, Is.True);
        }

        [Test()]
        public void WhenEmailDoesNotValidate_Fail()
        {
            string error = "Email not found";
            string candidate = "foobar.com";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_Email(validator, error);
            bool result = validator.Validate(candidate);
            Assert.That(result, Is.False);
        }

        [Test()]
        public void WhenEmailDoesNotValidate_GenerateError()
        {
            string errorMessage = "Email not found";
            string candidate = "foobar.com";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_Email(validator, errorMessage);
            bool result = validator.Validate(candidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
