using System;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_NotEmpty : StringValidatorDecorator
    {
        private readonly String _errorMessage;

        public StringValidator_NotEmpty(StringValidator a, String errorMessage)
            : base(a)
        {
            _errorMessage = errorMessage;
        }

        public override bool Validate(String toValidate, ref string errorMessage)
        {
            if (errorMessage == null)
                errorMessage = string.Empty;

            bool validates = toValidate != null && toValidate.Trim() != string.Empty;

            if (validates == false)
                errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + _errorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}