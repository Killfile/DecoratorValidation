using System;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_MinLength : StringValidatorDecorator
    {
        private readonly String _errorMessage;
        private readonly int _minLength;

        public StringValidator_MinLength(StringValidator a, int minLength, String errorMessage)
            : base(a)
        {
            _errorMessage = errorMessage;
            _minLength = minLength;
        }

        public override bool Validate(String toValidate, ref string errorMessage)
        {
            if (errorMessage == null)
                errorMessage = string.Empty;

            bool validates = toValidate.Length >= _minLength;

            if (validates == false)
                errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + _errorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}