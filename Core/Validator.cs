using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorValidation.Core
{
    public abstract class Validator<T>
    {
        public const String ErrorMessageDelimiter = @"/";

        public abstract bool Validate(T toValidate, StringBuilder errorMessage);

        
    }
}
