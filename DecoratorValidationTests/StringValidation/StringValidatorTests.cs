using System.Collections.Generic;
using DecoratorValidation.StringValidation;
using DecoratorValidation.StringValidation.Validators;
using NUnit.Framework;
using DecoratorValidation.Core;
using System;

namespace DecoratorValidationTests.StringValidation
{
    [TestFixture]
    public class StringValidatorTests
    {
        [Test]
        public void ValidateTest()
        {
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_BlackList(validator, new List<string>() {"Invalid"}, "Message");
            string errorMessage = null;
            validator.Validate("Invalid", ref errorMessage);
            Assert.AreEqual("Message", errorMessage);
        }
    }
}
