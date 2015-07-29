using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.FloatValidation.Validators
{
    public class FloatValidator_GreaterThan : ValidatorDecorator<float>
    {
        private readonly String _errorMessage;
        private readonly float FloorValue;
        private readonly bool GreaterThanOrEqualTo;

        /// <summary>
        /// Creates a validator for float comparison
        /// </summary>
        /// <param name="a">A float validator - this system uses the decorator pattern</param>
        /// <param name="floorValue">The value to compare against</param>
        /// <param name="greaterThanOrEqualTo">Set this to true if the comparison should be inclusive of the floor value</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        [Obsolete("Use the double or decimial validators instead.")]
        public FloatValidator_GreaterThan(Validator<float> a, float floorValue, bool greaterThanOrEqualTo, String ErrorMessage)
            : base(a)
        {
            _errorMessage = ErrorMessage;
            this.FloorValue = floorValue;
            this.GreaterThanOrEqualTo = greaterThanOrEqualTo;
        }

        public override bool Validate(object toValidateObj)
        {
            float toValidate = Cast(toValidateObj);
            isValid =  toValidate > FloorValue || (GreaterThanOrEqualTo == true && toValidate == FloorValue);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}