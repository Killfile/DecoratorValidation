using System;
using System.Text.RegularExpressions;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_Email : StringValidatorDecorator
    {
        private readonly String _regEx;
        private readonly String _errorMessage;

        public StringValidator_Email(StringValidator a, String errorMessage)
            : base(a)
        {
            //From this site: http://www.regular-expressions.info/email.html
            // "Some people, when confronted with a problem, think 'I know, I'll use regular expressions.'
            // Now they have two problems." --  Jamie Zawinski
            _regEx = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
            _errorMessage = errorMessage;
        }

        public override bool Validate(String toValidate, ref string errorMessage)
        {
            if (errorMessage == null) errorMessage = string.Empty;

            Regex pattern = new Regex(_regEx, RegexOptions.IgnoreCase);
            bool validates = pattern.IsMatch(toValidate);

            if (validates == false) errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + _errorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}