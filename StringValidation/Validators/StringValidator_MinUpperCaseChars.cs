using System;
using System.Text.RegularExpressions;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_MinUpperCaseChars : StringValidatorDecorator
    {
        private const String REG_EX = @"[A-Z]";
        private readonly int _minCount;
        private readonly String _errorMessage;

        public StringValidator_MinUpperCaseChars(StringValidator a, int minCount, String errorMessage)
            : base(a)
        {
            _minCount = minCount;
            _errorMessage = errorMessage;
        }

        public override bool Validate(String toValidate, ref string errorMessage)
        {
            if (errorMessage == null) errorMessage = string.Empty;

            Regex pattern = new Regex(REG_EX);
            bool validates = pattern.Matches(toValidate).Count >= _minCount;

            if (validates == false) errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + _errorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}