using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_MinLength : ValidatorDecorator<String>
    {
        private readonly String _errorMessage;
        private readonly int _minLength;

        public StringValidator_MinLength(Validator<String> a, int minLength, String errorMessage)
            : base(a)
        {
            _errorMessage = errorMessage;
            _minLength = minLength;
        }

        public override bool Validate(String toValidate)
        {
            
            isValid =  toValidate.Length >= _minLength;

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}