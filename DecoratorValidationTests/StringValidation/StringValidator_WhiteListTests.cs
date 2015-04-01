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
    public class StringValidator_WhiteListTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase("ABC", new String[] {"BC","AB"}, false)]
        [TestCase("ABC", new String[] {}, false)]
        [TestCase("ABC", new String[] { "ABC" }, true)]
        [TestCase("ABC", new String[] { "ABCD" }, false)]
        [TestCase("ABCABC", new String[] { "ABCABC", "DEFDEF", "GHI" }, true)]
        public void WhenWhiteListValidates(string candidate, String[] WhiteList, bool expectedResult)
        {
            string error = "WhiteList not met";
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_WhiteList(validator, WhiteList.ToList(), error);
            bool result = validator.Validate(candidate);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test()]
        public void WhenWhiteListDoesNotValidate_GenerateError()
        {
            string errorMessage = "WhiteList not found";
            string candidate = "abcabc";
            List<String> WhiteList = new List<String>();
            Validator<String> validator = new ValidatorBaseCase<String>();
            validator = new StringValidator_WhiteList(validator, WhiteList, errorMessage);
            bool result = validator.Validate(candidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
