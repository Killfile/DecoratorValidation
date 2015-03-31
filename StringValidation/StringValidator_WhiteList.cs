using DecoratorValidation.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_WhiteList : ValidatorDecorator<String>
    {
        private readonly List<String> _whiteList;
        private readonly String _errorMessage;

        public StringValidator_WhiteList(Validator<String> a, List<String> whiteList, String errorMessage)
            : base(a)
        {
            _whiteList = whiteList;
            _errorMessage = errorMessage;
        }

        public override bool Validate(String toValidate, StringBuilder errorAccumulator)
        {
           

            isValid =  _whiteList.Contains(toValidate);
            AppendErrorMessage(errorAccumulator, _errorMessage);

            return isValid && base.Validate(toValidate, errorAccumulator);
        }
    }
}