using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecoratorValidation.Core;
using DecoratorValidation.BoolValidation.Validators;
using DecoratorValidation.LogicalValidation;
using Moq;

namespace DecoratorValidationTests.LogicalValidatation
{
    [TestClass]
    public class LogicalValidator_OrTests
    {
        [TestMethod]
        public void CanConstructOrValidator()
        {
            Validator<bool> left = new ValidatorBaseCase<bool>();
            left = new BoolValidator_ExpectedValue(left, true, "Not true");

            Validator<bool> right = new ValidatorBaseCase<bool>();
            right = new BoolValidator_ExpectedValue(right, true, "Not true");

            Validator<bool> logicalOr = new ValidatorBaseCase<bool>();
            logicalOr = new LogicalValidator_Or<bool>(logicalOr, left, right, "Neither passed");
        }

        [TestMethod]
        public void MockedValidatorCanBeMadeToAlwaysFail()
        {
            Validator<bool> validator = GenerateFailingValidator();
            bool isValid = validator.Validate(true);
            Assert.IsFalse(isValid);
        }

        private static Validator<bool> GenerateFailingValidator()
        {
            var validatorMock = new Mock<Validator<bool>>();
            validatorMock.Setup(m => m.Validate(It.IsAny<bool>())).Returns(false);
            Validator<bool> validator = validatorMock.Object;
            return validator;
        }

        private static Validator<bool> GeneratePassingValidator()
        {
            var validatorMock = new Mock<Validator<bool>>();
            validatorMock.Setup(m => m.Validate(It.IsAny<bool>())).Returns(true);
            Validator<bool> validator = validatorMock.Object;
            return validator;
        }

        [TestMethod]
        public void OrValidatorReturnsTrueIfOnlyLeftValidates()
        {
            Validator<bool> left = GeneratePassingValidator();

            Validator<bool> right = GenerateFailingValidator();

            Validator<bool> logicalOr = new ValidatorBaseCase<bool>();
            logicalOr = new LogicalValidator_Or<bool>(logicalOr, left, right, "Neither passed");
            Assert.IsTrue(logicalOr.Validate(true));
        }

        [TestMethod]
        public void OrValidatorReturnsTrueIfOnlyRightValidates()
        {
            Validator<bool> right = GeneratePassingValidator();

            Validator<bool> left = GenerateFailingValidator();

            Validator<bool> logicalOr = new ValidatorBaseCase<bool>();
            logicalOr = new LogicalValidator_Or<bool>(logicalOr, left, right, "Neither passed");
            Assert.IsTrue(logicalOr.Validate(true));
        }

        [TestMethod]
        public void OrValidatorReturnsTrueIfBothValidate()
        {
            Validator<bool> left = GeneratePassingValidator();

            Validator<bool> right = GeneratePassingValidator();

            Validator<bool> logicalOr = new ValidatorBaseCase<bool>();
            logicalOr = new LogicalValidator_Or<bool>(logicalOr, left, right, "Neither passed");
            Assert.IsTrue(logicalOr.Validate(true));
        }

        [TestMethod]
        public void OrValidatorReturnsFalseIfNeitherValidates()
        {
            Validator<bool> left = GenerateFailingValidator();

            Validator<bool> right = GenerateFailingValidator();

            Validator<bool> logicalOr = new ValidatorBaseCase<bool>();
            logicalOr = new LogicalValidator_Or<bool>(logicalOr, left, right, "Neither passed");
            Assert.IsFalse(logicalOr.Validate(true));
        }
    }
}
