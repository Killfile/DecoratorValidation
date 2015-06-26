using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.DecimalValidation.Validators
{
    public class DecimalValidator_Within : ValidatorDecorator<decimal>
    {
        private readonly String _errorMessage;
        private readonly decimal TargetValue;
        private readonly decimal Delta;

        /// <summary>
        /// Creates a validator for decimal comparison
        /// </summary>
        /// <param name="a">A decimal validator - this system uses the decorator pattern</param>
        /// <param name="target">The value to compare against</param>
        /// <param name="delta">The allowable deviation from the target value.</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        public DecimalValidator_Within(Validator<decimal> a, decimal target, decimal delta, String ErrorMessage)
            : base(a)
        {
            _errorMessage = ErrorMessage;
            this.TargetValue = target;
            this.Delta = delta;
        }

        public override bool Validate(decimal toValidate)
        {
            isValid = Math.Abs(toValidate - TargetValue) <= Math.Abs(Delta);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}