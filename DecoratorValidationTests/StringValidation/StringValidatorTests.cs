using System.Collections.Generic;
using DecoratorValidation.StringValidation;
using DecoratorValidation.StringValidation.Validators;
using NUnit.Framework;
using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidationTests.StringValidation
{
    [TestFixture]
    public class StringValidatorTests
    {
        

        [Test]
        public void ValidateTest()
        {
            string errorMessage = "Message";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_BlackList(validator, new List<string>() {"Invalid"}, errorMessage);
            validator.Validate("Invalid");
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
            
        }
    }
}
