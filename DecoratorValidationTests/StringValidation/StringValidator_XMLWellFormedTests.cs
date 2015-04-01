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
    public class StringValidator_XMLWellFormedTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase("<strong>stuff", false)]
        [TestCase("<strong>stuff</strong>",  true)]
 
        public void WhenXMLWellFormedValidates(string candidate,  bool expectedResult)
        {
            string error = "XMLWellFormed not met";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_XMLWellFormed(validator, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test()]
        public void WhenXMLWellFormedDoesNotValidate_GenerateError()
        {
            string error = "XMLWellFormed not found";
            string candidate = "<strong>stuff";
     
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_XMLWellFormed(validator, error);
            bool result = validator.Validate(candidate, errorAccumulator);
            Assert.That(errorAccumulator.ToString(), Is.EqualTo(error));
        }
    }
}
