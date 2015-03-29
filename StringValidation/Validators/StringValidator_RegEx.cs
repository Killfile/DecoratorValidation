using System;
using System.Text.RegularExpressions;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_RegEx : StringValidatorDecorator
    {
        private readonly String _regEx;
        private readonly String _errorMessage;

        public StringValidator_RegEx(StringValidator a, String regEx, String errorMessage)
            : base(a)
        {
            _regEx = regEx;
            _errorMessage = errorMessage;
        }

        public override bool Validate(String toValidate, ref string errorMessage)
        {
            if (errorMessage == null) errorMessage = string.Empty;

            Regex pattern = new Regex(_regEx);
            bool validates = pattern.IsMatch(toValidate);

            if (validates == false) errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + _errorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}