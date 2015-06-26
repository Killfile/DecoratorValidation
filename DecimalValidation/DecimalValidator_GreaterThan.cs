using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.DecimalValidation.Validators
{
    // https://stackoverflow.com/questions/828807/what-is-the-base-class-for-c-sharp-numeric-value-types
    public class DecimalValidator_GreaterThan : ValidatorDecorator<decimal>
    {
        private readonly String _errorMessage;
        private readonly decimal FloorValue;
        private readonly bool GreaterThanOrEqualTo;

        /// <summary>
        /// Creates a validator for decimal comparison
        /// </summary>
        /// <param name="a">A decimal validator - this system uses the decorator pattern</param>
        /// <param name="floorValue">The value to compare against</param>
        /// <param name="greaterThanOrEqualTo">Set this to true if the comparison should be inclusive of the floor value</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        public DecimalValidator_GreaterThan(Validator<decimal> a, decimal floorValue, bool greaterThanOrEqualTo, String ErrorMessage)
            : base(a)
        {
            _errorMessage = ErrorMessage;
            this.FloorValue = floorValue;
            this.GreaterThanOrEqualTo = greaterThanOrEqualTo;
        }

        public override bool Validate(decimal toValidate)
        {
            isValid =  toValidate > FloorValue || (GreaterThanOrEqualTo == true && toValidate == FloorValue);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}