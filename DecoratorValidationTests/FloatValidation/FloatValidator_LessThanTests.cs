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
    public class FloatValidator_LessThanTests
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
        [TestCase(2, 1, true, false)]
        [TestCase(2, 1, false, false)]
        [TestCase(1, 2, true, true)]
        [TestCase(1, 2, false, true)]
        public void WhenFloatValidator_LessThanValidates(float toValidate, float bound, bool orEqualTo, bool expectedResult)
        {
            string errorMessage = "FloatValidator_LessThan Failed";
            Validator<float> validator = new ValidatorBaseCase<float>();
            validator = new FloatValidator_LessThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test()]
        [TestCase(1, 1, false)]
        public void WhenFloatValidator_LessThanFails_ErrorMessageIsGenerated(float toValidate, float bound, bool orEqualTo)
        {
            string errorMessage = "FloatValidator_LessThan Failed";
            Validator<float> validator = new ValidatorBaseCase<float>();
            validator = new FloatValidator_LessThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
