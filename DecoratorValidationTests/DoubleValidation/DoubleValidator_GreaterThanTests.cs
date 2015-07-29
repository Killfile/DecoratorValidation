using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorValidation.DoubleValidation.Validators;
using NUnit.Framework;
using DecoratorValidation.Core;
namespace DecoratorValidation.DoubleValidation.Validators.Tests
{
    [TestFixture()]
    public class DoubleValidator_GreaterThanTests
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
        public void WhenDoubleValidator_GreaterThanValidates(double toValidate, double bound, bool orEqualTo, bool expectedResult)
        {
            string errorMessage = "DoubleValidator_GreaterThan Failed";
            Validator<double> validator = new ValidatorBaseCase<double>();
            validator = new DoubleValidator_GreaterThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }



        [Test()]
        [TestCase(1, 1, false)]
        public void WhenDoubleValidator_GreaterThanFails_ErrorMessageIsGenerated(double toValidate, double bound, bool orEqualTo)
        {
            string errorMessage = "DoubleValidator_GreaterThan Failed";
            Validator<double> validator = new ValidatorBaseCase<double>();
            validator = new DoubleValidator_GreaterThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }

        [Test]
        [TestCase(5.5, typeof(int), Result=true, Description="Rounds to 6")]
        [TestCase(5.5, typeof(sbyte), Result = true, Description = "Rounds to 6")]
        [TestCase(5.5, typeof(byte), Result = true, Description = "Rounds to 6")]
        [TestCase(5.5, typeof(short), Result = true, Description = "Rounds to 6")]
        [TestCase(5.5, typeof(ushort), Result = true, Description = "Rounds to 6")]
        [TestCase(5.5, typeof(uint), Result = true, Description = "Rounds to 6")]
        [TestCase(5.5, typeof(long), Result = true, Description = "Rounds to 6")]
        [TestCase(5.5, typeof(float), Result = true, Description = "Rounds to 6")]
        public bool WhenDoubleValidatorIsUsedWithType(double baseValue, Type type)
        {
            string errorMessage = "DoubleValidator_GreaterThan Failed";
            var testValue = Convert.ChangeType(baseValue, type);
                        
            Validator<double> validator = new ValidatorBaseCase<double>();
            validator = new DoubleValidator_GreaterThan(validator, 5, false, errorMessage);
            return validator.Validate(testValue);
        }
    }
}
