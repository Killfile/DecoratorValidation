using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorValidation.DateValidation.Validators;
using NUnit.Framework;
using DecoratorValidation.Core;
namespace DecoratorValidation.DateValidation.Validators.Tests
{
    [TestFixture()]
    public class DateValidator_AfterTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase("2000-01-01 00:00:00", "2000-01-01 00:00:01", false)]
        [TestCase("2000-01-01 00:00:00", "2000-01-01 00:00:00", false)]
        [TestCase("2000-01-01 00:00:01", "2000-01-01 00:00:00", true)]
        public void WhenDateValidator_AfterValidates(String toValidate, String bound, bool expectedResult)
        {
            DateTime ToValidate = DateTime.Parse(toValidate);
            DateTime Bound = DateTime.Parse(bound);
            string errorMessage = "DateValidator_After Failed";
            Validator<DateTime> validator = new ValidatorBaseCase<DateTime>();
            validator = new DateValidator_After(validator, Bound, errorMessage);
            bool actual = validator.Validate(ToValidate, errorAccumulator);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test()]
        [TestCase("2000-01-01 00:00:00", "2000-01-01 00:00:01")]
        public void WhenDateValidator_AfterFails_ErrorMessageIsGenerated(String toValidate, String bound)
        {
            DateTime ToValidate = DateTime.Parse(toValidate);
            DateTime Bound = DateTime.Parse(bound);
            string errorMessage = "DateValidator_After Failed";
            Validator<DateTime> validator = new ValidatorBaseCase<DateTime>();
            validator = new DateValidator_After(validator, Bound, errorMessage);
            bool actual = validator.Validate(ToValidate, errorAccumulator);
            Assert.That(errorAccumulator.ToString(), Is.EqualTo(errorMessage));
        }
    }
}
