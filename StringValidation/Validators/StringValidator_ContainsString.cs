using DecoratorValidation.Core;
using System;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_ContainsString : ValidatorDecorator<String>
    {
        private readonly String _expectedString;
        private readonly String _errorMessage;

        public StringValidator_ContainsString(Validator<String> a, String expectedString, String errorMessage)
            : base(a)
        {
            _expectedString = expectedString;
            _errorMessage = errorMessage;
        }

        public override bool Validate(String toValidate, ref string errorMessage)
        {
            if (errorMessage == null) errorMessage = string.Empty;

            bool validates = toValidate.Contains(_expectedString);
            
            if (validates == false) errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + _errorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}