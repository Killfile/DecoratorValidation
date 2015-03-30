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

        protected ValidatorDecorator(Validator<T> a) {
            argument = a;
        }

        public override bool Validate(T toValidate, ref string errorMessage)
        {
            if (argument != null)
                return argument.Validate(toValidate, ref errorMessage);

            errorMessage = string.Empty;
            return true;
        }
    }
}
