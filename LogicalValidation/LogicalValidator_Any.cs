using DecoratorValidation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorValidation.LogicalValidation
{
    public class LogicalValidator_Any<T> : ValidatorDecorator<T> 
    {
        private string _errorMessage;
        private List<Validator<T>> _list;
        

        public LogicalValidator_Any(Validator<T> a, List<Validator<T>> list, String errorMessage) : base(a)
        {
            _errorMessage = errorMessage;
            _list = list;
        }

        public override bool Validate(T toValidate)
        {
            isValid = _list.Any(i => i.Validate(toValidate));
            AppendErrorMessage(_errorMessage);
            return isValid && base.Validate(toValidate);
        }
    }
}
