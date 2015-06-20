using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorValidation.FloatValidation.Validators;
using NUnit.Framework;
using DecoratorValidation.Core;
namespace DecoratorValidation.FloatValidation.Validators.Tests
{
    [TestFixture()]
    public class FloatValidator_GreaterThanTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase(1, 1, false, false)]
        [TestCase(1, 1, true, true)]
        [TestCase(2, 1, true, true)]
        [TestCase(2, 1, false, true)]
        [TestCase(1, 2, true, false)]
        [TestCase(1, 2, false, false)]
        public void WhenFloatValidator_GreaterThanValidates(float toValidate, float bound, bool orEqualTo, bool expectedResult)
        {
            string errorMessage = "FloatValidator_GreaterThan Failed";
            Validator<float> validator = new ValidatorBaseCase<float>();
            validator = new FloatValidator_GreaterThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test()]
        [TestCase(1, 1, false)]
        public void WhenFloatValidator_GreaterThanFails_ErrorMessageIsGenerated(float toValidate, float bound, bool orEqualTo)
        {
            string errorMessage = "FloatValidator_GreaterThan Failed";
            Validator<float> validator = new ValidatorBaseCase<float>();
            validator = new FloatValidator_GreaterThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
