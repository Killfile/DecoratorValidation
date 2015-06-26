using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorValidation.DecimalValidation.Validators;
using NUnit.Framework;
using DecoratorValidation.Core;

namespace DecoratorValidation.DecimalValidation.Validators.Tests
{
    [TestFixture()]
    public class DecimalValidator_GreaterThanTests
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
        public void WhenDecimalValidator_GreaterThanValidates(decimal toValidate, decimal bound, bool orEqualTo, bool expectedResult)
        {
            string errorMessage = "DecimalValidator_GreaterThan Failed";
            Validator<decimal> validator = new ValidatorBaseCase<decimal>();
            validator = new DecimalValidator_GreaterThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test()]
        [TestCase(1, 1, false)]
        public void WhenDecimalValidator_GreaterThanFails_ErrorMessageIsGenerated(decimal toValidate, decimal bound, bool orEqualTo)
        {
            string errorMessage = "DecimalValidator_GreaterThan Failed";
            Validator<decimal> validator = new ValidatorBaseCase<decimal>();
            validator = new DecimalValidator_GreaterThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }

        [Test]
        public void ShouldFail()
        {
            //Validator<int> validator = new ValidatorBaseCase<int>();
            //Validator<decimal> intVal = new DecimalValidator_GreaterThan(validator, 5, false, "error");
        }
    }
}
