using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorValidation.Core
{
    public class ValidatorBaseCase<T> : Validator<T> {

        public ValidatorBaseCase()
        {
            errorAccumulator = new StringBuilder();
        }



        public override bool Validate(T toValidate)
        {
            return true;
        }
    }
}
