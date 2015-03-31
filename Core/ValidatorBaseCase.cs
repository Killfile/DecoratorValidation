using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorValidation.Core
{
    public class ValidatorBaseCase<T> : Validator<T> {
        public override bool Validate(T toValidate, StringBuilder errorAccumulator)
        {
            return true;
        }
    }
}
