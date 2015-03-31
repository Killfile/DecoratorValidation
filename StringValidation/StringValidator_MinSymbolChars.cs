using DecoratorValidation.Core;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_MinSymbolChars : ValidatorDecorator<String>
    {
        private const String REG_EX = @"[!@#$%^&+=-]";
        private readonly int _minCount;
        private readonly String _errorMessage;

        public StringValidator_MinSymbolChars(Validator<String> a, int minCount, String errorMessage)
            : base(a)
        {
            _minCount = minCount;
            _errorMessage = errorMessage;
        }

        public override bool Validate(String toValidate, StringBuilder errorAccumulator)
        {
          

            Regex pattern = new Regex(REG_EX);
            isValid =  pattern.Matches(toValidate).Count >= _minCount;

            AppendErrorMessage(errorAccumulator, _errorMessage);

            return isValid && base.Validate(toValidate, errorAccumulator);
        }
    }
}