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
        private List<Validator<T>> _validators;
        
        public LogicalValidator_Or(Validator<T> a, Validator<T> left, Validator<T> right, String errorMessage) : base(a)
        {
            _errorMessage = errorMessage;
            _validators = new List<Validator<T>> {
                left, right
            };
        }

        public LogicalValidator_Or(Validator<T> a, List<Validator<T>> validators, String errorMessage) : base(a) {
            _errorMessage = errorMessage;
            _validators = validators;
        }

        public override bool Validate(object toValidateObj)
        {
            T toValidate = Cast(toValidateObj);
            isValid = _validators.Any(v => v.Validate(toValidate));
            AppendErrorMessage(_errorMessage);
            return isValid && base.Validate(toValidate);
        }
    }
}
