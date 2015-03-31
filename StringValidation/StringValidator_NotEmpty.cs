using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_NotEmpty : ValidatorDecorator<String>
    {
        private readonly String _errorMessage;

        public StringValidator_NotEmpty(Validator<String> a, String errorMessage)
            : base(a)
        {
            _errorMessage = errorMessage;
        }

        public override bool Validate(String toValidate, StringBuilder errorAccumulator)
        {
            
            isValid = toValidate != null && toValidate.Trim() != string.Empty;

            AppendErrorMessage(errorAccumulator, _errorMessage);

            return isValid && base.Validate(toValidate, errorAccumulator);
        }
    }
}