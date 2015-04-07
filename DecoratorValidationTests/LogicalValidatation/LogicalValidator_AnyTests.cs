using DecoratorValidation.Core;
using DecoratorValidation.LogicalValidation;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorValidationTests.LogicalValidatation
{
    [TestFixture]
    public class LogicalValidator_AnyTests
    {

        [Test]
        public void CanConstructAnyValidator()
        {
            List<Validator<bool>> validators = new List<Validator<bool>>()
            {
                GetFixedMock(false),
                GetFixedMock(false),
                GetFixedMock(false)
            };
            
            Validator<bool> anyValidator = new ValidatorBaseCase<bool>();
            anyValidator = new LogicalValidator_Any<bool>(anyValidator, validators, "None validated");
        }
        
        private static Validator<bool> GetFixedMock(bool validationReturnValue)
        {
            var mock = new Mock<Validator<bool>>();
            mock.Setup(m => m.Validate(It.IsAny<bool>())).Returns(validationReturnValue);
            return mock.Object;
        }

        [Test]
        [TestCase(false, false, false, false)]
        [TestCase(true, false, false, true)]
        [TestCase(false, true, false, true)]
        [TestCase(false, false, true, true)]
        [TestCase(false, true, true, true)]
        [TestCase(true, true, false, true)]
        [TestCase(true, true, true, true)]
        public void AnyValidator_Validation(bool a, bool b, bool c, bool expected)
        {
            List<Validator<bool>> validators = new List<Validator<bool>>()
            {
                GetFixedMock(a),
                GetFixedMock(b),
                GetFixedMock(c)
            };

            Validator<bool> anyValidator = new ValidatorBaseCase<bool>();
            anyValidator = new LogicalValidator_Any<bool>(anyValidator, validators, "None validated");
            Assert.That(anyValidator.Validate(true), Is.EqualTo(expected));
        }

    }
}
