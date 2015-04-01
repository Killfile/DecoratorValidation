using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.IntValidation.Validators
{
    public class IntValidator_GreaterThan : ValidatorDecorator<int>
    {
        private readonly String _errorMessage;
        private readonly int FloorValue;
        private readonly bool GreaterThanOrEqualTo;

        /// <summary>
        /// Creates a validator for integer comparison
        /// </summary>
        /// <param name="a">An integer validator - this system uses the constructor pattern</param>
        /// <param name="floorValue">The value to compare against</param>
        /// <param name="greaterThanOrEqualTo">Set this to true if the comparison should be inclusive of the floor value</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        public IntValidator_GreaterThan(Validator<int> a, int floorValue, bool greaterThanOrEqualTo, String ErrorMessage)
            : base(a)
        {
            _errorMessage = ErrorMessage;
            this.FloorValue = floorValue;
            this.GreaterThanOrEqualTo = greaterThanOrEqualTo;
        }

        public override bool Validate(int toValidate)
        {
            

            isValid =  toValidate > FloorValue || (GreaterThanOrEqualTo == true && toValidate == FloorValue);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}