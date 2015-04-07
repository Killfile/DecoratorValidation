using DecoratorValidation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorValidation.LogicalValidation
{
    public class LogicalValidator_Or<T> : ValidatorDecorator<T> 
    {
        private string _errorMessage;
        private Validator<T> _left;
        private Validator<T> _right;

        public LogicalValidator_Or(Validator<T> a, Validator<T> left, Validator<T> right, String errorMessage) : base(a)
        {
            _errorMessage = ErrorMessage;
            _left = left;
            _right = right;
        }

        public override bool Validate(T toValidate)
        {
            isValid = _left.Validate(toValidate) || _right.Validate(toValidate);
            AppendErrorMessage(_errorMessage);
            return isValid && base.Validate(toValidate);
        }
    }
}
