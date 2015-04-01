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
    public class DateValidator_BeforeTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase("2000-01-01 00:00:00", "2000-01-01 00:00:01", true)]
        [TestCase("2000-01-01 00:00:00", "2000-01-01 00:00:00", false)]
        [TestCase("2000-01-01 00:00:01", "2000-01-01 00:00:00", false)]
        public void WhenDateValidator_BeforeValidates(String toValidate, String bound, bool expectedResult)
        {
            DateTime ToValidate = DateTime.Parse(toValidate);
            DateTime Bound = DateTime.Parse(bound);
            string errorMessage = "DateValidator_Before Failed";
            Validator<DateTime> validator = new ValidatorBaseCase<DateTime>();
            validator = new DateValidator_Before(validator, Bound, errorMessage);
            bool actual = validator.Validate(ToValidate, errorAccumulator);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test()]
        [TestCase("2000-01-01 00:00:00", "2000-01-01 00:00:00")]
        public void WhenDateValidator_BeforeFails_ErrorMessageIsGenerated(String toValidate, String bound)
        {
            DateTime ToValidate = DateTime.Parse(toValidate);
            DateTime Bound = DateTime.Parse(bound);
            string errorMessage = "DateValidator_Before Failed";
            Validator<DateTime> validator = new ValidatorBaseCase<DateTime>();
            validator = new DateValidator_Before(validator, Bound, errorMessage);
            bool actual = validator.Validate(ToValidate, errorAccumulator);
            Assert.That(errorAccumulator.ToString(), Is.EqualTo(errorMessage));
        }
    }
}
