using System;
using System.Collections.Generic;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_BlackList : StringValidatorDecorator
    {
        private readonly List<String> _blackList;
        private readonly String _errorMessage;

        public StringValidator_BlackList(StringValidator a, List<String> blackList, String errorMessage)
            : base(a)
        {
            _blackList = blackList;
            _errorMessage = errorMessage;
        }

        public override bool Validate(String toValidate, ref string errorMessage)
        {
            if (errorMessage == null) errorMessage = string.Empty;

            bool validates = !_blackList.Contains(toValidate);

            if (validates == false) errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + this._errorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}