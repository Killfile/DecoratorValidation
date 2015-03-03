using System;
using System.Collections.Generic;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_WhiteList : StringValidatorDecorator
    {
        private readonly List<String> _whiteList;
        private readonly String _errorMessage;

        public StringValidator_WhiteList(StringValidator a, List<String> whiteList, String errorMessage)
            : base(a)
        {
            _whiteList = whiteList;
            _errorMessage = errorMessage;
        }

        public override bool Validate(String toValidate, ref string errorMessage)
        {
            if (errorMessage == null) errorMessage = string.Empty;

            bool validates = _whiteList.Contains(toValidate);

            if (validates == false) errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + _errorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}