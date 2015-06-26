using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.DoubleValidation.Validators
{
    public class DoubleValidator_GreaterThan : ValidatorDecorator<double>
    {
        private readonly String _errorMessage;
        private readonly double FloorValue;
        private readonly bool GreaterThanOrEqualTo;

        /// <summary>
        /// Creates a validator for double comparison
        /// </summary>
        /// <param name="a">An double validator - this system uses the decorator pattern</param>
        /// <param name="floorValue">The value to compare against</param>
        /// <param name="greaterThanOrEqualTo">Set this to true if the comparison should be inclusive of the floor value</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        public DoubleValidator_GreaterThan(Validator<double> a, double floorValue, bool greaterThanOrEqualTo, String ErrorMessage)
            : base(a)
        {
            _errorMessage = ErrorMessage;
            this.FloorValue = floorValue;
            this.GreaterThanOrEqualTo = greaterThanOrEqualTo;
        }

        public override bool Validate(double toValidate)
        {
            isValid =  toValidate > FloorValue || (GreaterThanOrEqualTo == true && toValidate == FloorValue);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }

    
}