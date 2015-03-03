using System;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_StartsWith : StringValidatorDecorator
    {
        private readonly String _expectedString;
        private readonly String _errorMessage;
        private readonly bool _isCaseSensitive;

        public StringValidator_StartsWith(StringValidator a, String expectedString, String errorMessage, bool isCaseSensitive = true)
            : base(a)
        {
            _expectedString = expectedString;
            _errorMessage = errorMessage;
            _isCaseSensitive = isCaseSensitive;
        }

        public override bool Validate(String toValidate, ref string errorMessage)
        {
            if (errorMessage == null) errorMessage = string.Empty;

            bool validates = _isCaseSensitive ? toValidate.StartsWith(_expectedString) : toValidate.ToLower().StartsWith(_expectedString.ToLower());
            
            if (validates == false) errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + _errorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}