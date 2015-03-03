using System;

namespace DecoratorValidation.IntValidation.Validators
{
    public class IntValidator_GreaterThan : IntValidatorDecorator
    {
        private readonly String ErrorMessage;
        private readonly int FloorValue;
        private readonly bool GreaterThanOrEqualTo;

        /// <summary>
        /// Creates a validator for integer comparison
        /// </summary>
        /// <param name="a">An integer validator - this system uses the constructor pattern</param>
        /// <param name="floorValue">The value to compare against</param>
        /// <param name="greaterThanOrEqualTo">Set this to true if the comparison should be inclusive of the floor value</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        public IntValidator_GreaterThan(IntValidator a, int floorValue, bool greaterThanOrEqualTo, String ErrorMessage)
            : base(a)
        {
            this.ErrorMessage = ErrorMessage;
            this.FloorValue = floorValue;
            this.GreaterThanOrEqualTo = greaterThanOrEqualTo;
        }

        public override bool Validate(int toValidate, ref String errorMessage)
        {
            if (errorMessage == null)
                errorMessage = String.Empty;

            bool validates = toValidate > FloorValue || (GreaterThanOrEqualTo == true && toValidate == FloorValue);

            if (validates == false)
                errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + this.ErrorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}