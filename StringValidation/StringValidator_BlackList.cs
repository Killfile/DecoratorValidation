using DecoratorValidation.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_BlackList : ValidatorDecorator<String>
    {
        private readonly List<String> _blackList;
        private readonly String _errorMessage;

        public StringValidator_BlackList(Validator<String> a, List<String> blackList, String errorMessage)
            : base(a)
        {
            _blackList = blackList;
            _errorMessage = errorMessage;
        }

        public override bool Validate(String toValidate)
        {
           

            isValid =  !_blackList.Contains(toValidate);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}