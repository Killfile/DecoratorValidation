﻿using DecoratorValidation.Core;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_RegEx : ValidatorDecorator<String>
    {
        private readonly String _regEx;
        private readonly String _errorMessage;

        public StringValidator_RegEx(Validator<String> a, String regEx, String errorMessage)
            : base(a)
        {
            _regEx = regEx;
            _errorMessage = errorMessage;
        }

        public override bool Validate(object toValidateObj)
        {
            String toValidate = Cast(toValidateObj);

            Regex pattern = new Regex(_regEx);
            isValid =  pattern.IsMatch(toValidate);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}