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
    public class StringValidator_MinSymbolCharsTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase("!@345678",3,false)]
        [TestCase("!@#45678",3,true)]
        [TestCase("!@#$5678",3, true)]
        public void WhenMinSymbolCharsValidates(string candidate, int MinSymbolChars, bool expectedResult)
        {
            string error = "MinSymbolChars not met";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinSymbolChars(validator, MinSymbolChars, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test()]
        public void WhenMinSymbolCharsDoesNotValidate_GenerateError()
        {
            string error = "MinSymbolChars not found";
            string candidate = "!@34567";
            int MinSymbolChars = 9;
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_MinSymbolChars(validator, MinSymbolChars, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(errorAccumulator.ToString(), Is.EqualTo(error));
        }
    }
}
