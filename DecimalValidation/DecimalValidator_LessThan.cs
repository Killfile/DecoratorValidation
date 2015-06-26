using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.DecimalValidation.Validators
{
    public class DecimalValidator_LessThan : ValidatorDecorator<decimal>
    {
        private readonly String _errorMessage;
        private readonly decimal CeilingValue;
        private readonly bool LessThanOrEqualTo;

        /// <summary>
        /// Creates a validator for decimal comparison
        /// </summary>
        /// <param name="a">A decimal validator - this system uses the decorator pattern</param>
        /// <param name="ceilingValue">The value to compare against</param>
        /// <param name="lessThanOrEqualTo">Set this to true if the comparison should be inclusive of the ceiling value</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        public DecimalValidator_LessThan(Validator<decimal> a, decimal ceilingValue, bool lessThanOrEqualTo, String ErrorMessage)
            : base(a)
        {
            _errorMessage = ErrorMessage;
            this.CeilingValue = ceilingValue;
            this.LessThanOrEqualTo = lessThanOrEqualTo;
        }

        public override bool Validate(decimal toValidate)
        {
            isValid = toValidate < CeilingValue || (LessThanOrEqualTo == true && toValidate == CeilingValue);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}