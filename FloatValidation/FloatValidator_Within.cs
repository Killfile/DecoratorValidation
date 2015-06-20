using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.FloatValidation.Validators
{
    public class FloatValidator_Within : ValidatorDecorator<float>
    {
        private readonly String _errorMessage;
        private readonly float TargetValue;
        private readonly float Delta;

        /// <summary>
        /// Creates a validator for float comparison
        /// </summary>
        /// <param name="a">A float validator - this system uses the decorator pattern</param>
        /// <param name="target">The value to compare against</param>
        /// <param name="delta">The allowable deviation from the target value.</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        public FloatValidator_Within(Validator<float> a, float target, float delta, String ErrorMessage)
            : base(a)
        {
            _errorMessage = ErrorMessage;
            this.TargetValue = target;
            this.Delta = delta;
        }

        public override bool Validate(float toValidate)
        {
            isValid = Math.Abs(toValidate - TargetValue) <= Math.Abs(Delta);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}