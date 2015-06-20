using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.FloatValidation.Validators
{
    public class FloatValidator_LessThan : ValidatorDecorator<float>
    {
        private readonly String _errorMessage;
        private readonly float CeilingValue;
        private readonly bool LessThanOrEqualTo;

        /// <summary>
        /// Creates a validator for float comparison
        /// </summary>
        /// <param name="a">A float validator - this system uses the decorator pattern</param>
        /// <param name="ceilingValue">The value to compare against</param>
        /// <param name="lessThanOrEqualTo">Set this to true if the comparison should be inclusive of the ceiling value</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        public FloatValidator_LessThan(Validator<float> a, float ceilingValue, bool lessThanOrEqualTo, String ErrorMessage)
            : base(a)
        {
            _errorMessage = ErrorMessage;
            this.CeilingValue = ceilingValue;
            this.LessThanOrEqualTo = lessThanOrEqualTo;
        }

        public override bool Validate(float toValidate)
        {
            isValid = toValidate < CeilingValue || (LessThanOrEqualTo == true && toValidate == CeilingValue);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}