using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorValidation.Core
{
    public abstract class ValidatorDecorator<T> : Validator<T>
    {
        protected Validator<T> innerValidator;
        protected bool isValid;

        protected ValidatorDecorator(Validator<T> a)
        {
            innerValidator = a;
            errorAccumulator = a.errorAccumulator;
        }

        public override bool Validate(T toValidate)
        {
            if (innerValidator != null)
                return innerValidator.Validate(toValidate);
            return true;
        }

        protected void AppendErrorMessage(string errorText)
        {
            if (errorAccumulator == null)
                throw new AccumulatorNotInitializedException();
            
            if (isValid) return;
            if (errorAccumulator.Length > 0)
                errorAccumulator.Append(ErrorMessageDelimiter);
            errorAccumulator.Append(errorText);
        }


    }
}
