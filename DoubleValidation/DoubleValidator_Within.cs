using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.DoubleValidation.Validators
{
    public class DoubleValidator_Within : ValidatorDecorator<double>
    {
        private readonly String _errorMessage;
        private readonly double TargetValue;
        private readonly double Delta;

        /// <summary>
        /// Creates a validator for double comparison
        /// </summary>
        /// <param name="a">A double validator - this system uses the decorator pattern</param>
        /// <param name="target">The value to compare against</param>
        /// <param name="delta">The allowable deviation from the target value.</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        public DoubleValidator_Within(Validator<double> a, double target, double delta, String ErrorMessage)
            : base(a)
        {
            _errorMessage = ErrorMessage;
            this.TargetValue = target;
            this.Delta = delta;
        }

        public override bool Validate(object toValidateObj)
        {
            double toValidate = Convert.ToDouble(toValidateObj);
            isValid = Math.Abs(toValidate - TargetValue) <= Math.Abs(Delta);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}