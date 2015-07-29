using DecoratorValidation.Core;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_MinUpperCaseChars : ValidatorDecorator<String>
    {
        private const String REG_EX = @"[A-Z]";
        private readonly int _minCount;
        private readonly String _errorMessage;

        public StringValidator_MinUpperCaseChars(Validator<String> a, int minCount, String errorMessage)
            : base(a)
        {
            _minCount = minCount;
            _errorMessage = errorMessage;
        }

        public override bool Validate(object toValidateObj)
        {
            String toValidate = Cast(toValidateObj);
            Regex pattern = new Regex(REG_EX);
            isValid = pattern.Matches(toValidate).Count >= _minCount;

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}