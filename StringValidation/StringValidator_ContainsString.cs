using DecoratorValidation.Core;
using System;
using System.Text;

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

        public override bool Validate(String toValidate, StringBuilder errorAccumulator)
        {
            
            isValid =  toValidate.Contains(_expectedString);

            AppendErrorMessage(errorAccumulator, _errorMessage);

            return isValid && base.Validate(toValidate, errorAccumulator);
        }
    }
}