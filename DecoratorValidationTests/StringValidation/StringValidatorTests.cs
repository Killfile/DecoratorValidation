using System.Collections.Generic;
using DecoratorValidation.StringValidation;
using DecoratorValidation.StringValidation.Validators;
using NUnit.Framework;

namespace DecoratorValidationTests.StringValidation
{
    [TestFixture]
    public class StringValidatorTests
    {
        [Test]
        public void ValidateTest()
        {
            StringValidator validator = new StringValidatorBaseCase();
            validator = new StringValidator_BlackList(validator, new List<string>() {"Invalid"}, "Message");
            string errorMessage = null;
            validator.Validate("Invalid", ref errorMessage);
            Assert.AreEqual("Message", errorMessage);
        }
    }
}
