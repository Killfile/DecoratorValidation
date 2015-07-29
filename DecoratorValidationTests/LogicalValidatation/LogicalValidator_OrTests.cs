using System;

using DecoratorValidation.Core;
using DecoratorValidation.BoolValidation.Validators;
using DecoratorValidation.LogicalValidation;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DecoratorValidationTests.LogicalValidatation
{
    [TestFixture]
    public class LogicalValidator_OrTests
    {
        [Test]
        public void CanConstructOrValidator_LeftRightSyntax()
        {
            Validator<bool> left = new ValidatorBaseCase<bool>();
            left = new BoolValidator_ExpectedValue(left, true, "Not true");

            Validator<bool> right = new ValidatorBaseCase<bool>();
            right = new BoolValidator_ExpectedValue(right, true, "Not true");

            Validator<bool> logicalOr = new ValidatorBaseCase<bool>();
            logicalOr = new LogicalValidator_Or<bool>(logicalOr, left, right, "Neither passed");
        }

        [Test]
        public void CanConstructOrValidator_ListSyntax()
        {
            Validator<bool> first = new ValidatorBaseCase<bool>();
            first = new BoolValidator_ExpectedValue(first, true, "Not true");

            Validator<bool> second = new ValidatorBaseCase<bool>();
            second = new BoolValidator_ExpectedValue(second, true, "Not true");

            List<Validator<bool>> list = new List<Validator<bool>>() {first, second};

            Validator<bool> logicalOr = new ValidatorBaseCase<bool>();
            logicalOr = new LogicalValidator_Or<bool>(logicalOr, list, "Neither passed");
        }

        [Test]
        public void MockedValidatorCanBeMadeToAlwaysFail()
        {
            Validator<bool> validator = GenerateValidator(false);
            bool isValid = validator.Validate(true);
            Assert.IsFalse(isValid);
        }

        private static Validator<bool> GenerateValidator(bool returnValue)
        {
            var validatorMock = new Mock<Validator<bool>>();
            validatorMock.Setup(m => m.Validate(It.IsAny<bool>())).Returns(returnValue);
            Validator<bool> validator = validatorMock.Object;
            return validator;
        }
        
        [Test]
        [TestCase(true, false, Result=true)]
        [TestCase(true, true, Result = true)]
        [TestCase(true, true, Result = true)]
        [TestCase(false, false, Result = false)]
        public bool OrValidatorEvaluatesWithLeftRightSyntax(bool leftResult, bool rightResult)
        {
            Validator<bool> left = GenerateValidator(leftResult);
            Validator<bool> right = GenerateValidator(rightResult);

            Validator<bool> logicalOr = new ValidatorBaseCase<bool>();
            logicalOr = new LogicalValidator_Or<bool>(logicalOr, left, right, "Neither passed");

            return logicalOr.Validate(true);
        }

        [Test]
        [TestCase(true, false, Result = true)]
        [TestCase(true, true, Result = true)]
        [TestCase(true, true, Result = true)]
        [TestCase(false, false, Result = false)]
        public bool OrValidatorEvaluatesWithListSyntax(bool leftResult, bool rightResult)
        {
            List<Validator<bool>> list = new List<Validator<bool>> {
                GenerateValidator(leftResult),
                GenerateValidator(rightResult)
            };

            Validator<bool> logicalOr = new ValidatorBaseCase<bool>();
            logicalOr = new LogicalValidator_Or<bool>(logicalOr, list, "Neither passed");

            return logicalOr.Validate(true);
        }
        
        [Test]
        public void OrVaildatorReturnsErrorMessageWhenValidationFails()
        {
            string errorMessage = "Neither Passed";
            Validator<bool> left = GenerateValidator(false);
            Validator<bool> right = GenerateValidator(false);

            Validator<bool> logicalOr = new ValidatorBaseCase<bool>();
            logicalOr = new LogicalValidator_Or<bool>(logicalOr, left, right, errorMessage);
            logicalOr.Validate(true);
            Assert.That(logicalOr.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
