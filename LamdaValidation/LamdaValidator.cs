﻿using DecoratorValidation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorValidation.LamdaValidation.Validators
{
    [Obsolete("Use the (correctly spelled) LambdaValidator instead.")]
    public class LamdaValidator<T> : ValidatorDecorator<T>
    {
        private Func<T, bool> _predicate;
        private string _errorMessage;

        public LamdaValidator(Validator<T> a, Func<T,bool> predicate, String ErrorMessage) : base(a) {
            _errorMessage = ErrorMessage;
            _predicate = predicate;
        }

        public override bool Validate(object toValidateObj)
        {
            T toValidate = Cast(toValidateObj);
            isValid = _predicate(toValidate);
            AppendErrorMessage(_errorMessage);
            return isValid && base.Validate(toValidate);
        }
    }
}
