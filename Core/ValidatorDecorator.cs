using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorValidation.Core
{
    public abstract class ValidatorDecorator<T> : Validator<T>
    {
        protected Validator<T> argument;
        protected bool isValid;
        
        protected ValidatorDecorator(Validator<T> a) {
            argument = a;
        }

        public override bool Validate(T toValidate, StringBuilder errorMessage)
        {
            if (argument != null)
                return argument.Validate(toValidate, errorMessage);
            return true;
        }

        protected void AppendErrorMessage(StringBuilder accumulator, string errorText)
        {
            if (accumulator == null)
                throw new AccumulatorNotInitializedException();
            
            if (isValid) return;
            if (accumulator.Length > 0)
                accumulator.Append(ErrorMessageDelimiter);
            accumulator.Append(errorText);
        }


    }
}
