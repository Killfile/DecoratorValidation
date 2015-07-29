using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_EndsWith : ValidatorDecorator<String>
    {
        private readonly String _expectedString;
        private readonly String _errorMessage;
        private readonly bool _isCaseSensitive;

        public StringValidator_EndsWith(Validator<String> a, String expectedString, String errorMessage, bool isCaseSensitive = true)
            : base(a)
        {
            _expectedString = expectedString;
            _errorMessage = errorMessage;
            _isCaseSensitive = isCaseSensitive;
        }

        public override bool Validate(object toValidateObj)
        {
            String toValidate = Cast(toValidateObj);
            isValid =  _isCaseSensitive ? toValidate.EndsWith(_expectedString) : toValidate.ToLower().EndsWith(_expectedString.ToLower());
            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}