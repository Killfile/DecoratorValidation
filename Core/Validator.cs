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
        internal StringBuilder errorAccumulator;


        public abstract bool Validate(T toValidate);



        public string ErrorMessage { get {
            return errorAccumulator.ToString();
        } }
    }
}
